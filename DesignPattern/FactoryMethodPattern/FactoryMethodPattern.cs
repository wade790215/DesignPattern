using System;
using System.Net.Http.Headers;

namespace DesignPattern
{
    //若產品線越來越多，則需要新增很多的工廠類別，這樣會造成類別過多，且不易維護
    internal class FactoryMethodPattern
    {
        //private ProductType productType;

        internal void Main()
        {
            //最基本的工廠寫法，具體類會耦合
            //IProduct product1 = null;
            //productType = ProductType.Drinks;

            //switch (productType)
            //{
            //    case ProductType.Drinks:
            //        product1 = new Drinks();
            //        break;
            //    case ProductType.Snack:
            //        product1 = new Snack();
            //        break;
            //    default:
            //        break;
            //}

            //Console.WriteLine(product1.GetProductName());

            //把工廠抽象出來的好處，減少具體類的耦合
            IProductFactory productFactory = new SnackFactory();
            IProduct product = productFactory.CreateProduct();
            Console.WriteLine(product.GetProductName());
        }

        public enum ProductType
        {
            Drinks,
            Snack
        }

        public interface IProductFactory
        {
            IProduct CreateProduct();
        }
        public interface IProduct
        {
            string GetProductName();
        }

        public class SnackFactory : IProductFactory
        {
            public IProduct CreateProduct()
            {
                return new Snack();
            }
        }

        public class DrinksFactory : IProductFactory
        {
            public IProduct CreateProduct()
            {
                return new Drinks();
            }
        }

        public class Drinks : IProduct
        {
            public string GetProductName()
            {
                return "Drinks";
            }
        }

        public class Snack : IProduct
        {
            public string GetProductName()
            {
                return "Snack";
            }
        }
    }
}