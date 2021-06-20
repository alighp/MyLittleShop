using System;

namespace MyLittleShop.Service.Goods.Dtos
{
    public class GetGoodWithCategorieTitleDto
    {
        public int GoodId { get; set; }
        public String GoodTitle { get; set; }
        public decimal GoodPrice { get; set; }
        public decimal GoodCount { get; set; }
        public String GoodCode { get; set; }
        public string CategoryTitle { get; set; }
    }
}
