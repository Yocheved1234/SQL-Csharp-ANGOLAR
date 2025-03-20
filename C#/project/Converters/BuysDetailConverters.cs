using Dal_Repository.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Repository
{
    public class BuysDetailConverters
    {
        public static Dto_Common_Enteties.BuysDetailDto ToBuyDetailDto(Dal_Repository.Modules.BuysDetail c)
        {
            if (c == null) return null;

            var newB = new Dto_Common_Enteties.BuysDetailDto
            {
                Id = c.Id,
                BuyId = c.BuyId,
                Amount = c.Amount,
                ProductId = c.ProductId
            };
            if (c.ProductId != null && c.Product != null)
            {
                newB.ProductN = c.Product.DescriptionP;
            }


            return newB;
        }

        public static List<Dto_Common_Enteties.BuysDetailDto> ToListBuyDetailDto(List<Modules.BuysDetail> lc)
        {
            return lc?.Select(ToBuyDetailDto).ToList() ?? new List<Dto_Common_Enteties.BuysDetailDto>();
        }

        public static Modules.BuysDetail ToBuyDetail(Dto_Common_Enteties.BuysDetailDto c)
        {
            Modules.BuysDetail New = new Modules.BuysDetail();
            New.Id = c.Id;
            New.BuyId = c.BuyId;
            New.ProductId = c.ProductId;
            New.Amount = c.Amount;
            return New;
        }
    }
}
