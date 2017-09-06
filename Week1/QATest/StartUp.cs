using System.Threading;
using QATest.src;

namespace QATest
{
    public class StartUp
    {
        public static void Main()
        {
            // //ThreadStuff();
            // AsyncStuff();
            // System.Console.WriteLine("It is done");
            FactoryPattern();
        }

        public static void EventStuff()
        {
            var r = XmRadio.Instance;
            var s = new XmSub();

            r.Broadcast();
            s.Subscribe(r);
            r.Broadcast();
        }

        public static void ThreadStuff()
        {
            var ap = new AsyncPro();
            ap.ThreadParty();
        }

        public static void TaskStuff()
        {
            var ap = new AsyncPro();

            ap.TaskParty();
        }

        public static void AsyncStuff()
        {
            var ap = new AsyncPro();

            ap.AsyncParty();
            Thread.Sleep(5000);
        }

        public static void FactoryPattern()
        {
            var g = new Gaming();
            var b = new Business();

            foreach (var item in g.stuff)
            {
                System.Console.WriteLine(item.GetType().FullName);
            }
        }

        public static void FactoryofFactories()
        {
            var n = new ComputerFactory();

            n.Instance<Gaming>();
        }
    }
}