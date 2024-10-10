using _2024_09_13___Sales.Models;
using System.Data.SqlClient;

namespace _2024_09_13___Sales
{
    public class SalesDb
    {
        SqlConnection conn;
        public SalesDb(string connectionString)
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
        }
        ~SalesDb()
        {
            conn.Close();
        }
        public void CreateSale(Sale sale)
        {
            string cmdText = $@"INSERT INTO Sales
                              VALUES ( @BuyerId, 
                                       @SellerId, 
                                       @AmountOfSale, 
                                       @DateOfSale)";

            SqlCommand command = new SqlCommand(cmdText, conn);

            command.Parameters.AddWithValue("BuyerId", sale.BuyerId);
            command.Parameters.AddWithValue("SellerId", sale.SellerId);
            command.Parameters.AddWithValue("AmountOfSale", sale.AmountOfSale);
            command.Parameters.AddWithValue("DateOfSale", sale.DateOfSale.ToShortDateString());

            command.CommandTimeout = 5;
            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows + " rows affected!");
        }
        private List<Sale> GetSaleByQuery(SqlDataReader reader)
        {
            List<Sale> sales = new List<Sale>();

            while (reader.Read())
            {
                sales.Add(new Sale()
                {
                    Id = (int)reader[0],
                    BuyerId = (int)reader[1],
                    SellerId = (int)reader[2],
                    AmountOfSale = (double)reader[3],
                    DateOfSale = (DateTime)reader[4]
                });
            }

            reader.Close();
            return sales;
        }
        private List<Seller> GetSellerByQuery(SqlDataReader reader)
        {
            List<Seller> sellers = new List<Seller>();

            while (reader.Read())
            {
                sellers.Add(new Seller()
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    Surname = (string)reader[2]
                });
            }

            reader.Close();
            return sellers;
        }
        private List<Buyer> GetBuyerByQuery(SqlDataReader reader)
        {
            List<Buyer> buyers = new List<Buyer>();

            while (reader.Read())
            {
                buyers.Add(new Buyer()
                {
                    Id = (int)reader[0],
                    Name = (string)reader[1],
                    Surname = (string)reader[2]
                });
            }

            reader.Close();
            return buyers;
        }
        public List<Sale> GetALLSales()
        {
            string cmdText = @"select * from Sales";

            SqlCommand command = new SqlCommand(cmdText, conn);

            SqlDataReader reader = command.ExecuteReader();

            return GetSaleByQuery(reader);
        }
        public List<Seller> GetALLSellers()
        {
            string cmdText = @"select * from Sellers";

            SqlCommand command = new SqlCommand(cmdText, conn);

            SqlDataReader reader = command.ExecuteReader();

            return GetSellerByQuery(reader);
        }
        public List<Buyer> GetALLBuyers()
        {
            string cmdText = @"select * from Buyers";

            SqlCommand command = new SqlCommand(cmdText, conn);

            SqlDataReader reader = command.ExecuteReader();

            return GetBuyerByQuery(reader);
        }
        public Sale GetLastSaleBySellerFullname(string name, string surname)
        {
            string cmdText = $@"select top 1 * from Sales as s
                                join Buyers as b on b.Id = s.BuyerId
                                where b.Name = @Name 
                                and b.Surname = @Surname
                                order by s.DateOfSale desc";

            SqlCommand command = new SqlCommand(cmdText, conn);

            command.Parameters.Add("Name", System.Data.SqlDbType.NVarChar)
                .Value = name;
            command.Parameters.Add("Surname", System.Data.SqlDbType.NVarChar)
                .Value = surname;

            SqlDataReader reader = command.ExecuteReader();
            
            return GetSaleByQuery(reader).FirstOrDefault();
        }
        public Seller GetBestSellerBySales()
        {
            string cmdText = $@"select top 1 slrs.Id, slrs.Name, slrs.Surname
                                from Sellers as slrs
                                join Sales as sls on sls.SellerId = slrs.Id
                                group by slrs.Id,slrs.Name,slrs.Surname
                                order by sum(sls.AmountOfSale) desc";

            SqlCommand command = new SqlCommand(cmdText, conn);

            SqlDataReader reader = command.ExecuteReader();
            
            return GetSellerByQuery(reader).FirstOrDefault();
        }
        public Sale GetSaleById(int id)
        {
            string cmdText = $@"select * from Sales where Id = {id}";

            SqlCommand command = new SqlCommand(cmdText, conn);

            SqlDataReader reader = command.ExecuteReader();

            return GetSaleByQuery(reader).FirstOrDefault();
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
}
