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
            //Serialization JSON
            
            FileManager.SerializationToJSON(commments.GetList(), "comments.json"); 
            
            //Deserialization JSON
            
            List<Comment> commentsFromFileJSON =(List<Comment>)FileManager.DeserializationFromJSON("comments.json",new List<Comment>());
            Console.WriteLine("Comments from file json:\n");
            foreach (var comment in commentsFromFileJSON)
            {
                Console.WriteLine(comment);
                Console.WriteLine($"AuthorInfo.Uid={comment.AuthorInfo.Uid}");
                Console.WriteLine("------------------------");
            }
            
            //Serialization Binary
            
            FileManager.SerializationToBinary(commments.GetList(), "comments.bin"); 
            
            //Deserialization Binary
            
            List<Comment> commentsFromFileBinary = (List<Comment>)FileManager.DeserializationFromBinary("comments.bin");
            Console.WriteLine("Comments from file binary:\n");
            foreach (var comment in commentsFromFileBinary)
            {
                Console.WriteLine(comment);
                Console.WriteLine($"AuthorInfo.Uid={comment.AuthorInfo.Uid}");
                Console.WriteLine("------------------------");
            }
            
        }
    }
}
