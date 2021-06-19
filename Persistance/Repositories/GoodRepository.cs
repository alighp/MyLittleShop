using Microsoft.EntityFrameworkCore;
using MyLittleShop.Entities;
using MyLittleShop.Model;
using MyLittleShop.Model.Dtos;
using MyLittleShop.Persistance;
using MyLittleShop.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleShop.Repositories
{
    public class GoodRepository : IGoodRepository
    {
        private readonly ApplicationDbContext _dataContext;

        public GoodRepository(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(Good good)
        {
            _dataContext.Add(good);
        }

        public void Delete(Good good)
        {
            _dataContext.Remove(good);
        }

        public Good FindByID(int id)
        {
            return _dataContext.Goods.Find(id);
        }

        public Good FindByCode(string code)
        {
            return _dataContext.Goods.SingleOrDefault(x=>x.Code == code);
        }

        public async Task<List<GetListGoodsAndCategorieTitleDto>> GetAll()
        {
            return await (from g in _dataContext.Goods/*.Where(x => x.Count > 5)*/
                         join gc in _dataContext.GoodCategories
                         on g.CategoryID equals gc.Id
                         select new GetListGoodsAndCategorieTitleDto
                         {
                             CategoryTitle = gc.Title,
                             GoodTitle = g.Title,
                             GoodCode = g.Code,
                             GoodCount = g.Count,
                             GoodPrice = g.Price
                         }).ToListAsync();
        }

        public GetGoodDto GetByID(int id)
        {
            return _dataContext.Goods
                .Where(x => x.Id == id)
                .Select(_=>new GetGoodDto 
                {
                    Title = _.Title,
                    Code = _.Code,
                    Price = _.Price,
                    CategoryId = _.CategoryID
                }).FirstOrDefault();
        }

        public bool ExistByCode(string code)
        {
            return _dataContext.Goods.Any(x => x.Code == code);
        }
    }
}
