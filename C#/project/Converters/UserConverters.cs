using Dal_Repository.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Repository
{
    internal class UserConverters
    {
        public static Dto_Common_Enteties.UserDto ToUserDto(Dal_Repository.Modules.User c)
        {
            if (c == null) return null;

            var newP = new Dto_Common_Enteties.UserDto
            {
                Id = c.Id,
                NameU = c.NameU,
                Phone = c.Phone,
                Email = c.Email,
                Buys = c.Buys
            };

            return newP;
        }

        public static List<Dto_Common_Enteties.UserDto> ToListUserDto(List<Modules.User> lc)
        {
            return lc?.Select(ToUserDto).ToList() ?? new List<Dto_Common_Enteties.UserDto>(); 
        }


        public static Modules.User ToUser(Dto_Common_Enteties.UserDto c)
        {
            if (c == null) return null;

            Modules.User New = new Modules.User();
            New.Id = c.Id;
            New.NameU = c.NameU;
            New.Phone = c.Phone;
            New.Email = c.Email;
            New.Buys = c.Buys;
            return New;
        }
    }
}
