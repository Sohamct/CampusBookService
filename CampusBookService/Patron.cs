using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CampusBookService
{
    [DataContract]
    public class Patron
    {
        public static List<string> validBranches = new List<string> { "CE", "EC", "CH", "MH", "IC", "IT", "MCA", "BCA", "MBA", "BBA", "M.Pharm", "B.Pharm", "MBBS", "BDS" };
        [DataMember]
        public string fname;
        [DataMember]
        public string lname;
        [DataMember]
        public string uname;
        public string branch;
        [DataMember]
        public string password;
        [DataMember]
        public DateTime registrationDate;

        public Patron(string firstName, string lastName, string userName, string branch, string Password)
        {
            fname = firstName;
            lname = lastName;
            uname = userName;
            Branch = branch;
            password = Password;
            registrationDate = DateTime.Now;
        }
        public Patron() { }
        

        [DataMember]
        public string Branch
        {
            get { return branch; }
            set
            {
                if (validBranches.Contains(value)){
                    branch = value;
                }
                else
                {
                    throw new ArgumentException("Invalid branch.");
                }
            }
        }
    }
}