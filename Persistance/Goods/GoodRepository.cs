using Microsoft.EntityFrameworkCore;
using MyLittleShop.Entities;
using MyLittleShop.Persistance;
using MyLittleShop.Service.Goods.Contracts;
using MyLittleShop.Service.Goods.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleShop.Repositories
{
    public class GoodRepository : IGoodRepository
    {
        private readonly ApplicationDbContext _Context;

        public GoodRepository(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public void Add(Good good)
        {
            _Context.Add(good);
        }
        public void Delete(Good good)
        {
            _Context.Remove(good);
        }
        public Good FindByID(int id)
        {
            return _Context.Goods.Find(id);
        }
        public Good FindByCode(string code)
        {
            return _Context.Goods.SingleOrDefault(x => x.Code == code);
        }
        public async Task<List<GetGoodWithCategorieTitleDto>> GetAll()
        {
            return await (from g in _Context.Goods
                          join gc in _Context.GoodCategories
                          on g.CategoryId equals gc.Id
                          select new GetGoodWithCategorieTitleDto
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
            return _Context.Goods
                .Where(x => x.Id == id)
                .Select(_ => new GetGoodDto
                {
                    Title = _.Title,
                    Code = _.Code,
                    Price = _.Price,
                    CategoryId = _.CategoryId
                }).FirstOrDefault();
        }
        public bool ExistByCode(string code)
        {
            return _Context.Goods.Any(x => x.Code == code);
        }
    }
}
