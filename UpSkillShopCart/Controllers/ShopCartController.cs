using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSkillShopCart.Interfaces;
using UpSkillShopCart.Models;
using UpSkillShopCart.Models.RequestBodies;

namespace UpSkillShopCart.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopCartController : ControllerBase
    {
        private readonly IService _service;

        public ShopCartController(ILogger<ShopCartController> logger, 
            IService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetCount(10));
        }

        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _service.GetProducts());
        }

        [HttpGet]
        [Route("productDetails/{productID}")]
        public async Task<IActionResult> GetProductDetails(Guid productID)
        {
            var product = await _service.GetProductDetails(productID);
            if(product == null)
            {
                return BadRequest("ID is invalid");
            }
            else
            {
                return Ok(product);
            }
        }

        [HttpPost]
        [Route("addToCart")]
        public async Task<IActionResult> AddToCart([FromBody] CartInformation cartInformation)
        {
            if(cartInformation == null)
                return BadRequest("Invalid request body passed");
            else
            {
                var cartDetailsAdded = await _service.AddToCart(cartInformation);
                if (cartDetailsAdded <= 0)
                    return BadRequest("Product can't be added");
                else
                    return Ok("Product added successfully");
            }
        }

        [HttpDelete]
        [Route("removeFromCart/{userID}/{productID}")]
        public async Task<IActionResult> DeleteFromCartByProdID(/*int userID,*/ Guid productID)
        {
            var isProductRemovedFromCart = await _service.DeleteFromCartByProdID(/*userID, */productID);
            if (!isProductRemovedFromCart)
                return BadRequest("Invalid userID or productID");
            else
                return Ok("Product removed successfully");
        }

        [HttpGet]
        [Route("cartList/{cartID}")]
        public async Task<IActionResult> GetCartDetails(Guid cartID)
        {
            var cartList = await _service.GetCartDetails(cartID);
            if (cartList == null)
                return BadRequest("CartID is invalid");
            else
                return Ok(cartList);
        }

        [HttpPost]
        [Route("SaveOrder")]
        public async Task<IActionResult> SaveOrder(OrderDetails orderDetails)
        {
            if (orderDetails == null)
                return BadRequest("Invalid request body passed");
            else
            {
                orderDetails.OrderStatus = Models.Enums.OrderStatus.InProcess;
                var isOrderSaved = await _service.SaveOrder(orderDetails);
                if (isOrderSaved <= 0)
                    return BadRequest("Order not saved");
                else
                    return Ok(isOrderSaved);
            }
        }

        [HttpGet]
        [Route("orderDetails/{orderID}")]
        public async Task<IActionResult> GetOrderDetails(Guid orderID)
        {
            var orderDetails = await _service.GetOrderDetails(orderID);
            if (orderDetails == null)
                return BadRequest("Order ID is invalid");
            else
                return Ok(orderDetails);
        }
    }
}
