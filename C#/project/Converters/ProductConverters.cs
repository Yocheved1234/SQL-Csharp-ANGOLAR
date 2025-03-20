using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dal_Repository
{
    public class ProductConverters
    {
        public static Dto_Common_Enteties.ProductDto ToProductDto(Dal_Repository.Modules.Product c)
        {
            if (c == null) return null;

            var newP = new Dto_Common_Enteties.ProductDto
            {
                Id = c.Id,
                ImageP = c.ImageP,
                DescriptionP = c.DescriptionP,
                Date = c.Date,
                Price = c.Price,
                Winner = c.Winner,
                Info = c.Info,
                CategoryName = c.CategoryId != null && c.Category != null ? c.Category.NameCategory : null
            };

            return newP;
        }


        public static List<Dto_Common_Enteties.ProductDto> ToListProductDto(List<Modules.Product> lc)
        {
            return lc?.Select(ToProductDto).ToList() ?? new List<Dto_Common_Enteties.ProductDto>();
        }
        public static Modules.Product ToProduct(Dto_Common_Enteties.ProductDto c)
        {
            if (c == null) return null;

            Modules.Product New = new Modules.Product();
            New.Id = c.Id;
            New.ImageP = c.ImageP;
            New.DescriptionP = c.DescriptionP;
            New.Date = c.Date;
            New.Price = c.Price;
            New.Winner = c.Winner;
            New.Info = c.Info;
            return New;
        }
    }
}
