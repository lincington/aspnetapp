namespace DockerWeb.ComHelper
{
    public class SqlServerDbHelper
    {
        public IFreeSql SqlServerfsql;

        public SqlServerDbHelper(string sqlstring)
        {
            SqlServerfsql = new FreeSql.FreeSqlBuilder()
          .UseConnectionString(FreeSql.DataType.SqlServer, sqlstring)
          .UseAutoSyncStructure(true) //自动同步实体结构【开发环境必备】
          .Build(); //请务必定义成 Singleton 单例模式
        }
    }
}
