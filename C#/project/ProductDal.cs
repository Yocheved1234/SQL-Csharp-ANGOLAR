using Dal_Repository.Modules;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dal_Repository
{
    public class ProductDal : IDal_Repository.IDalProduct<Dto_Common_Enteties.ProductDto>
    {
        ChineseAuction1Context db;
        public ProductDal(ChineseAuction1Context db)
        {
            this.db = db;
        }
        public async Task<List<Dto_Common_Enteties.ProductDto>> SelectAll()
        {
            var currentDate = DateTime.Now;
            var q = await db.Products
                .Include(c => c.Category)
                .Where(p => p.Date > currentDate)
                .ToListAsync();

            return Dal_Repository.ProductConverters.ToListProductDto(q);
        }
        public async Task<List<Dto_Common_Enteties.ProductDto>> SelectAllRafuld()
        {
            var currentDate = DateTime.Now.Date; 
            var q = await db.Products
                .Include(c => c.Category)
                .Where(p => p.Date <= currentDate)
                .ToListAsync();

            return Dal_Repository.ProductConverters.ToListProductDto(q);
        }

        public async Task<Dto_Common_Enteties.ProductDto> SelectById(int ProductId)
        {
            var Product = await db.Products.FindAsync(ProductId);
            return ProductConverters.ToProductDto(Product);
        }
        public async Task<int> Update(int ProductId, Dto_Common_Enteties.ProductDto ProductDto)
        {
            var product = db.Products.Find(ProductId);
            if (product == null)
            {
                return 0;
            }

            product.Winner = ProductDto.Winner;

            return db.SaveChanges();
        }

    }
}
