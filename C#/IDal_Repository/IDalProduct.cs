using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDal_Repository
{
    public interface IDalProduct<T>
    {
        public Task<List<Dto_Common_Enteties.ProductDto>> SelectAll();
        public Task<List<Dto_Common_Enteties.ProductDto>> SelectAllRafuld();
        public Task<Dto_Common_Enteties.ProductDto> SelectById(int ProductId);
        public Task<int> Update(int ProductId, Dto_Common_Enteties.ProductDto ProductDto);

    }
}
