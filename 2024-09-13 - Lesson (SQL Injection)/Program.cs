using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

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

        public void Create(Product product)
        {
            string cmdText = $@"INSERT INTO Products
                              VALUES ('{product.Name}', 
                                      '{product.Type}', 
                                       {product.Quantity}, 
                                       {product.CostPrice}, 
                                      '{product.Producer}', 
                                       {product.Price})";

            SqlCommand command = new SqlCommand(cmdText, conn);
            command.CommandTimeout = 5; // default - 30sec


            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows + " rows affected!");
        }
        public List<Product> GetALL()
        {
            string cmdText = $@"select * from Products";

            SqlCommand command = new SqlCommand(cmdText, conn);

            SqlDataReader reader = command.ExecuteReader();

            return this.GetProductByQuery(reader);
        }
        public List<Product> GetByName(string name)
        {
            string cmdText = $@"select * from Products where Name = '{name}'";

            SqlCommand command = new SqlCommand(cmdText, conn);

            SqlDataReader reader = command.ExecuteReader();
            
            return this.GetProductByQuery(reader);
        }
        private List<Product> GetProductByQuery(SqlDataReader reader)
        {
            List<Product> products = new List<Product>();

            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    Type = (string)reader[2],
                    Quantity = (int)reader[3],
                    CostPrice = (int)reader[4],
                    Producer = (string)reader[5],
                    Price = (int)reader[6],
                });
            }

            reader.Close();
            return products;
        }
        public void Update(Product product)
        {
            string cmdText = $@"update Products
                                set Name = '{product.Name}',
                                    TypeProduct = {product.Type},
                                    Quantity = {product.Quantity},
                                    CostPrice = {product.CostPrice},
                                    Producer = {product.Producer},
                                    Price = {product.Price}
                                    where Id = {product.Id}";
        }
        public Product GetById(int id)
        {
            string cmdText = $@"select * from Products where Id = {id}";

            SqlCommand command = new SqlCommand(cmdText, conn);

            SqlDataReader reader = command.ExecuteReader();

            return this.GetProductByQuery(reader).FirstOrDefault()!;
        }
        public void Delete(int id)
        {
            string cmdText = $@"delete Products where Id = {id}";

            SqlCommand command = new SqlCommand(cmdText, conn);

            command.ExecuteNonQuery();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string connectionString = @"Data Source=WINDEV2401EVAL\SQLEXPRESS;
                                        Initial Catalog=SportShop;
                                        Integrated Security=True;
                                        Connect Timeout=30;
                                        Encrypt=False;";
            SportShop sportShop = new SportShop(connectionString);
            //Product pr = new Product()
            //{
            //    Name = "Ball",
            //    Type = "Equipment",
            //    Quantity = 10,
            //    CostPrice = 100,
            //    Producer = "China",
            //    Price = 200
            //};
            //sportShop.Create(pr);
            //sportShop.Delete();
            Console.WriteLine("Enter name of Product to search : ");
            string name = Console.ReadLine();
            var products = sportShop.GetByName(name);
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
            //var changeProduct = sportShop.GetById(2);
            //changeProduct.Price = 500;
            //changeProduct.CostPrice = 300;
            //sportShop.Update(changeProduct);
        }
    }
}
