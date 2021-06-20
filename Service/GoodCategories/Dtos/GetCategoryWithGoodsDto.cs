using MyLittleShop.Service.Goods.Dtos;
using System.Collections.Generic;

namespace MyLittleShop.Service.GoodCategories.Dtos
{
    public class GetCategoryWithGoodsDto {
        public string CategoryTitle { get; set; }
        public List<GetListGoodsDto> GoodDto { get; set; }
    }
}
