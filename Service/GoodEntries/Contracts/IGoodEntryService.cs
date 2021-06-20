using MyLittleShop.Entities;
using MyLittleShop.Service.GoodEntries.Dtos;
using System.Collections.Generic;

namespace MyLittleShop.Service.GoodEntries.Contracts
{
    public interface IGoodEntryService
    {
        void Add(CreateGoodEntryDto dto);
        List<GetGoodEntryDto> GetAll();
        GetGoodEntryDto GetById(int id);
        void Delete(int id);
        void Update(int id, UpdateGoodEntryDto dto);
    }
}