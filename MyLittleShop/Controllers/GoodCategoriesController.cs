using Microsoft.AspNetCore.Mvc;
using MyLittleShop.Service.GoodCategories;
using MyLittleShop.Service.GoodCategories.Contracts;
using MyLittleShop.Service.GoodCategories.Dtos;
using System;
using System.Collections.Generic;

namespace MyLittleShop.Controllers
{
    [Route("api/good-categories")]
    [ApiController]
    public class GoodCategoriesController : ControllerBase
    {
        private readonly IGoodCategoryService _service;
        public GoodCategoriesController(IGoodCategoryService service)
        {
            _service = service;
        }
        [HttpPost]
        public void Add(CreateGoodCategoryDto dto)
        {
            _service.Add(dto);
        }
        [HttpGet("Goods")]
        public List<GetCategoryWithGoodsDto> GetAllCategoriesWithGoods()
        {
            return _service.GetAllWithGoods();
        }
        [HttpGet]
        public List<GetCategoryDto> GetAll()
        {
            return _service.GetAll();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
        [HttpPut("{id}")]
        public void Update(UpdateGoodCategoryDto dto, int id)
        {
            _service.Update(dto,id);
        }
    }
}
