﻿using System;
using System.Text.Json.Serialization;

namespace Laba_7
{
    [Serializable]
    public class Comment
    {
        private DateTime _dateSending;
        private AuthorInfo _authorInfo;
        private string _message;

        [JsonConstructor]
        public Comment( DateTime dateSending, string message)
        {
            DateSending = dateSending;
            Message = message;
        }

        public Comment(string uidAuthor, string nameAuthor, DateTime dateSending, string message)
        {
            DateSending = dateSending;
            Message = message;
            AuthorInfo = new AuthorInfo(uidAuthor, nameAuthor);
        }

        [JsonPropertyName("DateSending")]
        /// <summary>
        /// Date of sending comment ,if incorrect init value return ArgumentException
        /// </summary>
        public DateTime DateSending { get => _dateSending; 
            init {
                if (value > DateTime.Now)
                {
                    throw new ArgumentException();
                }
                else
                {
                    _dateSending = value;
                }
            } 
        }

        [JsonPropertyName("AuthorInfo")]
        /// <summary>
        /// Info about author comment
        /// </summary>
        public AuthorInfo AuthorInfo { get => _authorInfo; init => _authorInfo = value; }

        [JsonPropertyName("Message")]
        /// <summary>
        /// Message in comment ,if empty or null init value return ArgumentNullException
        /// </summary>
        public string Message { get => _message; init =>
             _message = !string.IsNullOrEmpty(value) ? value.Trim() :throw new ArgumentNullException(); 
        }
        public override string ToString()
        {
            return $"Author:[{AuthorInfo.Name}]\nDate of sending:[{DateSending}]\nMessage:[{Message}]";
        }

        /// <summary>
        /// Sort by AuthorInfo.Name in ascending order, return ArgumentNullException if one of the parameters is null
        /// </summary>
        /// <param name="left">first comment</param>
        /// <param name="right">second comment</param>
        /// <returns></returns>
        public static bool OrderByAuthorName(Comment left, Comment right)
        {
            if(left is not null && right is not null)
            {
                return string.Compare(left.AuthorInfo.Name, right.AuthorInfo.Name, StringComparison.Ordinal) > 0;

            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Sort by Message in ascending order, return ArgumentNullException if one of the parameters is null
        /// </summary>
        /// <param name="left">first comment</param>
        /// <param name="right">second comment</param>
        /// <returns></returns>
        public static bool OrderByMessage(Comment left, Comment right)
        {
            if (left is not null && right is not null)
            {
                return string.Compare(left.Message, right.Message, StringComparison.OrdinalIgnoreCase) > 0;

            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Sort by AuthorInfo.Name in descending order, return ArgumentNullException if one of the parameters is null
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool OrderByDescendingAuthorName(Comment left, Comment right)
        {
            if (left is not null && right is not null)
            {
                return string.Compare(left.AuthorInfo.Name, right.AuthorInfo.Name, StringComparison.Ordinal) < 0;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Sort by DateSending in ascending order, return ArgumentNullException if one of the parameters is null
        /// </summary>
        /// <param name="left">first comment</param>
        /// <param name="right">second comment</param>
        /// <returns></returns>
        public static bool OrderByDateSending(Comment left, Comment right)
        {
            if (left is not null && right is not null)
            {
                return DateTime.Compare(left.DateSending, right.DateSending) > 0;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        /// <summary>
        /// Sort by DateSending in descending order, return ArgumentNullException if one of the parameters is null
        /// </summary>
        /// <param name="left">first comment</param>
        /// <param name="right">second comment</param>
        /// <returns></returns>
        public static bool OrderByDescendingDateSending(Comment left, Comment right)
        {
            if (left is not null && right is not null)
            {
                return DateTime.Compare(left.DateSending, right.DateSending) < 0;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Filter by AuthorInfo.Uid
        /// </summary>
        /// <param name="comment">comment</param>
        /// <param name="value">search value</param>
        /// <returns></returns>
        public static bool FilterByAuthorUid(Comment comment, string value)
        {
            if (comment is not null && !string.IsNullOrEmpty(value))
            {
                return string.Compare(comment.AuthorInfo.Uid, value, StringComparison.OrdinalIgnoreCase) == 0;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        /// <summary>
        /// Generate random fields in Comment
        /// </summary>
        /// <returns></returns>
        public static Comment GenerateRandom()
        {
            return new Comment(
                uidAuthor:Randomaizer.GenerateRandomString(),
                nameAuthor:Randomaizer.GenerateRandomString(),
                dateSending:Randomaizer.GenerateRandomDate(),
                message:Randomaizer.GenerateRandomString()
                );
        }

    }
}
