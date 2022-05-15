using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaDaYaRemastered
{
    public interface IContractRepository
    {
        IEnumerable<CollectionContracts> GetAll();
        void AddContract(CollectionContracts collectionContracts);
        void UpdateContract(CollectionContracts collectionContracts);
        void DeleteContract(CollectionContracts collectionContracts);
    }
}
