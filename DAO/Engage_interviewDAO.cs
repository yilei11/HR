using Dapper;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Engage_interviewDAO
    {
        private string zfc = "Data Source=.;Initial Catalog=HR;Integrated Security=True";
        public async Task<Engage_interview> ChaYiAsync(string name)
        {
            using (SqlConnection sqlConnection = new SqlConnection(zfc))
            {
                string sql = $"SELECT * FROM [dbo].[engage_interview] WHERE [human_name] = '{name}'";
                return await sqlConnection.QueryFirstAsync<Engage_interview>(sql);
            }
        }

    }
}
