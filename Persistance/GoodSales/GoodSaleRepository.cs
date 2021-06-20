using MyLittleShop.Entities;
using MyLittleShop.Persistance;
using MyLittleShop.Service.GoodSales.Contracts;
using MyLittleShop.Service.GoodSales.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace MyLittleShop.Repositories
{
    public class GoodSaleRepository : IGoodSaleRepository
    {
        private readonly ApplicationDbContext _Context;

        public GoodSaleRepository(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public void Add(GoodSale goodSale)
        {
            _Context.Add(goodSale);

        }

        public void Delete(GoodSale goodSale)
        {
            _Context.Remove(goodSale);
        }


        public bool ExistByID(int id)
        {
            return _Context.GoodSales.Any(x => x.Id == id);
        }

        public List<GetGoodSaleDto> GetAll()
        {
            return (from gs in _Context.GoodSales
                    join g in _Context.Goods on
                    gs.GoodId equals g.Id
                    select new GetGoodSaleDto
                    {
                        Count = gs.Count,
                        Date = gs.Date,
                        TotalPrice = gs.TotalPrice,
                        GoodCode = g.Code
                    })
                .ToList();

        }


        public GetGoodSaleDto GetByID(int id)
        {
            return (from gs in _Context.GoodSales.Where(_ => _.Id == id)
                    join g in _Context.Goods
                    on gs.GoodId equals g.Id
                    select new GetGoodSaleDto
                    {
                        Count = gs.Count,
                        Date = gs.Date,
                        TotalPrice = gs.TotalPrice,
                        GoodCode = g.Code
                    }).FirstOrDefault();



        }

        GoodSale IGoodSaleRepository.Find(int id)
        {
            return _Context.GoodSales.Find(id);

        }
    }
}
