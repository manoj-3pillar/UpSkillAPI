using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UpSkillShopCart.Models;
using UpSkillShopCart.Models.RequestBodies;

namespace UpSkillShopCart.Interfaces
{
    public interface IService
    {
        Task<int> GetCount(int count);
        Task<List<ProductData>> GetProducts();
        Task<ProductData> GetProductDetails(Guid productID);
        Task<int> AddToCart(CartInformation cartInformation);
        Task<bool> DeleteFromCartByProdID(/*int userID,*/ Guid productID);
        Task<CartData> GetCartDetails(Guid cartID);
        Task<int> SaveOrder(OrderDetails orderDetails);
        Task<OrderDetails> GetOrderDetails(Guid orderID);
    }
}
