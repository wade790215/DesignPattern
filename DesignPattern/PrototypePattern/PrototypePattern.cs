using System;

namespace DesignPattern
{
    internal class PrototypePattern
    {
        internal void Main()
        {
            Person person = new Person("喬治", 18, new Address("高雄", "鳳仁路"));
            //Person person2 = person;
            Person person2 = (Person)person.Clone();

            person2.Name = "約翰";
            person2.Age = 20;
            person2.address.City = "台北";
            person2.address.Street = "忠孝東路";

            person.Show();
            person2.Show();
        }

        public class Person : ICloneable
        {
            public string Name { get; set; }
            public int Age { get; set; }

            //淺複製無法複製引用類型裡面的內容，需要再多做Clone
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

            public object Clone()
            {
                return new Person(Name, Age, (Address)address.Clone());
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
    }


}