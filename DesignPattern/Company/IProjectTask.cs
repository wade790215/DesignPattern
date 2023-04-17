using System;

namespace DesignPattern
{
    public interface IProjectTask
    {
        void PerformTask();
    }

    public class EOTask : IProjectTask
    {
        public void PerformTask()
        {
            Console.WriteLine("Performing EO task...");
        }
    }
}
