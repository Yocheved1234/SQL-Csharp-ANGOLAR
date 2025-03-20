using Dal_Repository.Modules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyControllers : ControllerBase
    {
        IBll_Services.IBllBuy c;
        public BuyControllers(IBll_Services.IBllBuy c)
        {
            this.c = c;
        }

        [HttpGet]
        public async Task<List<Dto_Common_Enteties.BuyDto>> Get()
        {
            return await c.SelectAll();
        }

        [HttpGet("{id}")]
        public async Task<List<Dto_Common_Enteties.BuyDto>> GetByUserId(int id)
        {
            return await c.SelectByUserId(id);
        }

        [HttpGet("selectById/{id}")]
        public async Task<Dto_Common_Enteties.BuyDto> GetById(int id)
        {
            return await c.SelectById(id);
        }

        [HttpPost]
        public async Task<Dto_Common_Enteties.BuyDto> AddBuy(Dto_Common_Enteties.BuyDto buy)
        {
            return await c.AddBuy(buy);
        }


        [HttpPost("HandelBuy/{id}")]
        public async Task<int> HandelBuy(int id, [FromQuery] string buy, [FromQuery] int sum)
        {
            var buyDetails = JsonConvert.DeserializeObject<Dictionary<int, int>>(buy);
            return await c.HandelBuy(id, buyDetails!, sum);
        }

        [HttpGet("getDiscount")]
        public async Task<int> Discount(int sum, int umount)
        {
            return await c.Discount(sum,umount);
        }
    }
}
