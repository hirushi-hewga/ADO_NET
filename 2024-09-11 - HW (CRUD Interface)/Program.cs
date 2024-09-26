using System.Data.SqlClient;
using System.Text;

namespace _2024_09_11___HW__CRUD_Interface_
{
    class Sales
    {
        SqlConnection conn;
        public Sales(string connectionString)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
        }
        ~Sales()
        {
            conn.Close();
        }
        public void Create()
        {

        }
        public void GetALL()
        {

        }
        public void Update()
        {

        }
        public void GetById()
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
            string connectionString = @"Data Source=WINDEV2401EVAL\SQLEXPRESS;
                                        Initial Catalog=Sales;
                                        Integrated Security=True;
                                        Connect Timeout=30;
                                        Encrypt=False;";
            Sales sportShop = new Sales(connectionString);
        }
    }
}
