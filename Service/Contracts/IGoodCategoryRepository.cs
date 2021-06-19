using MyLittleShop.Entities;
using MyLittleShop.Model;
using MyLittleShop.Model.Dtos;
using System.Collections.Generic;

namespace MyLittleShop.Repositories
{
    public interface IGoodCategoryRepository
    {
        void Add(GoodCategory goodCategory);
        void Delete(GoodCategory goodCategory);
        List<GetListCategoryAndGoodsDto> GetAllWithGoods();
        List<CreateGoodCategoryDto> GetAll();
        GoodCategory FindByID(int id);
        bool ExistByTitle(string title);
    }
}