using BigBasket.IRepository;
using BigBasket.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BigBasket.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        public Repository(bigbasket2406smitContext _db)
        {
            DbContext = _db;
        }

        public bigbasket2406smitContext DbContext { get; }

        public T Add(T entity)
        {

            DbContext.Add(entity);

            DbContext.SaveChanges();
            return entity;
        }   

        public IActionResult Delete(int id,T entity)
        {
            var categoryExist = DbContext.Set<T>().Find(id);


            DbContext.Entry<T>(categoryExist).State = EntityState.Detached;

            if (categoryExist == null)
            {
                return new BadRequestObjectResult(new { message = "Category Not Found !!! " });
            }
            else
            {

                DbContext.Remove(entity);
                DbContext.SaveChanges();

                return new OkObjectResult(new { message = "Data Deleted !!" });
            }
        }

        public List<T> Get()
        {
            return DbContext.Set<T>().ToList();
        }
   
        public List<T> GetBycondition(Expression<Func<T, bool>> expression)
        {
            return DbContext.Set<T>().Where(expression).ToList<T>();
        }

        public T GetById(Expression<Func<T, bool>> expression)
        {
            return DbContext.Set<T>().Where(expression).SingleOrDefault();
        }

        public IActionResult Update(int id,T entity)
        {


           var categoryExist =  DbContext.Set<T>().Find(id);


            DbContext.Entry<T>(categoryExist).State = EntityState.Detached;

            if (categoryExist == null)
            {
                return new BadRequestObjectResult(new { message = "Category Not Found !!! " });
            }
            else
            {

                DbContext.Update(entity);
                DbContext.SaveChanges();

                return new OkObjectResult(new { message = "Data Updated !!" });
            }

        }
    }
}
