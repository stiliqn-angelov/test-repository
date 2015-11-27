using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing_enviroment_console
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list=new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            Console.WriteLine(list[1].ToString());
            Console.WriteLine(list[2]);
            Console.Read();
        }
    }
}
