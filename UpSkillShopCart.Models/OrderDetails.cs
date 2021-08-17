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
        public Guid CartID { get; set; }
        public string ProductName { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
