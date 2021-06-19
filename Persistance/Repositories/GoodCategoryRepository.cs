using MyLittleShop.Entities;
using MyLittleShop.Model;
using MyLittleShop.Model.Dtos;
using MyLittleShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleShop.Persistance
{
    public class GoodCategoryRepository : IGoodCategoryRepository
    {
        private readonly ApplicationDbContext _dataContext;

        public GoodCategoryRepository(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Add(GoodCategory goodCategory)
        {
            _dataContext.Add(goodCategory);
        }
        public void Delete(GoodCategory goodCategory)
        {
            _dataContext.Remove(goodCategory);
        }



        public List<GetListCategoryAndGoodsDto> GetAllWithGoods()
        {
            return _dataContext.GoodCategories
               .Select(_ => new GetListCategoryAndGoodsDto
               {
                   CategoryTitle = _.Title,
                   GoodDto = _.Goods
                   .Select(_ => new GetListGoodsDto
                   {
                       GoodID = _.Id,
                       GoodTitle = _.Title
                   }).ToList()
               }).ToList();
        }

        public List<CreateGoodCategoryDto> GetAll()
        {
            return _dataContext.GoodCategories
                .Select(_ => new CreateGoodCategoryDto
                {
                    Title = _.Title
                })
                .ToList();

        }

        public GoodCategory FindByID(int id)
        {
            return _dataContext.GoodCategories.Find(id);
        }

        public bool ExistByTitle(string title)
        {
            return _dataContext.GoodCategories.Any(x => x.Title == title);
        }
    }
}
