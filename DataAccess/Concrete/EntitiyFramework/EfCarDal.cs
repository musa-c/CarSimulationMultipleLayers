using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            if(entity.Description.Length >= 2 && entity.DailyPrice > 0)
            {
                using (ReCapContext context = new())
                {
                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                }
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapContext context = new())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapContext context = new())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>>? filter = null)
        {
            using (ReCapContext context = new())
            {
                return filter == null 
                    ? context.Set<Car>().ToList() 
                    : context.Set<Car>().Where(filter).ToList()
;            }
        }

        public Car GetCarsByBrandId(int BrandId)
        {
            using (ReCapContext context = new())
            {
                return context.Set<Car>().SingleOrDefault(c => c.BrandId == BrandId);
            }
        }

        public Car GetCarsByColorId(int ColorId)
        {
            using (ReCapContext context = new())
            {
                return context.Set<Car>().SingleOrDefault(c => c.ColorId == ColorId);
            }
        }

        public void Update(Car entity)
        {
            using (ReCapContext context = new())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
