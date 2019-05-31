using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car { Model = "Model", Brand = "Brand", Number = "Number", Cost = 100, MaxDistance = 1000 };
            car = new DiscountDecorator(car, 10, 100);
            car = new RentDecorator(car) { Name = "Name", Surname = "Surname", NumberOfPassport = "NumberOfPassport" };
            Console.WriteLine(car.ToString());
        }
    }
    class Car
    {
        public string Model { set; get; }
        public string Brand { set; get; }
        public string Number { set; get; }
        public int Cost { set; get; }
        public int MaxDistance { set; get; }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Марка - {Model}");
            builder.AppendLine($"Модель - {Brand}");
            builder.AppendLine($"Номер - {Number}");
            builder.AppendLine($"Стоимость аренды в сутки - {Cost}");
            builder.AppendLine($"Максимально допустимое расстояние - {MaxDistance}");
            return builder.ToString();
        }
    }
    abstract class Decorator : Car
    {
        protected Car car;
        public Decorator(Car car)
        {
            this.car = car;
        }
    }
    class DiscountDecorator : Decorator
    {
        public DiscountDecorator(Car car, int discount, int additionalDistance) : base(car)
        {
            car.Cost -= discount;
            car.MaxDistance += additionalDistance;
        }
        public override string ToString()
        {
            return car.ToString();
        }
    }
    class RentDecorator : Decorator
    {
        public RentDecorator(Car car) : base(car) { }
        public string Name { set; get; }
        public string Surname { set; get; }
        public string NumberOfPassport { set; get; }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(car.ToString());
            builder.AppendLine($"Имя - {Name}");
            builder.AppendLine($"Фамилия - {Surname}");
            builder.AppendLine($"Номер паспорта - {NumberOfPassport}");
            return builder.ToString();
        }
    }
}