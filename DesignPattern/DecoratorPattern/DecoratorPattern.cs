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
            //IComponent gameobject = new GameObject();
            //gameobject = new Transform(gameobject);
            //gameobject = new Collider(gameobject);
            //gameobject.AssemblyComponent();
            //Console.WriteLine(gameobject.GetDescription());

            //// 創建柯博文實例
            //ITransformerWeapon optimusPrime = new OptimusPrime();
            //Console.WriteLine("初始裝備：");
            //optimusPrime.EquipWeapon();
            //Console.WriteLine("-------------------");

            //// 使用槍砲裝飾柯博文
            //TransformerWeapon gunDecorator = new Gun();
            //gunDecorator.SetTransformerWeapon(optimusPrime);

            //// 顯示裝飾後的裝備
            //Console.WriteLine("添加槍砲後的裝備：");
            //gunDecorator.EquipWeapon();
            //Console.WriteLine("-------------------");

            //Console.ReadLine();

            Shape shape = new Shape();
            IShapeComponent fillColor = new FillColor(shape);
            IShapeComponent borderColor = new BorderColor(shape);
            IShapeComponent shadowColor = new ShadowColor(shape);
            fillColor.FillStyle();  
            borderColor.BorderStyle();  
            shadowColor.ShadowStyle();
            Console.ReadLine();
        }
    }

    #region 練習2

    public interface  IShapeComponent
    {
        void FillStyle();
        void BorderStyle();
        void ShadowStyle(); 
    }

    public class Shape: IShapeComponent
    {
        public void FillStyle()
        {
            Console.WriteLine("MyFillStyle:");
        }

        public void BorderStyle()
        {
            Console.WriteLine("MyBorderStyle:");
        }

        public void ShadowStyle()
        {
            Console.WriteLine("MyShadowStyle:");
        }
    }

    public class ShapeDecorator : IShapeComponent
    {
        private IShapeComponent shapeComponent;

        public ShapeDecorator(IShapeComponent shapeComponent)
        {
            this.shapeComponent = shapeComponent;
        }

        public virtual void FillStyle()
        {
            shapeComponent.FillStyle();
        }

        public virtual void BorderStyle()
        {
            shapeComponent.BorderStyle();
        }

        public virtual void ShadowStyle()
        {
            shapeComponent.ShadowStyle();
        }
    }

    public class FillColor : ShapeDecorator
    {
        public FillColor(IShapeComponent shapeComponent) : base(shapeComponent)
        {
        }

        public void AddFillStyle()
        {
            Console.WriteLine("Fill Red");
        }   

        public override void FillStyle()
        {
            base.FillStyle();
            AddFillStyle();
        }
    }

    public class BorderColor : ShapeDecorator
    {
        public BorderColor(IShapeComponent shapeComponent) : base(shapeComponent)
        {
        }

        public void AddBorderStyle()
        {
            Console.WriteLine("Border Red");
        }

        public override void BorderStyle()
        {
            base.BorderStyle();
            AddBorderStyle();
        }
    }

    public class ShadowColor : ShapeDecorator
    {
        public ShadowColor(IShapeComponent shapeComponent) : base(shapeComponent)
        {
        }

        public void AddShadowStyle()
        {
            Console.WriteLine("Shadow Red");
        }

        public override void ShadowStyle()
        {
            base.ShadowStyle();
            AddShadowStyle();
        }
    }

    #endregion

    #region 練習

    //我們用變形金剛來舉例：假設變形金剛裡的柯博文，他戰鬥時只有拳頭。
    //而我們為了增強他的戰鬥能力，所以給他加了槍砲及劍的武器在他身上。
    //首先要先將被裝飾者柯博文（ConcreteComponent）以及
    //裝飾者武器（Decorator）的介面（Component）建立起來

    public interface ITransformerWeapon
    {
        void EquipWeapon();
    }

    public class OptimusPrime : ITransformerWeapon
    {
        public OptimusPrime()
        {
            Console.WriteLine("柯博文");
        }

        public void EquipWeapon()
        {
            Console.WriteLine("我的武器有:");
        }
    }

    public class TransformerWeapon : ITransformerWeapon
    {
        private ITransformerWeapon transformerWeapon;

        public void SetTransformerWeapon(ITransformerWeapon transformerWeapon)
        {
            this.transformerWeapon = transformerWeapon;
        }

        public virtual void EquipWeapon()
        {
            transformerWeapon.EquipWeapon();
        }
    }

    public class Gun : TransformerWeapon
    {
        private void EquipGun()
        {
            Console.WriteLine("槍砲");
        }

        public override void EquipWeapon()
        {
            base.EquipWeapon();
            EquipGun();
        }
    }


    #endregion

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
