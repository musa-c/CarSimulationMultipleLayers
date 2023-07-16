using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntitiyFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new(new EfCarDal());

            //GetCarDetails(carManager);
            //Add(carManager);
            //Update(carManager);
            //Delete(carManager);

            GetById(carManager);

            //GelAll(carManager);
            //GetCarsByBrandId(carManager);
            //GetCarDetails(carManager);
            //GetCarsByColorId(carManager);

        }

        private static void GetById(CarManager carManager)
        {
            Car car = carManager.GetById(3);
            Console.WriteLine(car.Id);
            Console.WriteLine(car.Name);
            Console.WriteLine(car.Description);
            Console.WriteLine(car.ModelYear);
            Console.WriteLine(car.DailyPrice);
        }

        private static void GetCarDetails(CarManager carManager)
        {
            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(item.CarId);
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Description);
                Console.WriteLine(item.BrandName);
                Console.WriteLine(item.ColorName);
                Console.WriteLine(item.DailyPrice);
                Console.WriteLine("---------------------------------");
            }
        }

        private static void GetCarsByColorId(CarManager carManager)
        {
            foreach (Car item in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Description);
                Console.WriteLine(item.BrandId);
                Console.WriteLine(item.ColorId);
                Console.WriteLine(item.DailyPrice);
                Console.WriteLine("---------------------------------");
            }
        }

        private static void GetCarsByBrandId(CarManager carManager)
        {
            foreach(Car item in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Description);
                Console.WriteLine(item.BrandId);
                Console.WriteLine(item.ColorId);
                Console.WriteLine(item.DailyPrice);
                Console.WriteLine("---------------------------------");
            }
        }

        private static void GelAll(CarManager carManager)
        {
            foreach (Car item in carManager.GetAll())
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Description);
                Console.WriteLine(item.BrandId);
                Console.WriteLine(item.ColorId);
                Console.WriteLine(item.DailyPrice);
                Console.WriteLine("---------------------------------");
            }
        }

        private static void Delete(CarManager carManager)
        {
            carManager.Delete(new Car { Id = 1});
        }

        private static void Update(CarManager carManager)
        {
            carManager.Update(new Car { Id = 4, Name = "Mercedes", BrandId = 1, ColorId = 1, ModelYear=2023, DailyPrice=48488, Description="şık bir mercedes"});
        }

        private static void Add(CarManager carManager)
        {
            carManager.Add(new Car { Id = 4, ColorId = 1, BrandId = 1, DailyPrice = 5000, Description = "asdasd", ModelYear = 2020 });
        }
    }
}