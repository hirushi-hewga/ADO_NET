using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace _2024_09_09___HW__Connection_Mode_
{
    internal class Program
    {
        public static void Reader(SqlConnection sqlConnection, string cmdText)
        {
            Console.WriteLine();
            SqlCommand command = new SqlCommand(cmdText, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i),17}");
            }
            Console.WriteLine();
            for (int i = 0; i < reader.FieldCount * 20; i++) Console.Write('-');
            Console.WriteLine();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($" {reader[i],17} ");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < reader.FieldCount * 20; i++) Console.Write('-');
            Console.WriteLine("\n");
        }
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
            Console.OutputEncoding = Encoding.UTF8;




            #region insert buyers

            /*
            string[] cmdTextBuyers = {@"insert into Buyers(Name, Surname) values('Barbey', 'Thoday');",
            @"insert into Buyers(Name, Surname) values('Vicki', 'Dicky');",
            @"insert into Buyers(Name, Surname) values('Ulysses', 'McKendo');",
            @"insert into Buyers(Name, Surname) values('Fiann', 'Plak');",
            @"insert into Buyers(Name, Surname) values('Zelig', 'Asman');",
            @"insert into Buyers(Name, Surname) values('Dwight', 'Amer');",
            @"insert into Buyers(Name, Surname) values('Emelyne', 'Donn');",
            @"insert into Buyers(Name, Surname) values('Sheffy', 'Robottham');",
            @"insert into Buyers(Name, Surname) values('Evelin', 'Dallow');",
            @"insert into Buyers(Name, Surname) values('Dixie', 'Thraves');",
            @"insert into Buyers(Name, Surname) values('Yasmeen', 'Everington');",
            @"insert into Buyers(Name, Surname) values('Godiva', 'Draper');",
            @"insert into Buyers(Name, Surname) values('Jaimie', 'Skim');",
            @"insert into Buyers(Name, Surname) values('Rab', 'Fairbairn');",
            @"insert into Buyers(Name, Surname) values('Lexy', 'Arkin');",
            @"insert into Buyers(Name, Surname) values('Regan', 'Damrel');"};
            for (int i = 0; i < cmdTextBuyers.Length; i++)
            {
                SqlCommand command = new SqlCommand(cmdTextBuyers[i], sqlConnection);
                int rows = command.ExecuteNonQuery();
                Console.WriteLine(rows + " rows affected!");
            }
            */

            #endregion

            #region insert sellers

            /*
            string[] cmdTextSellers = {@"insert into Sellers (Name, Surname) values ('Sandy', 'Brennand');",
            @"insert into Sellers (Name, Surname) values ('Nanete', 'Dik');"};
            for (int i = 0; i < cmdTextSellers.Length; i++)
            {
                SqlCommand command = new SqlCommand(cmdTextSellers[i], sqlConnection);
                int rows = command.ExecuteNonQuery();
                Console.WriteLine(rows + " rows affected!");
            }
            */

            #endregion

            #region insert sales

            /*
            string[] cmdTextSales = {@"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(9, 1, 1204.82, '2022-11-27');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(13, 1, 1040.33, '2022-08-16');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(7, 1, 570.59, '2022-09-26');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(2, 1, 963.42, '2022-04-15');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(7, 2, 187.1, '2024-04-01');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(1, 2, 338.63, '2022-03-25');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(4, 2, 259.17, '2022-09-16');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(12, 2, 264.4, '2023-08-25');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(14, 2, 1176.65, '2020-06-17');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(6, 2, 1419.65, '2021-06-05');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(16, 1, 555.65, '2020-03-11');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(15, 2, 1130.34, '2022-02-09');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(6, 2, 1455.09, '2020-01-02');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(5, 2, 1035.53, '2023-06-04');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(4, 2, 314.14, '2024-09-01');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(9, 1, 102.72, '2020-08-12');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(15, 1, 262.99, '2021-12-28');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(9, 1, 1496.76, '2020-05-11');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(5, 1, 302.99, '2024-05-30');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(7, 2, 1269.7, '2021-11-28');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(8, 2, 101.17, '2021-10-13');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(9, 1, 1006.99, '2024-02-03');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(14, 1, 1343.73, '2021-07-25');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(12, 2, 292.32, '2023-11-16');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(2, 2, 101.17, '2024-04-25');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(8, 2, 836.95, '2021-04-24');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(12, 2, 1453.08, '2023-01-21');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(15, 2, 1095.19, '2021-06-23');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(6, 2, 670.3, '2022-06-12');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(12, 2, 455.03, '2020-12-24');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(7, 1, 1396.86, '2021-12-30');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(15, 1, 1104.86, '2024-03-23');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(7, 2, 922.02, '2021-11-14');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(9, 1, 1277.64, '2022-11-14');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(13, 2, 659.31, '2023-10-30');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(6, 2, 607.35, '2020-12-26');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(10, 1, 1146.71, '2021-03-16');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(15, 2, 254.45, '2020-10-12');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(7, 1, 366.79, '2021-07-19');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(8, 1, 605.0, '2020-10-31');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(7, 2, 1273.38, '2023-08-04');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(1, 2, 1248.8, '2020-05-09');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(4, 2, 88.91, '2021-02-28');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(3, 2, 1095.0, '2020-07-10');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(7, 1, 351.95, '2024-06-23');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(6, 2, 1034.76, '2022-10-04');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(14, 2, 1493.24, '2020-04-05');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(6, 2, 894.84, '2023-09-25');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(12, 2, 863.96, '2020-05-10');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(8, 2, 1350.1, '2024-01-08');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(14, 1, 1496.76, '2023-12-22');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(15, 1, 581.75, '2021-06-03');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(4, 1, 99.8, '2020-04-12');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(14, 2, 370.29, '2022-02-13');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(14, 1, 1316.32, '2024-08-31');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(7, 1, 973.76, '2020-03-02');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(7, 1, 822.13, '2021-06-30');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(2, 2, 390.98, '2023-05-29');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(13, 2, 995.32, '2021-06-22');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(5, 2, 394.26, '2024-06-30');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(10, 1, 276.3, '2021-12-29');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(12, 2, 976.46, '2022-08-05');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(11, 1, 409.63, '2021-03-14');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(2, 1, 1007.55, '2024-06-14');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(5, 1, 987.55, '2020-06-01');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(7, 2, 426.71, '2023-12-22');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(10, 2, 1289.52, '2020-01-31');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(15, 1, 1072.37, '2021-10-28');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(2, 1, 1121.79, '2024-04-16');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(16, 1, 111.9, '2023-06-14');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(2, 1, 363.83, '2021-04-18');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(2, 2, 105.62, '2023-10-26');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(5, 2, 745.77, '2021-04-27');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(12, 2, 1401.53, '2020-08-24');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(4, 1, 1008.19, '2024-04-06');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(5, 2, 1076.41, '2023-04-26');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(12, 1, 592.14, '2023-07-11');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(2, 1, 916.75, '2021-02-11');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(13, 1, 98.86, '2020-05-24');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(8, 1, 132.72, '2020-08-14');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(10, 2, 772.05, '2022-07-30');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(16, 1, 1270.04, '2023-11-13');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(12, 1, 1305.71, '2021-01-19');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(13, 2, 41.66, '2020-10-03');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(3, 1, 1322.19, '2020-06-28');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(10, 2, 378.27, '2023-10-03');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(10, 2, 460.64, '2020-03-18');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(1, 2, 1140.38, '2022-12-27');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(1, 2, 896.23, '2022-11-23');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(3, 1, 913.55, '2023-02-11');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(16, 2, 353.85, '2023-12-19');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(16, 1, 1128.59, '2022-01-06');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(16, 2, 117.0, '2020-10-22');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(4, 2, 982.79, '2022-03-24');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(13, 2, 501.97, '2024-07-28');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(14, 1, 626.39, '2020-10-26');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(9, 2, 903.16, '2023-03-08');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(13, 1, 1476.08, '2022-08-07');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(4, 1, 206.14, '2020-05-04');",
            @"insert into Sales(BuyerId, SellerId, AmountOfSale, DateOfSale) values(6, 2, 450.29, '2020-02-04');"};
            for (int i = 0; i < cmdTextSales.Length; i++)
            {
                SqlCommand command = new SqlCommand(cmdTextSales[i], sqlConnection);
                int rows = command.ExecuteNonQuery();
                Console.WriteLine(rows + " rows affected!");
            }
            */

            #endregion



            #region 1

            /*
            Reader(sqlConnection, @"select * from Buyers");
            */

            #endregion

            #region 2

            /*
            Reader(sqlConnection, @"select * from Sellers");
            */

            #endregion

            #region 3

            /*
            Console.Write("Enter seller Name : ");
            string SellerName = Console.ReadLine();
            Console.Write("Enter seller Surname : ");
            string SellerSurname = Console.ReadLine();
            Reader(sqlConnection, @$"select slrs.Name + ' ' + slrs.Surname as 'Seller Fullname', sls.SellerId as 'Seller Id', sls.BuyerId as 'Buyer Id', sls.Id as 'Sale Id', sls.AmountOfSale as 'Amount of Sale', sls.DateOfSale as 'Date of Sale' from Sales as sls join Sellers as slrs on slrs.Id = sls.SellerId where slrs.Name = '{SellerName}' and slrs.Surname = '{SellerSurname}'");
            */

            #endregion

            #region 4

            /*
            Console.Write("Enter sale Amount : ");
            int AmountOfSale = int.Parse(Console.ReadLine());
            Reader(sqlConnection, @$"select s.Id as 'Sale Id', s.AmountOfSale as 'Amount of Sale', s.DateOfSale as 'Date of Sale' from Sales as s where s.AmountOfSale > {AmountOfSale}");
            */

            #endregion

            #region 5

            /*
            Console.Write("Enter buyer Name : ");
            string BuyerName = Console.ReadLine();
            Console.Write("Enter buyer Surname : ");
            string BuyerSurname = Console.ReadLine();
            Reader(sqlConnection, @$"select top 1 b.Name + ' ' + b.Surname as 'Buyer Fullname', s.AmountOfSale as 'Amount of Sale', s.DateOfSale as 'Date of Sale' from Buyers as b join Sales as s on s.BuyerId = b.Id where b.Name = '{BuyerName}' and b.Surname = '{BuyerSurname}' order by s.AmountOfSale desc");
            sqlConnection.Close(); sqlConnection.Open();
            Reader(sqlConnection, @$"select top 1 b.Name + ' ' + b.Surname as 'Buyer Fullname', s.AmountOfSale as 'Amount of Sale', s.DateOfSale as 'Date of Sale' from Buyers as b join Sales as s on s.BuyerId = b.Id where b.Name = '{BuyerName}' and b.Surname = '{BuyerSurname}' order by s.AmountOfSale");
            */

            #endregion

            #region 6

            /*
            Console.Write("Enter seller Name : ");
            string SellerName = Console.ReadLine();
            Console.Write("Enter seller Surname : ");
            string SellerSurname = Console.ReadLine();
            Reader(sqlConnection, @$"select top 1 slrs.Name + ' ' + slrs.Surname as 'Seller Fullname', sls.AmountOfSale as 'Amount of Sale', sls.DateOfSale as 'Date of Sale' from Sales as sls join Sellers as slrs on slrs.Id = sls.SellerId where slrs.Name = '{SellerName}' and slrs.Surname = '{SellerSurname}' order by sls.Id");
            */

            #endregion




            sqlConnection.Close();

        }
    }
}
