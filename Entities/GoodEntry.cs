using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleShop.Entities
{
    public class GoodEntry
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public Good Good { get; set; }
        public int GoodId { get; set; }

    }
}
