using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CampusBookService
{
    [ServiceContract]
    public interface IBookRequestService
    {
        [OperationContract]
        void makeNewRequest(string requester, string isbn);

        [OperationContract]
        void cancelRequest(string requester, string isbn);
        [OperationContract]
        void acceptRequest(string owner, string requester, string isbn);
        [OperationContract]
        void rejectRequest(string owner, string requester, string isbn);
        [OperationContract]
        BookRequest FetchRequestStatus(string requester, string isbn);
        [OperationContract]
        DataSet fetchAllRequestsFromIsbn(string owner, string isbn);
        [OperationContract]
        List<string> GetAllBorrowedIsbn(string borrowerUsername, bool status);
    }
}
