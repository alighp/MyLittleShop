using MyLittleShop.Entities;
using MyLittleShop.Service.GoodSales.Dtos;
using System.Collections.Generic;

namespace MyLittleShop.Service.GoodSales.Contracts
{
    public interface IGoodSaleService
    {
        List<GetGoodSaleDto> GetAll();
        GetGoodSaleDto GetById(int id);
        void Add(CreateGoodSaleDto dto);
        void Update(int id, UpdateGoodSaleDto dto);
        void Delete(int id);
    }
}