using Models;
using Repositories;

namespace Services
{
    public class CarService
    {
        private CarRepository _repository;

        public CarService()
        {
            _repository = new();    
        }

        public bool Insert(Car car)
        {
            return _repository.Insert(car);
        }

        public bool Update(Car car)
        {
            return _repository.Update(car);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public List<Car> GetAll()
        {
            return _repository.GetAll();
        }

        public Car Get(int id)
        {
            return _repository.Get(id);
        }
    }
}
