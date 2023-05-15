using System;

namespace DesignPattern
{
    public interface ISkill
    {
        void Perform();
    }

    public class WriteCode : ISkill
    {
        public void Perform()
        {
            Console.WriteLine("Writing code...");
        }
    }

    public class Debug : ISkill
    {
        public void Perform()
        {
            Console.WriteLine("Debugging...");
        }
    }

    public class Modeling : ISkill
    {
        public void Perform()
        {
            Console.WriteLine("Creating 3D models...");
        }
    }

    public class Animation : ISkill
    {
        public void Perform()
        {
            Console.WriteLine("Creating animations...");
        }
    }

    public class CoursePlanning : ISkill
    {
        public void Perform()
        {
            Console.WriteLine("Course planning...");
        }
    }

    public class ProgramManagement : ISkill
    {
        public void Perform()
        {
            Console.WriteLine("Project management...");
        }
    }
}
