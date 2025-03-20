using Dto_Common_Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal_Repository;
using Dal_Repository;
using Dto_Common_Enteties;
using Dal_Repository.Modules;
namespace Bll_Services
{
    public class ProductBll : IBll_Services.IBllProduct
    {
        IDal_Repository.IDalProduct<Dto_Common_Enteties.ProductDto> c;
        ChineseAuction1Context db;
        IDal_Repository.IDalProduct<Dto_Common_Enteties.ProductDto> p;
        IDal_Repository.IDalBuyDetail<Dto_Common_Enteties.BuysDetailDto> d;
        IDal_Repository.IDalBuy<Dto_Common_Enteties.BuyDto> buy;
        public ProductBll(IDal_Repository.IDalProduct<Dto_Common_Enteties.ProductDto> c,
            IDal_Repository.IDalProduct<Dto_Common_Enteties.ProductDto> p,
            IDal_Repository.IDalBuyDetail<Dto_Common_Enteties.BuysDetailDto> d,
            IDal_Repository.IDalBuy<Dto_Common_Enteties.BuyDto> buy,
            ChineseAuction1Context db)
        {
            this.c = c;
            this.d = d;
            this.p = p;
            this.buy = buy;
            this.db = db;
        }
        public async Task<List<Dto_Common_Enteties.ProductDto>> SelectAll()
        {
            return await c.SelectAll();
        }
        public async Task<List<Dto_Common_Enteties.ProductDto>> SelectAllRafuld()
        {
            var filteredProducts = await Do_Raffle();
            Console.WriteLine(filteredProducts);

            var products = await c.SelectAllRafuld();
            return products;
        }


        public async Task<Dto_Common_Enteties.ProductDto> SelectById(int ProductId)
        {
            return await c.SelectById(ProductId);
        }

        public async Task<int> Update(int ProductId, Dto_Common_Enteties.ProductDto ProductDto)
        {
            var result = c.Update(ProductId, ProductDto);

            if (result != null)
                return ProductId;
            return 0;
        }

        // ביצוע ההגרלה
        public async Task<List<Dto_Common_Enteties.BuyDto>> Do_Raffle()
        {
            List<Dto_Common_Enteties.BuyDto> up = new List<Dto_Common_Enteties.BuyDto>();
            var today = DateTime.Today;

            var products = await p.SelectAllRafuld();

            foreach (var product in products)
            {
                if (product.Winner == 0)
                {
                    List<Dto_Common_Enteties.BuysDetailDto> allWinners = new List<Dto_Common_Enteties.BuysDetailDto>();

                    var buyDetails = await d.SelectByProductId(product.Id);

                    foreach (var buyDetail in buyDetails)
                    {
                        for (int i = 0; i < buyDetail.Amount; i++)
                        {
                            allWinners.Add(buyDetail);
                        }
                    }
                    if (allWinners.Count > 0)
                    {
                        var random = new Random();
                        var winnerIndex = random.Next(allWinners.Count);
                        var winner = allWinners[winnerIndex];

                        var buyIdInt = winner.BuyId.Value;

                        var Buy = await buy.SelectById(buyIdInt);
                        int userId = Buy.UserId.Value;

                        product.Winner = userId;
                        up.Add(Buy);

                        await p.Update(product.Id, product);
                        db.SaveChanges();
                    }
                }
            }
            return up;
        }

        // סיונים
        public async Task<List<Dto_Common_Enteties.ProductDto>> FilterItems(decimal? minPrice = null, string? CategoryName = null)
        {
            var products = await c.SelectAll(); 

            var filteredProducts = products.AsQueryable();

            if (minPrice.HasValue) 
                filteredProducts = filteredProducts.Where(p => p.Price <= minPrice.Value);

            if (!string.IsNullOrEmpty(CategoryName)) 
                filteredProducts = filteredProducts.Where(p => p.CategoryName.Equals(CategoryName));

            return await Task.FromResult(filteredProducts.ToList());
        }

    }
}

