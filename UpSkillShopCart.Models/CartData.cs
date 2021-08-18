using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSkillShopCart.Models
{
    public class CartData
    {
        public Guid ID { get; set; }
        //public Guid UserID { get; set; }
        public List<ProductData> ProductDataList { get; set; }
    }
}
