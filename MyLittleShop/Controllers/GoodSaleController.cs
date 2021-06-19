using Microsoft.AspNetCore.Mvc;
using MyLittleShop.Entities;
using MyLittleShop.Model;
using MyLittleShop.Model.Dtos.GoodSale;
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
    public class GoodSaleController : ControllerBase
    {

        private readonly IUnitOfWork _unitofwork;
        private readonly IGoodSaleRepository _goodSaleRepository;
        private readonly IGoodRepository _goodRepository;


        public GoodSaleController(IGoodSaleRepository goodSaleRepository, IUnitOfWork unitofwork, IGoodRepository goodRepository)
        {
            _unitofwork = unitofwork;
            _goodSaleRepository = goodSaleRepository;
            _goodRepository = goodRepository;
        }
        // GET: api/<GoodSaleController>
        [HttpGet]
        public List<GoodSale> GetAll()
        {
            return _goodSaleRepository.GetAll();

        }

        // GET api/<GoodSaleController>/5
        [HttpGet("{id}")]
        public GoodSale Get(int id)
        {

            return _goodSaleRepository.GetByID(id);

        }

        // POST api/<GoodSaleController>
        [HttpPost]
        public void Post(CreateGoodSaleDto dto)
        {
            if (!_goodRepository.ExistByCode(dto.Code))
                throw new Exception("Good Not found");

            var good = _goodRepository.FindByCode(dto.Code);
            GoodSale goodSale = new GoodSale
            {
                Count = dto.Count,
                Date = dto.Date,
                GoodID = good.Id,

                TotalPrice = dto.TotalPrice
            };
            good.Count -= dto.Count;

            _goodSaleRepository.Add(goodSale);
            _unitofwork.Completed();
        }

        // PUT api/<GoodSaleController>/5
        [HttpPut("{id}")]
        public void Put(int id, UpdateGoodSaleDto dto)
        {

            if (!_goodSaleRepository.ExistByID(id))
                throw new Exception("GoodEntry Not Found");

            var goodSale = _goodSaleRepository.Find(id);
            var good = _goodRepository.FindByCode(dto.Code);

            good.Count += goodSale.Count;
            goodSale.Count = dto.Count;
            goodSale.Date = dto.Date;
            goodSale.TotalPrice = dto.TotalPrice;
            goodSale.GoodID = good.Id;
            good.Count -= dto.Count;


            _unitofwork.Completed();
        }

        // DELETE api/<GoodSaleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (!_goodSaleRepository.ExistByID(id))
                throw new Exception("GoodEntry Not Found");

            var goodSale = _goodSaleRepository.Find(id);

            _goodSaleRepository.Delete(goodSale);
            _unitofwork.Completed();

        }
    }
}
