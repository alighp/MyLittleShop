using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleShop.Model.Dtos
{
    public class GetListGoodsDto
    {
        public int GoodID { get; set; }
        public String GoodTitle { get; set; }
    }
}
