using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll_Services
{
    public interface IBllBuyDetail
    {
        public Task<List<Dto_Common_Enteties.BuysDetailDto>> SelectAll();

        public Task<int> Add(Dto_Common_Enteties.BuysDetailDto c);

        public Task<List<Dto_Common_Enteties.BuysDetailDto>> SelectByBuyId(int BuyId);

        public Task<List<Dto_Common_Enteties.BuysDetailDto>> SelectByProductId(int ProductId);

    }
}
