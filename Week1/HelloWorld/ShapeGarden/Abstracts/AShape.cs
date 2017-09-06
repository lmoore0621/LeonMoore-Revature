using ShapeGarden.Interfaces;

namespace ShapeGarden.Abstracts
{
    public abstract class AShape : IShape
    {
        public int Sides { get;}
        int IShape.Sides { get; set; }
        double IShape.Perimeter {get; set;}
        double IShape.Volume {get; set;}
        
        protected AShape(int s)
        {
            Sides = s;
        }
        
        public double Volume()
        {
            throw new System.NotImplementedException();
        }

        public virtual double Perimeter()
        {
            throw new System.NotImplementedException();
        }

        public abstract double Surface();
    }
}