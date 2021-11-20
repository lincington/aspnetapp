using System;

namespace DockerWeb
{
    /// <summary>
    /// 用法实例 : NLogTest.NlogInstance log = new NLogTest.NlogInstance("NameSpace.ClassName.FunctionName");
    /// log.Debug();log.Error();
    /// </summary>
    public class LogHelper : IDisposable
    {
        private bool alreadyDisposed = false;
        private NLog.Logger logger;

        private LogHelper(NLog.Logger logger)
        {
            this.logger = logger;
        }

        public LogHelper(string name)
            : this(NLog.LogManager.GetLogger(name))
        {
        }

        public static LogHelper Default { get; private set; }

        static LogHelper()
        {
            Default = new LogHelper(NLog.LogManager.GetCurrentClassLogger());
        }

        public void Debug(string msg, params object[] args)
        {
            logger.Debug(msg, args);
        }

        public void Debug(string msg, Exception err)
        {
            logger.Debug(msg, err);
        }

        public void Info(string msg, params object[] args)
        {
            logger.Info(msg, args);
        }

        public void Info(string msg, Exception err)
        {
            logger.Info(msg, err);
        }

        public void Trace(string msg, params object[] args)
        {
            logger.Trace(msg, args);
        }

        public void Trace(string msg, Exception err)
        {
            logger.Trace(msg, err);
        }

        public void Error(string msg, params object[] args)
        {
            logger.Error(msg, args);
        }

        public void Error(string msg, Exception err)
        {
            logger.Error(msg, err);
        }

        public void Fatal(string msg, params object[] args)
        {
            logger.Fatal(msg, args);
        }

        public void Fatal(string msg, Exception err)
        {
            logger.Fatal(msg, err);
        }

        protected void Dispose(bool disposing)
        {
            if (alreadyDisposed) return; //保证不重复释放
            if (disposing)
            {
                logger = null;
            }
            alreadyDisposed = true;
        }

        public void Dispose()
        {
            //调用带参数的Dispose方法，释放托管和非托管资源
            Dispose(true);
            //手动调用了Dispose释放资源，那么析构函数就是不必要的了，这里阻止GC调用析构函数
            System.GC.SuppressFinalize(this);
        }

        ~LogHelper()
        {
            Dispose(false);
        }
    }

}