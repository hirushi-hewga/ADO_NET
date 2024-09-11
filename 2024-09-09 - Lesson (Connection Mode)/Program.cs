using System.Data.SqlClient;
using System.Text;
using System.Threading.Channels;

namespace _2024_09_09___Lesson__Connection_Mode_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            workstation id=WorkersDatabase2024-08-19.mssql.somee.com;
            packet size=4096;
            user id=Hirushi_SQLLogin_2;
            pwd=wvrcqrk394;
            data source=WorkersDatabase2024-08-19.mssql.somee.com;
            persist security info=False;
            initial catalog=WorkersDatabase2024-08-19;
            TrustServerCertificate=True 
            */
            string connectionString = @"workstation id=WorkersDatabase2024-08-19.mssql.somee.com;
                                        packet size=4096;
                                        user id=Hirushi_SQLLogin_2;
                                        pwd=wvrcqrk394;
                                        data source=WorkersDatabase2024-08-19.mssql.somee.com;
                                        persist security info=False;
                                        initial catalog=WorkersDatabase2024-08-19;
                                        TrustServerCertificate=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            Console.WriteLine("Connection is success");






            #region Execute Non-Query
            //string cmdText = @"INSERT INTO Products
            //                  VALUES ('FootballBall', 'Equipment', 14, 1500, 'Ukraine', 2000)";

            //SqlCommand command = new SqlCommand(cmdText, sqlConnection);
            //command.CommandTimeout = 5; // default - 30sec


            ////// ExecuteNonQuery - виконує команду яка не повертає результат 
            /////(insert, update, delete...),
            //////але метод повертає кількітсь рядків, які були задіяні
            //int rows = command.ExecuteNonQuery();

            //Console.WriteLine(rows + " rows affected!");
            #endregion
            #region Execute Scalar
            //string cmdText = @"select AVG(Price) from Products";

            //SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            //// Execute Scalar - виконує команду, яка повертає одне значення
            //int res = (int)command.ExecuteScalar();

            ////Console.WriteLine("Result: " + res);
            #endregion
            #region Execute Reader
            //string cmdText = @"select * from Products";

            //SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            ////// ExecuteReader - виконує команду select та повертає результат у вигляді
            ////// DbDataReader
            //SqlDataReader reader = command.ExecuteReader();

            //Console.OutputEncoding = Encoding.UTF8;

            ////// відображається назви всіх колонок таблиці
            //for (int i = 0; i < reader.FieldCount; i++)
            //{
            //    Console.Write($" {reader.GetName(i),14}");
            //}
            //Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");

            //////// відображаємо всі значення кожного рядка
            //while (reader.Read())
            //{
            //    for (int i = 0; i < reader.FieldCount; i++)
            //    {
            //        Console.Write($" {reader[i],14} ");
            //    }
            //    Console.WriteLine();
            //}

            //reader.Close();
            #endregion

            //connection.Close();






            sqlConnection.Close();
        }
    }
}
