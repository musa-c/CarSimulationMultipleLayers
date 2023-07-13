using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2020, DailyPrice = 100, Description = "Tesla S" },
                new Car {Id = 2, BrandId = 1, ColorId = 2, ModelYear = 2021, DailyPrice = 120, Description = "Tesla E" },
                new Car {Id = 3, BrandId = 1, ColorId = 2, ModelYear = 2022, DailyPrice = 110, Description = "Tesla X" },
                new Car {Id = 4, BrandId = 1, ColorId = 3, ModelYear = 2023, DailyPrice = 170, Description = "Tesla Y" },
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car? carToDelete = _cars.FirstOrDefault(c => c.Id == car.Id);
            if (carToDelete != null)
            {
                _ = _cars.Remove(carToDelete);
            }
            else
            {
                _ = new Exception("Car not found");
            }
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            Car? car = _cars.FirstOrDefault(c => c.Id == id);
            if (car != null)
            {
                return car;
            }
            throw new Exception("Car not found");
        }

        public void Update(Car car)
        {
            Car? UpdateCar = _cars.FirstOrDefault(c => c.Id == car.Id);
            if (UpdateCar != null)
            {
                UpdateCar.BrandId = car.BrandId;
                UpdateCar.ColorId = car.ColorId;
                UpdateCar.ModelYear = car.ModelYear;
                UpdateCar.DailyPrice = car.DailyPrice;
                UpdateCar.Description = car.Description;
            }
            else
            {
                _ = new Exception("Car not found");
            }
        }
    }
}
