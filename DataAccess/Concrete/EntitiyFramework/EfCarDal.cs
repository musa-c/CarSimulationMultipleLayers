using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        //Cars'a özel metotlar

        public override void Add(Car entity)
        {
            // bu if else olayı businees katmanında da olabilir.!!!
            if(entity.Description.Length >= 2 && entity.DailyPrice > 0)
            {
                base.Add(entity);
            }
            else
            {
                Console.WriteLine("Araba ismi minimum 2 karakter olmalı ve günlük fiyatı 0'dan büyük olmalıdır.");
            };
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context = new())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cl in context.Colors
                             on c.ColorId equals cl.Id
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 Name = c.Name,
                                 BrandName = b.Name,
                                 ColorName = cl.Name,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }

        public List<Car> GetCarsByBrandId(int BrandId)
        {
            using (ReCapContext context = new())
            {
                return context.Set<Car>().Where(c => c.BrandId == BrandId).ToList();
            }
        }

        public List<Car> GetCarsByColorId(int ColorId)
        {
            using (ReCapContext context = new())
            {
                return context.Set<Car>().Where(c => c.ColorId == ColorId).ToList();
            }
        }
    }
}
