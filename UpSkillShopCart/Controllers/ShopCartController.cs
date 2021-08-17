using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpSkillShopCart.Interfaces;

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
    }
}
