using System;

namespace DesignPattern
{
    //這個很常用在開發，當狀態改變、達到目標、輸入事件...等等，會通知到訂閱者
    //好處:降低耦合訂閱者不知道誰在觀察他，只知道收到通知執行對應的行為
    public class ObserverPattern
    {
        public void Main()
        {
            #region 基礎版本
            //Leader leader = new Leader();
            //leader.Action = "去竹山";

            //FrontEndEngineer jackChang = new FrontEndEngineer("JackChang", leader);
            //FrontEndEngineer boQian = new FrontEndEngineer("BoQian", leader);

            //leader.Attach(jackChang);
            //leader.Attach(boQian);
            //leader.NotifyAllEngineers();
            #endregion

            #region 抽象觀察者與通知者
            //Leader leader = new Leader();
            //leader.Action = "去竹山";
            //FrontEndEngineer jackChang = new FrontEndEngineer("匯杰", leader);
            //ArtEngineer zhengfeng = new ArtEngineer("政峰", leader);
            //leader.Attach(jackChang);
            //leader.Attach(zhengfeng);
            //leader.NotifyAllEngineers();    

            //Boss boss = new Boss();
            //boss.Action = "去倒垃圾";
            //FrontEndEngineer boQian = new FrontEndEngineer("伯謙", boss);
            //boss.Attach(boQian); 
            //boss.NotifyAllEngineers(); 
            #endregion

            #region 觀察者要處理不同事件時的版本
            Leader leader = new Leader();   
            leader.Action = "去竹山";  

            FrontEndEngineer jackChang = new FrontEndEngineer();
            ArtEngineer zhengfeng = new ArtEngineer();

            leader.Update += (s=> jackChang.StopWork(s));
            leader.Update += (s=> zhengfeng.ContinueWork(s));

            leader.Notify();
            #endregion
        }

        #region 基礎版本
        //public class Leader
        //{
        //    private List<FrontEndEngineer> frontEndEngineers = new List<FrontEndEngineer>();

        //    private string action;

        //    public string Action { get => action; set => action = value; }

        //    public void Attach(FrontEndEngineer frontEndEngineer)
        //    {
        //        frontEndEngineers.Add(frontEndEngineer);
        //    }

        //    public void NotifyAllFrontEndEngineers()
        //    {
        //        foreach (var observer in frontEndEngineers)
        //        {
        //            observer.Update();
        //        }
        //    }
        //}

        //public class FrontEndEngineer
        //{
        //    private string name;
        //    private Leader leader;
        //    public FrontEndEngineer(string name, Leader leader)
        //    {
        //        this.name = name;
        //        this.leader = leader;
        //    }
        //    public void Update()
        //    {
        //        Console.WriteLine($"{name}收到通知停止Unity開發,{leader.Action}");
        //    }
        //}
        #endregion

        #region 抽象觀察者與通知者
        //public class Leader : ISubject
        //{
        //    private List<Engineer> engineers = new List<Engineer>();

        //    private string action;

        //    public string Action { get => action; set => action = value; }

        //    public void Attach(Engineer engineer)
        //    {
        //        engineers.Add(engineer);
        //    }

        //    public void Detach(Engineer engineer)
        //    {
        //        engineers.Remove(engineer);
        //    }

        //    public void NotifyAllEngineers()
        //    {
        //        foreach (var engineer in engineers)
        //        {
        //            engineer.Update();
        //        }
        //    }
        //}

        //public class Boss : ISubject
        //{
        //    private List<Engineer> engineers = new List<Engineer>();

        //    private string action;
        //    public string Action { get => action; set => action = value; }

        //    public void Attach(Engineer engineer)
        //    {
        //        engineers.Add(engineer);
        //    }

        //    public void Detach(Engineer engineer)
        //    {
        //        engineers.Remove(engineer);
        //    }

        //    public void NotifyAllEngineers()
        //    {
        //        foreach (var engineer in engineers)
        //        {
        //            engineer.Update();
        //        }
        //    }
        //}

        //public class FrontEndEngineer : Engineer
        //{
        //    public FrontEndEngineer(string name, ISubject subject) : base(name, subject)
        //    {
        //    }

        //    public override void Update()
        //    {
        //        Console.WriteLine($"{name}收到通知停止Unity開發,{subject.Action}");
        //    }
        //}

        //public class ArtEngineer : Engineer
        //{
        //    public ArtEngineer(string name, ISubject subject) : base(name, subject)
        //    {
        //    }

        //    public override void Update()
        //    {
        //        Console.WriteLine($"{name}收到通知停止Maya繪圖,{subject.Action}");
        //    }
        //}

        //public abstract class Engineer
        //{
        //    protected string name;
        //    protected ISubject subject;
        //    public Engineer(string name, ISubject subject)
        //    {
        //        this.name = name;
        //        this.subject = subject;
        //    }
        //    public abstract void Update();
        //}

        //public interface ISubject
        //{
        //    void Attach(Engineer engineer);

        //    void Detach(Engineer engineer);

        //    void NotifyAllEngineers();

        //    string Action { get; set; }
        //}
        
        #endregion

        #region 觀察者要處理不同事件時的版本
        public class Leader : INotify
        {
            private string action;

            public string Action { get => action; set => action = value; }

            public Action<string> Update;
            public void Notify()
            {
                Update?.Invoke(Action);
            }
        }

        public class Boss : INotify
        {
            private string action;

            public string Action { get => action; set => action = value; }

            public Action<string> Update;
            public void Notify()
            {
                Update?.Invoke(Action);
            }
        }

        public class FrontEndEngineer
        {
            public void StopWork(string subject)
            {
                Console.WriteLine($"收到通知停止Unity開發,{subject}");
            }
        }

        public class ArtEngineer
        {
            public void ContinueWork(string subject)
            {
                Console.WriteLine($"收到通知我不用{subject},繼續Maya繪圖");
            }
        }
        #endregion

        public interface INotify
        {
            void Notify();

            string Action { get; set; }
        }
    }
}