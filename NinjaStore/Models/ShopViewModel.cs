using Microsoft.EntityFrameworkCore.Metadata;
using NinjaStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaStore.Web.Models
{
    public class ShopViewModel
    {
        public List<Equipment> BuyAbleEquipment { get; set; }
        public List<Equipment> AllEquipment { get; set; }
        public List<Equipment> NinjaEquipment { get; set; }
        public Equipment Head { get; set; }
        public Equipment Hands { get; set; }
        public Equipment Feet { get; set; }
        public Equipment Necklace { get; set; }
        public Equipment Chest { get; set; }
        public Equipment Ring { get; set; }
        public int  Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Worth { get; set; }
        public Ninja CurrentNinja { get; set; }

    }
}
