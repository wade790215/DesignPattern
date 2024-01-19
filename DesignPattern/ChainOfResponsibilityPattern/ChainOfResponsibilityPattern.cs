using System;

namespace DesignPattern
{
    //使很多個對象都可以處理，避免請求者與處理者直接耦合，把需求連成一條鍊沿著這條鍊傳遞需求，直到需求被解決
    internal class ChainOfResponsibilityPattern
    {
        internal void Main()
        {
            //Request request = new Request()
            //{
            //    Name = "阿德",
            //    Reason = "滑鼠壞掉",
            //    ReasonType = ReasonType.Hardware
            //};

            //Approver eChen = new Director();
            //Approver moneyDragon = new WarehouseManagement();

            ////設定責任鍊
            //eChen.SetSuccessor(moneyDragon);

            //eChen.ProcessRequest(request);

            var request = new JobRequest()
            {
                Name = "阿德",
                Reason = "滑鼠壞掉",
                ReasonType = ReasonType.Junior
            };

            SupportHanlder junior = new JuniorSupportHandler();
            SupportHanlder middle = new MiddleSupportHandler();
            SupportHanlder senior = new SeniorSupportHandler();

            junior.SetSuccessor(middle);
            middle.SetSuccessor(senior);

            junior.HandleRequest(request);
            Console.ReadLine();
        }
    }

    #region Pratice 2

    public interface SupportHanlder
    {
        void HandleRequest(JobRequest request);

        void SetSuccessor(SupportHanlder successor);
    }

    public class JobRequest
    {
        public string Name { get; internal set; }
        public string Reason { get; internal set; }
        public ReasonType ReasonType { get; internal set; }
    }

    public class JuniorSupportHandler : SupportHanlder
    {
        private SupportHanlder successor;

        public void HandleRequest(JobRequest request)
        {
            if (request.ReasonType == ReasonType.Junior)
            {
                Console.WriteLine($"我可以處理:{request.Reason}");
            }
            else
            {
                Console.WriteLine("我不能處理交給下一位");
                successor.HandleRequest(request);
            }
        }

        public void SetSuccessor(SupportHanlder successor)
        {
            this.successor = successor;
        }
    }

    public class MiddleSupportHandler : SupportHanlder
    {
        private SupportHanlder successor;

        public void HandleRequest(JobRequest request)
        {
            if (request.ReasonType == ReasonType.Middle)
            {
                Console.WriteLine($"我可以處理:{request.Reason}");
            }
            else
            {
                Console.WriteLine("我不能處理交給下一位");
                successor.HandleRequest(request);
            }
        }

        public void SetSuccessor(SupportHanlder successor)
        {
            this.successor = successor;
        }
    }

    public class SeniorSupportHandler : SupportHanlder
    {
        private SupportHanlder successor;

        public void HandleRequest(JobRequest request)
        {
            if (request.ReasonType == ReasonType.Senior)
            {
                Console.WriteLine($"我可以處理:{request.Reason}");
            }
            else
            {
                Console.WriteLine("我不能處理交給下一位");
                successor.HandleRequest(request);
            }
        }

        public void SetSuccessor(SupportHanlder successor)
        {
            this.successor = successor;
        }
    }

    #endregion


    #region Pratice 1
    public enum ReasonType
    {
        Hardware,
        Software,
        Code,
        Junior,
        Middle,
        Senior
    }

    public class Request
    {
        public string Name { get; internal set; }
        public string Reason { get; internal set; }
        public ReasonType ReasonType { get; internal set; }
    }

    internal abstract class Approver
    {
        protected Approver successor;
        internal abstract void ProcessRequest(Request request);

        internal void SetSuccessor(Approver successor)
        {
            this.successor = successor;
        }
    }

    internal class WarehouseManagement : Approver
    {
        internal override void ProcessRequest(Request request)
        {
            switch (request.ReasonType)
            {
                case ReasonType.Hardware:
                    Console.WriteLine("看看公司有沒有庫存");
                    break;
                case ReasonType.Software:
                    Console.WriteLine("我沒辦法處理，下面一位");
                    successor.ProcessRequest(request);
                    break;
                case ReasonType.Code:
                    Console.WriteLine("我沒辦法處理，下面一位");
                    successor.ProcessRequest(request);
                    break;
                default:
                    break;
            }
        }
    }

    internal class Director : Approver
    {
        internal override void ProcessRequest(Request request)
        {
            switch (request.ReasonType)
            {
                case ReasonType.Hardware:
                    Console.WriteLine("我沒辦法處理，下面一位");
                    successor.ProcessRequest(request);
                    break;
                case ReasonType.Software:
                    Console.WriteLine("我沒辦法處理，下面一位");
                    successor.ProcessRequest(request);
                    break;
                case ReasonType.Code:
                    Console.WriteLine($"這我可以幫你看Code");
                    break;
                default:
                    break;
            }
        }
    }
    #endregion
}