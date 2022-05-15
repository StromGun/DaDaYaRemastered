using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaDaYaRemastered
{
    public class CollectionContracts
    {
        int numberContract;
        string dateSigning;
        string owner;
        string buyer;
        int price;
        string estateName;

        public int NumberContract { get => numberContract; set => numberContract = value; }
        public string DateSigning { get => dateSigning; set => dateSigning = value; }
        public string Owner { get => owner; set => owner = value; }
        public string Buyer { get => buyer; set => buyer = value; }
        public int Price { get => price; set => price = value; }
        public string EstateName { get => estateName; set => estateName = value; }
    }
}
