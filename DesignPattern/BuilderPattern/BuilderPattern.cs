using System;
using System.Runtime.ConstrainedExecution;

namespace DesignPattern
{
    //當創造的對象有分成很多部分組成，且每個部分都有不同的實現時，可以使用建造者模式
    //透過指揮者來組裝對象，可以透過不同的指揮者來組裝不同的對象
    internal class BuilderPattern
    {
        internal void Main()
        {
            //RacketDirector racketDirector = new RacketDirector();
            //BadmintonRacketBuilder yonexRacketBuilder = new YonexRacketBuilder();
            //BadmintonRacketBuilder victorRacketBuilder = new VictorRacketBuilder();

            //BadmintonRacket yonexRacket = racketDirector.CreateRacket(yonexRacketBuilder);
            //BadmintonRacket victorRacket = racketDirector.CreateRacket(victorRacketBuilder);

            //Console.WriteLine($"Brand:{yonexRacket.Brand},Tension:{yonexRacket.Tension}," +
            //    $"String:{yonexRacket.RacketString}");
            //Console.WriteLine($"Brand:{victorRacket.Brand},Tension:{victorRacket.Tension}," +
            //    $"String:{victorRacket.RacketString}");

            ComputerDirector computerDirector = new ComputerDirector();
            ComputerBuilder gamingComputerBuilder = new GamingComputerBuilder();
            ComputerBuilder officeComputerBuilder = new OfficeComputerBuilder();

            computerDirector.CreateComputer(gamingComputerBuilder);
            Console.WriteLine("=======================================");
            computerDirector.CreateComputer(officeComputerBuilder);

            Console.ReadLine();    
        }
    }

    #region Pratice1
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
    #endregion

    #region Pratice2

    public class ComputerDirector
    {
        public void CreateComputer(ComputerBuilder builder)
        {
            builder.CreateComputer();
            Console.WriteLine($"BuildComputerType:{builder.GetType().Name}");
            builder.BuildCPU();
            builder.BuildMemory();
            builder.BuildMainboard();
        }
    }

    public abstract class ComputerBuilder
    {
        protected Computer computer;

        public Computer CreateComputer()
        {
            computer = new Computer();
            return computer;
        }   

        public abstract void BuildCPU();
        public abstract void BuildMemory();
        public abstract void BuildMainboard();
    }

    public class GamingComputerBuilder : ComputerBuilder
    {
        public override void BuildCPU()
        {
            computer.CPU = "i7";    
            Console.WriteLine($"BuildCPU:{computer.CPU}");
        }

        public override void BuildMainboard()
        {
            computer.Mainboard = "Z390";
            Console.WriteLine($"BuildMainboard:{computer.Mainboard}");
        }

        public override void BuildMemory()
        {
            computer.Memory = "16G";
            Console.WriteLine($"BuildMemory:{computer.Memory}");
        }
    }

    public class OfficeComputerBuilder : ComputerBuilder
    {
        public override void BuildCPU()
        {
            computer.CPU = "i5";
            Console.WriteLine($"BuildCPU:{computer.CPU}");
        }

        public override void BuildMainboard()
        {
            computer.Mainboard = "H310";
            Console.WriteLine($"BuildMainboard:{computer.Mainboard}");
        }

        public override void BuildMemory()
        {
            computer.Memory = "8G";
            Console.WriteLine($"BuildMemory:{computer.Memory}");
        }
    }

    public class Computer
    {
        public string CPU { get; set; }
        public string Memory { get; set; }
        public string Mainboard { get; set; }   
    }

    #endregion
}