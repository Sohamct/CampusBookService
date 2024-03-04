﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CampusBookClient.CampusBook_BookStoreService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CampusBook_BookStoreService.IBookStoreService")]
    public interface IBookStoreService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookStoreService/getBooks", ReplyAction="http://tempuri.org/IBookStoreService/getBooksResponse")]
        System.Data.DataSet getBooks(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookStoreService/getBooks", ReplyAction="http://tempuri.org/IBookStoreService/getBooksResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> getBooksAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookStoreService/getBooksOfOwner", ReplyAction="http://tempuri.org/IBookStoreService/getBooksOfOwnerResponse")]
        System.Data.DataSet getBooksOfOwner(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookStoreService/getBooksOfOwner", ReplyAction="http://tempuri.org/IBookStoreService/getBooksOfOwnerResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> getBooksOfOwnerAsync(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookStoreService/GetBookByIsbn", ReplyAction="http://tempuri.org/IBookStoreService/GetBookByIsbnResponse")]
        CampusBookService.BookStore GetBookByIsbn(string isbn, string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookStoreService/GetBookByIsbn", ReplyAction="http://tempuri.org/IBookStoreService/GetBookByIsbnResponse")]
        System.Threading.Tasks.Task<CampusBookService.BookStore> GetBookByIsbnAsync(string isbn, string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookStoreService/EditBookByIsbn", ReplyAction="http://tempuri.org/IBookStoreService/EditBookByIsbnResponse")]
        CampusBookService.BookStore EditBookByIsbn(CampusBookService.BookStore book, byte[] bookImage, string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookStoreService/EditBookByIsbn", ReplyAction="http://tempuri.org/IBookStoreService/EditBookByIsbnResponse")]
        System.Threading.Tasks.Task<CampusBookService.BookStore> EditBookByIsbnAsync(CampusBookService.BookStore book, byte[] bookImage, string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookStoreService/deleteBook", ReplyAction="http://tempuri.org/IBookStoreService/deleteBookResponse")]
        void deleteBook(string isbn, string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookStoreService/deleteBook", ReplyAction="http://tempuri.org/IBookStoreService/deleteBookResponse")]
        System.Threading.Tasks.Task deleteBookAsync(string isbn, string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookStoreService/InsertBook", ReplyAction="http://tempuri.org/IBookStoreService/InsertBookResponse")]
        CampusBookService.BookStore InsertBook(CampusBookService.BookStore book, string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookStoreService/InsertBook", ReplyAction="http://tempuri.org/IBookStoreService/InsertBookResponse")]
        System.Threading.Tasks.Task<CampusBookService.BookStore> InsertBookAsync(CampusBookService.BookStore book, string username);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBookStoreServiceChannel : CampusBookClient.CampusBook_BookStoreService.IBookStoreService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BookStoreServiceClient : System.ServiceModel.ClientBase<CampusBookClient.CampusBook_BookStoreService.IBookStoreService>, CampusBookClient.CampusBook_BookStoreService.IBookStoreService {
        
        public BookStoreServiceClient() {
        }
        
        public BookStoreServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BookStoreServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BookStoreServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BookStoreServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet getBooks(string username) {
            return base.Channel.getBooks(username);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> getBooksAsync(string username) {
            return base.Channel.getBooksAsync(username);
        }
        
        public System.Data.DataSet getBooksOfOwner(string username) {
            return base.Channel.getBooksOfOwner(username);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> getBooksOfOwnerAsync(string username) {
            return base.Channel.getBooksOfOwnerAsync(username);
        }
        
        public CampusBookService.BookStore GetBookByIsbn(string isbn, string username) {
            return base.Channel.GetBookByIsbn(isbn, username);
        }
        
        public System.Threading.Tasks.Task<CampusBookService.BookStore> GetBookByIsbnAsync(string isbn, string username) {
            return base.Channel.GetBookByIsbnAsync(isbn, username);
        }
        
        public CampusBookService.BookStore EditBookByIsbn(CampusBookService.BookStore book, byte[] bookImage, string username) {
            return base.Channel.EditBookByIsbn(book, bookImage, username);
        }
        
        public System.Threading.Tasks.Task<CampusBookService.BookStore> EditBookByIsbnAsync(CampusBookService.BookStore book, byte[] bookImage, string username) {
            return base.Channel.EditBookByIsbnAsync(book, bookImage, username);
        }
        
        public void deleteBook(string isbn, string username) {
            base.Channel.deleteBook(isbn, username);
        }
        
        public System.Threading.Tasks.Task deleteBookAsync(string isbn, string username) {
            return base.Channel.deleteBookAsync(isbn, username);
        }
        
        public CampusBookService.BookStore InsertBook(CampusBookService.BookStore book, string username) {
            return base.Channel.InsertBook(book, username);
        }
        
        public System.Threading.Tasks.Task<CampusBookService.BookStore> InsertBookAsync(CampusBookService.BookStore book, string username) {
            return base.Channel.InsertBookAsync(book, username);
        }
    }
}
