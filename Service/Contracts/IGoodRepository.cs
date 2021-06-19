using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLittleShop.Entities;
using MyLittleShop.Model;
using MyLittleShop.Model.Dtos;
using MyLittleShop.Repositories;

namespace MyLittleShop.Service
{
    public interface IGoodRepository
    {
        void Add(Good good);
        void Delete(Good good);
        Task<List<GetListGoodsAndCategorieTitleDto>> GetAll();
        GetGoodDto GetByID(int id);
        Good FindByID(int id);
        Good FindByCode(string code);
        bool ExistByCode(string code);

    }
}
