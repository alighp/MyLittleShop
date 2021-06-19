using System.Collections.Generic;

namespace MyLittleShop.Model.Dtos
{
    public class GetListCategoryAndGoodsDto {
        public string CategoryTitle { get; set; }
        public List<GetListGoodsDto> GoodDto { get; set; }
    }
}
