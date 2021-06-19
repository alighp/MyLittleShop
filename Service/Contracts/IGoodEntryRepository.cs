using MyLittleShop.Entities;
using MyLittleShop.Model;
using System.Collections.Generic;

namespace MyLittleShop.Controllers
{
    public interface IGoodEntryRepository
    {
        void Add(GoodEntry goodEntry);
        List<GoodEntry> GetAll();
        GoodEntry Get(int id);
        GoodEntry FindByID(int id);
        void Delete(GoodEntry goodEntry);
        bool ExistByID(int id);
    }
}