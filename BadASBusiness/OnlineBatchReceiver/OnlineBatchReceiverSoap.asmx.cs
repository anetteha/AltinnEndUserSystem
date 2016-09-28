using System;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Configuration;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Diagnostics;

namespace Mottak
{
    /// <summary>
    /// Summary description for OnlineBatchReceiverSoap
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [System.Web.Services.WebServiceBindingAttribute(Name = "OnlineBatchReceiverSoap", Namespace = "http://AltInn.no/webservices/")]
    public class OnlineBatchReceiverSoap : WebService
    {
        private const string FAILED_DO_NOT_RETRY = "FAILED_DO_NOT_RETRY";
        private const string FAILED = "FAILED";
        private const string OK = "OK";

        [WebMethod]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://AltInn.no/webservices/ReceiveOnlineBatchExternalAttachment",
            RequestNamespace = "http://AltInn.no/webservices/",
            ResponseNamespace = "http://AltInn.no/webservices/",
            Use = System.Web.Services.Description.SoapBindingUse.Literal,
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ReceiveOnlineBatchExternalAttachment(string username, string passwd, string receiversReference, long sequenceNumber, string batch, [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")] byte[] attachments)
        {

            // Authenticate username + passw
            if (!Authenticate(username, passwd))
            {
                //TODO: Log
                return FAILED_DO_NOT_RETRY;
            }

            // Verify batch vs. XSD (Schema verification)
            if (!VerifyBatchSchema(batch))
            {
                return FAILED_DO_NOT_RETRY;
            }

            return OK;
        }

        private bool Authenticate(string username, string password)
        {
            //TODO: Implement
            return true;
        }

        private bool VerifyBatchSchema(string batchXML)
        {
            //TODO: Verify schema
            return true;
        }
    }
}
