using System;

namespace DesignPattern
{
    internal class FacadePattern
    {
        //將複雜的子系統封裝起來並簡化，只提供簡單的介面給客戶端使用
        //避免客戶端在使用API時，需要了解太多細節
        internal void Main()
        {
            //最基本的寫法，需要知道內部的細節
            //var computer = new Computer();
            //computer.CPU = new CPU();
            //computer.Memory = new Memory();
            //computer.Disk = new Disk();
            //computer.CPU.Run();
            //computer.Memory.Run();
            //computer.Disk.Run();

            //使用外觀模式，只需要知道外觀類的方法
            //var computer = new Computer();
            //computer.Run();

            HomeTheateFacade homeTheateFacade = new HomeTheateFacade();
            homeTheateFacade.WatchMovie();

            Console.ReadLine(); 
        }
    }
    #region Pratice1
    internal class Computer
    {
        private CPU cpu;
        private Memory memory;
        private Disk disk;

        public Computer()
        {
            cpu = new CPU();
            memory = new Memory();
            disk = new Disk();
        }
        public void Run()
        {
            cpu.Run();
            memory.Run();
            disk.Run();
        }
    }

    internal class Disk
    {
        public Disk()
        {
        }

        internal void Run()
        {
            Console.WriteLine($"Disk is ready.");
        }
    }

    internal class Memory
    {
        public Memory()
        {
        }

        internal void Run()
        {
            Console.WriteLine($"Memory is ready.");
        }
    }

    internal class CPU
    {
        public CPU()
        {
        }

        internal void Run()
        {
            Console.WriteLine($"CPU is ready.");
        }
    }
    #endregion

    #region Pratice2

    public interface IDeviceFunction
    {
        void On();  
        void Off(); 
        void Play();
    }

    public class HomeTheateFacade
    {
        private IDeviceFunction projector;
        private IDeviceFunction surroundSoundSystem;
        private IDeviceFunction bdPlayer;

        public HomeTheateFacade()
        {
            projector = new Projector();
            surroundSoundSystem = new SurroundSoundSystem();
            bdPlayer = new BDPlayer();
        }

        public void WatchMovie()
        {
            projector.On(); 
            surroundSoundSystem.On();
            bdPlayer.On();
            projector.Play();
            surroundSoundSystem.Play();
            bdPlayer.Play();
        }

        public void EndMovie()
        {
            projector.Off();
            surroundSoundSystem.Off();
            bdPlayer.Off();
        }
    }

    public class Projector : IDeviceFunction
    {
        public void On()
        {
            Console.WriteLine("Projector on.");
        }

        public void Off()
        {
            Console.WriteLine("Projector off.");
        }

        public void Play()
        {
            Console.WriteLine("Projector play.");
        }
    }

    public class SurroundSoundSystem : IDeviceFunction
    {
        public void On()
        {
            Console.WriteLine("SurroundSoundSystem on.");
        }

        public void Off()
        {
            Console.WriteLine("SurroundSoundSystem off.");
        }

        public void Play()
        {
            Console.WriteLine("SurroundSoundSystem play.");
        }
    }

    public class BDPlayer : IDeviceFunction
    {
        public void On()
        {
            Console.WriteLine("BDPlayer on.");
        }

        public void Off()
        {
            Console.WriteLine("BDPlayer off.");
        }

        public void Play()
        {
            Console.WriteLine("BDPlayer play.");
        }
    }

    #endregion
}