using MyLittleShop.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleShop.Entities
{
   
    public class Good
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public decimal  Price { get; set; }
        public int Count { get; set; }
        public int CategoryId { get; set; }
        public Color Color { get; set; }
        public GoodCategory GoodCategory { get; set; }
        public List<GoodEntry> GoodEntries { get; set; }
        public List<GoodSale> GoodSales { get; set; }
    }
}
