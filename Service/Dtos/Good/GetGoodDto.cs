using MyLittleShop.Entities.Enums;

namespace MyLittleShop.Repositories
{
    public class GetGoodDto
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public ColorEnum MyProperty { get; set; }

    }
}