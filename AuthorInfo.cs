using System;
using System.Text.Json.Serialization;

namespace Laba_7
{
    [Serializable]
    public class AuthorInfo
    {

        private string _uid;
        private string _name;

        public AuthorInfo(string uid, string name)
        {
            Uid = uid;
            Name = name;
        }

        [JsonPropertyName("Uid")]
        /// <summary>
        /// Uid user ,if empty or null init value return ArgumentNullException
        /// </summary>
        public string Uid
        {
            get => _uid; init =>
                _uid = !string.IsNullOrEmpty(value) ? value.Trim() : throw new ArgumentNullException();
        }

        [JsonPropertyName("Name")]
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
