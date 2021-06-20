using MyLittleShop.Service.Goods.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyLittleShop.Service.Goods.Contracts
{
    public interface IGoodService
    {
        void Add(CreateGoodDto dto);
        Task<List<GetGoodWithCategorieTitleDto>> GetAll();
        void Delete(int id);
        object FindByID(int id);
        void Update(UpdateGoodDto dto, int id);
        GetGoodDto GetById(int id);
    }
}