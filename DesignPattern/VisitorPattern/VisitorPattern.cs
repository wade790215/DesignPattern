using System;
using static DesignPattern.VisitorPattern;

namespace DesignPattern
{
    //訪問者模式是一種讓你可以在不更改對象結構的情況下並增加新操作的方式
    //優點:集中相關行為ICollisionVisitor擁有所有的行為，沒有分散在物件class上
    //缺點:若Visitor需要增加項目所有的訪問者都需要增加，訪問者可以直接取得物件的資料，違反封裝原則
    internal class VisitorPattern
    {
        internal void Main()
        {
            ICollidable player = new Player();
            ICollidable enemy = new Enemy();
            HandleCollision(player,enemy);
            HandleHealing(player);
        }

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

        }
    }
}