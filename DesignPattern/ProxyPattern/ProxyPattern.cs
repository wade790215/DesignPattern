using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DesignPattern
{
    //透過代理人來轉送資訊，將Sender封裝

    internal class ProxyPattern
    {
        public void Main()
        {
            //Receiver receiver = new Receiver() { Name = "YuTing" };
            //DeliveryMan deliveryMan = new DeliveryMan(receiver);
            //deliveryMan.Delivery();
            
            Client client = new Client();
            client.Read();
            Console.ReadLine();
        }
    }

    #region Pratice2

    public interface IFileReader
    {
        void ReadFile();
    }   

    public class RealFileReader : IFileReader
    {
        public void ReadFile()
        {
            Console.WriteLine("Read file from disk.");
        }
    }

    public class FileReaderProxy : IFileReader
    {
        private IFileReader fileReader;

        public FileReaderProxy(IFileReader fileReader)
        {
            this.fileReader = fileReader;
        }   

        public void ReadFile()
        {
            CheckAccess();
            Log();
            fileReader.ReadFile();  
        }

        public void CheckAccess()
        {
            Console.WriteLine("Check access.");
        }

        public void Log()
        {
            Console.WriteLine("Log.");
        }
    }

    public class Client
    {
        public void Read()
        {
            IFileReader fileReader = new FileReaderProxy(new RealFileReader());
            fileReader.ReadFile();
        }
    }

    #endregion

    #region Pratice1
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

    public interface IDelivery
    {
        void Delivery();
    }
    #endregion
}
