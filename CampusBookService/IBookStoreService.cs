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
    public interface IBookStoreService
    {
        [OperationContract]
        DataSet getBooks(string username);
        [OperationContract]
        DataSet getBooksOfOwner(string username);
        [OperationContract]
        BookStore GetBookByIsbn(string isbn, string username);
        [OperationContract]
        BookStore UpdateBookByIsbn(BookStore book,byte[] bookImage, string username, string oldIsbn);
        [OperationContract]
        void deleteBook(string isbn, string username);
        [OperationContract]
        BookStore InsertBook(BookStore book, string username);
        [OperationContract]
        DataSet GetBooksFromIsbns(List<string> isbn, string username);
    }
}
