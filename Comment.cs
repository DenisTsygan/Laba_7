using System;


namespace Laba_7
{
    public class Comment
    {
        private DateTime _dateSending;
        private UserInfo _authorInfo;
        private string _message;

        public Comment(string uidAuthor, string nameAuthor, DateTime dateSending, string message)
        {
            DateSending = dateSending;
            Message = message;
            AuthorInfo = new UserInfo(uidAuthor, nameAuthor);
        }

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
        /// <summary>
        /// Info about author comment
        /// </summary>
        public UserInfo AuthorInfo { get => _authorInfo; init => _authorInfo = value; }
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
