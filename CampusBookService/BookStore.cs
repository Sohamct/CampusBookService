using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace CampusBookService
{
    [DataContract]
    public class BookStore
    {
        public static List<string> validBranches = new List<string> { "CE", "EC", "CH", "MH", "IC", "IT", "MCA", "BCA", "MBA", "BBA", "M.Pharm", "B.Pharm", "MBBS", "BDS" };
        [DataMember]
        public string isbn { get; set; }
        [DataMember]

        public string bookname { get; set; }
        [DataMember]

        public string authorname { get; set; }
        [DataMember]

        public int pages { get; set; }
        [DataMember]

        public string bookimage { get; set; }
        [DataMember]

        public string subject { get; set; }
        [DataMember]

        public string ownerUsername { get; set; }
        [DataMember]

        public string description { get; set; }
        [DataMember]

        public DateTime returnDate { get; set; }
        [DataMember]
        public bool isAvailable { get; set; }
        [DataMember]
        public string borrowerUsername { get; set; }
        [DataMember]
        public string branch { get; set; }

        public BookStore()
        {

        }
        public BookStore(string isbn, string bookName, string authorName, int pages, string ownerUsername, string subject, string description, DateTime returnDate, string branch)
        {
            this.isbn = isbn;
            this.bookname = bookName;
            this.authorname = authorName;
            this.pages = pages;
            this.ownerUsername = ownerUsername;
            this.subject = subject;
            this.description = description;
            this.returnDate = returnDate;
            this.branch = branch;
            this.isAvailable = true;
            this.borrowerUsername = null;
        }
    }
}
