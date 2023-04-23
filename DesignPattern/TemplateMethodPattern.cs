using System;

namespace DesignPattern
{
    internal class TemplateMethodPattern
    {
        internal void Main()
        {
            WorkLog jackChang = new JackChang();
            jackChang.WriteWrokLog();

            WorkLog boQian = new BoQian();
            boQian.WriteWrokLog();

            WorkLog yuDer = new YuDer();
            yuDer.WriteWrokLog();
        }

        public abstract class WorkLog
        {
            public void WriteWrokLog()
            {
                WriteName();
                WriteWorkContent();
                PassToEChen();
            }

            protected abstract void WriteName();
            protected abstract void WriteWorkContent();
            protected void PassToEChen()
            {
                Console.WriteLine($"Pass work log to EChen");
            }
        }

        public class JackChang : WorkLog
        {
            protected override void WriteName()
            {
                Console.WriteLine("JackChang");
            }

            protected override void WriteWorkContent()
            {
                Console.WriteLine("Coding.");
            }
        }

        public class BoQian : WorkLog
        {
            protected override void WriteName()
            {
                Console.WriteLine("BoQian");
            }

            protected override void WriteWorkContent()
            {
                Console.WriteLine("Fix bug.");
            }
        }

        public class YuDer : WorkLog
        {
            protected override void WriteName()
            {
                Console.WriteLine("YuDer");
            }

            protected override void WriteWorkContent()
            {
                Console.WriteLine("補休-身體不適");
            }
        }
    }
}