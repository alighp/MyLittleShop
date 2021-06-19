using System;

namespace MyLittleShop.Entities
{
    public class GoodSale { 
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public int GoodID { get; set; }
        public Good Good { get; set; }

    }
}
