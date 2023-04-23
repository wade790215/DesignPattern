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

            #region 代理模式
            //ProxyPattern proxyPattern = new ProxyPattern();
            //proxyPattern.Main();
            #endregion

            #region 工廠方法模式
            //FactoryMethodPattern factoryMethodPattern = new FactoryMethodPattern();
            //factoryMethodPattern.Main();
            #endregion

            #region 原型模式
            //PrototypePattern prototypePattern = new PrototypePattern();
            //prototypePattern.Main();
            #endregion

            #region 模板方法模式
            //TemplateMethodPattern templateMethodPattern = new TemplateMethodPattern();
            //templateMethodPattern.Main();
            #endregion
        }
    }
}
