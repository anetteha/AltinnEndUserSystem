using System.ServiceModel;
using RecieveForms.Messages;

namespace RecieveForms
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IGetAltinnForm" in both code and config file together.
    [ServiceContract]
    public interface IGetAltinnForm
    {
        [OperationContract]
        PushFormInlineAttachmentResponse PushFormInlineAttachment(object request);

        [OperationContract]
        PushFormExternalAttachmentResponse PushFormExternalAttachment(object request);
    }
}
