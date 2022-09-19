using BigBasket.IRepository;
using BigBasket.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigBasket.IService
{
    public interface ICategoryService : IRepository<Category>
    {
        List<adminCategoryDisplayDTO> searchCategory(string searchParameter);

        public List<Category> GetBycondition(int id);
        public IActionResult Update(int id,Category category);

        public IActionResult Delete(int id, Category category);


    }
}
