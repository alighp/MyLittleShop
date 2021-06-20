using Microsoft.AspNetCore.Mvc;
using MyLittleShop.Service.Goods.Contracts;
using MyLittleShop.Service.Goods.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyLittleShop.Controllers
{
    [ApiController]
    [Route("api/goods")]
    public class GoodsController : ControllerBase
    {
        private readonly IGoodService _service;
        public GoodsController(IGoodService service)
        {
            _service = service;
        }
        [HttpPost]
        public void Post(CreateGoodDto dto)
        {
            _service.Add(dto);
        }
        [HttpGet]
        public async Task<List<GetGoodWithCategorieTitleDto>> GetAll()
        {
            return await _service.GetAll();
        }
        [HttpGet("{id}")]
        public GetGoodDto GetByID(int id)
        {
            return _service.GetById(id);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
        [HttpPut("{id}")]
        public void Update(UpdateGoodDto dto, int id)
        {
            _service.Update(dto, id);
        }
    }
}
