using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDal_Repository
{
    public interface IDalBuyDetail<T>
    {
        Task<List<Dto_Common_Enteties.BuysDetailDto>> SelectAll();

        Task<int> Add(Dto_Common_Enteties.BuysDetailDto c);

        Task<List<Dto_Common_Enteties.BuysDetailDto>> SelectByBuyId(int buyId);

        Task<List<Dto_Common_Enteties.BuysDetailDto>> SelectByProductId(int productId);
    }
}
