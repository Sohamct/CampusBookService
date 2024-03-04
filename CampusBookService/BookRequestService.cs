using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CampusBookService
{
    public class BookRequestService : IBookRequestService
    {
        private string cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CampusBook;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void VerifyBookOwner(string owner, string isbn)
        {
            try
            {
                if (!PatronService.sessionTokens.ContainsKey(owner))
                {
                    throw new FaultException("Please login to the system.");
                }
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open(); 
                    SqlCommand cmd = new SqlCommand("SELECT 1 FROM BookStore WHERE isbn = @isbn AND ownerUsername = @ownerUsername", conn);
                    cmd.Parameters.AddWithValue("@isbn", isbn);
                    cmd.Parameters.AddWithValue("@ownerUsername", owner);
                    object result = cmd.ExecuteScalar() ?? throw new FaultException("User is not the owner of the book or book does not exist.");
                }
            }
            catch (SqlException ex)
            {
                throw new FaultException("Error while Verifying book ownership: " + ex.Message);
            }
        }
        public BookRequest FetchRequestStatus(string requester, string isbn)
        {
            try
            {
                BookRequest br = null;
                if (!PatronService.sessionTokens.ContainsKey(requester))
                {
                    throw new FaultException("Please login to the system.");
                }

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM BookRequest WHERE isbn = @isbn AND requester = @requester", conn);
                    cmd.Parameters.AddWithValue("@isbn", isbn);
                    cmd.Parameters.AddWithValue("@requester", requester);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        br = new BookRequest
                        (
                            reader["isbn"].ToString(),
                            requester = reader["requester"].ToString(),
                            reader["status"] as bool?,
                            Convert.ToDateTime(reader["requestDate"])
                        );
                    }
                }

                return br;
            }
            catch (SqlException ex)
            {
                throw new FaultException("Error while checking already requested: " + ex.Message);
            }
        }

        public void acceptRequest(string owner, string requester, string isbn)
        {
            try
            {
                VerifyBookOwner(owner, isbn);

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        SqlCommand cmdRequest = new SqlCommand("UPDATE BookRequest SET status = @status WHERE isbn = @isbn AND requester = @requester", conn, transaction);
                        cmdRequest.Parameters.AddWithValue("@isbn", isbn);
                        cmdRequest.Parameters.AddWithValue("@requester", requester);
                        cmdRequest.Parameters.AddWithValue("@status", 1);
                        cmdRequest.ExecuteNonQuery();

                        SqlCommand cmdStore = new SqlCommand("UPDATE BookStore SET isAvailable = @isAvailable, borrowerUsername = @borrowerUsername WHERE isbn = @isbn", conn, transaction);
                        cmdStore.Parameters.AddWithValue("@isAvailable", 0);
                        cmdStore.Parameters.AddWithValue("@isbn", isbn);
                        cmdStore.Parameters.AddWithValue("@borrowerUsername", requester);
                        cmdStore.ExecuteNonQuery();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new FaultException("Error while processing request: " + ex.Message);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new FaultException("Error while accepting request: " + ex.Message);
            }
        }

        public void cancelRequest(string requester, string isbn)
        {
            try
            {
                if (!PatronService.sessionTokens.ContainsKey(requester))
                {
                    throw new FaultException("Please login to the system.");
                }
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM BookRequest WHERE isbn = @isbn AND requester = @requester", conn);
                    cmd.Parameters.AddWithValue("@isbn", isbn);
                    cmd.Parameters.AddWithValue("@requester", requester);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new FaultException("Error while cancelling the request: " + e.Message);
            }
        }

        public void makeNewRequest(string requester, string isbn)
        {
            try
            {
                if (!PatronService.sessionTokens.ContainsKey(requester))
                {
                    throw new FaultException("Please login to the system.");
                }

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO BookRequest (isbn, requester) VALUES (@isbn, @requester)", conn);
                    cmd.Parameters.AddWithValue("@isbn", isbn);
                    cmd.Parameters.AddWithValue("@requester", requester);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw new FaultException("Error while making a new request: " + e.Message);
            }
        }

        public void rejectRequest(string owner, string requester, string isbn)
        {
            try
            {
                VerifyBookOwner(owner, isbn);
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM BookRequest WHERE isbn=@isbn AND requester=@requester", conn);
                    cmd.Parameters.AddWithValue("@isbn", isbn);
                    cmd.Parameters.AddWithValue("@requester", requester);
                    cmd.ExecuteNonQuery();
                }
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE BookStore SET isAvailable=@isAvailable WHERE isbn=@isbn", conn);
                    cmd.Parameters.AddWithValue("@isbn", isbn);
                    cmd.Parameters.AddWithValue("@isAvailable", 1);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new FaultException("Error while rejecting request: " + ex.Message);
            }
        }
        public DataSet fetchAllRequestsFromIsbn(string owner, string isbn)
        {
            try
            {
                VerifyBookOwner(owner, isbn);

                using (SqlConnection conn = new SqlConnection(cs))
                {
                    DataSet dataset = new DataSet();
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("SELECT * FROM BookRequest WHERE isbn = @isbn ORDER BY requestDate", conn);
                        cmd.Parameters.AddWithValue("@isbn", isbn);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dataset);
                    }
                    catch (SqlException ex)
                    {
                        throw new FaultException($"Failed to retrieve book requests: {ex.Message}");
                    }
                    return dataset;
                }
            }
            catch (Exception e)
            {
                throw new FaultException($"Error while fetching book requests: {e.Message}");
            }
        }

    }
}
