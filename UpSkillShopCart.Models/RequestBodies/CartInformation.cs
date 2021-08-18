using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSkillShopCart.Models.RequestBodies
{
    public class CartInformation
    {
        public Guid? CartID { get; set; }
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
