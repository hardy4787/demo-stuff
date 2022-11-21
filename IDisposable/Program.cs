using System.Configuration;
using System.Data.SqlClient;
using Dapper;

namespace IDisposable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateConnectionsAndMemory(50);
            //EnforceFinilize();
            Console.WriteLine($"Total Allocated {ConnectionAndMemory.TotalAllocated}, Total Freed {ConnectionAndMemory.TotalFreed}");
        }

        private static void EnforceFinilize()
        {
            GC.Collect(3);
            GC.WaitForPendingFinalizers();
            GC.Collect(3);
        }

        private static void CreateConnectionsAndMemory(int quantity)
        {
            Random random = new Random();

            for (int i = 0; i < quantity; i++)
            {
                int chunkSize = random.Next(4096);
                Console.WriteLine(chunkSize);
                using var connectionAndMemory = new ConnectionAndMemory(chunkSize);
                connectionAndMemory.DoWork();
            }
        }
    }
}