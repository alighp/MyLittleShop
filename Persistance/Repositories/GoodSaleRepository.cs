using MyLittleShop.Entities;
using MyLittleShop.Model;
using MyLittleShop.Model.Dtos.GoodSale;
using MyLittleShop.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleShop.Repositories
{
    public class GoodSaleRepository : IGoodSaleRepository
    {
        private readonly ApplicationDbContext _dataContext;

        public GoodSaleRepository(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Add(GoodSale goodSale)
        {
            _dataContext.Add(goodSale);

        }

        public void Delete(GoodSale goodSale)
        {
            _dataContext.Remove(goodSale);
        }

        public GoodSale Find(int id)
        {
           return  _dataContext.GoodSales.Find(id);

        }
        public bool ExistByID(int id)
        {
            return _dataContext.GoodSales.Any(x => x.Id == id);
        }

        public List<GoodSale> GetAll()
        {
           return _dataContext.GoodSales.ToList();

        }


        public GoodSale GetByID(int id)
        {
            return _dataContext.GoodSales.FirstOrDefault(_ => _.Id == id);


        }


    }
}
