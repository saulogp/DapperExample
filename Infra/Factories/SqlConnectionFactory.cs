using ExemploDapper.Infra.Contracts;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ExemploDapper.Infra.Factories
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        public IDbConnection Connection() => new SqlConnection("Data Source=DESKTOP-N6GH1IU\\SQLEXPRESS;Initial Catalog=DapperExemploDB;Integrated Security=True;");
    }
}
