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
                HomeDeviceCommand homeDeviceCommand = new HomeDeviceCommand();
                homeDeviceCommand.SetNotiflySystem(notiflySystem);
                MyPhone myPhone = new MyPhone(homeDeviceCommand);
                notiflySystem.AddOberserve(myPhone);

                DeviceFactory deviceFactory = new DeviceFactory();
                IDeviceControl smartLight = deviceFactory.CreateDevice(new DeviceStatus("燈", "開燈", "智慧燈"));
                IDeviceControl rayLight = deviceFactory.CreateDevice(new DeviceStatus("燈", "開燈", "雷射燈"));
                IDeviceControl homeAudio = deviceFactory.CreateDevice(new DeviceStatus("音響", "開啟音響", "家庭劇院"));
                IDeviceControl audio =  deviceFactory.CreateDevice(new DeviceStatus("音響", "開啟音響", "一般音響"));
                IDeviceCommand lightOn = new LightOnCommand(smartLight);
                IDeviceCommand lightOff = new LightOffCommand(smartLight);
                IDeviceCommand audioOn = new AudioOnCommand(homeAudio);
                IDeviceCommand audioOff = new AudioOffCommand(homeAudio);
                homeDeviceCommand.AddCommand(lightOn);
                homeDeviceCommand.AddCommand(lightOff);
                homeDeviceCommand.AddCommand(audioOn);
                homeDeviceCommand.AddCommand(audioOff);

                homeDeviceCommand.Execute(lightOn);
                homeDeviceCommand.Execute(audioOn);
                myPhone.UseHomeStrategy(new LeavingHome());
                Console.ReadLine();
            }
        }

        #region 命令模式

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

            public void ExecuteAllOffCommands()
            {
                foreach (var deviceCommand in deviceCommands)
                {
                    if (deviceCommand is LightOffCommand || deviceCommand is AudioOffCommand)
                    {
                        deviceCommand.Execute();
                        notiflySystem.Notify(deviceCommand.GetDeviceStatus());
                    }
                }
            }

            public void ExecuteAllLightOnCommands()
            {
                foreach (var deviceCommand in deviceCommands)
                {
                    if (deviceCommand is LightOnCommand)
                    {
                        deviceCommand.Execute();
                        notiflySystem.Notify(deviceCommand.GetDeviceStatus());
                    }
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
            private IDeviceControl light;

            public LightOnCommand(IDeviceControl light)
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
            private IDeviceControl light;

            public LightOffCommand(IDeviceControl light)
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
            private IDeviceControl audio;

            public AudioOnCommand(IDeviceControl audio)
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
            private IDeviceControl audio;

            public AudioOffCommand(IDeviceControl audio)
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

        #endregion

        #region 觀察者模式

        public class MyPhone : IOberserve
        {
            private HomeDeviceCommand homeDeviceCommand;    
            public MyPhone(HomeDeviceCommand homeDeviceCommand) 
            {
                this.homeDeviceCommand = homeDeviceCommand; 
            }

            public void UseHomeStrategy(ISmartHomeStrategy smartHomeStrategy)
            {
                if(smartHomeStrategy != null)
                    smartHomeStrategy.Execute(homeDeviceCommand);
            }

            public void Update(DeviceStatus status)
            {
                Console.WriteLine($"[MyPhone] Received Update: Device - {status.Brand}, Status - {status.Status}, Time - {status.Timestamp}");
            }
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
            public IDeviceControl CreateDevice(DeviceStatus deviceStatus)
            {
                switch(deviceStatus.DeviceName)
                {
                    case "燈":
                        switch(deviceStatus.Brand)
                        {
                            case "智慧燈":
                                return new SmartLight(deviceStatus);
                            case "雷射燈":
                                return new RayLight(deviceStatus);
                            default:
                                return new Light(deviceStatus);
                        }
                    case "音響":
                        switch (deviceStatus.Brand)
                        {
                            case "智慧音響":
                                return new SmartAudio(deviceStatus);
                            case "家庭劇院":
                                return new HomeAudio(deviceStatus);
                            default:
                                return new Audio(deviceStatus);
                        }
                    default:
                        return null;
                }
            }
        }

        #endregion

        #region 策略模式

        public class LeavingHome : ISmartHomeStrategy
        {
            //關閉所有的設備
            public void Execute(HomeDeviceCommand homeDeviceCommand)
            {
                Console.WriteLine("\n離家模式關閉所有設備");
                homeDeviceCommand.ExecuteAllOffCommands();  
            }
        }

        public class ComingHome : ISmartHomeStrategy
        {
            //打開所有的電燈
            public void Execute(HomeDeviceCommand homeDeviceCommand)
            {
                homeDeviceCommand.ExecuteAllLightOnCommands();
                Console.WriteLine("回家模式打開所有電燈");
            }
        }


        #endregion

        #region 裝飾者模式

        public interface IDecorator
        {
            void Decorate();
        }

        #endregion

        #region Interface

        public interface ISmartHomeStrategy
        {
            void Execute(HomeDeviceCommand homeDeviceCommand);
        }

        public interface IDeviceInfo
        {
            string Brand { get; set; }
        }

        public interface IDeviceControl
        {
            void On();
            void Off();
            DeviceStatus GetDeviceStatus();
        }

        public interface IDeviceCommand
        {
            void Execute();
            DeviceStatus GetDeviceStatus();
        }

        public interface IOberserve
        {
            void Update(DeviceStatus deviceStatus);
        }


        #endregion

        #region Property

        public class DeviceStatus
        {
            public string DeviceName { get; set; }
            public string Status { get; set; }
            public string Brand { get; set; }
            public DateTime Timestamp { get; set; }

            public DeviceStatus(string deviceName, string status, string brand)
            {
                DeviceName = deviceName;
                Status = status;
                Brand = brand;
                Timestamp = DateTime.Now;
            }
        }

        public class Audio : IDeviceInfo, IDeviceControl
        {
            public string Brand { get; set; }
            private DeviceStatus deviceStatus;

            public Audio(DeviceStatus deviceStatus)
            {
                this.deviceStatus = deviceStatus;
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

        public class Light : IDeviceInfo, IDeviceControl
        {
            public string Brand { get; set; }
            private DeviceStatus deviceStatus;

            public Light(DeviceStatus deviceStatus)
            {
                this.deviceStatus = deviceStatus;
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

        public class SmartLight : Light
        {
            public SmartLight(DeviceStatus deviceStatus) : base(deviceStatus)
            {
                Brand = "智慧燈";
            }
        }

        public class RayLight : Light
        {
            public RayLight(DeviceStatus deviceStatus) : base(deviceStatus)
            {
                Brand = "雷射燈";
            }
        }

        public class SmartAudio : Audio
        {
            public SmartAudio(DeviceStatus deviceStatus) : base(deviceStatus)
            {
                Brand = "智慧音響";
            }
        }

        public class HomeAudio : Audio
        {
            public HomeAudio(DeviceStatus deviceStatus) : base(deviceStatus)
            {
                Brand = "家庭劇院";
            }
        }

        #endregion
    }
}
