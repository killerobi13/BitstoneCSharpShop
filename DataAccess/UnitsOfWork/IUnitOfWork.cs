using Shop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.UnitsOfWork
{
    public interface IUnitOfWork
    {
         CategoryRepository CategoryRepository { get; }
         OrderRepository OrderRepository { get; }
         OrderItemRepository OrderItemRepository { get; }
         ProductRepository ProductRepository { get; }
         void Save();


    }
}
