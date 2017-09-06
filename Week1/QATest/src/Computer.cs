using System.Collections.Generic;

namespace QATest.src
{
    public abstract class Computer 
    {
        public List<Hardware> stuff = new List<Hardware>();

        protected Computer()
        {
            BuildComputer();
        }

        protected abstract void BuildComputer();
    }

    public class Gaming : Computer 
    {
        protected override void  BuildComputer()
        {
            stuff.Add(new Keyboard());
            stuff.Add(new Monitor());
            stuff.Add(new Monitor());
            stuff.Add(new HardDrive());    
            stuff.Add(new HardDrive());            
            stuff.Add(new HardDrive());            
        }
    }

    public class Business : Computer 
    {
        protected override void  BuildComputer()
        {
            stuff.Add(new Keyboard());
            stuff.Add(new Monitor());
            stuff.Add(new HardDrive());            
        }
    }
}