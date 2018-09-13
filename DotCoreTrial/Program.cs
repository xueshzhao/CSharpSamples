using System;
using DotCoreTrial.TrialSample;

namespace DotCoreTrial.HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Add for Git operation trial");
            Console.WriteLine("now we add a new branch");
            FileOperationTrial sample = new FileOperationTrial();
            sample.generateFile(@"d:/1.txt");
        }
    }
}
