﻿using System;

namespace DesignPattern
{
    //當創造的對象有分成很多部分組成，且每個部分都有不同的實現時，可以使用建造者模式
    //透過指揮者來組裝對象，可以透過不同的指揮者來組裝不同的對象
    internal class BuilderPattern
    {
        internal void Main()
        {
            RacketDirector racketDirector = new RacketDirector();
            BadmintonRacketBuilder yonexRacketBuilder = new YonexRacketBuilder();
            BadmintonRacketBuilder victorRacketBuilder = new VictorRacketBuilder();

            BadmintonRacket yonexRacket = racketDirector.CreateRacket(yonexRacketBuilder);
            BadmintonRacket victorRacket = racketDirector.CreateRacket(victorRacketBuilder);

            Console.WriteLine($"Brand:{yonexRacket.Brand},Tension:{yonexRacket.Tension}," +
                $"String:{yonexRacket.RacketString}");
            Console.WriteLine($"Brand:{victorRacket.Brand},Tension:{victorRacket.Tension}," +
                $"String:{victorRacket.RacketString}");
        }
    }

    public class RacketDirector
    {
        public BadmintonRacket CreateRacket(BadmintonRacketBuilder builder)
        {
            builder.CreateRacket();
            builder.BuildBrand();
            builder.BuildString();
            builder.BuildRacketTension();
            return builder.GetBadmintonRacket();
        }
    }

    public class BadmintonRacket
    {
        public string Brand { get; set; }
        public string RacketString { get; set; }
        public string Tension { get; set; }
    }

    public abstract class BadmintonRacketBuilder
    {
        protected BadmintonRacket badmintonRacket;
        public void CreateRacket()
        {
            badmintonRacket = new BadmintonRacket();
        }

        public BadmintonRacket GetBadmintonRacket()
        {
            return badmintonRacket;
        }

        public abstract void BuildBrand();
        public abstract void BuildString();
        public abstract void BuildRacketTension();
    }

    public class YonexRacketBuilder : BadmintonRacketBuilder
    {
        public override void BuildBrand()
        {
            badmintonRacket.Brand = "Yonex";
        }

        public override void BuildRacketTension()
        {
            badmintonRacket.Tension = "30lbs";
        }

        public override void BuildString()
        {
            badmintonRacket.RacketString = "BG80";
        }
    }

    public class VictorRacketBuilder : BadmintonRacketBuilder
    {
        public override void BuildBrand()
        {
            badmintonRacket.Brand = "Victor";
        }

        public override void BuildRacketTension()
        {
            badmintonRacket.Tension = "28lbs";
        }

        public override void BuildString()
        {
            badmintonRacket.RacketString = "VBS-65";
        }
    }
}