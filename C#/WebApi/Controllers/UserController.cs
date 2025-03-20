using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IBll_Services.IBllUser c;
        public UserController(IBll_Services.IBllUser c)
        {
            this.c = c;
        }

        [HttpGet]
        public async Task<List<Dto_Common_Enteties.UserDto>> Get()
        {
            return await c.SelectAll();
        }

        [HttpGet("{id}")]
        public async Task<Dto_Common_Enteties.UserDto> GetById(int id)
        {
            return await c.SelectById(id);
        }

        [HttpGet("checkUser/{email}")]
        public async Task<Dto_Common_Enteties.UserDto> GetByEmail(string email)
        {
            return await c.SelectByEmailAsync(email);
        }


        [HttpPatch("{id}")]
        public async Task<Dto_Common_Enteties.UserDto> UpdateUser(int id, Dto_Common_Enteties.UserDto userDto)
        {
            return await c.Update(id, userDto); 
        }

        [HttpPost]
        public async Task<Dto_Common_Enteties.UserDto> Post(Dto_Common_Enteties.UserDto user)
        {
            return await c.Add(user);
        }
    }
}
