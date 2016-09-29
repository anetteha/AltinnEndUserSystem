﻿using System;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Services;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

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
        public string ReceiveOnlineBatchExternalAttachment(string username, string passwd, string receiversReference, long sequenceNumber, string batch, [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")] byte[] attachments)
        {            
            if (Authenticate(username, passwd))
                // Verify batch vs. XSD (Schema verification)

                return Response(!VerifyBatchSchema(batch)? resultCodeType.FAILED_DO_NOT_RETRY : resultCodeType.OK);

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

            var filepath = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));

            var schemaSet = new XmlSchemaSet();
            schemaSet.Add("", filepath + "/xsd/genericbatch.2013.06.xsd");

            xdoc.Validate(schemaSet, (sender, e) =>
            {
                //TODO: Log
                result = false;
            });

            return result;
        }

        private string Response(resultCodeType code)
        {
            var receiptResult = new OnlineBatchReceiptResult
            {
                resultCode = code,
                resultCodeSpecified = false,
                Value = ""
            };

            var stringWriter = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(typeof(OnlineBatchReceiptResult));
            serializer.Serialize(stringWriter, receiptResult);
            return stringWriter.ToString();            
        }
    }
}
