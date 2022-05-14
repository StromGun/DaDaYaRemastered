using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaDaYaRemastered
{
    public class CollectionBuyers
    {
        int buyerId;
        string buyerName;
        string buyerTelephone;
        string estateName;

        public int BuyerId { get => buyerId; set => buyerId = value; }
        public string BuyerName { get => buyerName; set => buyerName = value; }
        public string BuyerTelephone { get => buyerTelephone; set => buyerTelephone = value; }
        public string EstateName { get => estateName; set => estateName = value; }
    }
}
