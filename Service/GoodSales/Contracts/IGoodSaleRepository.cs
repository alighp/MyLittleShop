using MyLittleShop.Entities;
using MyLittleShop.Service.GoodSales.Dtos;
using System.Collections.Generic;

namespace MyLittleShop.Service.GoodSales.Contracts
{
    public interface IGoodSaleRepository
    {
        void Add(GoodSale good);
        void Delete(GoodSale goodCategory);
        List<GetGoodSaleDto> GetAll();
        GetGoodSaleDto GetByID(int id);
        GoodSale Find(int id);
        bool ExistByID(int id);
    }
}