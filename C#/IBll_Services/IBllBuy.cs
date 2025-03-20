using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll_Services
{
    public interface IBllBuy
    {
        public Task<List<Dto_Common_Enteties.BuyDto>> SelectAll();
        public Task<List<Dto_Common_Enteties.BuyDto>> SelectByUserId(int UserId);
        public Task<Dto_Common_Enteties.BuyDto> SelectById(int Id);
        public Task<int> HandelBuy(int Id, Dictionary<int, int> products, int sum);
        public Task<Dto_Common_Enteties.BuyDto> AddBuy(Dto_Common_Enteties.BuyDto buy);
        public Task<int> Discount(int sum, int umount);

    }
}
