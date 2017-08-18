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
        public static void ElfTask()
        {
            while (true)
            {
                Program.elfMutex.WaitOne();
                Program.m.WaitOne();
                Program.elfCount++;
                if (Program.elfCount == 3)
                {
                    Program.santaSem.Release();
                }
                else
                {
                    Program.elfMutex.ReleaseMutex();
                }
                Program.m.ReleaseMutex();
                Program.elfSem.WaitOne();
                GetHelp();
                Program.m.WaitOne();
                Program.elfCount--;
                if (Program.elfCount == 0)
                {
                    Console.WriteLine(Thread.CurrentThread.Name);
                    Program.elfMutex.ReleaseMutex();
                }
                Program.m.ReleaseMutex();
                Thread.Sleep(500);
            }
        }

        private static void GetHelp()
        {
            Console.WriteLine("Elf getting help");
        }
    }
}
