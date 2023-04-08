using System;

namespace DesignPattern
{
    public class NPC : Person
    {
        public override void Talk()
        {
            Console.WriteLine("I am a NPC");
        }
    }
}
