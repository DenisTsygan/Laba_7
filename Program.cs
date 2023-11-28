using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Laba_7
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var sw = new Stopwatch();

            TaskManager taskManager = new TaskManager();
            var taskInfo = taskManager.GenerateArrayComments(8, 100000);

            var array =await taskInfo;
            
            sw.Start();
            await taskManager.SortByFieldInArrayParalel(array, "Message", 10);
            //taskManager.SortByFieldInArrayOneTheard(array, "Message");
            sw.Stop();
            Console.WriteLine("Sec=" + sw.Elapsed);
            
            /*
            //Parallel sorting with different numbers of threads
            Task sortTask1 = taskManager.SortByFieldInArrayParalel(array, "DateSending", 5);
            Task sortTask2 = taskManager.SortByFieldInArrayParalel(array, "DateSending", 10);
            await Task.WhenAll(sortTask1, sortTask2);
            
            */
            Console.WriteLine("end program");
        }
    }
}
