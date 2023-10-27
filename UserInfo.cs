using System;

namespace Laba_7
{
    public class UserInfo
    {

        private string _uid;
        private string _name;

        public UserInfo(string uid, string name)
        {
            Uid = uid;
            Name = name;
        }

        /// <summary>
        /// Uid user ,if empty or null init value return ArgumentNullException
        /// </summary>

        public string Uid
        {
            get => _uid; init =>
                _uid = !string.IsNullOrEmpty(value) ? value.Trim() : throw new ArgumentNullException();
        }
        /// <summary>
        /// Name user ,if empty or null init value return ArgumentNullException
        /// </summary>
        public string Name
        {
            get => _name; init =>
                _name = !string.IsNullOrEmpty(value) ? value.Trim() : throw new ArgumentNullException();
        }
    }
}
