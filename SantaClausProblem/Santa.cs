using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SantaClausProblem
{
    class Santa
    {
        public static void SantaTask()
        {
            while (true)
            {
                Program.santaSem.WaitOne();
                Program.m.WaitOne();
                if (Program.reindeerCount == 9)
                {
                    Program.reindeerCount = 0;
                    PrepSleigh();
                    Program.reindeerSem.Release(9);
                }
                else
                {
                    Program.elfSem.Release(3);
                    HelpElves();
                }
                Program.m.ReleaseMutex();
            }
        }

        private static void HelpElves()
        {
            Console.WriteLine("Santa helping elves");
        }

        private static void PrepSleigh()
        {
            Console.WriteLine("Santa prepping sleigh");
        }
    }
}
