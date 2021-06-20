using Microsoft.AspNetCore.Mvc;
using MyLittleShop.Entities;
using MyLittleShop.Service.GoodEntries.Contracts;
using MyLittleShop.Service.GoodEntries.Dtos;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyLittleShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodEntryController : ControllerBase
    {
        private readonly IGoodEntryService _service;
        public GoodEntryController(IGoodEntryService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<GetGoodEntryDto> GetAll()
        {
            return _service.GetAll();
        }
        [HttpGet("{id}")]
        public GetGoodEntryDto Get(int id)
        {
            return _service.GetById(id);
        }
        [HttpPost]
        public void Post(CreateGoodEntryDto dto)
        {
            _service.Add(dto);
        }
        [HttpPut("{id}")]
        public void Put(int id, UpdateGoodEntryDto dto)
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
