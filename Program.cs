using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Laba_7
{
    class Program
    {
        static async Task Main(string[] args)
        {

            TaskManager taskManager = new TaskManager();
            var taskInfo = taskManager.GenerateArrayComments(8, 1000);

            var array =await taskInfo;
            //Filtered array by field Message contains(b)
            var filteredArrayByMessage = array.Where(comment=>comment.Message.Contains('b',StringComparison.OrdinalIgnoreCase));
            //Filtered array by field AuthorName contains(i)
            var filteredArrayByAuthorName = array.Where(comment => comment.AuthorInfo.Name.Contains('i', StringComparison.OrdinalIgnoreCase));
            //Filtered array by field DateSending < 2000 year
            var filteredArrayByDateSending = array.Where(comment => comment.DateSending.Year<2000);
            //Filtered array by field DateSending > 2004 year then by field AuthorName contains(p)
            var filteredArrayByDateSendingThenAuthorName = array.Where(comment => comment.DateSending.Year > 2004)
                .Where(comment => comment.AuthorInfo.Name.Contains('p', StringComparison.OrdinalIgnoreCase)
            );

            foreach (var comment in filteredArrayByDateSendingThenAuthorName)
            {
                Console.WriteLine(comment);
            }

            var countLatestComments = array.Count(comment => comment.DateSending > DateTime.Now.AddYears(-1));
            Console.WriteLine("Count of comments over the past year");
            Console.WriteLine(countLatestComments);

        }
    }
}
