using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLittleShop.Entities;
using MyLittleShop.Model;
using MyLittleShop.Model.Dtos;
using MyLittleShop.Repositories;
using MyLittleShop.Service;
using MyLittleShop.UnitOfWorks;

namespace MyLittleShop.Controllers
{
    [ApiController]
    [Route("api/goods")]

    public class GoodsController : ControllerBase
    {
        private readonly IGoodRepository _repository;
        private readonly IUnitOfWork _unitofwork;


        public GoodsController(IGoodRepository repository, IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
            _repository = repository;
        }

        [HttpPost]
        public void Post(CreateGoodDto dto)
        {
            if (_repository.ExistByCode(dto.Code))
                throw new Exception("Not Found");
            var good = new Good
            {
                Title = dto.Title,
                Code = dto.Code,
                Count = 0,
                Price = dto.Price,
                CategoryID = dto.CategoryId,
                ColorID = dto.ColorID


            };
            _repository.Add(good);
            _unitofwork.Completed();

        }

        //get all Goods and their Categories with count>5  with join  
        [HttpGet]
        public async Task<List<GetListGoodsAndCategorieTitleDto>> GetAll()
        {
            return await _repository.GetAll();
        }
        [HttpGet("{id}")]
        public GetGoodDto GetByID(int id)
        {
            return _repository.GetByID(id);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var good = _repository.FindByID(id);

            if (good == null)
                throw new Exception("Good Not Found");

            _repository.Delete(good);
            _unitofwork.Completed();
        }

        [HttpPut("{id}")]
        public void Update(UpdateGoodDto dto, int id)
        {
            var good = _repository.FindByID(id);

            if (good == null)
                throw new Exception("Good Not Found");

            good.Code = dto.Code;
            good.Price = dto.Price;
            good.Title = dto.Title;
            good.ColorID = dto.ColorID;


            _unitofwork.Completed();
        }

    }
}
