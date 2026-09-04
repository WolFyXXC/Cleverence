using System;
using Task2;

class Program
{
    static void Main()
    {
        for (int i = 0; i < 7; i++)
        {
            int id_reader = i;
            Task.Run(() =>
            {
                while (true)
                {
                    int value = Server.GetCount();
                    Console.WriteLine($"[Reader {id_reader}] Read count: {value}");
                    Thread.Sleep(1000);
                }
            });
        }

        Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                Server.AddToCount(1);
                Thread.Sleep(3000);
            }
        });

        Console.ReadLine();
    }
}