using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DesignPattern
{
    //享元模式
    //當需要大量相同的物件時，可以使用享元模式來減少記憶體的使用
    //每個使用者拿到的物件都是同一個物件，所以要注意物件的狀態
    internal class FlyweightPattern
    {
        internal void Main()
        {
            //var flyWeightFactory = new FlyweightFactory();
            //var flyWeight = flyWeightFactory.GetFlyweight(1);
            //flyWeight.Operation(100);

            EquipmentFactory equipmentFactory = new EquipmentFactory();
            Equipment equipment = new Equipment() {Name = "Sword", ATK = 100, DEF = 66 };
            equipmentFactory.AddEquipment(equipment.Name, equipment);
            Console.WriteLine(equipmentFactory.GetEquipment(equipment.Name).ATK);
            Console.ReadLine();
        }
    }

    #region Pratice2

    public interface IEquipment
    {
        string Name { get; set; }
        int ATK { get; set; }
        int DEF { get; set; }

    }

    public class Equipment : IEquipment
    {
        public string Name { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }
    }

    public class EquipmentFactory
    {
        private Dictionary<string, IEquipment> equipments = new Dictionary<string, IEquipment>();

        public void AddEquipment(string key, IEquipment equipment)
        {
            equipments[key] = equipment;
        }

        //享元模式的核心概念是共享同一個物件，所以當找不到時回傳null而不是建立新物件
        public IEquipment GetEquipment(string key)
        {
            if (!equipments.ContainsKey(key))
                return null;
            return equipments[key];
        }
    }

    #endregion

    #region Pratice 1
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
    #endregion
}