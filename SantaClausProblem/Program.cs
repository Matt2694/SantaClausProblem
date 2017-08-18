using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SantaClausProblem
{
    class Program
    {
        public static int elfCount = 0;
        public static int reindeerCount = 0;

        public static Semaphore santaSem = new Semaphore(0, 1);
        public static Semaphore reindeerSem = new Semaphore(9, 9);
        public static Semaphore elfSem = new Semaphore(3, 3);
        public static Semaphore elSem2 = new Semaphore(1, 1);

        public static Mutex m = new Mutex();
        //public static Mutex elfMutex = new Mutex();

        static Thread santaThread;
        static Thread[] reindeerThreads = new Thread[9];
        static Thread[] elfThreads = new Thread[3];

        static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }

        private void Run()
        {
            santaThread = new Thread(new ThreadStart(Santa.SantaTask));
            santaThread.Name = "Santa";
            santaThread.Start();
            for (int i = 0; i < 3; i++)
            {
                elfThreads[i] = new Thread(new ThreadStart(Elf.ElfTask));
                elfThreads[i].Name = "Elf #" + i;
                elfThreads[i].Start();
            }
            for (int i = 0; i < 9; i++)
            {
                reindeerThreads[i] = new Thread(new ThreadStart(Reindeer.ReindeerTask));
                reindeerThreads[i].Name = "Reindeer #" + i;
                reindeerThreads[i].Start();
                Thread.Sleep(100);
            }
        }


    }
}
