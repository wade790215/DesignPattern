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
            #region 依賴反轉
            //DIP dip = new DIP();
            //dip.Main();
            #endregion

            #region 李氏替換
            //LSP lsp = new LSP();
            //lsp.Main();
            #endregion

            #region 策略模式
            //StrategyPattern strategyPattern = new StrategyPattern();
            //strategyPattern.Main();
            #endregion

            #region 裝飾者模式
            //DecoratorPattern decoratorPattern = new DecoratorPattern();
            //decoratorPattern.Main();
            #endregion

            #region 代理模式
            //ProxyPattern proxyPattern = new ProxyPattern();
            //proxyPattern.Main();
            #endregion

            #region 原型模式
            //PrototypePattern prototypePattern = new PrototypePattern();
            //prototypePattern.Main();
            #endregion

            #region 模板方法模式
            //TemplateMethodPattern templateMethodPattern = new TemplateMethodPattern();
            //templateMethodPattern.Main();
            #endregion

            #region 外觀模式
            //FacadePattern facadePattern = new FacadePattern();
            //facadePattern.Main();
            #endregion

            #region 建造者模式
            //BuilderPattern builderPattern = new BuilderPattern();
            //builderPattern.Main();
            #endregion

            #region 觀察者模式
            //ObserverPattern observerPattern = new ObserverPattern();
            //observerPattern.Main();
            #endregion

            #region 工廠方法模式
            //FactoryMethodPattern factoryMethodPattern = new FactoryMethodPattern();
            //factoryMethodPattern.Main();
            #endregion

            #region 探討抽象工廠模式
            //AbstractFactoryPattern abstractFactoryPattern = new AbstractFactoryPattern();
            //abstractFactoryPattern.Main();
            #endregion

            #region 狀態模式
            //StatePattern statePattern = new StatePattern();
            //statePattern.Main();
            #endregion

            #region 轉接器模式
            //AdapterPattern adapterPattern = new AdapterPattern();
            //adapterPattern.Main();
            #endregion

            #region 備忘錄模式
            //MementoPattern mementoPattern = new MementoPattern();
            //mementoPattern.Main();
            #endregion

            #region 組合模式
            //ompositePattern compositePattern = new CompositePattern();
            //compositePattern.Main();
            #endregion

            #region 合成聚合復合模式
            //CARPPattern Pattern = new CARPPattern();
            //Pattern.Main();
            #endregion

            #region 命令模式
            //CommandPattern commandPattern = new CommandPattern();
            //commandPattern.Main();
            #endregion

            #region 責任鏈模式
            //ChainOfResponsibilityPattern chainOfResponsibilityPattern = new ChainOfResponsibilityPattern();
            //chainOfResponsibilityPattern.Main();
            #endregion

            #region 中介者模式
            MediatorPattern mediatorPattern = new MediatorPattern();
            mediatorPattern.Main();
            #endregion

            #region 享元模式
            //FlyweightPattern flyweightPattern = new FlyweightPattern();
            //flyweightPattern.Main();
            #endregion

            #region 訪問者模式
            //VisitorPattern visitorPattern = new VisitorPattern();
            //visitorPattern.Main();
            #endregion

            #region 單例模式
            //SingletonPattern singletonPattern = new SingletonPattern();
            //singletonPattern.Main();
            #endregion
        }
    }
}
