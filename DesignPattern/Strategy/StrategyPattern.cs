using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPattern
{
    internal class StrategyPattern
    {
        internal void Main()
        {
            //ShoppingCart shoppingCart = new ShoppingCart(new TwentyPercentOff());
            //shoppingCart.AddProduct(new TShirt { Price = 1000 });
            //shoppingCart.AddProduct(new Shoes { Price = 2000 });
            //Console.WriteLine($"Total price is {shoppingCart.CalculateTotalPrice()}");

            var factory = new ConcereteStrategyFactory();
            IRouteStrategy routeStrtegy = factory.CreateStrategy();

            var navigator = new Navigator();        
            navigator.SetRouteStrategy(routeStrtegy);
            navigator.BuildRoute();
            Console.ReadLine();
        }

        #region Pratice2

        public interface IStrategyFactory
        {
            IRouteStrategy CreateStrategy();
        }

        public class ConcereteStrategyFactory : IStrategyFactory
        {
            public IRouteStrategy CreateStrategy()
            {
                return new CarRouteStrategy();
            }
        }

        public interface IRouteStrategy
        {
            void BuildRoute();
        }

        public class Navigator
        {
            private IRouteStrategy routeStrategy;

            public void SetRouteStrategy(IRouteStrategy routeStrategy)
            {
                this.routeStrategy = routeStrategy;
            }

            public void BuildRoute()
            {
                routeStrategy.BuildRoute();
            }
        }

        public class CarRouteStrategy : IRouteStrategy
        {
            public void BuildRoute()
            {
                Console.WriteLine("Build route for car");
            }
        }

        public class WalkRouteStrategy : IRouteStrategy
        {
            public void BuildRoute()
            {
                Console.WriteLine("Build route for walk");
            }
        }
        #endregion

        #region Pratice
        public class ShoppingCart
        {
            private List<IProduct> products = new List<IProduct>();
            private IDiscountStrategy strategy;

            public ShoppingCart(IDiscountStrategy strategy)
            {
                this.strategy = strategy;
            }

            public void AddProduct(IProduct product)
            {
                products.Add(product);
            }

            public void RemoveProduct(IProduct product)
            {
                products.Remove(product);
            }

            public float CalculateTotalPrice()
            {
                float totalPrice = products.Sum(p => p.Price);
                return strategy.ApplyDiscount(totalPrice);
            }
        }

        public class TwentyPercentOff : IDiscountStrategy
        {
            public float ApplyDiscount(float price)
            {
                return price * 0.8f;
            }
        }

        public class BuyThousandGetHundred : IDiscountStrategy
        {
            public float ApplyDiscount(float price)
            {
                return price = price >= 1000f ? price * 0.9f : price;
            }
        }

        public class TShirt : IProduct
        {
            public string Name => "TShirt";

            public float Price { get; set; }
        }

        public class Shoes : IProduct
        {
            public string Name => "Addidas";

            public float Price { get; set; }
        }

        public interface IDiscountStrategy
        {
            float ApplyDiscount(float price);
        }

        public interface IProduct
        {
            string Name { get; }
            float Price { get; set; }
        }
        #endregion

    }


}