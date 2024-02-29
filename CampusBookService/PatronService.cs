using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ServiceModel.Configuration;
using Microsoft.SqlServer.Server;
using System.ServiceModel;

namespace CampusBookService
{
    [DataContract]
    public class PatronService: IPatronService
    {
        private string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CampusBook;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static Dictionary<string, string> sessionTokens = new Dictionary<string, string>();

        public Patron GetPatronByUsername(string username)
        {
            //string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            Patron patron = null;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from Patron where username=@Username", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Username", username);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    patron = new Patron
                    {
                        fname = reader["firstname"].ToString(),
                        lname = reader["lastname"].ToString(),
                        uname = reader["username"].ToString(),
                        Branch = reader["branch"].ToString(),
                        password = reader["password"].ToString(),
                        registrationDate = (DateTime)reader["registrationDate"],
                    };
                }
            }
            return patron;

        }
        public Patron getPatronByUsernameAndPassword(string username, string password)
        {
            Patron patron = null;
            //string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from Patron where username=@Username and password=@Password", conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    patron = new Patron
                    {
                        fname = reader["firstname"].ToString(),
                        lname = reader["lastname"].ToString(),
                        uname = reader["username"].ToString(),
                        Branch = reader["branch"].ToString(),
                        password = "",
                        registrationDate = (DateTime)reader["registrationDate"],
                    };
                }
            }
            if (patron == null)
            {
                throw new FaultException("User not found!");
            }
            return patron;
        }
        public Patron LoginPatron(string uname, string password)
        {
            try
            {
                Patron pt = getPatronByUsernameAndPassword(uname, password);
                CreateSession(uname);
                return pt;
            }
            catch (Exception ex)
            {
                throw new FaultException("Error occured while login: "+ ex.Message);
            }
        }
        public Patron SignupPatron(Patron pt)
        {
            try
            {
                Console.WriteLine(pt);
                if (IsExistingPatron(pt.uname))
                {
                    throw new InvalidOperationException("A Patron with the provided username already exists!");
                }
                InsertPatron(pt);
                Patron newPatron = GetPatronByUsername(pt.uname);
                CreateSession(pt.uname);
                return newPatron;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to signup patron: {ex.Message}");
                throw new FaultException($"Failed to signup patron: {ex.Message}");
            }
        }
        private void CreateSession(string patronUsername)
        {
            string sessionToken = Guid.NewGuid().ToString();
            sessionTokens[patronUsername] = sessionToken;
            Console.WriteLine($"Session created for patron with ID {patronUsername}. Session token: {sessionToken}");
        }
 
        List<string> IPatronService.GetValidBranches()
        {
            return Patron.validBranches;
        }

        private void InsertPatron(Patron pt)
        {
            //string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Patron (username, firstname, lastname, branch, password) VALUES (@Username, @FirstName, @LastName, @Branch, @Password); SELECT SCOPE_IDENTITY()", conn);
                cmd.Parameters.AddWithValue("@Username", pt.uname);
                cmd.Parameters.AddWithValue("@FirstName", pt.fname);
                cmd.Parameters.AddWithValue("@LastName", pt.lname);
                cmd.Parameters.AddWithValue("@Branch", pt.Branch);
                cmd.Parameters.AddWithValue("@Password", pt.password);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private bool IsExistingPatron(string username)
        {
            bool exists = false;
            //string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Patron WHERE username = @Username", conn);
                cmd.Parameters.AddWithValue("@Username", username);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                exists = (count > 0);
            }
            return exists;
        }
        public bool LogoutPatron(string username)
        {
            if (sessionTokens.ContainsKey(username))
            {
                sessionTokens.Remove(username);
                return true;
            }
            else
            {
                return false;
            }
        }
    
    }
}