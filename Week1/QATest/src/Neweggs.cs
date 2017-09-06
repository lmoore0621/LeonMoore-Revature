namespace QATest.src
{
    public class Neweggs
    {
        
    }

    public class ComputerFactory : Neweggs 
    {
        public Computer Instance<T>() where T : Computer, new()
        {
            return new T();
        }
    }

    public class MonitorFactory : Neweggs
    {
        
    }
}