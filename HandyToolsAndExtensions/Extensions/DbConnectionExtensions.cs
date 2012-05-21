using System.Data;

namespace HandyToolsAndExtensions.Extensions
{
    public static class DbConnectionExtensions
    {
        public static void ExecuteSql(this IDbConnection connection, string sql)
        {
            using (var command = connection.CreateCommand())
            {
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
        }
    }
}