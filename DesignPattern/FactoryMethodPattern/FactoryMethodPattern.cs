using System;
using System.Net.Http.Headers;

namespace DesignPattern
{
    internal class FactoryMethodPattern
    {
        private ProductType productType;

        internal void Main()
        {
            //最基本的工廠寫法，具體類會耦合Main
            IProduct product1 = null;
            productType = ProductType.Drinks;

            switch (productType)
            {
                case ProductType.Drinks:
                    product1 = new Drinks();
                    break;
                case ProductType.Snack:
                    product1 = new Snack();
                    break;
                default:
                    break;
            }

            Console.WriteLine(product1.GetProductName());

            //把工廠抽象出來的好處，減少具體類的耦合
            ProductFactory productFactory = new ProductFactory(ProductType.Drinks);
            IProduct product = productFactory.CreateProduct();
            Console.WriteLine(product.GetProductName());
        }
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

    public class ProductFactory : IProductFactory
    {
        private ProductType type;

        public ProductFactory(ProductType type)
        {
            this.type = type;
        }

        public IProduct CreateProduct()
        {
            switch (type)
            {
                case ProductType.Drinks:
                    return new Drinks();
                case ProductType.Snack:
                    return new Snack();
            }
            return null;
        }
    }

    public class SnackFactory : IProductFactory
    {
        public IProduct CreateProduct()
        {
            return new Snack();
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