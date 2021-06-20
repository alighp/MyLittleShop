using MyLittleShop.Entities;
using MyLittleShop.Service.GoodCategories.Dtos;
using System.Collections.Generic;

namespace MyLittleShop.Service.GoodCategories.Contracts
{
    public interface IGoodCategoryRepository
    {
        void Add(GoodCategory goodCategory);
        void Delete(GoodCategory goodCategory);
        List<GetCategoryWithGoodsDto> GetAllCategoriesWithGoods();
        List<GetCategoryDto> GetAll();
        GoodCategory FindByID(int id);
        bool ExistByTitle(string title);
    }
}