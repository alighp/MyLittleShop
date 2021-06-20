using MyLittleShop.Entities;
using MyLittleShop.Service.Goods.Contracts;
using MyLittleShop.Service.GoodSales.Contracts;
using MyLittleShop.Service.GoodSales.Dtos;
using MyLittleShop.Service.GoodSales.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLittleShop.Service.GoodSales
{
    public class GoodSaleService:IGoodSaleService
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IGoodSaleRepository _goodSaleRepository;
        private readonly IGoodRepository _goodRepository;


        public GoodSaleService(IGoodSaleRepository goodSaleRepository, IUnitOfWork unitofwork, IGoodRepository goodRepository)
        {
            _unitofwork = unitofwork;
            _goodSaleRepository = goodSaleRepository;
            _goodRepository = goodRepository;
        }

        public void Add(CreateGoodSaleDto dto)
        {
            if (!_goodRepository.ExistByCode(dto.Code))
                throw new NotFoundGoodCodeException();

            var good = _goodRepository.FindByCode(dto.Code);
            GoodSale goodSale = new GoodSale
            {
                Count = dto.Count,
                Date = dto.Date,
                GoodId = good.Id,

                TotalPrice = dto.TotalPrice
            };
            good.Count -= dto.Count;

            _goodSaleRepository.Add(goodSale);
            _unitofwork.Completed();
        }

        public void Delete(int id)
        {
            if (!_goodSaleRepository.ExistByID(id))
                throw new NotFoundIdException();

            var goodSale = _goodSaleRepository.Find(id);

            _goodSaleRepository.Delete(goodSale);
            _unitofwork.Completed();
        }

        public List<GetGoodSaleDto> GetAll()
        {
            return _goodSaleRepository.GetAll();
        }

        public GetGoodSaleDto GetById(int id)
        {
           return _goodSaleRepository.GetByID(id);

        }

        public void Update(int id, UpdateGoodSaleDto dto)
        {
            if (!_goodSaleRepository.ExistByID(id))
                throw new NotFoundIdException();

            var goodSale = _goodSaleRepository.Find(id);
            var good = _goodRepository.FindByCode(dto.Code);

            good.Count += goodSale.Count;
            goodSale.Count = dto.Count;
            goodSale.Date = dto.Date;
            goodSale.TotalPrice = dto.TotalPrice;
            goodSale.GoodId = good.Id;
            good.Count -= dto.Count;


            _unitofwork.Completed();
        }

       
    }
}
