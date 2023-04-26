using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace DesignPattern
{
    internal class AbstractFactoryPattern
    {
        internal void Main()
        {
            ProductFactory productFactory = new ProductFactory();
            IProduct product = productFactory.CreateProduct();
            Console.WriteLine(product.GetProductName());
        }
    }

    public class ProductFactory
    {
        private const string AssemblyName = "DesignPattern";

        public IProduct CreateProduct(string type)
        {
            switch (type)
            {
                case "Drinks":
                    return new Drinks();
                case "Snack":
                    return new Snack();
                default:
                    throw new Exception("No product found.");
            }
        }

        //反射+設定檔
        public IProduct CreateProduct()
        {
            string type = ConfigurationManager.AppSettings["ProductType"];
            string className = $"{AssemblyName}.{type}";
            Type productType = Type.GetType(className);

            if (productType == null)
            {
                throw new Exception("No product found.");
            }

            var product = Activator.CreateInstance(productType);
            return product as IProduct;
        }
    }

    public interface IProduct
    {
        string GetProductName();
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