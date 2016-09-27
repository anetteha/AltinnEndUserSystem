﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.SvcRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://AltInn.no/webservices/", ConfigurationName="SvcRef.OnlineBatchReceiverSoap")]
    public interface OnlineBatchReceiverSoap {
        
        // CODEGEN: Generating message contract since element name username from namespace http://AltInn.no/webservices/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://AltInn.no/webservices/ReceiveOnlineBatchExternalAttachment", ReplyAction="*")]
        Client.SvcRef.ReceiveOnlineBatchExternalAttachmentResponse ReceiveOnlineBatchExternalAttachment(Client.SvcRef.ReceiveOnlineBatchExternalAttachmentRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://AltInn.no/webservices/ReceiveOnlineBatchExternalAttachment", ReplyAction="*")]
        System.Threading.Tasks.Task<Client.SvcRef.ReceiveOnlineBatchExternalAttachmentResponse> ReceiveOnlineBatchExternalAttachmentAsync(Client.SvcRef.ReceiveOnlineBatchExternalAttachmentRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ReceiveOnlineBatchExternalAttachmentRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ReceiveOnlineBatchExternalAttachment", Namespace="http://AltInn.no/webservices/", Order=0)]
        public Client.SvcRef.ReceiveOnlineBatchExternalAttachmentRequestBody Body;
        
        public ReceiveOnlineBatchExternalAttachmentRequest() {
        }
        
        public ReceiveOnlineBatchExternalAttachmentRequest(Client.SvcRef.ReceiveOnlineBatchExternalAttachmentRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://AltInn.no/webservices/")]
    public partial class ReceiveOnlineBatchExternalAttachmentRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string username;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string passwd;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string receiversReference;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public long sequenceNumber;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string batch;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public byte[] attachments;
        
        public ReceiveOnlineBatchExternalAttachmentRequestBody() {
        }
        
        public ReceiveOnlineBatchExternalAttachmentRequestBody(string username, string passwd, string receiversReference, long sequenceNumber, string batch, byte[] attachments) {
            this.username = username;
            this.passwd = passwd;
            this.receiversReference = receiversReference;
            this.sequenceNumber = sequenceNumber;
            this.batch = batch;
            this.attachments = attachments;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ReceiveOnlineBatchExternalAttachmentResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ReceiveOnlineBatchExternalAttachmentResponse", Namespace="http://AltInn.no/webservices/", Order=0)]
        public Client.SvcRef.ReceiveOnlineBatchExternalAttachmentResponseBody Body;
        
        public ReceiveOnlineBatchExternalAttachmentResponse() {
        }
        
        public ReceiveOnlineBatchExternalAttachmentResponse(Client.SvcRef.ReceiveOnlineBatchExternalAttachmentResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://AltInn.no/webservices/")]
    public partial class ReceiveOnlineBatchExternalAttachmentResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string ReceiveOnlineBatchExternalAttachmentResult;
        
        public ReceiveOnlineBatchExternalAttachmentResponseBody() {
        }
        
        public ReceiveOnlineBatchExternalAttachmentResponseBody(string ReceiveOnlineBatchExternalAttachmentResult) {
            this.ReceiveOnlineBatchExternalAttachmentResult = ReceiveOnlineBatchExternalAttachmentResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface OnlineBatchReceiverSoapChannel : Client.SvcRef.OnlineBatchReceiverSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OnlineBatchReceiverSoapClient : System.ServiceModel.ClientBase<Client.SvcRef.OnlineBatchReceiverSoap>, Client.SvcRef.OnlineBatchReceiverSoap {
        
        public OnlineBatchReceiverSoapClient() {
        }
        
        public OnlineBatchReceiverSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OnlineBatchReceiverSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OnlineBatchReceiverSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OnlineBatchReceiverSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Client.SvcRef.ReceiveOnlineBatchExternalAttachmentResponse Client.SvcRef.OnlineBatchReceiverSoap.ReceiveOnlineBatchExternalAttachment(Client.SvcRef.ReceiveOnlineBatchExternalAttachmentRequest request) {
            return base.Channel.ReceiveOnlineBatchExternalAttachment(request);
        }
        
        public string ReceiveOnlineBatchExternalAttachment(string username, string passwd, string receiversReference, long sequenceNumber, string batch, byte[] attachments) {
            Client.SvcRef.ReceiveOnlineBatchExternalAttachmentRequest inValue = new Client.SvcRef.ReceiveOnlineBatchExternalAttachmentRequest();
            inValue.Body = new Client.SvcRef.ReceiveOnlineBatchExternalAttachmentRequestBody();
            inValue.Body.username = username;
            inValue.Body.passwd = passwd;
            inValue.Body.receiversReference = receiversReference;
            inValue.Body.sequenceNumber = sequenceNumber;
            inValue.Body.batch = batch;
            inValue.Body.attachments = attachments;
            Client.SvcRef.ReceiveOnlineBatchExternalAttachmentResponse retVal = ((Client.SvcRef.OnlineBatchReceiverSoap)(this)).ReceiveOnlineBatchExternalAttachment(inValue);
            return retVal.Body.ReceiveOnlineBatchExternalAttachmentResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Client.SvcRef.ReceiveOnlineBatchExternalAttachmentResponse> Client.SvcRef.OnlineBatchReceiverSoap.ReceiveOnlineBatchExternalAttachmentAsync(Client.SvcRef.ReceiveOnlineBatchExternalAttachmentRequest request) {
            return base.Channel.ReceiveOnlineBatchExternalAttachmentAsync(request);
        }
        
        public System.Threading.Tasks.Task<Client.SvcRef.ReceiveOnlineBatchExternalAttachmentResponse> ReceiveOnlineBatchExternalAttachmentAsync(string username, string passwd, string receiversReference, long sequenceNumber, string batch, byte[] attachments) {
            Client.SvcRef.ReceiveOnlineBatchExternalAttachmentRequest inValue = new Client.SvcRef.ReceiveOnlineBatchExternalAttachmentRequest();
            inValue.Body = new Client.SvcRef.ReceiveOnlineBatchExternalAttachmentRequestBody();
            inValue.Body.username = username;
            inValue.Body.passwd = passwd;
            inValue.Body.receiversReference = receiversReference;
            inValue.Body.sequenceNumber = sequenceNumber;
            inValue.Body.batch = batch;
            inValue.Body.attachments = attachments;
            return ((Client.SvcRef.OnlineBatchReceiverSoap)(this)).ReceiveOnlineBatchExternalAttachmentAsync(inValue);
        }
    }
}
