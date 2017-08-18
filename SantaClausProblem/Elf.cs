using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SantaClausProblem
{
    class Elf
    {
        private static int count = 0;
        private static object o = new object();
        public static void ElfTask()
        {
            while (true)
            {
                //Program.elfMutex.WaitOne();
                Program.elSem2.WaitOne();
                Program.m.WaitOne();
                Program.elfCount++;
                if (Program.elfCount == 3)
                {
                    //Console.WriteLine(Thread.CurrentThread.Name + "Santa");
                    Program.santaSem.Release();
                }
                else
                {
                    //Console.WriteLine(Thread.CurrentThread.Name);
                    //Program.elfMutex.ReleaseMutex();
                    Program.elSem2.Release(1);
                }
                Program.m.ReleaseMutex();
                Program.elfSem.WaitOne();
                GetHelp();
                Program.m.WaitOne();
                Program.elfCount--;
                if (Program.elfCount == 0)
                {
                    //Console.WriteLine(Thread.CurrentThread.Name);
                    //Program.elfMutex.ReleaseMutex();
                    Program.elSem2.Release(1);
                }
                Program.m.ReleaseMutex();
                //Thread.Sleep(100);
            }
        }

        private static void GetHelp()
        {
            Console.WriteLine("{0} getting help", Thread.CurrentThread.Name);
        }
    }
}
