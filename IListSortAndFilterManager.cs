using System.Collections.Generic;

namespace Laba_7
{
    public class IListSortAndFilterManager
    {
        public delegate bool CompareDelegate<T>(T left, T right);
        public delegate bool SearchDelegate<T>(T obj, string searchValue);

        /// <summary>
        /// Sort by field in IList<<typeparamref name="T"/>> 
        /// </summary>
        /// <typeparam name="T">class of objects</typeparam>
        /// <param name="colectionObjects">colection objects</param>
        /// <param name="compareDelegate">compare delegate</param>
        public static void SortByField<T>(IList<T> colectionObjects, CompareDelegate<T> compareDelegate)
        {
            for (int i = 0; i < colectionObjects.Count-1; i++)
            {
                for (int j = 0; j < colectionObjects.Count-1; j++)
                {
                    if (compareDelegate(colectionObjects[j], colectionObjects[j + 1]))
                    {
                        (colectionObjects[j], colectionObjects[j + 1]) = (colectionObjects[j + 1], colectionObjects[j]);
                    }
                }
            }
        }
        /// <summary>
        /// Filter in in IList<<typeparamref name="T"/>> by field
        /// </summary>
        /// <typeparam name="T">class of objects</typeparam>
        /// <param name="colectionObjects">colection objects</param>
        /// <param name="searchValue"> search value</param>
        /// <param name="searchDelegate"> search delegate</param>
        /// <returns></returns>
        public static IList<T> FilterByField<T>(IList<T> colectionObjects , string searchValue, SearchDelegate<T> searchDelegate)
        {
            IList<T> temp = new List<T>();
            for (int i = 0; i < colectionObjects.Count ; i++)
            {
               if(searchDelegate(colectionObjects[i], searchValue))
               {
                    temp.Add(colectionObjects[i]);
               }
            }
            return temp;
        }

    }
}
