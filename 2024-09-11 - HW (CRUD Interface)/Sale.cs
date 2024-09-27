using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_09_11___HW__CRUD_Interface_
{
    internal class Sale
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public double AmountOfSale { get; set; }
        public DateTime DateOfSale { get; set; }
        public override string ToString()
        {
            return $"{AmountOfSale,-15} {DateOfSale.ToShortDateString(),-15}";
        }
    }
}
