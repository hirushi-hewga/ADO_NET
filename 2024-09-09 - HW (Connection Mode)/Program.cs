using System.Data.SqlClient;

namespace _2024_09_09___HW__Connection_Mode_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "workstation id=WorkersDatabase2024-08-19.mssql.somee.com;" +
                "packet size=4096;" +
                "user id=Hirushi_SQLLogin_2;" +
                "pwd=wvrcqrk394;" +
                "data source=WorkersDatabase2024-08-19.mssql.somee.com;" +
                "persist security info=False;" +
                "initial catalog=WorkersDatabase2024-08-19;" +
                "TrustServerCertificate=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();




            Console.WriteLine("HPPS");




            sqlConnection.Close();
        }
    }
}
