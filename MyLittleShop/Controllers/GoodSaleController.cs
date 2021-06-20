using Microsoft.AspNetCore.Mvc;
using MyLittleShop.Entities;
using MyLittleShop.Service.GoodSales.Contracts;
using MyLittleShop.Service.GoodSales.Dtos;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyLittleShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodSaleController : ControllerBase
    {
        private readonly IGoodSaleService _service;
        public GoodSaleController(IGoodSaleService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<GetGoodSaleDto> GetAll()
        {
            return _service.GetAll();
        }
        [HttpGet("{id}")]
        public GetGoodSaleDto Get(int id)
        {
            return _service.GetById(id);
        }
        [HttpPost]
        public void Post(CreateGoodSaleDto dto)
        {
            _service.Add(dto);
        }
        [HttpPut("{id}")]
        public void Put(int id, UpdateGoodSaleDto dto)
        {
            _service.Update(id, dto);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
