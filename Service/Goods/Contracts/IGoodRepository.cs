using MyLittleShop.Entities;
using MyLittleShop.Service.Goods.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyLittleShop.Service.Goods.Contracts
{
    public interface IGoodRepository
    {
        void Add(Good good);
        void Delete(Good good);
        Task<List<GetGoodWithCategorieTitleDto>> GetAll();
        GetGoodDto GetByID(int id);
        Good FindByID(int id);
        Good FindByCode(string code);
        bool ExistByCode(string code);

    }
}
