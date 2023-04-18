using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    internal class MainCalss
    {
        static void Main(string[] args)
        {
            #region 允和公司
            //YunheCompany yunheCompany = new YunheCompany();

            //foreach (var frontEndEngineers in EmpolyeeInfoDatas.ApplyFrontEndEngineer())
            //{
            //    yunheCompany.HireStaff(frontEndEngineers);
            //}

            //List<YunheEmpolyee> frontEndEngineersSenior = yunheCompany.QueryEmployees(Position.FrontEndEngineer, Seniority.Senior);

            //var projectManagement = new ProjectManagement();
            //var eoTask = new EOTask();

            //projectManagement.AssignWork(frontEndEngineersSenior, typeof(Debug), eoTask);
            #endregion

            #region 依賴反轉
            //DIP dip = new DIP();
            //dip.Main();
            #endregion

            #region 李氏替換
            //LSP lsp = new LSP();    
            //lsp.Main();
            #endregion

            #region 裝飾者模式
            //DecoratorPattern decoratorPattern = new DecoratorPattern();
            //decoratorPattern.Main();
            #endregion

            string s = "abaccdeff";
            Console.WriteLine(RepeatNum(s, 2));
        }

        public static int RepeatNum(string s, int n)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (dic.ContainsKey(s[i]))
                {
                    dic[s[i]] = dic[s[i]] + 1;

                    if (dic[s[i]] == n)
                    {
                        return s[i];
                    }
                }
                else
                {
                    dic.Add(s[i], 1);
                }
            }
           
            return -1;
        }
    }
}
