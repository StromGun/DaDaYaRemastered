using System.Collections.Generic;

namespace DaDaYaRemastered
{
    public interface IEstatesRepository
    {
        IEnumerable<CollectionEstates> GetAll();
        void AddEstate(CollectionEstates estate);
        void UpdateEstate(CollectionEstates estate);
        void DeleteEstate(CollectionEstates estate);
    }
}
