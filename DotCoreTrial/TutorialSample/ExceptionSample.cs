using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProgrames.TutorialSample
{
    class ExceptionSample
    {
        public void test()
        {
            string str = null;
            try
            {
                
                str=str.ToLower();
            }
            catch
            {
                Console.WriteLine(String.Format("exception happened {0}", str == null ? str : ""));
                //throw;
            }
            finally
            {
                Console.WriteLine(string.Format("finally"));
            }
        }
    }
}
