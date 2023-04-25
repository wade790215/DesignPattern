using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace DesignPattern
{
    internal class StrategyPattern
    {
        internal void Main()
        {
            ShoppingCart shoppingCart = new ShoppingCart(new TwentyPercentOff());

            shoppingCart.AddProduct(new TShirt { Price = 1000 });
            shoppingCart.AddProduct(new Shoes { Price = 2000 });

            Console.WriteLine($"Total price is {shoppingCart.CalculateTotalPrice()}");
        }


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

    }


}