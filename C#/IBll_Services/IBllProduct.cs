using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBll_Services
{
    public interface IBllProduct
    {
        public Task<List<Dto_Common_Enteties.ProductDto>> SelectAll();
        public Task<List<Dto_Common_Enteties.ProductDto>> SelectAllRafuld();
        public Task<Dto_Common_Enteties.ProductDto> SelectById(int ProductId);
        public Task<int> Update(int ProductId, Dto_Common_Enteties.ProductDto ProductDto);
        public Task<List<Dto_Common_Enteties.BuyDto>> Do_Raffle();
        public Task<List<Dto_Common_Enteties.ProductDto>> FilterItems(decimal? minPrice = null, string categoryName = null);



    }
}
