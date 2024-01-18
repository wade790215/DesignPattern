using System;

namespace DesignPattern
{
    internal class AdapterPattern
    {
        internal void Main()
        {
            //ITarget target = new Adapter();
            //target.Request();

            VectorGraphicAdapter vectorGraphicAdapter = new VectorGraphicAdapter(new VectorGraphic());
            vectorGraphicAdapter.Render();
            Console.ReadLine(); 
        }
    }

    #region Practice1
    public class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Called SpecificRequest()");
        }
    }

    public interface ITarget
    {
        void Request();
    }

    public class Adapter : ITarget
    {
        private Adaptee adaptee;

        public Adapter()
        {
            this.adaptee = new Adaptee();
        }

        public void Request()
        {
            adaptee.SpecificRequest(); 
        }
    }

    #endregion

    #region Practice2

    public interface IGraphicRenderer
    {
        void Render();
    }

    public class VectorGraphicAdapter : IGraphicRenderer
    {
        private VectorGraphic vectorGraphic;

        public VectorGraphicAdapter(VectorGraphic vectorGraphic)
        {
            this.vectorGraphic = vectorGraphic;
        }

        public void Render()
        {
            vectorGraphic.ThirtPatyRender();    
        }
    }

    public class VectorGraphic
    {
        public void ThirtPatyRender()
        {
            Console.WriteLine("ThirtPatyRender");
        }
    }

    #endregion
}