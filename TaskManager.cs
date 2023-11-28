using System;
using System.Threading.Tasks;

namespace Laba_7
{
    public class TaskManager
    {
        /// <summary>
        /// delegate for sorting
        /// </summary>
        /// <param name="left">first Comment</param>
        /// <param name="right">second Comment</param>
        /// <returns></returns>
        private delegate bool Compare(Comment left, Comment right);

        /// <summary>
        /// Return new array with length(lengthArray) and random Comment, return ArgumentException if incorrect one of params
        /// </summary>
        /// <param name="countTheards">count theards to compleate this task</param>
        /// <param name="lengthArray">length return array</param>
        /// <returns></returns>
        public async Task<Comment[]> GenerateArrayComments(int countTheards,int lengthArray)
        {
            if(countTheards>0 && lengthArray>0 && countTheards < lengthArray)
            {
                Task[] tasks = new Task[countTheards];
                Comment[] arr = new Comment[lengthArray];
                int startIndex;
                int endIndex;
                int segmentSize = lengthArray / countTheards;
                for (int i = 0; i < countTheards; i++)
                {
                    startIndex = i * segmentSize;
                    endIndex = (i == countTheards - 1) ? lengthArray : (i + 1) * segmentSize;
                    tasks[i]= SetSegmentCommentsToArray(arr, startIndex, endIndex);
                }
                await Task.WhenAll(tasks);
                return arr;
            }
            else
            {
                throw new ArgumentException("Invalid params(countTheards or lengthArray)");
            }
        }


        /// <summary>
        /// Filling segment on array with random Coment
        /// </summary>
        /// <param name="array">array where filling occurs</param>
        /// <param name="startIndex">start index segment</param>
        /// <param name="endIndex">end index segment</param>
        /// <returns></returns>
        private async Task SetSegmentCommentsToArray(Comment[] array, int startIndex, int endIndex)
        {
            await Task.Run(() =>
            {
                for (int i = startIndex; i < endIndex; i++)
                {
                    array[i] = Comment.GenerateRandom();
                }
            });
           
        }
        /// <summary>
        /// Sort in multiple threads by field in array, return ArgumentException if incorrect one of params
        /// </summary>
        /// <param name="array">array to sort</param>
        /// <param name="field">sort by field in Comment</param>
        /// <param name="countTheards">count theardsto compleate this task</param>
        /// <returns></returns>
        public async Task SortByFieldInArrayParalel(Comment[] array, string field,int countTheards)
        {
            if(array is not null && !string.IsNullOrEmpty(field) && countTheards > 0)
            {
                Compare compare;
                switch (field)
                {
                    case "AuthorName":
                        compare = Comment.OrderByAuthorName;
                        break;
                    case "Message":
                        compare = Comment.OrderByMessage;
                        break;
                    case "DateSending":
                        compare = Comment.OrderByDateSending;
                        break;
                    default:
                        throw new ArgumentException("Comment dont have field for sort, like=" + field);
                }
                Task[] tasks = new Task[countTheards];
                int startIndex;
                int endIndex;
                int segmentSize = array.Length / countTheards;
                for (int i = 0; i < countTheards; i++)
                {
                    startIndex = i * segmentSize;
                    endIndex = (i == countTheards - 1) ? array.Length : (i + 1) * segmentSize;
                    tasks[i] = SortByFieldSegment(array, startIndex, endIndex, compare);
                }
                await Task.WhenAll(tasks);

                //Merger sorted segments array
                int startEndIndex;
                startIndex = 0;
                for (int i = 0; i < countTheards; i++)
                {
                    endIndex = (i == countTheards - 1) ? array.Length : (i + 1) * segmentSize;
                    startEndIndex = (i == countTheards - 1) ? array.Length : (i + 2) * segmentSize;
                    Merge(array, startIndex, endIndex, startEndIndex, compare);
                }

            }
            else
            {
                throw new ArgumentException();
            }

        }
        /// <summary>
        /// Sort in single thread by field in array, return ArgumentException if incorrect one of params
        /// </summary>
        /// <param name="array">array to sort</param>
        /// <param name="field">sort by field in Comment</param>
        /// <returns></returns>
        public void SortByFieldInArrayOneTheard(Comment[] array, string field)
        {
            if (array is not null )
            {
                Compare compare;
                switch (field)
                {
                    case "AuthorName":
                        compare = Comment.OrderByAuthorName;
                        break;
                    case "Message":
                        compare = Comment.OrderByMessage;
                        break;
                    case "DateSending":
                        compare = Comment.OrderByDateSending;
                        break;
                    default:
                        throw new ArgumentException("Comment dont have field for sort, like=" + field);
                }
                InsertionSort(array, 0, array.Length - 1, compare);
            }
            else
            {
                throw new ArgumentException();
            }
        }
        /// <summary>
        /// Sort in by field in segment array
        /// </summary>
        /// <param name="array">array to sort</param>
        /// <param name="startIndex">start index segment</param>
        /// <param name="endIndex">end index segment</param>
        /// <param name="compare">delegate for sorting</param>
        private async Task SortByFieldSegment(Comment[] array, int startIndex, int endIndex,Compare compare)
        {
            await Task.Run(() => {
                InsertionSort(array, startIndex, endIndex - 1, compare);
                }
            );
            
        }

        /// <summary>
        /// Insertion sort array
        /// </summary>
        /// <param name="array">array to sorted</param>
        /// <param name="minIndex">from what index to start sorting </param>
        /// <param name="maxIndex">at what index to start sorting</param>
        /// <param name="compare">delegate for sorting</param>
        private void InsertionSort(Comment[] array, int minIndex, int maxIndex, Compare compare)
        {
            for (int i = minIndex+1; i <= maxIndex; i++)
            {
                Comment key = array[i];
                int j = i - 1;

                while (j >= minIndex && !compare(key,array[j]))
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = key;
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="mid"></param>
        /// <param name="right"></param>
        /// <param name="compare"></param>
        private  void Merge(Comment[] array, int left, int mid, int right, Compare compare)
        {
            int length1 = mid - left;
            int length2 = right - mid;

            Comment[] leftArray = new Comment[length1];
            Comment[] rightArray = new Comment[length2];

            Array.Copy(array, left, leftArray, 0, length1);
            Array.Copy(array, mid, rightArray, 0, length2);

            int it1 = 0;
            int it2 = 0;

            while (it1 < length1 && it2 < length2)
            {
                if (!compare(leftArray[it1], rightArray[it2]))
                {
                    array[left] = leftArray[it1];
                    it1 += 1;
                }
                else
                {
                    array[left] = rightArray[it2];
                    it2 += 1;
                }

                left += 1;
            }

            while (it1 < length1)
            {
                array[left] = leftArray[it1];
                it1 += 1;
                left += 1;
            }

            while (it2 < length2)
            {
                array[left] = rightArray[it2];
                it2 += 1;
                left += 1;
            }
        }
    }
}
