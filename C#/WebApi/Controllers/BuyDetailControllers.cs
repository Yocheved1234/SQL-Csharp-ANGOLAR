using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyDetailControllers : ControllerBase 
    {
        IBll_Services.IBllBuyDetail c;
        public BuyDetailControllers(IBll_Services.IBllBuyDetail c)
        {
            this.c = c;
        }

        [HttpGet]
        public async Task<List<Dto_Common_Enteties.BuysDetailDto>> Get()
        {
            return await c.SelectAll();
        }

        [HttpGet("{id}")]
        public async Task<List<Dto_Common_Enteties.BuysDetailDto>> SelectByBuyId(int id)
        {
            return await c.SelectByBuyId(id);
        }

        [HttpGet("product/{id}")]
        public async Task<List<Dto_Common_Enteties.BuysDetailDto>> SelectByProductId(int id)
        {
            return await c.SelectByProductId(id);
        }

        [HttpPost]
        public async Task<int> Post(Dto_Common_Enteties.BuysDetailDto buyD)
        {
             return await c.Add(buyD);
        }
    }
}
