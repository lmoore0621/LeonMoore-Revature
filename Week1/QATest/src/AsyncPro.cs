using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QATest.src
{
    public class AsyncPro
    {
        private Dictionary<string, string> TStatus = new Dictionary<string, string>();
        public void ThreadParty()
        {
            var t1 = new Thread(() => {DoSomething("A");});
            var t2 = new Thread(() => {DoSomething("B");});

            t1.Start();
            t2.Start();

            DoSomething("1");

            if(t1.IsAlive)
            {

            }
            t1.Join();
            t2.Join();
        }   

        
        private void DoSomething(string s)
        {
            for(var x = 0; x < 1000; x++)
            {
                System.Console.WriteLine(s);
            }
        }

        public void TaskParty()
        {
            var t1 = new Task(() => {DoSomething("t1", "A");}, new CancellationToken());
            var t2 = new Task(() => {DoSomething("t2", "B");}, new CancellationToken());

            DoSomething("t0", "0");

            t1.Start();
            t2.Start();

            t1.ConfigureAwait(true);
            t2.ConfigureAwait(true);

            t1.ContinueWith((Task t) => {System.Console.WriteLine("cancled t1");});            
            t2.ContinueWith((Task t) => {System.Console.WriteLine("cancled t2");});            

            Task.WaitAny(new Task[]{t1, t2}, 1000);
            //Task.WaitAll(t1, t2);

            foreach (var item in TStatus)
            {
                System.Console.WriteLine("{0}: {1}", item.Key, item.Value );
            }
        }

        public Task AsyncParty()
        {
            return Task.Run(() => {
            T1Async().Start();
            T2Async().Start();

           DoSomething("t0", "0");
        });
        }

        private Task T1Async()
        {
            return new Task(() =>
            {
                DoSomething("t1", "A");
            });
        }

        private Task T2Async()
        {
            return new Task(() =>
            {
                DoSomething("t2", "B");
            });
        }

        private void DoSomething(string t, string s)
        {
            for(var x = 0; x < 10; x+=1)
            {
                System.Console.WriteLine(s);
            }
            TStatus[t] = "done";
        }


    }
}
