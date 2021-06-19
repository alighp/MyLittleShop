using MyLittleShop.Entities;
using MyLittleShop.Model;
using MyLittleShop.Model.Dtos.GoodSale;
using System.Collections.Generic;

namespace MyLittleShop.Repositories
{
    public interface IGoodSaleRepository
    {
        void Add(GoodSale good);
        void Delete(GoodSale goodCategory);
        List<GoodSale> GetAll();
        GoodSale GetByID(int id);
        GoodSale Find(int id);
        bool ExistByID(int id);
    }
}