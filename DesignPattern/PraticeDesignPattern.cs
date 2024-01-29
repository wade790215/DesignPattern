using System;
using System.Collections.Generic;

namespace DesignPattern
{
    public class PraticeDesignPattern
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
                homeDeviceCommand.Execute(audioOn);
                Console.ReadLine();
            }
        }

        #region 命令模式
        public interface IDeviceCommand
        {
            void Execute();
            DeviceStatus GetDeviceStatus();
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
                    notiflySystem.Notify(deviceCommand.GetDeviceStatus());
                }
            }

            public void Execute(IDeviceCommand deviceCommand)
            {
                if (deviceCommands.Contains(deviceCommand))
                {
                    deviceCommand.Execute();
                    notiflySystem.Notify(deviceCommand.GetDeviceStatus()); 
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

            public DeviceStatus GetDeviceStatus()
            {
                return light.GetDeviceStatus();
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

            public DeviceStatus GetDeviceStatus()
            {
                return light.GetDeviceStatus();
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

            public DeviceStatus GetDeviceStatus()
            {
                return audio.GetDeviceStatus();
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

            public DeviceStatus GetDeviceStatus()
            {
                return audio.GetDeviceStatus();
            }
        }

        public class Audio : IDevice
        {
            public string Brand { get; set; }
            private DeviceStatus deviceStatus;

            public Audio()
            {
                deviceStatus = new DeviceStatus("音響", "關閉音響","一般音響");
            }

            public void On()
            {
                deviceStatus.Status = "開啟音響";
                Console.WriteLine(deviceStatus.Status);
            }

            public void Off()
            {
                deviceStatus.Status = "關閉音響";
                Console.WriteLine(deviceStatus.Status);
            }

            public DeviceStatus GetDeviceStatus()
            {
                return deviceStatus;
            }
        }

        public class Light : IDevice
        {
            public string Brand { get; set; }
            private DeviceStatus deviceStatus;

            public Light()
            {
                deviceStatus = new DeviceStatus("燈", "關燈","一般燈");
            }

            public void On()
            {
                deviceStatus.Status = "開燈";
                Console.WriteLine(deviceStatus.Status);
            }

            public void Off()
            {
                deviceStatus.Status = "關燈";
                Console.WriteLine(deviceStatus.Status);
            }

            public DeviceStatus GetDeviceStatus()
            {
                return deviceStatus;
            }
        }

        #endregion

        #region 觀察者模式

        public class MyPhone : IOberserve
        {
            public void Update(DeviceStatus status)
            {
                Console.WriteLine($"[MyPhone] Received Update: Device - {status.DeviceName}, Status - {status.Status}, Time - {status.Timestamp}");
            }
        }

        public interface IOberserve
        {
            void Update(DeviceStatus deviceStatus);
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

            public void Notify(DeviceStatus deviceStatus)
            {
                foreach (var oberserve in oberserves)
                {
                    oberserve.Update(deviceStatus);
                }
            }
        }

        #endregion

        #region 工廠模式

        public class DeviceFactory
        {
            public IDevice CreateDevice(DeviceStatus deviceStatus)
            {
                switch(deviceStatus.DeviceName)
                {
                    case "燈":
                        return new Light();
                    case "音響":
                        return new Audio();
                    default:
                        return null;
                }
            }
        }

        #endregion

        public interface IDevice
        {
            string Brand { get; set; }     
        }

        public class DeviceStatus
        {
            public string DeviceName { get; set; }
            public string Status { get; set; }
            public string Brand { get; set; }
            public DateTime Timestamp { get; set; }

            public DeviceStatus(string deviceName, string status,string brand)
            {
                DeviceName = deviceName;
                Status = status;
                Brand = brand;
                Timestamp = DateTime.Now;
            }
        }
    }
}
