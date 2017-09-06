using ShapeGarden.Abstracts;
using ShapeGarden.Interfaces;

namespace ShapeGarden.Models
{
    public class Rectangle : AShape
    {
        public Rectangle() : base(4) {}

        public override double Surface()
        {
            throw new System.NotImplementedException();
        }

        ~Rectangle() //Destructor - Finallizer
        {
            var s = new Square();
        }
    }
}