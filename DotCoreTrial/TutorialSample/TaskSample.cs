using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SampleProgrames.TutorialSample
{
    class TaskSample
    {
        Task[] loop;
        Func<Task> createTask;
        public void doSomething(Func<Task> creator)
        {
            System.Diagnostics.Contracts.Contract.Requires(creator != null);
            Action<Task> init = t =>
            {
                if (t != null)
                {
                    t.Start();
                }
                TimeSpan interval = TimeSpan.FromMilliseconds(100);
            };
            for(int i = 0; i < 5; i++)
            {
                bool success = true;
                try
                {
                    loop[i] = creator();
                    init(loop[i]);
                }catch(Exception e)
                {
                    success = false;
                }
                finally
                {
                    if (!success)
                    {
                        
                        //var result=loop.Where(t => !t.IsCanceled).Select(t => t.IsCanceled);
                        loop.Where(t => !t.IsCompleted).ToList().ForEach(t => t.Dispose());
                        //looloop.ToList().ForEach();
                        //log out and do something
                        


                    }
                }
                if (!success) break;
            }
            Task.WhenAll(loop).Wait();
        }

        const int NOT_START = 1;
        const int START = 2;
        const int SHUTINGDOWN = 3;
        const int SHUTDOWN = 4;
        const int STOP = 5;
        volatile int status = 1;
        public void loopFunc()
        {

            Task.Factory.StartNew(()=>
            {
                Interlocked.CompareExchange(ref status, NOT_START, START);
                try
                {
                    while(status== START)
                    {
                        //do what you want here
                        //real logic
                        for(; ; )
                        {

                        }
                        
                    }
                    //do clean up things here

                }catch(Exception e)
                {
                    //log exception and change status
                    status = SHUTDOWN;
                }
            }, CancellationToken.None,
                TaskCreationOptions.None,null);

            while (true)
            {
                if (string.IsNullOrEmpty("")) break;
                if (string.IsNullOrEmpty("")) return;
                //do other things here
                // call other functions

                bool done = false;
                try
                {
                    //do hard job here

                    done = true;
                }catch (Exception)
                {
                    //log exception or throw exception
                    done = false;
                    //clean up
                }
                finally
                {

                }
                if (done)
                {

                }
                else
                {

                }
            }
        }
        long cursor=0;
        async Task<long> taskTest()
        {

            await Task.Factory.StartNew(() =>
            {
                while (true)
                {

                }
            });
            return 1;
        }

    }
    
}
