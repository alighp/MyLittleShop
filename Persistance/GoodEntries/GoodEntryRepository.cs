using MyLittleShop.Entities;
using MyLittleShop.Service.GoodEntries.Contracts;
using MyLittleShop.Service.GoodEntries.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace MyLittleShop.Persistance
{
    public class GoodEntryRepository : IGoodEntryRepository
    {
        private readonly ApplicationDbContext _Context;

        public GoodEntryRepository(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public void Add(GoodEntry goodEntry)
        {
            _Context.Add(goodEntry);
        }
        public void Delete(GoodEntry goodEntry)
        {
            _Context.Remove(goodEntry);
        }
        public bool ExistByID(int id)
        {
            return _Context.GoodEntries.Any(x => x.Id == id);
        }
        public GoodEntry FindByID(int id)
        {
            return _Context.GoodEntries.Find(id);
        }
        public GetGoodEntryDto Get(int id)
        {
            var goodEntry = _Context.GoodEntries.FirstOrDefault(_ => _.Id == id);
            return new GetGoodEntryDto {
                Count = goodEntry.Count,
                Date = goodEntry.Date,
                TotalPrice = goodEntry.TotalPrice

            };
        }
        public List<GetGoodEntryDto> GetAll()
        {
            return _Context.GoodEntries
                .Select(_=>new GetGoodEntryDto 
                {
                    Count = _.Count,
                    Date = _.Date,
                    TotalPrice = _.TotalPrice,
                }).ToList();
        }
    }
}