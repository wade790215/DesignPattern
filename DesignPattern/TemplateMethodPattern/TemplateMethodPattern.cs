using System;

namespace DesignPattern
{
    //模板方法模式通常會有個抽象的父類別並提供抽象方法或是已經實做好的算法必須照著做
    //子類別可以覆寫父類別的方法，但是不能改變算法的流程
    internal class TemplateMethodPattern
    {
        internal void Main()
        {
            //WorkLog jackChang = new JackChang();
            //jackChang.WriteWrokLog();

            //WorkLog boQian = new BoQian();
            //boQian.WriteWrokLog();

            //WorkLog yuDer = new YuDer();
            //yuDer.WriteWrokLog();

            DataAnalyzer finacialDataAnalyzer = new FinacialDataAnalyzer();
            finacialDataAnalyzer.ProcessData();

            DataAnalyzer salesDataAnalyzer = new SalesDataAnalyzer();
            salesDataAnalyzer.ProcessData();
        }

        #region Pratice1

        public abstract class DataAnalyzer 
        {
            public void ProcessData()
            {
                LoadData();
                AnalyzeData();
                CleanData();
                GenerateReport();
            }

            protected virtual void LoadData()
            {
                Console.WriteLine("Load data from database.");
            }

            protected virtual void AnalyzeData()
            {
                Console.WriteLine("Analyze data.");
            }

            protected virtual void CleanData()
            {
                Console.WriteLine("Clean data.");
            }   

            protected virtual void GenerateReport()
            {
                Console.WriteLine("Generate report.");
            }   
        }

        public class  FinacialDataAnalyzer:DataAnalyzer
        {
            protected override void AnalyzeData()
            {
                Console.WriteLine("Analyze finace data.");
            }
        }

        public class SalesDataAnalyzer : DataAnalyzer
        {
            protected override void AnalyzeData()
            {
                Console.WriteLine("Analyze sales data.");
            }
        }

        #endregion

        #region Pratice2
        public abstract class WorkLog
        {
            public void WriteWrokLog()
            {
                WriteName();
                WriteWorkContent();
                PassToEChen();
            }

            protected abstract void WriteName();
            protected abstract void WriteWorkContent();
            protected void PassToEChen()
            {
                Console.WriteLine($"Pass work log to EChen");
            }
        }

        public class JackChang : WorkLog
        {
            protected override void WriteName()
            {
                Console.WriteLine("JackChang");
            }

            protected override void WriteWorkContent()
            {
                Console.WriteLine("Coding.");
            }
        }

        public class BoQian : WorkLog
        {
            protected override void WriteName()
            {
                Console.WriteLine("BoQian");
            }

            protected override void WriteWorkContent()
            {
                Console.WriteLine("Fix bug.");
            }
        }

        public class YuDer : WorkLog
        {
            protected override void WriteName()
            {
                Console.WriteLine("YuDer");
            }

            protected override void WriteWorkContent()
            {
                Console.WriteLine("補休-身體不適");
            }
        }
        #endregion
    }
}