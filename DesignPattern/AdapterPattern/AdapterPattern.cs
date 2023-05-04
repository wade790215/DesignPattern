using System;

namespace DesignPattern
{
    internal class AdapterPattern
    {
        internal void Main()
        {
            ITarget target = new Adapter();
            target.Request();
        }
    }

    public class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Called SpecificRequest()");
        }
    }

    public interface ITarget
    {
        void Request();
    }

    public class Adapter : ITarget
    {
        private Adaptee adaptee;

        public Adapter()
        {
            this.adaptee = new Adaptee();
        }

        public void Request()
        {
            adaptee.SpecificRequest(); 
        }
    }
}