﻿
namespace ServiceLibrary
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://AltInn.no/webservices/", ConfigurationName = "OnlineBatchReceiverSoap")]
    public interface OnlineBatchReceiverSoap
    {

        // CODEGEN: Generating message contract since element name username from namespace http://AltInn.no/webservices/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Name = "sync", Action = "http://AltInn.no/webservices/ReceiveOnlineBatchExternalAttachment", ReplyAction = "*")]
        ReceiveOnlineBatchExternalAttachmentResponse ReceiveOnlineBatchExternalAttachment(ReceiveOnlineBatchExternalAttachmentRequest request);

        [System.ServiceModel.OperationContractAttribute(Name = "async", Action = "http://AltInn.no/webservices/ReceiveOnlineBatchExternalAttachment", ReplyAction = "*")]
        System.Threading.Tasks.Task<ReceiveOnlineBatchExternalAttachmentResponse> ReceiveOnlineBatchExternalAttachmentAsync(ReceiveOnlineBatchExternalAttachmentRequest request);
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class ReceiveOnlineBatchExternalAttachmentRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "ReceiveOnlineBatchExternalAttachment", Namespace = "http://AltInn.no/webservices/", Order = 0)]
        public ReceiveOnlineBatchExternalAttachmentRequestBody Body;

        public ReceiveOnlineBatchExternalAttachmentRequest()
        {
        }

        public ReceiveOnlineBatchExternalAttachmentRequest(ReceiveOnlineBatchExternalAttachmentRequestBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://AltInn.no/webservices/")]
    public partial class ReceiveOnlineBatchExternalAttachmentRequestBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string username;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 1)]
        public string passwd;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 2)]
        public string receiversReference;

        [System.Runtime.Serialization.DataMemberAttribute(Order = 3)]
        public long sequenceNumber;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 4)]
        public string batch;

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 5)]
        public byte[] attachments;

        public ReceiveOnlineBatchExternalAttachmentRequestBody()
        {
        }

        public ReceiveOnlineBatchExternalAttachmentRequestBody(string username, string passwd, string receiversReference, long sequenceNumber, string batch, byte[] attachments)
        {
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
    [System.ServiceModel.MessageContractAttribute(IsWrapped = false)]
    public partial class ReceiveOnlineBatchExternalAttachmentResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Name = "ReceiveOnlineBatchExternalAttachmentResponse", Namespace = "http://AltInn.no/webservices/", Order = 0)]
        public ReceiveOnlineBatchExternalAttachmentResponseBody Body;

        public ReceiveOnlineBatchExternalAttachmentResponse()
        {
        }

        public ReceiveOnlineBatchExternalAttachmentResponse(ReceiveOnlineBatchExternalAttachmentResponseBody Body)
        {
            this.Body = Body;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace = "http://AltInn.no/webservices/")]
    public partial class ReceiveOnlineBatchExternalAttachmentResponseBody
    {

        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue = false, Order = 0)]
        public string ReceiveOnlineBatchExternalAttachmentResult;

        public ReceiveOnlineBatchExternalAttachmentResponseBody()
        {
        }

        public ReceiveOnlineBatchExternalAttachmentResponseBody(string ReceiveOnlineBatchExternalAttachmentResult)
        {
            this.ReceiveOnlineBatchExternalAttachmentResult = ReceiveOnlineBatchExternalAttachmentResult;
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface OnlineBatchReceiverSoapChannel : OnlineBatchReceiverSoap, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OnlineBatchReceiverSoapClient : System.ServiceModel.ClientBase<OnlineBatchReceiverSoap>, OnlineBatchReceiverSoap
    {

        public OnlineBatchReceiverSoapClient()
        {
        }

        public OnlineBatchReceiverSoapClient(string endpointConfigurationName) :
                base(endpointConfigurationName)
        {
        }

        public OnlineBatchReceiverSoapClient(string endpointConfigurationName, string remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public OnlineBatchReceiverSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public OnlineBatchReceiverSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
                base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ReceiveOnlineBatchExternalAttachmentResponse OnlineBatchReceiverSoap.ReceiveOnlineBatchExternalAttachment(ReceiveOnlineBatchExternalAttachmentRequest request)
        {
            return base.Channel.ReceiveOnlineBatchExternalAttachment(request);
        }

        public string ReceiveOnlineBatchExternalAttachment(string username, string passwd, string receiversReference, long sequenceNumber, string batch, byte[] attachments)
        {
            ReceiveOnlineBatchExternalAttachmentRequest inValue = new ReceiveOnlineBatchExternalAttachmentRequest();
            inValue.Body = new ReceiveOnlineBatchExternalAttachmentRequestBody();
            inValue.Body.username = username;
            inValue.Body.passwd = passwd;
            inValue.Body.receiversReference = receiversReference;
            inValue.Body.sequenceNumber = sequenceNumber;
            inValue.Body.batch = batch;
            inValue.Body.attachments = attachments;
            ReceiveOnlineBatchExternalAttachmentResponse retVal = ((OnlineBatchReceiverSoap)(this)).ReceiveOnlineBatchExternalAttachment(inValue);
            return retVal.Body.ReceiveOnlineBatchExternalAttachmentResult;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ReceiveOnlineBatchExternalAttachmentResponse> OnlineBatchReceiverSoap.ReceiveOnlineBatchExternalAttachmentAsync(ReceiveOnlineBatchExternalAttachmentRequest request)
        {
            return base.Channel.ReceiveOnlineBatchExternalAttachmentAsync(request);
        }

        public System.Threading.Tasks.Task<ReceiveOnlineBatchExternalAttachmentResponse> ReceiveOnlineBatchExternalAttachmentAsync(string username, string passwd, string receiversReference, long sequenceNumber, string batch, byte[] attachments)
        {
            ReceiveOnlineBatchExternalAttachmentRequest inValue = new ReceiveOnlineBatchExternalAttachmentRequest();
            inValue.Body = new ReceiveOnlineBatchExternalAttachmentRequestBody();
            inValue.Body.username = username;
            inValue.Body.passwd = passwd;
            inValue.Body.receiversReference = receiversReference;
            inValue.Body.sequenceNumber = sequenceNumber;
            inValue.Body.batch = batch;
            inValue.Body.attachments = attachments;
            return ((OnlineBatchReceiverSoap)(this)).ReceiveOnlineBatchExternalAttachmentAsync(inValue);
        }
    }
}
