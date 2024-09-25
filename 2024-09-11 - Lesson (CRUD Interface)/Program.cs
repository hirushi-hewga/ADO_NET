using System.Data.SqlClient;
using System.Text;

namespace _2024_09_11___Lesson__CRUD_Interface_
{
    class SportShop
    {
        //CRUD Interface
        //[C]reate
        //[R]ead
        //[U]pdate
        //[D]elete

        SqlConnection conn;
        public SportShop(string connectionString)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
        }
        ~SportShop()
        {
            conn.Close();
        }

        public void Create()
        {
            string cmdText = @"INSERT INTO Products
                              VALUES ('FootballBall', 'Equipment', 14, 1500, 'Ukraine', 2000)";

            SqlCommand command = new SqlCommand(cmdText, conn);
            command.CommandTimeout = 5; // default - 30sec


            //// ExecuteNonQuery - виконує команду яка не повертає результат 
            ///(insert, update, delete...),
            ////але метод повертає кількітсь рядків, які були задіяні
            int rows = command.ExecuteNonQuery();

            Console.WriteLine(rows + " rows affected!");
        }
        public void GetALL()
        {

        }
        public void Update()
        {

        }
        public void Delete()
        {

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                        Initial Catalog=master;
                                        Integrated Security=True;
                                        Connect Timeout=30;
                                        Encrypt=False;";
            SportShop sportShop = new SportShop(connectionString);
        }
    }
}
