using DatabaseHelper.Common;
using Microsoft.Data.SqlClient;

namespace DatabaseHelper.SQL
{
    public class Database : DatabaseCommon<SqlConnection, SqlCommand,SqlParameter ,SqlTransaction>
    {
        public Database(string connectionString) : base(connectionString) { }
    }
}
