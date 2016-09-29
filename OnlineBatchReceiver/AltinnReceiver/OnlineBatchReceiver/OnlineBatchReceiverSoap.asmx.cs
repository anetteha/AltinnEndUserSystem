using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Web.Services;
using System.Xml.Serialization;
using log4net;
using OnlineBatchReceiver.Utils;

namespace OnlineBatchReceiver
{
    /// <summary>
    /// Summary description for OnlineBatchReceiverSoap
    /// </summary>
    // [WebService(Namespace = "http://tempuri.org/")]
    // [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [WebServiceBinding(Name = "OnlineBatchReceiverSoap", Namespace = "http://AltInn.no/webservices/")]
    public class OnlineBatchReceiverSoap : WebService
    {
        private readonly ILog _logger;
        // Finds the directory where the app is deployed
        private readonly string _filepath = Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path));

        public OnlineBatchReceiverSoap()
        {
            _logger = LogManager.GetLogger(GetType());
        }

        [WebMethod]
        [System.Web.Services.Protocols.SoapDocumentMethod("http://AltInn.no/webservices/ReceiveOnlineBatchExternalAttachment",
            RequestNamespace = "http://AltInn.no/webservices/",
            ResponseNamespace = "http://AltInn.no/webservices/",
            Use = System.Web.Services.Description.SoapBindingUse.Literal,
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ReceiveOnlineBatchExternalAttachment(string username, string passwd, string receiversReference, long sequenceNumber, string batch, [XmlElement(DataType = "base64Binary")] byte[] attachments)
        {
            _logger.Info("ReceiveOnlineBatchExternalAttachment Recieved from: " + username);
            _logger.Debug("ReceiveOnlineBatchExternalAttachment Recieved from: " + username + " Batch: " + batch);

            // Authenticate username + passw
            if (!Authenticate(username, passwd))
            {
                _logger.Debug("ReceiveOnlineBatchExternalAttachment Invalid request");
                return Response(resultCodeType.FAILED_DO_NOT_RETRY);
            }
            _logger.Debug("ReceiveOnlineBatchExternalAttachment, User Aithenticated");
            // Verify batch vs. XSD (Schema verification)
            if (!XmlUtils.ValidateBatchXml(batch, _filepath, new List<string> { "/xsd/genericbatch.2013.06.xsd" }))
            {
                _logger.Debug("ReceiveOnlineBatchExternalAttachment Validation Failed");
                return Response(resultCodeType.FAILED_DO_NOT_RETRY);
            }

            try
            {
                var serializer = XmlUtils.GetXmlSerializerOfType<DataBatch>();
                var result = XmlUtils.DeserializeXmlString<DataBatch>(serializer, batch);

                // Saving payload to disk
                var filename = Guid.NewGuid() + "_" + username + "_" + receiversReference + "_" + sequenceNumber + ".xml";
                FileUtil.SaveXmlFileToDisk(_filepath, ConfigurationManager.AppSettings["RecievedXmlFolder"], filename, serializer, result);

                // TODO save attachments as zip
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return ex.Message;
            }

            _logger.Debug("ReceiveOnlineBatchExternalAttachment Validated OK ");
            return Response(resultCodeType.OK);
        }

        private static bool Authenticate(string username, string password)
        {
            // User is always Altinn, password cannot be empty
            return username == "Altinn" && !string.IsNullOrEmpty(password);
        }

        private string Response(resultCodeType code)
        {
            var receiptResult = new OnlineBatchReceiptResult
            {
                resultCode = code,
                resultCodeSpecified = true,
                Value = ""
            };

            return XmlUtils.SerializeXmlObjectToString(receiptResult);
        }
    }
}
