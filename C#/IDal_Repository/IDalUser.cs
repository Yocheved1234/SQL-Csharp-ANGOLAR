using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDal_Repository
{
    public interface IDalUser<T>
    {
        public Task<List<Dto_Common_Enteties.UserDto>> SelectAll();
        public Task<Dto_Common_Enteties.UserDto> Add(Dto_Common_Enteties.UserDto c);
        public Task<Dto_Common_Enteties.UserDto> SelectById(int userId);
        public Task<int> Update(int userId, Dto_Common_Enteties.UserDto userDto);
        public Task<Dto_Common_Enteties.UserDto> SelectByEmailAsync(string Email);

    }
}
