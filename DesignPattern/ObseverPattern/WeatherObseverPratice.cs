using System.Collections.Generic;
using System;

namespace DesignPattern
{
    public class WeatherObseverPratice
    {
        public void Main()
        {
            WeatherStation weatherStation = new WeatherStation();
            CurrentDataDisplay currentDataDisplay = new CurrentDataDisplay(weatherStation);
            ForecastDisplay forecastDisplay = new ForecastDisplay(weatherStation);
            StatisticsDisplay statisticsDisplay = new StatisticsDisplay(weatherStation);
            
            weatherStation.SetMeasurements(25,70,100);
        }
        
        public interface ISubject
        {
            void Register(IOberserver oberserver);

            void UnRegister(IOberserver oberserver);

            void Notify();
        }

        public interface IOberserver
        {
            void Update();
        }
        
        public interface IDisplayElement
        {
            void Display();
        }

        public class WeatherStation : ISubject
        {
            private List<IOberserver> oberservers = new List<IOberserver>();
            private float temperature;
            private float humidity;
            private float pressure;
            
            public void Register(IOberserver oberserver)
            {
                oberservers.Add(oberserver);
            }

            public void UnRegister(IOberserver oberserver)
            {
                oberservers.Remove(oberserver);
            }

            public void Notify()
            {
                foreach (var oberserver in oberservers)
                {
                    oberserver.Update();
                }
            }
            
            public float GetTemperature()
            {
                return temperature;
            }
            
            public float GetHumidity()
            {
                return humidity;
            }
            
            public float GetPressure()
            {
                return pressure;
            }
            
            public string GetForecast()
            {
                if(temperature > 30)
                {
                    return "Hot";
                }
                else if(temperature < 10)
                {
                    return "Cold";
                }
                else
                {
                    return "Normal";
                }
            }
            
            public void SetMeasurements(float temperature, float humidity, float pressure)
            {
                this.temperature = temperature;
                this.humidity = humidity;
                this.pressure = pressure;
                Notify();
            }
        }
        
        public class CurrentDataDisplay : IOberserver, IDisplayElement
        {
            private WeatherStation weatherStation;
            private float temperature;
            private float humidity;
            private float pressure;
            
            public CurrentDataDisplay(WeatherStation weatherStation)
            {
                this.weatherStation = weatherStation;
                weatherStation.Register(this);
            }
            
            public void Update()
            {
                Console.WriteLine("UpdateCurrentData");
                temperature = weatherStation.GetTemperature();
                humidity = weatherStation.GetHumidity();
                pressure = weatherStation.GetPressure();
                Display();
            }

            public void Display()
            {
                Console.WriteLine($"CurrentDataDisplay: {temperature} {humidity} {pressure}");
            
            }
        }
        
        public class ForecastDisplay : IOberserver , IDisplayElement
        {
            private WeatherStation weatherStation;
            private string forecast;
            
            public ForecastDisplay(WeatherStation weatherStation)
            {
                this.weatherStation = weatherStation;
                weatherStation.Register(this);
            }
            
            public void Update()
            {
                Console.WriteLine("UpdateForecast");
                forecast = weatherStation.GetForecast();
                Display();
            }

            public void Display()
            {
                Console.WriteLine($"ForecastDisplay: {forecast}");
            }
        }
        
        public class StatisticsDisplay : IOberserver , IDisplayElement
        {
            private WeatherStation weatherStation;
            private float tempAvg;
            private float tempMax;
            private float tempMin;
            
            public StatisticsDisplay(WeatherStation weatherStation)
            {
                this.weatherStation = weatherStation;
                weatherStation.Register(this);
            }
            
            public void Update()
            {
                Console.WriteLine("UpdateStatistics");
                tempAvg = (weatherStation.GetTemperature() + tempAvg) / 2;
                tempMax = Math.Max(weatherStation.GetTemperature(), tempMax);
                tempMin = Math.Min(weatherStation.GetTemperature(), tempMin);
                Display();
            }

            public void Display()
            {
                Console.WriteLine($"StatisticsDisplay: {tempAvg} {tempMax} {tempMin}");
            }
        }
    }
}