using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SantaClausProblem
{
    class Reindeer
    {
        public static void ReindeerTask()
        {
            while (true)
            {
                Program.m.WaitOne();
                Program.reindeerCount++;
                if (Program.reindeerCount == 9)
                {
                    Program.santaSem.Release();
                }
                Program.m.ReleaseMutex();
                Program.reindeerSem.WaitOne();
                GetHitched();
                Thread.Sleep(500);
            }
        }

        private static void GetHitched()
        {
            Console.WriteLine("Reindeer getting hitched");
        }
    }
}
