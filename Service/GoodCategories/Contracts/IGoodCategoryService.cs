using MyLittleShop.Service.GoodCategories.Contracts;
using MyLittleShop.Service.GoodCategories.Dtos;
using System.Collections.Generic;

namespace MyLittleShop.Service.GoodCategories.Contracts
{
    public interface IGoodCategoryService
    {
        void Add(CreateGoodCategoryDto dto);
        List<GetCategoryWithGoodsDto> GetAllWithGoods();
        List<GetCategoryDto> GetAll();
        void Delete(int id);
        void Update(UpdateGoodCategoryDto dto, int id);
    }
}