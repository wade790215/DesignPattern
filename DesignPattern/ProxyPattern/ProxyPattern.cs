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

    //代理的對象
    public class RealFileReader : IFileReader
    {
        public void ReadFile()
        {
            Console.WriteLine("Read file from disk.");
        }
    }

    //代理人，對RealFileReader進行封裝
    //代理人可以做一些額外的事情，例如檢查權限、紀錄log
    //代理人可以對RealFileReader進行控制，例如限制存取次數
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

    //客戶端
    //透過代理人來存取檔案
    public class Client
    {
        public void Read()
        {
            FileReaderProxy fileReader = new FileReaderProxy(new RealFileReader());
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
