using BigBasket.IService;
using BigBasket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBasket.Controllers
{   [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly bigbasket2406smitContext DbContext;
        private readonly IProductService productService;
        public ProductController(bigbasket2406smitContext dbContext, IProductService ProductService)
        {
            DbContext = dbContext;
            productService = ProductService;
        }



        [AllowAnonymous]
        [HttpGet]
        public ActionResult<productDisplayDTO> GetProductForDisplay()
        {
            return Ok(productService.getProductsforDisplay());
        }

        [AllowAnonymous]
        [HttpGet("SearchProduct/{name}")]

        public ActionResult<Product> SearchedProduct(string name)
        {
            return Ok(productService.searchProduct(name));
        }


        [HttpPost]

        public ActionResult<Product> AddProduct([FromBody] Product product)
        {
            return Ok(product);
        }
    }
}
