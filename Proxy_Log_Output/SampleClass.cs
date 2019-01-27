using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_Log_Output
{
    [Aspect]
    public class SampleClass : ContextBoundObject
    {

        public SampleClass()
        {
            //コンストラクタ
        }

        ~SampleClass()
        {
            //デストラクタ
        }

        public string SampleMethod(string str)
        {
            Console.WriteLine("SampleMethod Start!!");
            return null;
        }

        public string SampleMethod2(string str)
        {
            Console.WriteLine("SampleMethod2 Start!!");
            return null;
        }
    }
}
