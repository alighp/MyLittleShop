using System;

namespace MyLittleShop.Model
{
    public class CreateGoodSaleDto
    {

        public string Code { get; set; }
        public string title { get; set; }
        public int TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public int GoodId { get; set; }

    }
}