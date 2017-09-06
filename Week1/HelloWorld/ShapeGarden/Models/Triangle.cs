using ShapeGarden.Abstracts;

namespace ShapeGarden.Interfaces
{
    public class Triangle : AShape
    {
        public Triangle() : base(3) {}

        public override double Surface()
        {
            throw new System.NotImplementedException();
        }
    }
}