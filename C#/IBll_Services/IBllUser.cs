using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll_Services
{
    public interface IBllUser
    {
        public Task<Dto_Common_Enteties.UserDto> SelectById(int userId);
        public Task<List<Dto_Common_Enteties.UserDto>> SelectAll();
        public Task<Dto_Common_Enteties.UserDto> Add(Dto_Common_Enteties.UserDto c);
        public Task<Dto_Common_Enteties.UserDto> Update(int userId, Dto_Common_Enteties.UserDto user);
        public Task<Dto_Common_Enteties.UserDto> SelectByEmailAsync(string Email);

    }
}
