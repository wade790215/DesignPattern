using System;

namespace DesignPattern
{
    internal class MediatorPattern
    {
        internal void Main()
        {
            ConcreteMediator mediator = new ConcreteMediator();
            Colleague colleague1 = new ConcreteColleague1(mediator);
            Colleague colleague2 = new ConcreteColleague2(mediator);
            mediator.Colleague1 = colleague1;
            mediator.Colleague2 = colleague2;
            colleague1.Send("吃飯了嗎?");
            colleague2.Send("還沒");
        }
    }

    internal abstract class Mediator
    {
        internal abstract void Send(string message, Colleague colleague);
    }

    internal abstract class Colleague
    {
        protected Mediator mediator;
        internal Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }
        internal abstract void Send(string message);
        internal abstract void Notify(string message);
    }

    internal class ConcreteColleague1 : Colleague
    {
        internal ConcreteColleague1(Mediator mediator) : base(mediator)
        {
        }
        internal override void Send(string message)
        {
            mediator.Send(message, this);
        }
        internal override void Notify(string message)
        {
            Console.WriteLine($"同事1得到訊息:{message}");
        }
    }

    internal class ConcreteColleague2 : Colleague
    {
        internal ConcreteColleague2(Mediator mediator) : base(mediator)
        {
        }
        internal override void Send(string message)
        {
            mediator.Send(message, this);
        }
        internal override void Notify(string message)
        {
            Console.WriteLine($"同事2得到訊息:{message}");
        }
    }

    internal class ConcreteMediator : Mediator
    {
        internal ConcreteColleague1 Colleague1 { get; set; }
        internal ConcreteColleague2 Colleague2 { get; set; }
        internal override void Send(string message, Colleague colleague)
        {
            if (Colleague1 == colleague)
            {
                Colleague2.Notify(message);
            }
            else
            {
                Colleague1.Notify(message);
            }
        }
    }
}