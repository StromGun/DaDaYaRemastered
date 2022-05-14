using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaDaYaRemastered
{
    public interface IBuyerRepository
    {
        IEnumerable<CollectionBuyers> GetAll();
        void AddBuyer(CollectionBuyers buyer);
        void UpdateBuyer(CollectionBuyers buyer);
        void DeleteBuyer(CollectionBuyers buyer);
    }
}
