using MyLittleShop.Entities;
using MyLittleShop.Service.GoodCategories.Contracts;
using MyLittleShop.Service.GoodCategories.Dtos;
using MyLittleShop.Service.Goods.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace MyLittleShop.Persistance
{
    public class GoodCategoryRepository : IGoodCategoryRepository
    {
        private readonly ApplicationDbContext _Context;
        public GoodCategoryRepository(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public void Add(GoodCategory goodCategory)
        {
            _Context.Add(goodCategory);
        }
        public void Delete(GoodCategory goodCategory)
        {
            _Context.Remove(goodCategory);
        }
        public List<GetCategoryWithGoodsDto> GetAllCategoriesWithGoods()
        {
            return (from gc in _Context.GoodCategories
                    join g in _Context.Goods
                    on gc.Id equals g.CategoryId
                    select new GetCategoryWithGoodsDto
                    {
                        CategoryTitle = gc.Title,
                        GoodDto = gc.Goods
                      .Select(_ => new GetListGoodsDto
                      {
                          GoodID = _.Id,
                          GoodTitle = _.Title
                          
                      }).ToList()
                    }).ToList();
        }
        public List<GetCategoryDto> GetAll()
        {
            return _Context.GoodCategories
                .Select(_ => new GetCategoryDto
                {
                    CategoryTitle = _.Title
                })
                .ToList();
        }
        public GoodCategory FindByID(int id)
        {
            return _Context.GoodCategories.Find(id);
        }
        public bool ExistByTitle(string title)
        {
            return _Context.GoodCategories.Any(x => x.Title == title);
        }
    }
}
