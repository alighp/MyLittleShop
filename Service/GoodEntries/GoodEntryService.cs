using MyLittleShop.Entities;
using MyLittleShop.Service.GoodEntries.Contracts;
using MyLittleShop.Service.GoodEntries.Dtos;
using MyLittleShop.Service.GoodEntries.Exceptions;
using MyLittleShop.Service.Goods.Contracts;
using System;
using System.Collections.Generic;

namespace MyLittleShop.Service.GoodEntries
{
    public class GoodEntryService: IGoodEntryService
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IGoodEntryRepository _goodEntryrepository;
        private readonly IGoodRepository _goodRepository;


        public GoodEntryService(IGoodEntryRepository goodEntryrepository, IUnitOfWork unitofwork, IGoodRepository goodRepository)
        {
            _unitofwork = unitofwork;
            _goodEntryrepository = goodEntryrepository;
            _goodRepository = goodRepository;
        }
        public void Add(CreateGoodEntryDto dto) {
            if (!_goodRepository.ExistByCode(dto.Code))
            throw new NotFoundGoodCodeException();


            var good = _goodRepository.FindByCode(dto.Code);
            GoodEntry goodEntry = new GoodEntry
            {
                Count = dto.Count,
                Date = dto.Date,
                GoodId = good.Id,

                TotalPrice = dto.TotalPrice
            };
            good.Count += dto.Count;

            _goodEntryrepository.Add(goodEntry);
            _unitofwork.Completed();
        }

        public void Delete(int id)
        {
            if (!_goodEntryrepository.ExistByID(id))
                throw new NotFoundIdException();


            var goodEntry = _goodEntryrepository.FindByID(id);

            _goodEntryrepository.Delete(goodEntry);
            _unitofwork.Completed();
        }

        public List<GetGoodEntryDto> GetAll()
        {
           return _goodEntryrepository.GetAll();
        }

        public GetGoodEntryDto GetById(int id)
        {
            return _goodEntryrepository.Get(id);
        }

        public void Update(int id, UpdateGoodEntryDto dto)
        {
            if (!_goodEntryrepository.ExistByID(id))
                throw new NotFoundGoodCodeException();


            var goodEntry = _goodEntryrepository.FindByID(id);
            var good = _goodRepository.FindByCode(dto.Code);

            good.Count -= goodEntry.Count;
            goodEntry.Count = dto.Count;
            goodEntry.Date = dto.Date;
            goodEntry.TotalPrice = dto.TotalPrice;
            goodEntry.GoodId = good.Id;
            good.Count += dto.Count;


            _unitofwork.Completed();
        }
    }
}
