using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    internal class LSP
    {
        public void Main()
        {
            Person person = new EChen();

            person.Eat();
            person.Breathe();
            person.Think(); 
        }
    }

    internal class Person
    {
        public virtual void Eat()
        {
            Console.WriteLine("Eat");
        }

        public virtual void Breathe()
        {
            Console.WriteLine("Breathe");
        }

        public virtual void Think()
        {
            Console.WriteLine("Think");
        }
    }

    internal class EChen : Person
    {
        public override void Breathe()
        {
            Console.WriteLine($"{typeof(EChen).Name} Breathe");
        }
    }

    internal class JackChang : Person
    {

    }
}
