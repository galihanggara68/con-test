using System.Data.SqlClient;

namespace ConTestWeb.Util
{
    public class Connector
    {
        private SqlConnection connection;

        public Connector(string conString)
        {
            connection = new SqlConnection(conString);
        }

        public SqlConnection GetConnection()
        {
            return this.connection;
        }
    }
}
