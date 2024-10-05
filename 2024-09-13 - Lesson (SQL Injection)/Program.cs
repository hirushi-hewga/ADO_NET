using System.Diagnostics;
using System.Text;
using System.Xml.Linq;
using data_access.Models;

namespace _2024_09_11___Lesson__CRUD_Interface_
{
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
            Product pr = new Product();
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

            //Console.WriteLine("Enter name of Product to search : ");
            //string name = Console.ReadLine();
            //var products = sportShop.GetByName(name);
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product);
            //}

            //var products = sportShop.GetALL();
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product.ToString());
            //}

            var changeProduct = sportShop.GetById(8);
            changeProduct.Price += 500;
            changeProduct.CostPrice += 300;
            sportShop.Update(changeProduct);
        }
    }
}
