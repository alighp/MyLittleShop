using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleShop.Model.Dtos.GoodSale
{
    public class UpdateGoodSaleDto
    {
        public string Code { get; set; }
        public string title { get; set; }
        public int TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }
}
