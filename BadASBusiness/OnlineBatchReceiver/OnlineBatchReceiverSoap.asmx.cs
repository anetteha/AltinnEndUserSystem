using System;
using System.Web.Services;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace OnlineBatchReceiver
{
    /// <summary>
    /// Summary description for OnlineBatchReceiverSoap
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [WebServiceBinding(Name = "OnlineBatchReceiverSoap", Namespace = "http://AltInn.no/webservices/")]
    public class OnlineBatchReceiverSoap : WebService
    {
        [WebMethod]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://AltInn.no/webservices/ReceiveOnlineBatchExternalAttachment",
            RequestNamespace = "http://AltInn.no/webservices/",
            ResponseNamespace = "http://AltInn.no/webservices/",
            Use = System.Web.Services.Description.SoapBindingUse.Literal,
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public OnlineBatchReceiptResult ReceiveOnlineBatchExternalAttachment(string username, string passwd, string receiversReference, long sequenceNumber, string batch, [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")] byte[] attachments)
        {
            // Authenticate username + passw
            if (Authenticate(username, passwd))
                // Verify batch vs. XSD (Schema verification)
                return Response(!VerifyBatchSchema(batch) ? resultCodeType.FAILED_DO_NOT_RETRY : resultCodeType.OK);

            //TODO: Log
            return Response(resultCodeType.FAILED_DO_NOT_RETRY);


        }

        private bool Authenticate(string username, string password)
        {
            // Trust everyone :)
            return true;
        }

        private static bool VerifyBatchSchema(string batchXml)
        {
            //Validerer skjema med xdocument
            var result = true;
            XDocument xdoc;

            try
            {
                xdoc = XDocument.Parse(batchXml);
            }
            catch (Exception ex)
            {
                //TODO: Log
                return false;
            }

            var schemaSet = new XmlSchemaSet();
            schemaSet.Add("", "xsd/genericbatch.2013.06.xsd");

            // TODO: Legge til denne filen på en smart måte?


            xdoc.Validate(schemaSet, (sender, e) =>
            {
                //TODO: Log
                result = false;
            });

            return result;
        }

        private OnlineBatchReceiptResult Response(resultCodeType code)
        {
            var respons = new OnlineBatchReceiptResult
            {
                resultCode = code,
                resultCodeSpecified = false,
                Value = ""
            };

            return respons;
        }
    }
}
