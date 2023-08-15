using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<Car> GetById(int id)
        {
            if(DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<Car>(Messages.MainenanceTime);
            }
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.Id==id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int BrandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetCarsByBrandId(BrandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int ColorId)
        {
            if (DateTime.Now.Hour == 3)
            {
                return new ErrorDataResult<List<Car>>(Messages.MainenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetCarsByColorId(ColorId));
        }

        public IResult Update(Car car)
        {
           _carDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
    }
}
