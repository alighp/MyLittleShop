using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLittleShop.Model;
using MyLittleShop.Model.Dtos;
using MyLittleShop.Repositories;
using MyLittleShop.UnitOfWorks;
using MyLittleShop.Entities;

namespace MyLittleShop.Controllers
{
    [Route("api/good-categories")]
    [ApiController]
    public class GoodCategoriesController : ControllerBase
    {
        private readonly IGoodCategoryRepository _repository;
        private readonly IUnitOfWork _unitofwork;


        public GoodCategoriesController(IGoodCategoryRepository repository,IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
            _repository = repository;
        }


        [HttpPost]
        public void Add(CreateGoodCategoryDto dto)
        {
            if (_repository.ExistByTitle(dto.Title))
                throw new Exception("Not Found");

            var goodCategory = new GoodCategory
            {
                Title = dto.Title
            };
            _repository.Add(goodCategory);
            _unitofwork.Completed();
        }


        [HttpGet("Goods")]
        public List<GetListCategoryAndGoodsDto> GetAllCategoriesWithGoods()
        {
            return _repository.GetAllWithGoods();
        }
        [HttpGet]
        public List<GetListCategoryAndGoodsDto> GetAll()
        {
            return _repository.GetAllWithGoods();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var GoodCategory = _repository.FindByID(id);
            if (GoodCategory == null)
                throw new Exception("Good Not Found");

            _repository.Delete(GoodCategory);
            _unitofwork.Completed();
        }

        [HttpPut("{id}")]
        public void Update(UpdateGoodCategoryDto dto, int id)
        {
            var GoodCategory = _repository.FindByID(id);
            if (GoodCategory == null)
                throw new Exception("Good Not Found");

            GoodCategory.Title = dto.Title;
            _unitofwork.Completed();
        }
    }
}
