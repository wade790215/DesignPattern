using System;
using System.Security.Cryptography.X509Certificates;

namespace DesignPattern
{
    internal class PrototypePattern
    {
        internal void Main()
        {
            //Person person = new Person("喬治", 18, new Address("高雄", "鳳仁路"));
            ////Person person2 = person;
            //Person person2 = (Person)person.Clone();

            //person2.Name = "約翰";
            //person2.Age = 20;
            //person2.address.City = "台北";
            //person2.address.Street = "忠孝東路";

            //person.Show();
            //person2.Show();

            IGameCharacter warrior = new Warrior("喬治", 18);
            IGameCharacter mage = new Mage("約翰", 20);

            IGameCharacter newWarrior = warrior.Clone();
            newWarrior.Name = "喬治2";
            Console.WriteLine( newWarrior.Level);
            Console.ReadLine();
        }

        #region Pratice2    

        public interface IGameCharacter
        {
            string Name { get; set; }
            int Level { get; set; }
            IGameCharacter Clone();
        }

        public class Warrior : IGameCharacter
        {
            public string Name { get; set; }
            public int Level { get; set; }

            public Warrior(string name, int level)
            {
                Name = name;
                Level = level;
            }

            public IGameCharacter Clone()
            {
                return new Warrior(Name, Level);
            }
        }

        public class Mage : IGameCharacter
        {
            public string Name { get; set; }
            public int Level { get; set; }

            public Mage(string name, int level)
            {
                Name = name;
                Level = level;
            }

            public IGameCharacter Clone()
            {
                return new Mage(Name, Level);
            }
        }

        #endregion

        #region Pratice1
        public class Person : ICloneable
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Address address;

            public Person(string name, int age, Address address)
            {
                Name = name;
                Age = age;
                this.address = address;
            }

            public void Show()
            {
                Console.WriteLine($"Name:{Name},Age:{Age},Address:{address.City}-{address.Street}");
            }

            //淺複製無法複製引用類型裡面的內容，需要再多做Clone
            public object Clone()
            {
                return new Person(Name, Age, /*address*/(Address)address.Clone());
            }
        }

        public class Address : ICloneable
        {
            public string City { get; set; }
            public string Street { get; set; }

            public Address(string city, string street)
            {
                City = city;
                Street = street;
            }

            public object Clone()
            {
                return new Address(Street, City);
            }
        }
        #endregion
    }
}