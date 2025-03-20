using Dal_Repository.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal_Repository
{
    public class BuyConverters
    {
        public static Dto_Common_Enteties.BuyDto ToBuyDto(Dal_Repository.Modules.Buy c)
        {
            if (c == null) return null;

            var newP = new Dto_Common_Enteties.BuyDto
            {
                Id = c.Id,
                UserId = c.UserId,
                Price = c.Price,
                Date = c.Date,
                Note = c.Note,

            };
            if (c.UserId != null && c.User != null)
            {
                newP.UserName = c.User.NameU;
            }
            return newP;
        }

        public static List<Dto_Common_Enteties.BuyDto> ToListBuyDto(List<Modules.Buy> lc)
        {
            return lc?.Select(ToBuyDto).ToList() ?? new List<Dto_Common_Enteties.BuyDto>();
        }

        public static Modules.Buy ToBuy(Dto_Common_Enteties.BuyDto c)
        {
            Modules.Buy New = new Modules.Buy();
            New.Id = c.Id;
            New.Price = c.Price;
            New.Date = c.Date;
            New.Note = c.Note;
            New.UserId = c.UserId;

            return New;
        }
    }
}
