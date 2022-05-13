using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaDaYaRemastered
{
    public interface IOwnerRepository
    {
        IEnumerable<CollectionOwners> GetAll();
        void AddOwner(CollectionOwners estate);
        void UpdateOwner(CollectionOwners estate);
        void DeleteOwner(CollectionOwners estate);
    }
}
