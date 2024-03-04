using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CampusBookService
{
    [DataContract]
    public class BookRequest
    {
        [DataMember]
        public string isbn { get; set; }
        [DataMember]
        public string requester { get; set; }
        [DataMember]
        public bool? status { get; set; }
        [DataMember]
        public DateTime requestDate { get; set; }

        public BookRequest(string isbn, string requester, bool? status, DateTime requestDate)
        {
            this.isbn = isbn;
            this.requester = requester;
            this.status = status;
            this.requestDate = requestDate;
        }
    }
}
