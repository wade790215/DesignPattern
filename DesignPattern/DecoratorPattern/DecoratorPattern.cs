using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern
{
    internal class DecoratorPattern
    {
        //被裝飾者可以靈活的增加或刪除功能
        //不需修改代碼就可以增加功能
        public void Main()
        {
            IComponent gameobject = new GameObject();
            gameobject = new Transform(gameobject);
            gameobject = new Collider(gameobject);
            gameobject.AssemblyComponent();
            Console.WriteLine(gameobject.GetDescription());
        }
    }

    public class GameObject : IComponent
    {
        public void AssemblyComponent()
        {
            Console.WriteLine("Instantiate a gameobject.");
        }

        public string GetDescription()
        {
            return "a gameobject";
        }
    }

    public interface IComponent
    {
        void AssemblyComponent();
        string GetDescription();
    }

    public abstract class Component : IComponent
    {
        private IComponent component;

        public Component(IComponent component)
        {
            this.component = component;
        }

        public virtual void AssemblyComponent()
        {
            component.AssemblyComponent();
        }

        public virtual string GetDescription()
        {
            return component.GetDescription();
        }
    }

    public class Transform : Component
    {
        public Transform(IComponent component) : base(component)
        {
        }

        public override void AssemblyComponent()
        {
            base.AssemblyComponent();
            Console.WriteLine($"增加{GetType().Name}功能");
        }

        public override string GetDescription()
        {
            return base.GetDescription() + $",擁有{GetType().Name}功能";
        }
    }

    public class Collider : Component
    {
        public Collider(IComponent component) : base(component)
        {
        }

        public override void AssemblyComponent()
        {
            base.AssemblyComponent();
            Console.WriteLine($"增加{GetType().Name}功能");
        }

        public override string GetDescription()
        {
            return base.GetDescription() + $",擁有{GetType().Name}功能";
        }
    }
}
