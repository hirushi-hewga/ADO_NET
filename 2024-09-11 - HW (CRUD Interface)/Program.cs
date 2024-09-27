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
        public void CreateSale(Sale sale)
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
        public List<Sale> GetALLSales()
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
        public Sale GetSale(string name, string surname)
        {
            string cmdText = $@"select top 1 * from Sales as s
                                join Buyers as b on b.Id = s.BuyerId
                                where b.Name = '{name}' 
                                and b.Surname = '{surname}'
                                order by s.DateOfSale desc";

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
        //public void Update(Sale sale)
        //{
        //    string cmdText = $@"update Sales
        //                        set BuyerId = {sale.BuyerId},
        //                            SellerId = {sale.SellerId},
        //                            AmountOfSale = {sale.AmountOfSale},
        //                            DateOfSale = '{sale.DateOfSale.ToShortDateString()}'
        //                            where Id = {sale.Id}";

        //    SqlCommand command = new SqlCommand(cmdText, conn);
        //    command.CommandTimeout = 5;

        //    command.ExecuteNonQuery();
        //}
        public Sale GetSaleById(int id)
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
        public void DeleteSeller(int id)
        {
            string cmdText = $@"delete Sellers where Id = {id}";

            SqlCommand command = new SqlCommand(cmdText, conn);

            command.ExecuteNonQuery();
        }
        public void DeleteBuyer(int id)
        {
            string cmdText = $@"delete Buyers where Id = {id}";

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
                        Console.Write("Enter Buyer Id : ");
                        int BuyerId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Seller Id : ");
                        int SellerId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Amount of Sale : ");
                        float AmountOfSale = float.Parse(Console.ReadLine());
                        Console.Write("Enter Year of Sale : ");
                        int YearOfSale = int.Parse(Console.ReadLine());
                        Console.Write("Enter Month of Sale : ");
                        int MonthOfSale = int.Parse(Console.ReadLine());
                        Console.Write("Enter Day of Sale : ");
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
                        sales.CreateSale(sale);
                        break;
                    case 2:
                        var sales_ = sales.GetALLSales();
                        foreach (var item in sales_)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        break;
                    case 3:
                        Console.Write("Enter Buyer Name : ");
                        string BuyerName = Console.ReadLine();
                        Console.Write("Enter Buyer Surname : ");
                        string BuyerSurname = Console.ReadLine();
                        Sale sale_ = sales.GetSale(BuyerName, BuyerSurname);
                        Console.Write(sale_.ToString());
                        break;
                    case 4:
                        int choice_ = 0;
                        bool isValidData = true;
                        while (choice_ < 1 && choice_ > 2)
                        {
                            if (!isValidData)
                                Console.WriteLine("Invalid choice!\n");
                            Console.Write("1 - Delete Buyer" +
                                "\n2 - Delete Seller" +
                                "\nEnter your choice : ");
                            choice_ = int.Parse(Console.ReadLine());
                            Console.Clear();
                            if (choice_ == 1)
                            {
                                Console.Write("Enter Buyer Id : ");
                                int BuyerId_ = int.Parse(Console.ReadLine());
                                sales.DeleteBuyer(BuyerId_);
                            }
                            else if (choice_ == 2)
                            {
                                Console.Write("Enter Seller Id : ");
                                int SellerId_ = int.Parse(Console.ReadLine());
                                sales.DeleteSeller(SellerId_);
                            }
                            else
                            {
                                isValidData = false;
                                Console.Clear();
                            }
                        }
                        break;
                    case 5:

                        break;
                    case 6:
                        Console.WriteLine("Goodbye.");
                        break;
                }
            }
        }
    }
}