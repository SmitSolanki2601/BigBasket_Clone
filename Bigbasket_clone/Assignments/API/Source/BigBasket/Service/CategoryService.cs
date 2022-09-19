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
    public class CategoryService : Repository<Category>, ICategoryService
    {
        public CategoryService(bigbasket2406smitContext DbContext) : base(DbContext)
        {
        }

        public List<adminCategoryDisplayDTO> searchCategory(string searchParameter)
        {
            var searchedCategoriesQuery = DbContext.Categories.Where(x => x.CategoryName.Contains(searchParameter)).ToList<Category>();

            var searchedCategory = new List<adminCategoryDisplayDTO>();

            foreach (var item in searchedCategoriesQuery)
            {
                searchedCategory.Add(new adminCategoryDisplayDTO { CategoryId = item.CategoryId, CategoryName = item.CategoryName, ParentId = item.ParentId, CatAddedDate = item.CatAddedDate });
            }

            
            return searchedCategory;
        }

        public List<Category> GetBycondition(int id)
        {
            return base.GetBycondition(x => x.ParentId == id);
        }

        public IActionResult UpdateCategory(int id, Category category)
        {
          if(!(category.CategoryId == id))
            {
                return new BadRequestObjectResult(new { message = "Data Is Inappropriate !! Please Send Valid data to update"});
            }
          else
            {
                
               return  base.Update(id, category);
            }
        }
    }

}
