using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll_Services
{
    public class BuyDetailBll : IBll_Services.IBllBuyDetail
    {
        IDal_Repository.IDalBuyDetail<Dto_Common_Enteties.BuysDetailDto> c;
        public BuyDetailBll(IDal_Repository.IDalBuyDetail<Dto_Common_Enteties.BuysDetailDto> c)
        {
            this.c = c;
        }
        public async Task<List<Dto_Common_Enteties.BuysDetailDto>> SelectAll()
        {
            return await c.SelectAll();
        }
        public async Task<int> Add(Dto_Common_Enteties.BuysDetailDto buyD)
        {
            return await c.Add(buyD);
        }
        public async Task<List<Dto_Common_Enteties.BuysDetailDto>> SelectByBuyId(int BuyId)
        {
            return await c.SelectByBuyId(BuyId);
        }
        public async Task<List<Dto_Common_Enteties.BuysDetailDto>> SelectByProductId(int ProductId)
        {
            return await c.SelectByProductId(ProductId);
        }
    }
}
