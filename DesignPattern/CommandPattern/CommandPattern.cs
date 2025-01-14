using System;
using System.Collections.Generic;

namespace DesignPattern
{
    public class CommandPattern
    {
        public void Main()
        {
            //Light light = new Light();
            //TV tv = new TV();
            //ICommand lightOn = new LightOnCommand(light);
            //ICommand tvOn = new TVOnCommand(tv);

            //RemoteControl remoteControl = new RemoteControl();
            //remoteControl.AddCommand(lightOn);
            //remoteControl.AddCommand(tvOn);
            //remoteControl.PressButton(tvOn);

            Coffee coffee = new Coffee();   
            Tea tea = new Tea();
            ICommand maker = new MakeCoffeeCommand(coffee);
            maker.Execute();
            Console.ReadLine(); 
        }
    }
    #region Pratice 2

    public class MakeCoffeeCommand : ICommand
    {
        private Coffee coffee;
        public MakeCoffeeCommand(Coffee coffee)
        {
            this.coffee = coffee;
        }
        public void Execute()
        {
            coffee.MakeCoffee();
        }
    }

    public class MakeTeaCommand : ICommand
    {
        private Tea tea;
        public MakeTeaCommand(Tea tea)
        {
            this.tea = tea;
        }
        public void Execute()
        {
            tea.MakeTea();
        }
    }

    public class Coffee
    { 
        public void MakeCoffee()
        {             
            Console.WriteLine("製作咖啡");
        }
    }

    public class Tea
    {
        public void MakeTea()
        {
            Console.WriteLine("製作茶");
        }
    }

    #endregion

    #region Pratice 1
    public interface ICommand
    {
         void Execute();
    }

    public class LightOnCommand : ICommand
    {
        private PraticeDesignPattern.Light light;
        public LightOnCommand(PraticeDesignPattern.Light light)
        {
            this.light = light;
        }
        public void Execute()
        {
            light.On();
        }
    }

    public class RemoteControl
    {
        private List<ICommand> commands = new List<ICommand>();

        public void AddCommand(ICommand command)
        {
            commands.Add(command);
        }

        public void RemoveCommand(ICommand command)
        {
            commands.Remove(command);
        }

        public void PressButton(ICommand command)
        {
            if (commands.Contains(command))
                command.Execute();
        }

        public void PressButton()
        {
            foreach (var command in commands)
            {
                command.Execute();
            }
        }
    }

    internal class TVOnCommand : ICommand
    {
        private TV TV;
        public TVOnCommand(TV tV)
        {
            TV = tV;
        }

        public void Execute()
        {
            TV.On();
        }
    }

    internal class TV
    {
        public void On()
        {
            Console.WriteLine($"開電視");
        }
    }
    #endregion
}