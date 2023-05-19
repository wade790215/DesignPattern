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
            var computer = new Computer();
            computer.Run();
        }
    }

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
}