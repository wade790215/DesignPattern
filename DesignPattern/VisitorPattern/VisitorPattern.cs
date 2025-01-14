using System;

namespace DesignPattern
{
    //訪問者模式是一種讓你可以在不更改對象結構的情況下並增加新操作的方式
    //優點:集中相關行為ICollisionVisitor擁有所有的行為，沒有分散在物件class上
    //缺點:若Visitor需要增加項目所有的訪問者都需要增加，訪問者可以直接取得物件的資料，違反封裝原則
    internal class VisitorPattern
    {
        internal void Main()
        {
            //ICollidable player = new Player();
            //ICollidable enemy = new Enemy();
            //HandleCollision(player,enemy);
            //HandleHealing(player);

            IComputerComponentAcceptor hardDrive = new HardDrive();
            IComputerComponentAcceptor cpu = new CPU();
            IComputerComponentAcceptor memory = new Memory();
            var CCD =  new ComputerComponentDiagnostics();
            hardDrive.Accept(CCD);
            cpu.Accept(CCD);
            memory.Accept(CCD);
            Console.ReadLine();
        }

        #region Pratice 2

        //訪問者接口
        public interface IComputerComponentVisitor
        {
            void VisitHardDrive(HardDrive hardDrive);
            void VisitCPU(CPU cpu);
            void VisitMemory(Memory memory);
        }

        //訪問者實作
        public class ComputerComponentDiagnostics : IComputerComponentVisitor
        {
            void IComputerComponentVisitor.VisitCPU(CPU cpu)
            {
                Console.WriteLine($"CPU Brand:{cpu.Brand}");
            }

            void IComputerComponentVisitor.VisitHardDrive(HardDrive hardDrive)
            {
                Console.WriteLine($"HardDrive Brand:{hardDrive.Brand}");
            }

            void IComputerComponentVisitor.VisitMemory(Memory memory)
            {
                Console.WriteLine($"Memory Brand:{memory.Brand}");
            }
        }

        //被訪問者接口
        public interface IComputerComponentAcceptor
        {
            void Accept(IComputerComponentVisitor visitor);
        }

        //被訪問者實作
        public class HardDrive : IComputerComponentAcceptor
        {
            public string Brand = "WD";
            public void Accept(IComputerComponentVisitor visitor)
            {
                visitor.VisitHardDrive(this);
            }
        }

        public class CPU : IComputerComponentAcceptor
        {
            public string Brand = "i7";
            public void Accept(IComputerComponentVisitor visitor)
            {
                visitor.VisitCPU(this);
            }
        }

        public class Memory : IComputerComponentAcceptor
        {
            public string Brand = "Kingston";
            public void Accept(IComputerComponentVisitor visitor)
            {
                visitor.VisitMemory(this);
            }
        }

        #endregion

        #region Pratice 1
        //定義訪問條件
        public void HandleCollision(ICollidable a, ICollidable b)
        {
            a.Accept(new CollisionHandler());
            b.Accept(new CollisionHandler());
        }

        public void HandleHealing(ICollidable a)
        {
            a.Accept(new HealingVisitor());
        }

        public class CollisionHandler : ICollisionVisitor
        {
            public void Visit(Player player)
            {
                player.DecreaseHP();
                Console.WriteLine($"相撞了..PlayerHealth:{player.Health}");
            }

            public void Visit(Enemy enemy)
            {
                enemy.DecreaseHP();
                Console.WriteLine($"相撞了..EnemyHealth:{enemy.Health}");
            }
        }

        public class HealingVisitor : ICollisionVisitor
        {
            public void Visit(Player player)
            {
                player.IncreaseHP();
                Console.WriteLine($"幫補...PlayerHealth:{player.Health}");
            }

            public void Visit(Enemy enemy)
            {
                enemy.IncreaseHP();
                Console.WriteLine($"幫補...EnemyHealth:{enemy.Health}");
            }
        }

        public interface ICollisionVisitor
        {
            void Visit(Player player);
            void Visit(Enemy enemy);
        }

        public interface ICollidable
        {
            void Accept(ICollisionVisitor visitor);
        }

        public class Player : ICollidable
        {
            private int health = 100;
            public int Health { get { return health; } private set { value = health; } }

            public void Accept(ICollisionVisitor visitor)
            {
                visitor.Visit(this);
            }

            public void DecreaseHP()
            {
                health -= 1;
            }

            public void IncreaseHP()
            {
                health += 1;
            }
        }

        public class Enemy : ICollidable
        {
            private int health = 100;
            public int Health { get { return health; } private set { value = health; } }

            public void Accept(ICollisionVisitor visitor)
            {
                visitor.Visit(this);
            }

            public void DecreaseHP()
            {
                health -= 1;
            }

            public void IncreaseHP()
            {
                health += 1;
            }
            #endregion
        }
    }


}