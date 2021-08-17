using System;

namespace UpSkillShopCart.Models
{
    public class ProductData
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int QuantityForCart { get; set; }
    }
}
