namespace ShapeGarden.Interfaces
{
    public interface IShape
    {
        int Sides { get; set; }

        double Perimeter { get; set; }    
        double Volume { get; set; }                        
    } 
}
