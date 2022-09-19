using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BigBasket.IRepository
{
   public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> Get();

        TEntity GetById(Expression<Func<TEntity, bool>> expression);
        IActionResult Update(int id, TEntity entity);
        IActionResult Delete(int id, TEntity entity);

 
        TEntity Add(TEntity entity);
    }
}
