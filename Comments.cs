using System;
using System.Collections.Generic;
using System.Text;

namespace Laba_7
{

    public class Comments
    {
        private List<Comment> _comments;
        /// <summary>
        /// if the comments is null , initialize _comments with zero length
        /// </summary>
        /// <param name="comments">elements to adding to the list</param>
        public Comments(params Comment[] comments)
        {
            if (comments is not null)
            {
                List<Comment> newList = new List<Comment>();
                foreach(var comment in comments)
                {
                    newList.Add(comment);
                }
                _comments = newList;
            }
            else
            {
                _comments = new List<Comment>();
            }
        }
        /// <summary>
        /// return list comments
        /// </summary>
        /// <returns></returns>
        public List<Comment> GetList()
        {
            return _comments;
        }
        /// <summary>
        /// adding the element to the List _comments, if element is null return ArgumentNullException
        /// </summary>
        /// <param name="element">element to the adding </param>
        public void AddElement(Comment element)
        {
            if(element is not null)
            {
                _comments.Add(element);
            }
            else
            {
                throw new ArgumentNullException();
            }
            
        }
        /// <summary>
        /// removing an element from  list  by index, if index is out of range return ArgumentOutOfRangeException
        /// </summary>
        /// <param name="indexRemove">index of the element to be removed</param>
        public void RemoveElementByIndex(int indexRemove)
        {
            _comments.RemoveAt(indexRemove);
        }
        /// <summary>
        /// Update element by index , if index is out of range return ArgumentOutOfRangeException,if element is null return ArgumentNullException
        /// </summary>
        /// <param name="element"> updated element</param>
        /// <param name="indexUpdate">index updated element</param>
        public void UpdateElementByIndex(Comment element, int indexUpdate)
        {
            if(element is not null)
            {
                if (indexUpdate > 0 && indexUpdate < _comments.Count)
                {
                    _comments[indexUpdate] = element;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
            
        }
        /// <summary>
        /// return new List,if empty or null string uid return ArgumentNullException
        /// </summary>
        /// <param name="uid">author uid of comment</param>
        public List<Comment> FindByAuthorUid(string uid)
        {
            if (!string.IsNullOrEmpty(uid))
            {
                return _comments.FindAll(el => el.AuthorInfo.Uid == uid);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        /// <summary>
        /// return new List ,if incorrect dateSending return ArgumentException
        /// </summary>
        /// <param name="dateSending"> date of sending comment</param>
        public List<Comment> FindByDateSending(DateTime dateSending)
        {
            if(dateSending > DateTime.Now)
            {
                throw new ArgumentException();
            }
            else
            {
                return _comments.FindAll(el => el.DateSending.Year == dateSending.Year && el.DateSending.Month == dateSending.Month && dateSending.Day == dateSending.Day);
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            foreach (var element in _comments)
            {
                str.Append(element + "\n\n");
            }
            return str.ToString();
        }

    }
}
