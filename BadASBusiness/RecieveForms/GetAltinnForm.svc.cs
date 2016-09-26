using System;
using RecieveForms.Messages;

namespace RecieveForms
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GetAltinnForm" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select GetAltinnForm.svc or GetAltinnForm.svc.cs at the Solution Explorer and start debugging.
    public class GetAltinnForm : IGetAltinnForm
    {
        PushFormInlineAttachmentResponse IGetAltinnForm.PushFormInlineAttachment(object request)
        {
            throw new NotImplementedException();
        }

        PushFormExternalAttachmentResponse IGetAltinnForm.PushFormExternalAttachment(object request)
        {
            throw new NotImplementedException();
        }
    }
}
