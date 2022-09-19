using BigBasket.IService;
using BigBasket.Models;
using BigBasket.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBasket.Service
{


    public class ProductService : Repository<Product>,IProductService
    {
        public ProductService(bigbasket2406smitContext DbContext) : base(DbContext)
        {

        }

        public List<Product> Get()
        {
            return base.Get();
        }
        public List<productDisplayDTO> getProductsforDisplay()
        {
            var products = new List<productDisplayDTO>();

        //            public string ProductImgUrl { get; set; }

        //public string ProductColour { get; set; }
        //public string CountryOfOrigin { get; set; }


        var productsForDisplay = from product in DbContext.Products
                                    join productdet in DbContext.ProductDetails 
                                    on product.ProductId equals productdet.ProductId
                                 join brands in DbContext.Brands 
                                     on product.BrandId equals brands.BrandId
                                     join Categories in DbContext.Categories
                                     on product.CategoryId equals Categories.CategoryId
                               
                                     select new productDisplayDTO { productName = product.ProductName, brand = brands.BrandName , category = Categories.CategoryName, price = product.Price,ProductImgUrl = productdet.ProductImgUrl, ProductColour = productdet.ProductColour };

            foreach (var item in productsForDisplay)
            {
                products.Add(item);
            }

            return products;
        }

        public List<productDisplayDTO> searchProduct(string searchParameter)
        {
            var products = getProductsforDisplay();

            var searchedProducts = (from prod in products
                                    where prod.productName.Contains(searchParameter)
                                     select prod).ToList<productDisplayDTO>();

 

            return searchedProducts;
        }

       

        //public async Task<IActionResult> PutProduct(int id, Product product)
        //{
        //    if (id != product.ProductId)
        //        return new BadRequestResult();
        //    var result = await GetById(id);
        //    if (result == null)
        //        return new NotFoundObjectResult(new { message = "no data found" });
        //    return await base.Put(result, product);
        //}

    }   
}
