using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=11,ColorId=98,DailyPrice=4500,ModelYear=2009,Description="Temiz Bmw"},
                new Car{Id=2,BrandId=22,ColorId=96,DailyPrice=1450,ModelYear=2011,Description="Az Kullanılmış Ford"},
                new Car{Id=3,BrandId=33,ColorId=94,DailyPrice=2200,ModelYear=2010,Description="Hatcback Clio"},
                new Car{Id=4,BrandId=44,ColorId=92,DailyPrice=3000,ModelYear=2012,Description="Memurdan Mercedes"},
                new Car{Id=5,BrandId=55,ColorId=90,DailyPrice=950,ModelYear=2001,Description="Piyasada Tek Tofaş"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(car);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.Id == Id).ToList();
        }

        public void Update(Car car)
        {
            //Göderdiğim ürün Id'sine sahip olan listedeki ürünü bul.
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
