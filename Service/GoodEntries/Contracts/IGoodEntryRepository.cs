using MyLittleShop.Entities;
using MyLittleShop.Service.GoodEntries.Dtos;
using System.Collections.Generic;

namespace MyLittleShop.Service.GoodEntries.Contracts
{
    public interface IGoodEntryRepository
    {
        void Add(GoodEntry goodEntry);
        List<GetGoodEntryDto> GetAll();
        GetGoodEntryDto Get(int id);
        GoodEntry FindByID(int id);
        void Delete(GoodEntry goodEntry);
        bool ExistByID(int id);
    }
}