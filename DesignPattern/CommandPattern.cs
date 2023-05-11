using System;
using System.Collections.Generic;

namespace DesignPattern
{
    public class CommandPattern
    {
        public void Main()
        {
            Light light = new Light();
            TV tv = new TV();
            ICommand lightOn = new LightOnCommand(light);
            ICommand tvOn = new TVOnCommand(tv);

            RemoteControl remoteControl = new RemoteControl();
            remoteControl.AddCommand(lightOn);
            remoteControl.AddCommand(tvOn);
            remoteControl.PressButton(tvOn);
        }
    }

    public interface ICommand
    {
         void Execute();
    }

    public class LightOnCommand : ICommand
    {
        private Light light;
        public LightOnCommand(Light light)
        {
            this.light = light;
        }
        public void Execute()
        {
            light.On();
        }
    }

    public class Light
    {
        public void On()
        {
            Console.WriteLine("開燈");
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
}