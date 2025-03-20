using Dal_Repository.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll_Services
{
    public class UserBll : IBll_Services.IBllUser
    {
        IDal_Repository.IDalUser<Dto_Common_Enteties.UserDto> c;
        public UserBll(IDal_Repository.IDalUser<Dto_Common_Enteties.UserDto> c)
        {
            this.c = c;
        }
        public async Task<Dto_Common_Enteties.UserDto> SelectById(int userId)
        {
            return await c.SelectById(userId);
        }
        public async Task<Dto_Common_Enteties.UserDto> SelectByEmailAsync(string Email)
        {
            return await c.SelectByEmailAsync(Email);
        }
        public async Task<List<Dto_Common_Enteties.UserDto>> SelectAll()
        {
            return await c.SelectAll();
        }
        public async Task<Dto_Common_Enteties.UserDto> Add(Dto_Common_Enteties.UserDto userDto)
        {
            return await c.Add(userDto); 
        }

        public async Task<Dto_Common_Enteties.UserDto> Update(int userId, Dto_Common_Enteties.UserDto user)
        {
            var result = c.Update(userId, user);

            if (result != null)
                return user;
            return null;
        }

    }
}
