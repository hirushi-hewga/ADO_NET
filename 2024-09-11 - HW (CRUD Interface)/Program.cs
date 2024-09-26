using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Text;
using System.Xml.Serialization;

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
        public void Create(Sale sale)
        {
            string cmdText = $@"INSERT INTO Sales
                              VALUES ( {sale.BuyerId}, 
                                       {sale.SellerId}, 
                                       {sale.AmountOfSale}, 
                                      '{sale.DateOfSale.ToShortDateString()}')";

            SqlCommand command = new SqlCommand(cmdText, conn);
            command.CommandTimeout = 5;

            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows + " rows affected!");
        }
        public List<Sale> GetALL()
        {
            string cmdText = @"select * from Sales";

            SqlCommand command = new SqlCommand(cmdText, conn);

            SqlDataReader reader = command.ExecuteReader();
            List<Sale> products = new List<Sale>();

            while (reader.Read())
            {
                products.Add(new Sale()
                {
                    Id = (int)reader[0],
                    BuyerId = (int)reader[1],
                    SellerId = (int)reader[2],
                    AmountOfSale = (float)reader[3],
                    DateOfSale = (DateTime)reader[4]
                });
            }

            reader.Close();
            return products;
        }
        public void Update(Sale sale)
        {
            string cmdText = $@"update Sales
                                set BuyerId = {sale.BuyerId},
                                    SellerId = {sale.SellerId},
                                    AmountOfSale = {sale.AmountOfSale},
                                    DateOfSale = '{sale.DateOfSale.ToShortDateString()}'
                                    where Id = {sale.Id}";

            SqlCommand command = new SqlCommand(cmdText, conn);
            command.CommandTimeout = 5;

            command.ExecuteNonQuery();
        }
        public Sale GetById(int id)
        {
            string cmdText = $@"select * from Sales where Id = {id}";

            SqlCommand command = new SqlCommand(cmdText, conn);

            SqlDataReader reader = command.ExecuteReader();

            Sale sale = new Sale();

            while (reader.Read())
            {
                sale.Id = (int)reader[0];
                sale.BuyerId = (int)reader[1];
                sale.SellerId = (int)reader[2];
                sale.AmountOfSale = (float)reader[3];
                sale.DateOfSale = (DateTime)reader[4];
            }
            reader.Close();
            return sale;
        }
        public void Delete(int id)
        {
            string cmdText = $@"delete Sales where Id = {id}";

            SqlCommand command = new SqlCommand(cmdText, conn);

            command.ExecuteNonQuery();
        }
    }
    internal class Program
    {
        static public int Menu()
        {
            Console.Write("1 - Create Sale" +
                "\n2 - Show Sales" +
                "\n3 - Last Sale by Buyer" +
                "\n4 - Delete Seller or Buyer by Id" +
                "\n5 - Show Seller with largest Amount of Sales" +
                "\n6 - Exit" +
                "\nEnter your choice : ");
            int choice = int.Parse(Console.ReadLine());
            Console.Clear();
            return choice;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string connectionString = @"Data Source=WINDEV2401EVAL\SQLEXPRESS;
                                        Initial Catalog=Sales;
                                        Integrated Security=True;
                                        Connect Timeout=30;
                                        Encrypt=False;";
            Sales sales = new Sales(connectionString);


            int choice = 0;
            while (choice != 6)
            {
                Console.Clear();
                switch (Menu())
                {
                    case 1:
                        Console.Write("Enter Buyer Id (1-25)");
                        int BuyerId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Seller Id (1-5)");
                        int SellerId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Buyer Id (1-25)");
                        float AmountOfSale = float.Parse(Console.ReadLine());
                        Console.Write("Enter Buyer Id (1-25)");
                        int YearOfSale = int.Parse(Console.ReadLine());
                        Console.Write("Enter Buyer Id (1-25)");
                        int MonthOfSale = int.Parse(Console.ReadLine());
                        Console.Write("Enter Buyer Id (1-25)");
                        int DayOfSale = int.Parse(Console.ReadLine());
                        Sale sale = new Sale()
                        {
                            BuyerId = BuyerId,
                            SellerId = SellerId,
                            AmountOfSale = AmountOfSale,
                            DateOfSale = new DateTime(YearOfSale,
                                                      MonthOfSale,
                                                      DayOfSale)
                        };
                        sales.Create(sale);
                        break;
                    case 2:
                        var sales_ = sales.GetALL();
                        foreach (var item in sales_)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        break;
                    case 3:

                        break;
                    default:
                        Console.WriteLine("Goodbye.");
                        break;
                }
            }
        }
    }
}