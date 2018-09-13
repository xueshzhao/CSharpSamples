using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace DotCoreTrial.TrialSample
{
    class FileOperationTrial
    {
        private static readonly long fileLength =10*1024*1024;
        public void generateFile(string path)
        {
            byte[] buffer = new byte[2000];
            System.DateTime start = DateTime.Now;
            int offset = 0;
            Random rand = new Random();
            using (FileStream ss = File.Open(path, FileMode.OpenOrCreate))
            {
                while (offset < fileLength)
                {
                    rand.NextBytes(buffer);
                    ss.Seek(offset,SeekOrigin.Begin);
                    ss.Write(buffer, 0, (int)Math.Min(buffer.Length, fileLength - offset));
                    offset += (int)Math.Min(buffer.Length, fileLength - offset)+1;
                    //Console.WriteLine(offset);
                }
                Console.WriteLine(string.Format("File length : {0}", ss.Length));
                ss.Flush();
                ss.Close();
                //ss.Dispose();
            }
            TimeSpan span = DateTime.Now - start;
            Console.WriteLine(string.Format("1: takes {0} ms to generate",span.Milliseconds));

            //int[] offsets = new int[5];
            start = DateTime.Now;
            //FileStream sss = File.Open(path, FileMode.OpenOrCreate);
            long s = 0;
            List<Task> tasks = new List<Task>();
            foreach(long end in this.getEnum(fileLength))
            {
                Task t = this.writeFile(path, s, end);
                tasks.Add(t);
                t.Start();
                s = end + 1;
            }
            Task.WaitAll(tasks.ToArray());
            span = DateTime.Now - start;
            FileStream sss = File.Open(path, FileMode.OpenOrCreate);
            Console.WriteLine(string.Format("File length : {0}", sss.Length));
            //sss.Flush();
            //sss.Close();
            Console.WriteLine(string.Format("2: takes {0} ms to generate", span.Milliseconds));

        }
        private IEnumerable<long> getEnum(long length)
        {
            //long start = 0;
            foreach(int i in Enumerable.Range(1, 5))
            {
                yield return i*2*1024*1024;
            }
        }
        private Task writeFile(string outFile, long offset, long ending)
        {
            return new Task(()=>
            {
                Random rand = new Random();
                byte[] buffer = new byte[2000];
                FileStream sss = File.Open(outFile, FileMode.Open, FileAccess.ReadWrite,FileShare.ReadWrite);
                while (offset < ending)
                {
                    rand.NextBytes(buffer);
                    sss.Seek(offset, SeekOrigin.Begin);
                    sss.Write(buffer, 0, (int)Math.Min(buffer.Length, ending - offset));
                    offset += Math.Min(buffer.Length, ending - offset)+1;
                    //Console.WriteLine(offset);
                }
                sss.Flush();
                sss.Close();
            });
        }
    }
}
