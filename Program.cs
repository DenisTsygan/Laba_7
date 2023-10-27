using System;
using System.Collections.Generic;

namespace Laba_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Comment comment1 = new Comment(uidAuthor: "123egr33grfddfg", nameAuthor: "ded", dateSending: new DateTime(1234, 11, 15,10,4,43), message: "gj!");
            Comment comment2 = new Comment(uidAuthor: "123egr33grfddfg", nameAuthor: "ded", dateSending: new DateTime(2004, 11, 15, 11, 4, 43), message: "hello....");
            Comment comment3 = new Comment(uidAuthor: "y50no508ebefdd333", nameAuthor: "molli", dateSending: new DateTime(2005, 11, 15, 3, 4, 37), message: "nice to meet you");
            Comment comment4 = new Comment(uidAuthor: "nbkdf9-n=234_33", nameAuthor: "boris", dateSending: new DateTime(2004, 11, 15, 1, 4, 43), message: "its was magic");
            Comment comment5 = new Comment(uidAuthor: "y50no508ebefdd333", nameAuthor: "molli", dateSending: new DateTime(2004, 11, 15, 1, 4, 43), message: "well done");

            Comments list= new Comments(comment1, comment4, comment5);
            Console.WriteLine("\nList");
            Console.WriteLine(list);
            Console.WriteLine("\nList add comment3,comment2");
            list.AddElement(comment3);
            list.AddElement(comment2);
            Console.WriteLine(list);
            Console.WriteLine("\nList1 found by author uid - y50no508ebefdd333");
            List<Comment> list1 = list.FindByAuthorUid("y50no508ebefdd333");
            foreach(var element in list1)
            {
                Console.WriteLine(element+"\n");
            }
            Console.WriteLine("\nList2 found by date of sending comment - 2004.11.15");
            List<Comment> list2 = list.FindByDateSending(new DateTime(2004, 11,15));
            foreach (var element in list2)
            {
                Console.WriteLine(element + "\n");
            }
            Console.WriteLine("\nList remove element by index 4,by index 0");
            list.RemoveElementByIndex(4);
            list.RemoveElementByIndex(0);
            Console.WriteLine(list);
            Console.WriteLine("\nUpdate by index 1 - comment1");
            list.UpdateElementByIndex(comment1, 1);
            Console.WriteLine(list);
            

        }
    }
}
