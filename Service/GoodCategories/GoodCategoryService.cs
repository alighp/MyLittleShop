using MyLittleShop.Entities;
using MyLittleShop.Service.GoodCategories.Contracts;
using MyLittleShop.Service.GoodCategories.Dtos;
using MyLittleShop.Service.GoodCategories.Exceptions;
using System;
using System.Collections.Generic;

namespace MyLittleShop.Service.GoodCategories
{
    public class GoodCategoryService : IGoodCategoryService
    {
        private readonly IGoodCategoryRepository _repository;
        private readonly IUnitOfWork _unitofwork;


        public GoodCategoryService(IGoodCategoryRepository repository, IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
            _repository = repository;
        }

        public void Add(CreateGoodCategoryDto dto)
        {
            if (_repository.ExistByTitle(dto.Title))
                throw new DuplicateTitleException();

            var goodCategory = new GoodCategory
            {
                Title = dto.Title
            };
            _repository.Add(goodCategory);
            _unitofwork.Completed();
        }

        public void Delete(int id)
        {
            var GoodCategory = _repository.FindByID(id);
            if (GoodCategory == null)
                throw new NotFoundIdException();

            _repository.Delete(GoodCategory);
            _unitofwork.Completed();
        }

        public List<GetCategoryDto> GetAll()
        {
            return _repository.GetAll();
        }

        public List<GetCategoryWithGoodsDto> GetAllWithGoods()
        {
            return _repository.GetAllCategoriesWithGoods();
        }

        public void Update(UpdateGoodCategoryDto dto, int id)
        {
            var GoodCategory = _repository.FindByID(id);
            if (GoodCategory == null)
                throw new NotFoundIdException();
            GoodCategory.Title = dto.Title;
            _unitofwork.Completed();
        }
    }
}
