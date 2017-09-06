namespace QATest.src
{
    public class XmSub
    {
        public void Subscribe(XmRadio r)
        {
            r.MicHandler += Listening;
        }

        public void UnSubscribe(XmRadio r)
        {
            r.MicHandler -= Listening;
        }

        private void Listening()
        {
            System.Console.WriteLine("smooth jazz rocks!!");
        }
    }
}