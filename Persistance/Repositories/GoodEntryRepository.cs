using MyLittleShop.Controllers;
using MyLittleShop.Entities;
using MyLittleShop.Model;
using MyLittleShop.Model.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace MyLittleShop.Persistance
{
    public class GoodEntryRepository : IGoodEntryRepository
    {
        private readonly ApplicationDbContext _dataContext;

        public GoodEntryRepository(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void Add(GoodEntry goodEntry)
        {
            _dataContext.Add(goodEntry);
        }

        public void Delete(GoodEntry goodEntry)
        {
            _dataContext.Remove(goodEntry);
        }



        public bool ExistByID(int id)
        {
            return _dataContext.GoodEntries.Any(x => x.Id == id);
        }

        public GoodEntry FindByID(int id)
        {
            return _dataContext.GoodEntries.Find(id);
        }

        public GoodEntry Get(int id)
        {
            return _dataContext.GoodEntries.FirstOrDefault(_ => _.Id == id);
        }

        public List<GoodEntry> GetAll()
        {
            return _dataContext.GoodEntries.ToList();
        }
    }
}
