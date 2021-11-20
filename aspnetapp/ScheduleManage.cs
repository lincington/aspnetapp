using DockerWeb.ComHelper;
using Quartz;
using Quartz.Impl;
using StackExchange.Redis;

namespace DockerWeb
{
    public class ScheduleManage
    {

        public static void Show()
        {
            //创建调度单元
            Task<IScheduler> tsk = StdSchedulerFactory.GetDefaultScheduler();
            IScheduler scheduler = tsk.Result;
            //2.创建一个具体的作业即job (具体的job需要单独在一个文件中执行)
            IJobDetail job = JobBuilder.Create<SendMessageJob>().WithIdentity("完成").Build();
            //3.创建并配置一个触发器即trigger   1s执行一次
            ITrigger _CronTrigger = TriggerBuilder.Create()
              .WithIdentity("定时确认")
              .WithCronSchedule("0 15 20 ? * MON-FRI") //秒 分 时 某一天 月 周 年(可选参数)
              .Build()
              as ITrigger;
            //4.将job和trigger加入到作业调度池中
            scheduler.ScheduleJob(job, _CronTrigger);
            //5.开启调度
            scheduler.Start();
         
        }
    }


    public class SendMessageJob : IJob
    {
        /// <summary>
        /// 创建要执行的作业
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Execute(IJobExecutionContext context)
        {
            ConnHelper.StockNumdata();
            IDatabase db = StackExchangeRedisHelper.Instance.GetDatabase();
            await Task.Run(() =>
            {
                for (int i = 0; i < 4000; i++)
                {
                    if (!db.StringGet(i.ToString("D6")).IsNullOrEmpty)
                    {
                        string sh = db.StringGet(i.ToString("D6"));
                        Task DDt = ConnHelper.AsyncFunc2(sh);
                        DDt.Wait();

                        Task DDte = ConnHelper.AsyncFunc1(sh);
                        DDte.Wait();
                    }
                }
            });
        }
    }

}
