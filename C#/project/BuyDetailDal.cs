using Dal_Repository.Modules;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Repository
{
    public class BuyDetailDal : IDal_Repository.IDalBuyDetail<Dto_Common_Enteties.BuysDetailDto>
    {
        ChineseAuction1Context db;
        public BuyDetailDal(ChineseAuction1Context db)
        {
            this.db = db;
        }
        public async Task<List<Dto_Common_Enteties.BuysDetailDto>> SelectAll()
        {
            var q = db.BuysDetails.Include(b => b.Product).ToList();
            return Dal_Repository.BuysDetailConverters.ToListBuyDetailDto(q);
        }
        public async Task<int> Add(Dto_Common_Enteties.BuysDetailDto c)
        {
            db.BuysDetails.Add(BuysDetailConverters.ToBuyDetail(c));
            int x = db.SaveChanges();
            return x;
        }
        public async Task<List<Dto_Common_Enteties.BuysDetailDto>> SelectByBuyId(int BuyId)
        {
              var q = db.BuysDetails.Include(u => u.Product)
             .Where(b => b.BuyId == BuyId)
             .ToList();
              return Dal_Repository.BuysDetailConverters.ToListBuyDetailDto(q);
        }

        public async Task<List<Dto_Common_Enteties.BuysDetailDto>> SelectByProductId(int ProductId)
        {
            var q = db.BuysDetails.Include(u => u.Product)
           .Where(b => b.ProductId == ProductId)
           .ToList();
            return Dal_Repository.BuysDetailConverters.ToListBuyDetailDto(q);
        }
    }
}
