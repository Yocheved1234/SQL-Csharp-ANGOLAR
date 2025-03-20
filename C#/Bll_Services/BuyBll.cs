using Dal_Repository;
using Dal_Repository.Modules;
using IDal_Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bll_Services
{
    public class BuyBll : IBll_Services.IBllBuy
    {
        ChineseAuction1Context db;
        IDal_Repository.IDalProduct<Dto_Common_Enteties.ProductDto> p;
        IDal_Repository.IDalBuy<Dto_Common_Enteties.BuyDto> c;
        IDal_Repository.IDalBuyDetail<Dto_Common_Enteties.BuysDetailDto> buyD;


        public BuyBll(IDal_Repository.IDalBuy<Dto_Common_Enteties.BuyDto> c,
            IDal_Repository.IDalProduct<Dto_Common_Enteties.ProductDto> p,
            IDal_Repository.IDalBuyDetail<Dto_Common_Enteties.BuysDetailDto> buyD,
            ChineseAuction1Context db)
        {
            this.c = c;
            this.p = p;
            this.db = db;
            this.buyD = buyD;
        }
        public async Task<List<Dto_Common_Enteties.BuyDto>> SelectAll()
        {
            return await c.SelectAll();
        }
        public async Task<Dto_Common_Enteties.BuyDto> AddBuy(Dto_Common_Enteties.BuyDto buy)
        {
            return await c.AddBuy(buy);
        }
        public async Task<List<Dto_Common_Enteties.BuyDto>> SelectByUserId(int UserId)
        {
            return await c.SelectByUserId(UserId);
        }
        public async Task<Dto_Common_Enteties.BuyDto> SelectById(int Id)
        {
            return await c.SelectById(Id);
        }

        // הוספת קניה
        public async Task<int> HandelBuy(int Id, Dictionary<int, int> products, int sum)
        {
            DateTime date = DateTime.UtcNow;
            var buyEntity = BuyConverters.ToBuy(new Dto_Common_Enteties.BuyDto
            {
                UserId = Id,
                Date = date,
                Price = sum,
                Note = "all done!"
            });

            var t = db.Buys.Add(buyEntity);
            var x = db.SaveChanges();

            foreach (var item in products)
            {
                var i = BuysDetailConverters.ToBuyDetail(new Dto_Common_Enteties.BuysDetailDto
                {
                    BuyId = buyEntity.Id,
                    ProductId = item.Key,
                    Amount = item.Value
                });

                var p1 = db.BuysDetails.Add(i);
                var p2 = db.SaveChanges();
            }


            return buyEntity.Id;


        }

        // הנחה
        public async Task<int> Discount(int sum, int umount)
        {
            if (umount >= 20)
            {
                double result = Convert.ToDouble(sum) * 0.9;
                return (int)result;
            }
            double y = (double)(100 - umount) / 100;
            return (int)(sum * y);

        }
    }
}
