using ShapeGarden.Abstracts;

namespace ShapeGarden.Models
{
    public class Circle : AShape
    {
        public Circle() : base(int.MaxValue) {}

        public override double Surface()
        {
            throw new System.NotImplementedException();
        }
    }
}