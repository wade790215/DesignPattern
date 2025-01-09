using System;

namespace DesignPattern
{
    public class DesignPatternBookPratice
    {
        public void Main()
        {
            IQuckable oldDuck = new OldDuck();
            oldDuck.Quack();
            
            IQuckable youngDuck = new YoungDuck();
            youngDuck.Quack();
        }
        
        public interface IQuckable
        {
            void Quack();
        }
        
        public class OldDuck : IQuckable
        {
            public void Quack()
            {
                Console.WriteLine("Quack");
            }
        }
        
        public class YoungDuck : IQuckable
        {
            public void Quack()
            {
                Console.WriteLine("Quack Quack");
            }
        }
    }
}