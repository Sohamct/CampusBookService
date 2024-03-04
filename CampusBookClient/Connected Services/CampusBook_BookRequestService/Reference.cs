﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CampusBookClient.CampusBook_BookRequestService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CampusBook_BookRequestService.IBookRequestService")]
    public interface IBookRequestService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookRequestService/makeNewRequest", ReplyAction="http://tempuri.org/IBookRequestService/makeNewRequestResponse")]
        void makeNewRequest(string requester, string isbn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookRequestService/makeNewRequest", ReplyAction="http://tempuri.org/IBookRequestService/makeNewRequestResponse")]
        System.Threading.Tasks.Task makeNewRequestAsync(string requester, string isbn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookRequestService/cancelRequest", ReplyAction="http://tempuri.org/IBookRequestService/cancelRequestResponse")]
        void cancelRequest(string requester, string isbn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookRequestService/cancelRequest", ReplyAction="http://tempuri.org/IBookRequestService/cancelRequestResponse")]
        System.Threading.Tasks.Task cancelRequestAsync(string requester, string isbn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookRequestService/acceptRequest", ReplyAction="http://tempuri.org/IBookRequestService/acceptRequestResponse")]
        void acceptRequest(string owner, string requester, string isbn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookRequestService/acceptRequest", ReplyAction="http://tempuri.org/IBookRequestService/acceptRequestResponse")]
        System.Threading.Tasks.Task acceptRequestAsync(string owner, string requester, string isbn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookRequestService/rejectRequest", ReplyAction="http://tempuri.org/IBookRequestService/rejectRequestResponse")]
        void rejectRequest(string owner, string requester, string isbn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBookRequestService/rejectRequest", ReplyAction="http://tempuri.org/IBookRequestService/rejectRequestResponse")]
        System.Threading.Tasks.Task rejectRequestAsync(string owner, string requester, string isbn);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IBookRequestServiceChannel : CampusBookClient.CampusBook_BookRequestService.IBookRequestService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class BookRequestServiceClient : System.ServiceModel.ClientBase<CampusBookClient.CampusBook_BookRequestService.IBookRequestService>, CampusBookClient.CampusBook_BookRequestService.IBookRequestService {
        
        public BookRequestServiceClient() {
        }
        
        public BookRequestServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public BookRequestServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BookRequestServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public BookRequestServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void makeNewRequest(string requester, string isbn) {
            base.Channel.makeNewRequest(requester, isbn);
        }
        
        public System.Threading.Tasks.Task makeNewRequestAsync(string requester, string isbn) {
            return base.Channel.makeNewRequestAsync(requester, isbn);
        }
        
        public void cancelRequest(string requester, string isbn) {
            base.Channel.cancelRequest(requester, isbn);
        }
        
        public System.Threading.Tasks.Task cancelRequestAsync(string requester, string isbn) {
            return base.Channel.cancelRequestAsync(requester, isbn);
        }
        
        public void acceptRequest(string owner, string requester, string isbn) {
            base.Channel.acceptRequest(owner, requester, isbn);
        }
        
        public System.Threading.Tasks.Task acceptRequestAsync(string owner, string requester, string isbn) {
            return base.Channel.acceptRequestAsync(owner, requester, isbn);
        }
        
        public void rejectRequest(string owner, string requester, string isbn) {
            base.Channel.rejectRequest(owner, requester, isbn);
        }
        
        public System.Threading.Tasks.Task rejectRequestAsync(string owner, string requester, string isbn) {
            return base.Channel.rejectRequestAsync(owner, requester, isbn);
        }
    }
}
