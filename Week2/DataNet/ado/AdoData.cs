using System.Data;
using System.Data.SqlClient;

namespace DataNet.ado
{
    public class AdoData
    {
        private string connection = "data source=leonrevaturedb.database.windows.net;initial catalog=LeonSqlDDL2;user id=lmoore0621;Password=Aol12345=;";
        public void ReadDisconnected()
        {
            DataSet ds = new DataSet();
            
            using (var con = new SqlConnection(connection))
            {
                string query = "SELECT * FROM SalesLT.Customer;";
                SqlCommand command = new SqlCommand(query);
                SqlDataAdapter da = new SqlDataAdapter();

                command.Connection = con;
                da.SelectCommand = command;
                con.Open();

                da.Fill(ds);
            }

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                System.Console.WriteLine("{0} {1}", item[3], item["LastName"]);
            }
        }

        public void ReadConnected()
        {
            using (var con = new SqlConnection(connection))
            {
                SqlDataReader dr;
                var q = "SELECT * FROM SalesLT.Customer;";
                var command = new SqlCommand(q);

                con.Open();
                command.Connection = con;
                dr = command.ExecuteReader();

                while (dr.Read())
                {
                    System.Console.WriteLine("{0} {1}", dr[3], dr["LastName"]);
                }
            }
        }
    }
}