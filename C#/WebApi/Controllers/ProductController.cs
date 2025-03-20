using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IBll_Services.IBllProduct c;
        public ProductController(IBll_Services.IBllProduct c)
        {
            this.c = c;
        }

        [HttpGet]
        public async Task<List<Dto_Common_Enteties.ProductDto>> Get()
        {
            return await c.SelectAll();
        }

        [HttpGet("Rafuld")]
        public async Task<List<Dto_Common_Enteties.ProductDto>> GetRafuld()
        {
            return await c.SelectAllRafuld();
        }

        [HttpGet("{id}")]
        public async Task<Dto_Common_Enteties.ProductDto> GetById(int id)
        {
            return await c.SelectById(id);
        }

        [HttpGet("Raful/all")]
        public async Task<List<Dto_Common_Enteties.BuyDto>> Do_Raffle()
        {
            return await c.Do_Raffle();
        }

        [HttpGet("Filter!")]
        public async Task<List<Dto_Common_Enteties.ProductDto>> FilterItems(decimal? minPrice = null, string? CategoryName = null)
        {
            return await c.FilterItems(minPrice,CategoryName);
        }
    }
}
