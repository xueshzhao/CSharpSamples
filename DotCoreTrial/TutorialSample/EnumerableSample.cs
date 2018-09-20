using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProgrames.TutorialSample
{
    class EnumerableSample
    {
        static void Main()
        {
            /*
            IEnumerable<Student> ies=Enumerable.Range(1, 5).Select((i,index)=>  new Student { Age = i,Score=index }).Where(stu=>stu.Age>1).OrderBy(stu=>stu.Score);
            foreach(Student stu in ies)
            {
                Console.WriteLine(string.Format("score={0}  age={1}", stu.Score, stu.Age));
                Console.WriteLine($"score={stu.Score}+age={stu.Age}");
            }
            */
            /**
            HttpClienSample hs = new HttpClienSample();
            string s=hs.getSparkApps();
            Application[] apps=hs.getApps(s);
            foreach(Application app in apps)
            {
                Console.WriteLine(hs.getJobStr(app));
            }
    */
            ListNode s = new ListNode(1);
            string[] ss = new string[] { "c", "c" };
            s.LongestCommonPrefix(ss);
            
        }
    }
}
