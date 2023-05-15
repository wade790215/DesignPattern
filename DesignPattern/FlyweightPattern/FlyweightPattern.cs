using System;
using System.Collections.Generic;

namespace DesignPattern
{
    //享元模式
    //將物件分為兩種，一種是內部狀態，一種是外部狀態
    //內部狀態是不會改變的，外部狀態是會改變的
    //內部狀態是可以共用的，外部狀態是不可以共用的
    //外部狀態是由客戶端傳入的
    //外部狀態是不可以共用的，所以要傳入
    //內部狀態是可以共用的，所以要設計成靜態
    //內部狀態是不會改變的，所以要設計成只讀
    //內部狀態是不會改變的，所以要設計成只能在建構子設定

    internal class FlyweightPattern
    {
        internal void Main()
        {
            var flyWeightFactory = new FlyweightFactory();
            var flyWeight = flyWeightFactory.GetFlyweight(1);
            flyWeight.Operation(100);
        }
    }

    public interface IFlyWeight
    {
        void Operation(int extrinsicstate);
    }

    public class ConcreteFlyweight : IFlyWeight
    {
        private int intrinsicstate;

        public ConcreteFlyweight(int intrinsicstate)
        {
            this.intrinsicstate = intrinsicstate;
        }

        public void Operation(int extrinsicstate)
        {
            Console.WriteLine("Intrinsic State = " + intrinsicstate +
                              " Extrinsic State = " + extrinsicstate);
        }
    }

    public class FlyweightFactory
    {
        private Dictionary<int, IFlyWeight> flyweights = new Dictionary<int, IFlyWeight>();

        public IFlyWeight GetFlyweight(int key)
        {
            if (!flyweights.ContainsKey(key))
                flyweights[key] = new ConcreteFlyweight(key);
            return flyweights[key];
        }
    }
}