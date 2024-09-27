using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_09_11___HW__CRUD_Interface_
{
    internal class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public override string ToString()
        {
            return $"{Name,-14} {Surname,-14}";
        }
    }
}
