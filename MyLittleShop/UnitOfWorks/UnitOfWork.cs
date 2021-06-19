using MyLittleShop.Model;
using MyLittleShop.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleShop.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dataContext;

        public UnitOfWork(ApplicationDbContext dataContext)
        {
            _dataContext = dataContext;
        }


        public void Completed()
        {
            _dataContext.SaveChanges();
        }
    }
}
