using BigBasket.IService;
using BigBasket.Models;
using BigBasket.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBasket.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {


        private ICategoryService CategoryService { get; }
        private bigbasket2406smitContext DBContext { get; }

        public CategoryController(ICategoryService categoryService, bigbasket2406smitContext dBContext)
        {
            CategoryService = categoryService;
            DBContext = dBContext;

        }

        [AllowAnonymous]
        [HttpGet]

        public ActionResult<List<Category>> GetCategory()
        {
            return Ok(CategoryService.Get());
        }
        [AllowAnonymous]
        [HttpGet("subcategory/{id}")]
        public ActionResult<List<Category>> GetSubcategory(int id = 0)
        {
            return Ok(CategoryService.GetBycondition(id));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]

        public ActionResult<Category> GetCategoryById(int id)
        {
            return Ok(CategoryService.GetById(x => x.CategoryId == id));
        }

        [HttpPost("AddCategory")]

        public ActionResult<Category> AddCategory([FromBody] Category category)
        {
            var catExists = DBContext.Categories.Any(x => x.CategoryName == category.CategoryName);

            if(catExists) { return BadRequest("Category Already Exists !!"); }

            else
            {
               return Ok(CategoryService.Add(category));
            }

        }

        [AllowAnonymous]
        [HttpPut("{id}")]

        public IActionResult UpdateCategory(int id , [FromBody] Category category)
        {
            return (CategoryService.Update(id,category)); 
        }


        [AllowAnonymous]
        [HttpGet("searchCategory/{name}")]


        public ActionResult<adminCategoryDisplayDTO> SearchedCategory(string name)
        {
           
                var catArray = CategoryService.searchCategory(name);

                if (catArray.Count > 0) { return Ok(catArray); }
                else if(name.Length <=0) { return BadRequest(new { message = "No Result Found For  Blank Input" }); }
                else { return BadRequest(new { message = "Result Not Found !" }); }
            
         
        }


        //[AllowAnonymous]
        //[HttpGet("searchCategory/{name}")]


        //public ActionResult<adminCategoryDisplayDTO> SearchedCategory(string name)
        //{

        //    var catArray = CategoryService.searchCategory(name);

        //    if (catArray.Count > 0) { return Ok(catArray); }
        //    else if (name.Length <= 0) { return BadRequest(new { message = "No Result Found For  Blank Input" }); }
        //    else { return BadRequest(new { message = "Result Not Found !" }); }


        //}


    }
}
