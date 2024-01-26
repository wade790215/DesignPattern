using System;
using System.Collections.Generic;

namespace DesignPattern
{
    internal class PraticeDesignPattern
    {
        public void Main()
        {
            SmartHomeControlSystem smartHomeControlSystem = new SmartHomeControlSystem();
            smartHomeControlSystem.Main();
        }

        public class SmartHomeControlSystem
        {
            public void Main()
            {
                NotiflySystem notiflySystem = new NotiflySystem();  
                MyPhone myPhone = new MyPhone();
                notiflySystem.AddOberserve(myPhone);

                HomeDeviceCommand homeDeviceCommand = new HomeDeviceCommand();
                homeDeviceCommand.SetNotiflySystem(notiflySystem);  
                Light light = new Light();
                Audio audio = new Audio();
                IDeviceCommand lightOn = new LightOnCommand(light);
                IDeviceCommand lightOff = new LightOffCommand(light);
                IDeviceCommand audioOn = new AudioOnCommand(audio);
                IDeviceCommand audioOff = new AudioOffCommand(audio);
                homeDeviceCommand.AddCommand(lightOn);
                homeDeviceCommand.AddCommand(lightOff);
                homeDeviceCommand.AddCommand(audioOn);
                homeDeviceCommand.AddCommand(audioOff);

                homeDeviceCommand.Execute(lightOn);
                Console.ReadLine();
            }
        }

        #region 命令模式
        public interface IDeviceCommand
        {
            void Execute();
        }

        public class HomeDeviceCommand
        {
            private List<IDeviceCommand> deviceCommands = new List<IDeviceCommand>();
            private NotiflySystem notiflySystem;

            public void SetNotiflySystem(NotiflySystem notiflySystem)
            {
                this.notiflySystem = notiflySystem;
            }

            public void AddCommand(IDeviceCommand deviceCommand)
            {
                deviceCommands.Add(deviceCommand);
            }

            public void RemoveCommand(IDeviceCommand deviceCommand)
            {
                if (deviceCommands.Contains(deviceCommand))
                    deviceCommands.Remove(deviceCommand);
            }

            public void Clear()
            {
                deviceCommands.Clear();
            }

            public void ExecuteAll()
            {
                foreach (var deviceCommand in deviceCommands)
                {
                    deviceCommand.Execute();
                    notiflySystem.Notify();
                }
            }

            public void Execute(IDeviceCommand deviceCommand)
            {
                if (deviceCommands.Contains(deviceCommand))
                {
                    deviceCommand.Execute();    
                    notiflySystem.Notify(); 
                }
            }
        }

        public class LightOnCommand : IDeviceCommand
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

        public class LightOffCommand : IDeviceCommand
        {
            private Light light;

            public LightOffCommand(Light light)
            {
                this.light = light;
            }

            public void Execute()
            {
                light.Off();
            }
        }

        public class AudioOnCommand : IDeviceCommand
        {
            private Audio audio;

            public AudioOnCommand(Audio audio)
            {
                this.audio = audio;
            }

            public void Execute()
            {
                audio.On();
            }
        }

        public class AudioOffCommand : IDeviceCommand
        {
            private Audio audio;

            public AudioOffCommand(Audio audio)
            {
                this.audio = audio;
            }

            public void Execute()
            {
                audio.Off();
            }
        }

        public class Audio 
        {
            public void On()
            {
                Console.WriteLine("開啟音響");
            }

            public void Off()
            {
                Console.WriteLine("關閉音響");
            }
        }
        #endregion

        #region 觀察者模式

        public class MyPhone : IOberserve
        {
            public void Update()
            {
                Console.WriteLine("收到狀態改變通知");
            }
        }

        public interface IOberserve
        {
            void Update();
        }

        public class NotiflySystem
        { 
            private List<IOberserve> oberserves = new List<IOberserve>();       

            public void AddOberserve(IOberserve oberserve)
            {
                oberserves.Add(oberserve);
            }

            public void RemoveOberserve(IOberserve oberserve)
            {
                if (oberserves.Contains(oberserve))
                    oberserves.Remove(oberserve);
            }

            public void Notify()
            {
                foreach (var oberserve in oberserves)
                {
                    oberserve.Update();
                }
            }
        }

        #endregion

    }
}
