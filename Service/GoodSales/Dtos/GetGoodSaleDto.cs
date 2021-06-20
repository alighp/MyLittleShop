using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleShop.Service.GoodSales.Dtos
{
    public class GetGoodSaleDto
    {
        public string GoodCode { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }
}
