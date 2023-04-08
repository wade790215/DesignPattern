using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    internal class MainCalss
    {
        static void Main(string[] args)
        {
            PersonFactory factory = new PersonFactory();

            Person mainCharacter = factory.CreatePerson(PersonType.MainCharacter);
            Person partner = factory.CreatePerson(PersonType.Partner);
            Person npc = factory.CreatePerson(PersonType.NPC);

            Console.WriteLine(mainCharacter.Talk());
        }
    }
}
