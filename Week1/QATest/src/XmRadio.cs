using System.Threading;

namespace QATest.src
{
    public class XmRadio
    {
        public delegate void RadioSignal();
        public event RadioSignal MicHandler;    

        private static XmRadio _instance;

        private XmRadio()
        {
        }    

        public static XmRadio Instance 
        {
            get
            {
                // c# 4-
                // lock (_instance)
                // {
                //     if(_instance == null)
                //     {
                //         _instance = new XmRadio();
                //     }
                //     return _instance;
                // }
                if(_instance == null)
                {
                    _instance = new XmRadio();
                }
                return _instance;
            }
        }

        public void Broadcast()
        {
            var count = 1;

            while(count < 6)
            {
                Thread.Sleep(2000);
                System.Console.WriteLine("Playing side on 104.9FM...");
                
                if(MicHandler != null)
                {
                    MicHandler();
                }
                count += 1;
            }
        }
    }
}