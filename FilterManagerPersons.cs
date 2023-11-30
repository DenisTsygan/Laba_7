using System;
using System.Collections.Generic;
using System.Linq;

namespace Laba_7
{
    public class FilterManagerPersons
    {
        /// <summary>
        /// FIlter list persons by field and searchValue, return ArgumentNullException if list is null or field or searchValue is null or (searchValue is not int or string)
        /// </summary>
        /// <param name="list"> list for filter </param>
        /// <param name="field"> field in Person for filter </param>
        /// <param name="searchValue">search value for filter</param>
        /// <returns></returns>
        public static IEnumerable<Person> SearchByField (IEnumerable<Person> list , string field , object searchValue)
        {
            if(list is not null && !string.IsNullOrEmpty(field) && searchValue is not null && (searchValue is int || searchValue is string))
            {
                int valueInt ;
                string valueStr = searchValue.ToString();
                bool valueIsInt = int.TryParse(valueStr, out valueInt);
                if (!valueIsInt)
                {
                    switch (field)
                    {
                        case "FirstName":
                            return list.Where(people => people.FirstName.Contains(valueStr, StringComparison.OrdinalIgnoreCase));
                        case "LastName":
                            return list.Where(people => people.LastName.Contains(valueStr, StringComparison.OrdinalIgnoreCase));
                        case "Email":
                            return list.Where(people => people.Email.Contains(valueStr, StringComparison.OrdinalIgnoreCase));
                        case "IpAddress":
                            return list.Where(people => people.IpAddress.Contains(valueStr, StringComparison.OrdinalIgnoreCase));
                        case "Gender":
                            return list.Where(people => people.Gender.Contains(valueStr, StringComparison.OrdinalIgnoreCase));
                        default:
                            throw new ArgumentException("Person dont have string field for filter, like=" + field);
                    }
                }
                else
                {
                    switch (field)
                    {
                        case "Id":
                            return list.Where(people => people.Id== valueInt);
                        case "Age":
                            return list.Where(people => people.Age == valueInt);
                        default:
                            throw new ArgumentException("Person dont have int field for filter, like=" + field);
                    }
                }
                
            }
            else
            {
                throw new ArgumentException();
            }
            
        }
        /// <summary>
        /// Find max value By Field , return ArgumentException if list is null or uncorrect field
        /// </summary>
        /// <param name="list"> int field in Person for filter </param>
        /// <param name="field">field for </param>
        /// <returns></returns>
        public static int FindMaxValueByField(IEnumerable<Person> list, string field)
        {
            if (list is not null && !string.IsNullOrEmpty(field)){
                switch (field)
                {
                    case "Id":
                        return list.Max(people => people.Id);
                    case "Age":
                        return list.Max(people => people.Age);

                    default:
                        throw new ArgumentException("Person dont have int field for filter, like=" + field);
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }
        /// <summary>
        /// Find min value By Field , return ArgumentException if list is null or uncorrect field
        /// </summary>
        /// <param name="list"> int field in Person for filter </param>
        /// <param name="field">field for </param>
        /// <returns></returns>
        public static int FindMinValueByField(IEnumerable<Person> list, string field)
        {
            if (list is not null && !string.IsNullOrEmpty(field))
            {
                switch (field)
                {
                    case "Id":
                        return list.Min(people => people.Id);

                    case "Age":
                        return list.Min(people => people.Age);

                    default:
                        throw new ArgumentException("Person dont have int field for filter, like=" + field);
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }
        /// <summary>
        /// Find average value By Field , return ArgumentException if list is null or uncorrect field
        /// </summary>
        /// <param name="list"> int field in Person for filter </param>
        /// <param name="field">field for </param>
        /// <returns></returns>
        public static double FindAverageValuebyField(IEnumerable<Person> list, string field)
        {
            if (list is not null && !string.IsNullOrEmpty(field))
            {
                switch (field)
                {
                    case "Id":
                        return list.Sum(people => people.Id) / (double)list.Count();
                    case "Age":
                        return list.Sum(people => people.Id) / (double)list.Count();
                    default:
                        throw new ArgumentException("Person dont have int field for filter, like=" + field);
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
