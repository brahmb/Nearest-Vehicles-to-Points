using Nearest_Vehicles_to_points.Classes;
using System;
using System.Diagnostics;

namespace Nearest_Vehicles_to_points
{
    class Program
    {
        static void Main(string[] args)
        {
            DataProcess dataProcess = new DataProcess();
            Stopwatch stopWatch = new Stopwatch();

            // Load Data
            stopWatch.Start();
            dataProcess.LoadData();
            stopWatch.Stop();
            Console.WriteLine($"Data File read execution time : {stopWatch.ElapsedMilliseconds} ms");
            long totalMilliseconds = stopWatch.ElapsedMilliseconds;

            // Calculate distances
            stopWatch.Start();
            dataProcess.GetClosest(34.544909F, -102.100843F);
            dataProcess.GetClosest(32.345544F, -99.123124F);
            dataProcess.GetClosest(33.234235F, -100.214124F);
            dataProcess.GetClosest(35.195739F, -95.348899F);
            dataProcess.GetClosest(31.895839F, -97.789573F);
            dataProcess.GetClosest(32.895839F, -101.789573F);
            dataProcess.GetClosest(34.115839F, -100.225732F);
            dataProcess.GetClosest(32.335839F, -99.992232F);
            dataProcess.GetClosest(33.535339F, -94.792232F);
            dataProcess.GetClosest(32.234235F, -100.222222F);
            stopWatch.Stop();
            Console.WriteLine($"Closest position calculation execution time : {stopWatch.ElapsedMilliseconds} ms");
            totalMilliseconds += stopWatch.ElapsedMilliseconds;

            // Final
            Console.WriteLine($"Total execution time : {totalMilliseconds} ms");
            Console.Write("Press any key to continue...");
            Console.Read();

        }
    }
}
