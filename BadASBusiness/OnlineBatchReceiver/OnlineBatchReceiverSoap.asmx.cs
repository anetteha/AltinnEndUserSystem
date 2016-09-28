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
                return Response(FAILED_DO_NOT_RETRY);
            }

            // Verify batch vs. XSD (Schema verification)
            if (!VerifyBatchSchema(batch))
            {

                return Response(FAILED_DO_NOT_RETRY);
            }

            return Response(OK);
        }

        private bool Authenticate(string username, string password)
        {
            //Not much more todo
            return true;
        }

        private bool VerifyBatchSchema(string batchXML)
        {
            //Validerer skjema med xdocument
            var result = true;
            XDocument xdoc;

            try
            {
                xdoc = XDocument.Parse(batchXML);
            }
            catch (Exception ex)
            {
                result = false;
                //TODO: Log
                return result;
            }

            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add("", "c:\\genericbatch.2013.06.xsd");  // TODO: Legge til denne filen på en smart måte?


            xdoc.Validate(schemaSet, (sender, e) =>
            {
                //TODO: Log
                result = false;
            });

            return result;
        }

        private string Response(string message)
        {
            //TODO build response based on onlinebatchresponse

            var response = "svar fra mottak: " + message;
            return response;
        }
    }
}
