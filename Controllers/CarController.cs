using Models;
using Services;

namespace Controllers
{
    public class CarController
    {
        private CarService _service;

        public CarController()
        {
            _service = new CarService();
        }

        public bool Insert(Car car)
        {
            return _service.Insert(car);
        }

        public bool Update(Car car)
        {
            return _service.Update(car);
        }

        public bool Delete(int id)
        {
            return _service.Delete(id);
        }

        public List<Car> GetAll()
        {
            return _service.GetAll();
        }

        public Car Get(int id)
        {
            return _service.Get(id);
        }
    }
}
