﻿using System;
using System.Collections.Generic;

namespace DesignPattern
{
    //中介者模式的目的是要解除物件之間的耦合，並集中管理物件之間的溝通，如果要有新的物件只需要在中介者加入並可使用
    //缺點是會造成中介者本身複雜化
    //有點像是寫Controller把需要的功能透過控制器組裝並驅動

    internal class MediatorPattern
    {
        internal void Main()
        {
            Mediator mediator = new PM();
            Colleague programmer = new Programmer(mediator, "前端");
            Colleague art = new Art(mediator, "美術");
            mediator.AddColleague(programmer);
            mediator.AddColleague(art);

            programmer.SendTo("幫我放物件到美術場景內", art);
            art.SendAllExceptMyself("前端們幫我開發好用工具");
        }
    }

    internal abstract class Mediator
    {
        protected List<Colleague> ColleagueList = new List<Colleague>();

        internal void AddColleague(Colleague colleague)
        {
            ColleagueList.Add(colleague);
        }

        internal void RemoveColleague(Colleague colleague)
        {
            ColleagueList.Remove(colleague);
        }

        internal Colleague GetColleague(Colleague colleague)
        {
            return ColleagueList.Find(c => c.Identifier == colleague.Identifier);
        }

        internal abstract void SendAllExceptMyself(string message, Colleague colleague);
        internal abstract void SendTo(string message, Colleague colleague);
    }

    internal abstract class Colleague
    {
        protected Mediator mediator;
        public string Identifier { get; private set; }
        internal Colleague(Mediator mediator, string identifier)
        {
            this.mediator = mediator;
            Identifier = identifier;
        }
        internal virtual void SendAllExceptMyself(string message)
        {
            mediator.SendAllExceptMyself(message, this);
        }

        internal virtual void SendTo(string message , Colleague colleague)
        {
            mediator.SendTo(message, colleague);
        }
        internal abstract void Notify(string message);
    }

    internal class PM : Mediator
    {
        internal override void SendAllExceptMyself(string message, Colleague colleague)
        {
            foreach (var item in ColleagueList)
            {
                if(item != colleague)
                    item.Notify(message);  
            }
        }

        internal override void SendTo(string message, Colleague colleague)
        {
            Colleague targetColleague = GetColleague(colleague);
            targetColleague?.Notify(message);    
        }
    }

    internal class Programmer : Colleague
    {
        public Programmer(Mediator mediator, string identifier) : base(mediator, identifier)
        {
        }

        internal override void Notify(string message)
        {
            Console.WriteLine($"前端收到:{message}");
        }
    }

    internal class Art : Colleague
    {
        public Art(Mediator mediator, string identifier) : base(mediator, identifier)
        {
        }

        internal override void Notify(string message)
        {
            Console.WriteLine($"美術收到:{message}");
        }
    }
}