using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpSkillShopCart.Models.Enums;

namespace UpSkillShopCart.Models
{
    public class OrderDetails
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public List<ProductData> ProductList { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
