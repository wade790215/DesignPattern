using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    internal class SingletonPattern
    {
        internal void Main()
        {
            Singleton singleton = Singleton.GetInstance();
            Console.WriteLine($"Volume:{singleton.GetVolume()}");  
            Console.WriteLine($"Resolution:{singleton.GetResolution()}");
            Console.ReadLine();
        }   
    }

    public class Singleton
    {
        private static readonly object lockObject = new object();
        private static Singleton singleton = null;

        private Singleton()
        {
        }

        private Perferences perferences = new Perferences();    

        public static Singleton GetInstance()
        {
            lock (lockObject)
            {
                if (singleton == null)
                {
                    singleton = new Singleton();
                }
            }

            return singleton;
        }

        public float GetVolume()
        {
            return perferences.Volume;
        }   

        public void SetVolume(float volume)
        {
            perferences.Volume = volume;
        }

        public float GetResolution()
        {
            return perferences.Resolution;
        }

        public void SetResolution(float resolution)
        {
            perferences.Resolution = resolution;
        }
    }

    public class Perferences
    {
        private float volume = 1.0f;
        private float resolution = 600;

        public float Volume
        {
            get { return volume; }
            set { volume = value; }
        }

        public float Resolution
        {
            get { return resolution; }
            set { resolution = value; }
        }
    }
}
