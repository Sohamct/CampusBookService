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
    public interface IPatronService
    {
        [OperationContract]
        Patron GetPatronByUsername(string username);
        [OperationContract]
        Patron SignupPatron(Patron pt);
        [OperationContract]
        List<string> GetValidBranches();
        [OperationContract]
        Patron LoginPatron(string username, string password);
        [OperationContract]
        bool LogoutPatron(string username);
        [OperationContract]
        DataSet GetPatronsFullNameByUsername(List<string> usernames);

    }
}
