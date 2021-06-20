using MyLittleShop.Entities;
using MyLittleShop.Service.Goods.Contracts;
using MyLittleShop.Service.Goods.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyLittleShop.Service.Goods
{
    public class GoodService : IGoodService
    {
        private readonly IGoodRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public GoodService(IGoodRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(CreateGoodDto dto)
        {
            if (_repository.ExistByCode(dto.Code))
                throw new Exception("Not Found");
            var good = new Good
            {
                Title = dto.Title,
                Code = dto.Code,
                Count = 0,
                Price = dto.Price,
                CategoryId = dto.CategoryId,
                Color = dto.ColorID


            };
            _repository.Add(good);
            _unitOfWork.Completed();


        }

        public void Delete(int id)
        {
            var good = _repository.FindByID(id);
            if (good == null)
                throw new Exception("Good Not Found");

            _repository.Delete(good);
            _unitOfWork.Completed();
        }

        public object FindByID(int id)
        {
            throw new NotImplementedException();
        }

        //get all Goods and their Categories with count>5  with join  
        public Task<List<GetGoodWithCategorieTitleDto>> GetAll()
        {
            return _repository.GetAll();
        }

        public GetGoodDto GetById(int id)
        {
            return _repository.GetByID(id);
        }

        public void Update(UpdateGoodDto dto, int id)
        {
            var good = _repository.FindByID(id);

            if (good == null)
                throw new Exception("Good Not Found");

            good.Code = dto.Code;
            good.Price = dto.Price;
            good.Title = dto.Title;
            good.Color = dto.ColorID;


            _unitOfWork.Completed();
        }
    }
}
