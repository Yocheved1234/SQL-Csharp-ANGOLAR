using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDal_Repository
{
    public interface IDalBuy<T>
    {
        public Task<List<Dto_Common_Enteties.BuyDto>> SelectAll();
        public Task<List<Dto_Common_Enteties.BuyDto>> SelectByUserId(int UserId);
        public Task<Dto_Common_Enteties.BuyDto> SelectById(int Id);
        public Task<Dto_Common_Enteties.BuyDto> AddBuy(Dto_Common_Enteties.BuyDto buy);


    }
}
