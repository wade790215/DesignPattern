using System;

namespace DesignPattern
{
    internal class CARPPattern
    {
        internal void Main()
        {
            Car car = new Car();
            car.Engine = new Engine() { Name = "本田"};
            car.Wheel = new Wheel() { Name = "馬牌"};
            Console.WriteLine($"這台車裝了{car.Engine.Name}引擎和{car.Wheel.Name}輪胎");

            Scooter scooter = new Scooter("SYM","米其林");
            Console.WriteLine($"這台車裝了{scooter.Engine.Name}引擎和{scooter.Wheel.Name}輪胎");
        }
    }

    //Aggregation 
    //聚合是一種弱擁有關係，車壞了引擎輪子沒壞
    public class Car
    {
        public Engine Engine { get; set; }
        public Wheel Wheel { get; set; }
    }

    public class Engine
    {
        public string Name { get; set; }
    }

    public class Wheel
    {
        public string Name { get; set; }
    }

    //Composition
    //合成是一種強擁有關係，車壞了整組壞
    public class Scooter
    {
        public Scooter(string engine , string wheel)
        {
            Engine = new Engine() { Name = engine};
            Wheel = new Wheel() { Name = wheel};
        }

        public Engine Engine { get; set; }
        public Wheel Wheel { get; set; }
    }
   
}