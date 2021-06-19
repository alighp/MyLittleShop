using Microsoft.AspNetCore.Mvc;
using MyLittleShop.Entities;
using MyLittleShop.Model;
using MyLittleShop.Repositories;
using MyLittleShop.Service;
using MyLittleShop.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyLittleShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodEntryController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IGoodEntryRepository _goodEntryrepository;
        private readonly IGoodRepository _goodRepository;


        public GoodEntryController(IGoodEntryRepository goodEntryrepository, IUnitOfWork unitofwork,IGoodRepository goodRepository)
        {
            _unitofwork = unitofwork;
            _goodEntryrepository = goodEntryrepository;
            _goodRepository = goodRepository;
        }
        // GET: api/<GoodEntryController>
        [HttpGet]
        public List<GoodEntry> GetAll()
        {
            return _goodEntryrepository.GetAll();
        }

        // GET api/<GoodEntryController>/5
        [HttpGet("{id}")]
        public GoodEntry Get(int id)
        {
            return _goodEntryrepository.Get(id);

        }

        // POST api/<GoodEntryController>
        [HttpPost]
        public void Post(CreateGoodEntryDto dto)
        {
            if (!_goodRepository.ExistByCode(dto.Code))
                throw new Exception("Good Not found");

            var good = _goodRepository.FindByCode(dto.Code);
            GoodEntry goodEntry = new GoodEntry
            {
                Count = dto.Count,
                Date = dto.Date,
                GoodID = good.Id,

                TotalPrice = dto.TotalPrice
            };
            good.Count += dto.Count;

            _goodEntryrepository.Add(goodEntry);
            _unitofwork.Completed();
        }

        // PUT api/<GoodEntryController>/5
        [HttpPut("{id}")]
        public void Put(int id, UpdateGoodEntryDto dto)
        {
            if (!_goodEntryrepository.ExistByID(id))
                throw new Exception("GoodEntry Not Found");

            var goodEntry = _goodEntryrepository.FindByID(id);
            var good = _goodRepository.FindByCode(dto.Code);

            good.Count -= goodEntry.Count;
            goodEntry.Count = dto.Count;
            goodEntry.Date = dto.Date;
            goodEntry.TotalPrice = dto.TotalPrice;
            goodEntry.GoodID = good.Id;
            good.Count += dto.Count;


            _unitofwork.Completed();
        }

        // DELETE api/<GoodEntryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (!_goodEntryrepository.ExistByID(id))
                throw new Exception("GoodEntry Not Found");

            var goodEntry = _goodEntryrepository.FindByID(id);

            _goodEntryrepository.Delete(goodEntry);
            _unitofwork.Completed();
        }
    }
}
