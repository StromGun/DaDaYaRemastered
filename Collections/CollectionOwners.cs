using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaDaYaRemastered
{
    public class CollectionOwners
    {
        int ownerId;
        string ownerName;
        string ownerTelephone;

        public int OwnerId { get => ownerId; set => ownerId = value; }
        public string OwnerName { get => ownerName; set => ownerName = value; }
        public string OwnerTelephone { get => ownerTelephone; set => ownerTelephone = value; }
    }
}
