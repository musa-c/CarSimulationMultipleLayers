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
            //UserManager userManager = new(new EfUserDal());
            //UserAdd(userManager);

            //CustomerManager customerManager = new(new EfCustomerDal());
            //CustomerAdd(customerManager);

            RentalManager rentalManager = new(new EfRentalDal());
            //RentalAdd(rentalManager);
            //RentalUpdate(rentalManager);
            RentalGetAll(rentalManager);

            //GetCarDetails(carManager);
            //Add(carManager);
            //Update(carManager);
            //Delete(carManager);

            //GetById(carManager);

            //GelAll(carManager);
            //GetCarsByColorId(carManager);
            //GetCarDetails(carManager);
            //GetCarsByColorId(carManager);

        }

        private static void RentalUpdate(RentalManager rentalManager)
        {
            var result = rentalManager.Update(new Rental { Id = 2, CarId = 3, CustomerId = 2, RentDate = new DateTime(2021, 02, 15), ReturnDate = new DateTime(2023, 05, 25) });
            Console.WriteLine(result.Message);
        }

        private static void RentalGetAll(RentalManager rentalManager)
        {
            var result = rentalManager.GetAll();
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.CarId);
                Console.WriteLine(item.CustomerId);
                Console.WriteLine(item.RentDate);
                Console.WriteLine(item.ReturnDate);
            }
        }

        private static void RentalAdd(RentalManager rentalManager)
        {
            var result = rentalManager.Add(new Rental { Id = 3, CarId = 3, CustomerId = 2, RentDate = new DateTime(2023, 07, 23) });
            Console.WriteLine(result.Message);
        }

        private static void CustomerAdd(CustomerManager customerManager)
        {
            var result = customerManager.Add(new Customer {Id = 2, UserId = 2, CompanyName = "HHolding" });
            Console.WriteLine(result.Message);
        }

        private static void UserAdd(UserManager userManager)
        {
            var result = userManager.Add(new User { Id = 2, Email = "sdsdsa@gmail.com", FirstName = "hasan", LastName = "aslan", Password = "1112" });
            Console.WriteLine(result.Message);
        }

        private static void GetById(CarManager carManager)
        {
            Car car = carManager.GetById(3).Data;
            Console.WriteLine(car.Id);
            Console.WriteLine(car.Name);
            Console.WriteLine(car.Description);
            Console.WriteLine(car.ModelYear);
            Console.WriteLine(car.DailyPrice);
        }

        private static void GetCarDetails(CarManager carManager)
        {
            foreach (var item in carManager.GetCarDetails().Data)
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
            var result = carManager.GetCarsByColorId(1);
            if (result.Success == true)
            {
                foreach (var item in carManager.GetCarsByColorId(1).Data)
                {
                    Console.WriteLine(item.Id);
                    Console.WriteLine(item.Description);
                    Console.WriteLine(item.BrandId);
                    Console.WriteLine(item.ColorId);
                    Console.WriteLine(item.DailyPrice);
                    Console.WriteLine("---------------------------------");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
         
        }

        private static void GetCarsByBrandId(CarManager carManager)
        {
            foreach(Car item in carManager.GetCarsByBrandId(1).Data)
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
            foreach (Car item in carManager.GetAll().Data)
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
            var result = carManager.Add(new Car { Id = 4, ColorId = 1, BrandId = 1, DailyPrice = 5000, Description = "asdasd", ModelYear = 2020 });
            Console.WriteLine(result.Message);
        }
    }
}