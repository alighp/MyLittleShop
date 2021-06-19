using System;

namespace MyLittleShop.Model.Dtos
{
    public class GetListGoodsAndCategorieTitleDto
    {
        public int GoodId { get; set; }
        public String GoodTitle { get; set; }
        public decimal GoodPrice { get; set; }
        public decimal GoodCount { get; set; }
        public String GoodCode { get; set; }
        public string CategoryTitle { get; set; }
    }
}
