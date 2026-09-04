using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class Server
    {
        private static int count = 0;
        private static readonly ReaderWriterLockSlim locked = new ReaderWriterLockSlim();

        public static int GetCount()
        {
            locked.EnterReadLock();
            try
            {
                return count;
            }
            finally
            {
                locked.ExitReadLock();
            }
        }

        public static void AddToCount(int value)
        {
            locked.EnterWriteLock();
            try
            {
                Console.WriteLine("[Writer] Start writing...");
                Thread.Sleep(3000);
                count += value;
                Console.WriteLine($"[Writer] Added {value} to count");
            }
            finally
            {
                locked.ExitWriteLock();
            }
        }
    }
}