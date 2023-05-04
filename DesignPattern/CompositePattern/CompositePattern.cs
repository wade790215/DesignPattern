using System;
using System.Collections.Generic;
using System.Text;
using static DesignPattern.CompositePattern;

namespace DesignPattern
{
    internal class CompositePattern
    {
        internal void Main()
        {
            //建立一個根節點
            var root = new Composite("root");

            //建立一個分支
            var branch1 = new Composite("branch1");
            var branch2 = new Composite("branch2");

            //建立一個葉節點
            var leaf1 = new Leaf("leaf1");
            var leaf2 = new Leaf("leaf2");
            var leaf3 = new Leaf("leaf3");

            //將葉節點加入分支
            branch1.Add(leaf1);
            branch1.Add(leaf3);
            branch2.Add(leaf2);

            //將分支加入根節點
            root.Add(branch1);
            root.Add(branch2);

            //顯示結構
            root.Display(1);

            Console.WriteLine("Node Information:");
            //Console.WriteLine(root.GetNodeInfo());
            //Console.WriteLine(branch1.GetNodeInfo());
            Console.WriteLine(branch1.GetAllNodeInfo());
            //Console.WriteLine(leaf1.GetNodeInfo());
        }

        public abstract class Component
        {
            protected string name;
            public Component(string name)
            {
                this.name = name;
            }
            public abstract void Add(Component c);
            public abstract void Remove(Component c);
            public abstract void Display(int deepth);

            public abstract string GetNodeInfo();
        }

        public class Leaf : Component
        {
            public Leaf(string name) : base(name)
            {

            }

            public override void Add(Component c)
            {
                Console.WriteLine("Cannot add a leaf");
            }

            public override void Remove(Component c)
            {
                Console.WriteLine("Cannot remove from a leaf");
            }

            public override void Display(int deepth)
            {
                Console.WriteLine(new string('-', deepth) + name);
            }

            public override string GetNodeInfo()
            {
                return "Leaf Node: " + name + "\n";
            }
        }

        public class Composite : Component
        {
            private List<Component> children = new List<Component>();
            public Composite(string name) : base(name)
            {

            }

            public override void Add(Component c)
            {
                children.Add(c);
            }

            public override void Remove(Component c)
            {
                children.Remove(c);
            }

            public override void Display(int deepth)
            {
                Console.WriteLine(new string('-', deepth) + name);
                foreach (Component component in children)
                {
                    component.Display(deepth + 2);
                }
            }

            public override string GetNodeInfo()
            {
                return "Composite Node: " + name + "\n";
            }

            public string GetAllNodeInfo(int depth = 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(new string('-', depth) + GetNodeInfo());

                foreach (var child in children)
                {
                    if (child is Composite composite)
                    {
                        sb.Append(composite.GetAllNodeInfo(depth + 2));
                    }
                    else
                    {
                        sb.Append(new string('-', depth + 2) + child.GetNodeInfo());
                    }
                }

                return sb.ToString();
            }
        }
    }
}