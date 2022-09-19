using BigBasket.IRepository;
using BigBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBasket.IService
{
    public interface IProductService : IRepository<Product>
    {
        List<Product> Get();

        List<productDisplayDTO> getProductsforDisplay();

        public List<productDisplayDTO> searchProduct(string searchParameter);

    }
}
