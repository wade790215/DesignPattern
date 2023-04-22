using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPattern
{
    internal class ProxyPattern
    {
        public void Main()
        {
            Receiver receiver = new Receiver() { Name = "YuTing" };
            DeliveryMan deliveryMan = new DeliveryMan(receiver);
            deliveryMan.Delivery();           
        }
    }

    public class Sender : IDelivery
    {
        public string Name { get; set; }

        private Receiver receiver;

        public Sender(Receiver receiver)
        {
            this.receiver = receiver; 
        }
            

        public void Delivery()
        {
            Console.WriteLine($"{Name} is delivering the package to {receiver.Name}.");
        }
    }

    public class DeliveryMan : IDelivery
    {
        private Sender boQian;
        private Receiver receiver;
        public DeliveryMan(Receiver receiver)
        {
            this.receiver = receiver;
            boQian = new Sender(receiver) { Name = "BoQian" };
        }

        public void Delivery()
        {
            boQian.Delivery();    
            Console.WriteLine("DeliveryMan is delivering.");
            Thread.Sleep(3000);
            Console.WriteLine($"{receiver.Name} received a package");
        }
    }

    public class Receiver
    {
        public string Name { get; set; }
    }
}
