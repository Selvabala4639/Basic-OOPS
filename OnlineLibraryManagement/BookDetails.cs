using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineLibraryManagement
{
    public class BookDetails
    {
        /*
        1.	BookID (Auto Increment - BID1000)
2.	BookName
3.	AuthorName
4.	BookCount

        */
        private static int s_bookID = 1000;
        public string BookID { get; }
        public string BookName { get; set; } 
        public string AuthorName { get; set; }
        public int BookCount { get; set; }

        public BookDetails(string bookName, string authorName, int bookCount)
        {
            s_bookID++;
            BookID = "BID" + s_bookID;
            BookName = bookName;
            AuthorName = authorName;
            BookCount=  bookCount;
            
        }
        public BookDetails(string book)
        {
            string [] values = book.Split(",");
            s_bookID = int.Parse(values[0].Remove(0,3));
            BookID = values[0];
            BookName = values[1];
            AuthorName = values[2];
            BookCount=  int.Parse(values[3]);
        }
    }
}