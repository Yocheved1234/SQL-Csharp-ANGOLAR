using Dal_Repository.Modules;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Repository
{
    public class UserDal : IDal_Repository.IDalUser<Dto_Common_Enteties.UserDto>
    {
        ChineseAuction1Context db;
        public UserDal(ChineseAuction1Context db)
        {
            this.db = db;
        }
        public async Task<Dto_Common_Enteties.UserDto> Add(Dto_Common_Enteties.UserDto c)
        {
            var existingUser = await db.Users.FirstOrDefaultAsync(u => u.Email == c.Email);
            if (existingUser != null)
            {
                throw new Exception("User with this email already exists.");
            }

            var newUser = UserConverters.ToUser(c);
            db.Users.Add(newUser);
            await db.SaveChangesAsync();

            return UserConverters.ToUserDto(newUser);
        }


        public async Task<List<Dto_Common_Enteties.UserDto>> SelectAll()
        {
            var q = db.Users.ToList();
            return UserConverters.ToListUserDto(q);
        }

        public async Task<Dto_Common_Enteties.UserDto> SelectById(int userId)
        {
            var user = await db.Users.FindAsync(userId);
            return UserConverters.ToUserDto(user);
        }
        public async Task<Dto_Common_Enteties.UserDto> SelectByEmailAsync(string Email)
        {
            var user1 = await db.Users.Include(v => v.BuysNavigation)
                                      .FirstOrDefaultAsync(u => u.Email == Email);
            return UserConverters.ToUserDto(user1);
        }

        public async Task<int> Update(int userId, Dto_Common_Enteties.UserDto userDto)
        {
            var user = db.Users.Find(userId);
            if (user == null)
            {
                return 0;
            }

            user.NameU = userDto.NameU;
            user.Phone = userDto.Phone;
            user.Email = userDto.Email;
            user.Buys = userDto.Buys;

            return db.SaveChanges();
        }
    }
}
