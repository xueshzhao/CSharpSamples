using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProgrames.TutorialSample
{
    class AnonymousDelegate
    {
        public void test()
        {
            Func<string, bool> Sample1 = s =>
             {
                 return s == "";
             };
            Func<int> sample2 = delegate { return 1; };
            Action<double> sample3 = d => { d = d + 10; };
            List<Student> students = new List<Student>();
            students.Add(new Student() { Age = 10, Score = 100 });
            Func<Student, bool> higher = s => s.Age>5;
            students.Where(higher).OrderBy(x=>x.Score);
            students.Take(0).Select(student => student.Score + 10);
        }
        
    }
    class Student
    {
    public int Age;
    public int Score;
    }
}
