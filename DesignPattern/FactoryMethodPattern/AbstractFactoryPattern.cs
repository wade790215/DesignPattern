using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace DesignPattern
{
    //簡單工廠建立物件，利用反射來創建對應的物件，解決類別會過多的缺點
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