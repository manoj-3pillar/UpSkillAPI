using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSkillShopCart.Interfaces;
using UpSkillShopCart.Models;
using UpSkillShopCart.Models.RequestBodies;

namespace UpSkillShopCart.Services
{
    public class Service : IService
    {
        private List<ProductData> productList;
        private List<CartData> cartList;

        public Service()
        {
            productList = new List<ProductData>()
            {
                new ProductData
                {   
                    ID = new Guid("fc014793-75c1-49a4-882e-dfb560986011"),
                    Name = "Laptop",
                    Description = "Laptop Description"
                },
                new ProductData
                {
                    ID = new Guid("fc014793-75c1-49a4-882e-dfb560986012"),
                    Name = "Mobile",
                    Description = "Mobile Description"
                },
                new ProductData
                {
                    ID = new Guid("fc014793-75c1-49a4-882e-dfb560986013"),
                    Name = "Tablet",
                    Description = "Tablet Description"
                },
                new ProductData
                {
                    ID = new Guid("fc014793-75c1-49a4-882e-dfb560986014"),
                    Name = "Ipod",
                    Description = "Ipod Description"
                },
            };

            cartList = new List<CartData>();
        }

        public async Task<int> GetCount(int count)
        {
            return count;
        }
        
        public async Task<List<ProductData>> GetProducts()
        {
            return productList;
        }

        public async Task<ProductData> GetProductDetails(Guid productID)
        {
            return productList.FirstOrDefault(p => p.ID == productID);
        }

        public async Task<int> AddToCart(CartInformation cartInformation)
        {
            var productToBeAddedInCart = productList.FirstOrDefault(p => p.ID == cartInformation.ProductID);
            CartData cartData = new CartData();
            if (productToBeAddedInCart != null)
            {
                if (cartInformation.CartID == null)
                {
                    cartInformation.CartID = new Guid();
                    cartData.ProductDataList.Add(productToBeAddedInCart);
                }
                else
                {
                    cartData = await GetCartDetails(cartInformation.CartID.Value);
                    if (cartData == null)
                        return 0;
                    else if(cartData.ProductDataList.FirstOrDefault(p => p.ID == cartInformation.ProductID) != null)
                    {
                        cartData.ProductDataList.FirstOrDefault(p => p.ID == cartInformation.ProductID).QuantityForCart = cartInformation.Quantity;
                        return 1;
                    }
                    else
                    {
                        if (cartInformation.Quantity <= 0)
                            return 0;
                        else
                        {
                            productToBeAddedInCart.QuantityForCart = cartInformation.Quantity;
                            cartData.ProductDataList.Add(productToBeAddedInCart);
                        }
                    }
                }
                return 1;
            }
            else
                return 0;
        }

        public async Task<bool> DeleteFromCartByProdID(/*Guid userID, */Guid productID)
        {
            var itemToRemove = cartList.FirstOrDefault(c => /*c.UserID == userID && */c.ProductDataList.FirstOrDefault(p => p.ID == productID) != null);
            if (itemToRemove == null)
                return false;

            return cartList.Remove(itemToRemove);
        }

        public async Task<CartData> GetCartDetails(Guid cartID)
        {
            return cartList.Where(c => c.ID == cartID)?.FirstOrDefault();
        }

        //public async Task SaveOrder(OrderDetails orderDetails)
        //{
        //    var cartItemsToBeOrdered = 
        //}
    }
}
