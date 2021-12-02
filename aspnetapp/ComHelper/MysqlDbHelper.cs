namespace DockerWeb.ComHelper
{
    public class MysqlDbHelper
    {
        public IFreeSql SqlServerfsql;

        public MysqlDbHelper(string sqlstring)
        {
            SqlServerfsql = new FreeSql.FreeSqlBuilder()
          .UseConnectionString(FreeSql.DataType.MySql, sqlstring)
          .UseAutoSyncStructure(true) //自动同步实体结构【开发环境必备】
          .Build(); //请务必定义成 Singleton 单例模式
        }
    }
}
