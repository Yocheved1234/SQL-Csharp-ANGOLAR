using Dal_Repository.Modules;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Repository
{
    public class BuyDal : IDal_Repository.IDalBuy<Dto_Common_Enteties.BuyDto>
    {
        ChineseAuction1Context db;
        public BuyDal(ChineseAuction1Context db)
        {
            this.db = db;
        }
        public async Task<List<Dto_Common_Enteties.BuyDto>> SelectAll()
        {
            var q = db.Buys.Include(u => u.User).ToList();
            return BuyConverters.ToListBuyDto(q);
        }

        public async Task<List<Dto_Common_Enteties.BuyDto>> SelectByUserId(int UserId)
        {
            var q = db.Buys.Include(u => u.User)
           .Where(b => b.UserId == UserId).ToList();
            return BuyConverters.ToListBuyDto(q);
        }
        public async Task<Dto_Common_Enteties.BuyDto> AddBuy(Dto_Common_Enteties.BuyDto buyDto)
        {
            var buy = new Buy
            {
                UserId = buyDto.UserId,
                Date = buyDto.Date,
                Price = buyDto.Price,
                Note = buyDto.Note
            };

            db.Buys.Add(buy);
            await db.SaveChangesAsync();

            return BuyConverters.ToBuyDto(buy);
        }

        public async Task<Dto_Common_Enteties.BuyDto> SelectById(int Id)
        {
            var user = await db.Buys.FindAsync(Id);
            return BuyConverters.ToBuyDto(user);
        }
    }
}
