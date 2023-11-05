using System;
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
    }
}
