using System;

namespace DesignPattern
{
    public class DesignPatternBookPratice
    {
        public void Main()
        {
            Simulator simulator = new Simulator();
            simulator.Simulate();
        }

        public class Simulator
        {
            public void Simulate()
            {
                IQuckable oldDuck = new QuackCounter(new OldDuck());
                IQuckable youngDuck = new QuackCounter(new YoungDuck());
                GooseAdapter gooseAdapter = new GooseAdapter(new Goose());

                Simulate(oldDuck);
                Simulate(youngDuck);
                gooseAdapter.Quack();
                
                var quackCounter = new QuackCounter(gooseAdapter);
                Console.WriteLine($"QuackCounter:{quackCounter.GetQuacks()}");
            }

            public void Simulate(IQuckable duck)
            {
                duck.Quack();
            }
        }

        public class QuackCounter : IQuckable
        {
            private IQuckable duck;
            //靜態函數可以記錄所有QuackCounter的數量
            private static int _numberOfQuacks;
            
            public QuackCounter(IQuckable duck)
            {
                this.duck = duck;
            }

            public void Quack()
            {
                duck.Quack();
                _numberOfQuacks++;
            }
            
            public int GetQuacks()
            {
                return _numberOfQuacks;
            }
        }

        public class Goose
        {
            public void Honk()
            {
                Console.WriteLine("Honk");
            }
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

        public interface IQuckable
        {
            void Quack();
        }

        public class GooseAdapter : IQuckable
        {
            private Goose goose;

            public GooseAdapter(Goose goose)
            {
                this.goose = goose;
            }

            public void Quack()
            {
                goose.Honk();
            }
        }
    }
}