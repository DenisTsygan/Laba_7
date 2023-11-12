using System;
using System.Collections.Generic;

namespace Laba_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Comment comment1 = new Comment(uidAuthor: "123egr33grfddfg", nameAuthor: "ded", dateSending: new DateTime(1234, 11, 15, 10, 4, 43), message: "gj!");
            Comment comment2 = new Comment(uidAuthor: "123egr33grfddfg", nameAuthor: "ded", dateSending: new DateTime(2004, 11, 15, 11, 4, 43), message: "hello....");
            Comment comment3 = new Comment(uidAuthor: "y50no508ebefdd333", nameAuthor: "molli", dateSending: new DateTime(2005, 11, 15, 3, 4, 37), message: "nice to meet you");
            Comment comment4 = new Comment(uidAuthor: "nbkdf9-n=234_33", nameAuthor: "boris", dateSending: new DateTime(2004, 11, 15, 1, 4, 43), message: "its was magic");
            Comment comment5 = new Comment(uidAuthor: "y50no508ebefdd333", nameAuthor: "molli", dateSending: new DateTime(2004, 11, 15, 1, 4, 43), message: "well done");

            Comments commments = new Comments(comment1, comment4, comment5, comment2, comment3);
            Console.WriteLine("Init list:");
            Console.WriteLine(commments);
            IListSortAndFilterManager.SortByField<Comment>(commments.GetList(), Comment.OrderByAuthorName);
            Console.WriteLine("After sort by AuthorName in ascending order:");
            Console.WriteLine(commments);
            
            IListSortAndFilterManager.SortByField<Comment>(commments.GetList(), Comment.OrderByDescendingDateSending);
            Console.WriteLine("After sort by DateSending in descending order:");
            Console.WriteLine(commments);

            //Lambda
            IListSortAndFilterManager.SortByField<Comment>(commments.GetList(), (Comment left, Comment right)=> DateTime.Compare(left.DateSending, right.DateSending) > 0);
            Console.WriteLine("After sort by DateSending in ascending order:");
            Console.WriteLine(commments);
            //Lambda end

            List< Comment > newComments1= (List<Comment>) IListSortAndFilterManager.FilterByField<Comment>(commments.GetList(), "y50no508ebefdd333", Comment.FilterByAuthorUid);
            Console.WriteLine("Filter by AuthorUid (y50no508ebefdd333):\n");
            foreach (var item in newComments1)
            {
                Console.WriteLine(item+"\n");
            }

            //Lambda
            List<Comment> newComments2 = (List<Comment>)IListSortAndFilterManager.FilterByField<Comment>(commments.GetList(), 
                "W",
                (Comment comment,string searchValue)=>comment.Message.Contains(searchValue,StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Filter by Message (W):\n");
            foreach (var item in newComments2)
            {
                Console.WriteLine(item + "\n");
            }
            //Lambda end

            //Anonymous method
            List<Comment> newComments3 = (List<Comment>)IListSortAndFilterManager.FilterByField<Comment>(commments.GetList(),
                "!",
                delegate(Comment comment, string searchValue) {
                    return comment.Message.Contains(searchValue, StringComparison.OrdinalIgnoreCase);
                }
            );
            Console.WriteLine("Filter by Message (!):\n");
            foreach (var item in newComments3)
            {
                Console.WriteLine(item + "\n");
            }
            //Anonymous method end
        }
    }
}
