using System;
using System.Collections.Generic;
using System.Linq;
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
    public class OnlineBatchReceiverSoap : System.Web.Services.WebService
    {
        private const string FAILED_DO_NOT_RETRY = "FAILED_DO_NOT_RETRY";
        private const string FAILED = "FAILED";
        private const string OK = "OK";

        private static object semaphore = new object();
        private static string inboxDirPath;
        private static string logFilePath;
        private static string schFilePath;
        private static string rschFilePath;
        private static long logFileThresholdMB;
        private static string appName;
        private static System.Diagnostics.EventLog appLog = null;


        static OnlineBatchReceiverSoap()
        {
            GetConfig();
            appLog = new System.Diagnostics.EventLog();
            appLog.Source = appName;
            Log("Application Started");
        }

        [WebMethod]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://AltInn.no/webservices/ReceiveOnlineBatchExternalAttachment", 
            RequestNamespace = "http://AltInn.no/webservices/", 
            ResponseNamespace = "http://AltInn.no/webservices/", 
            Use = System.Web.Services.Description.SoapBindingUse.Literal, 
            ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ReceiveOnlineBatchExternalAttachment(string username, string passwd, string receiversReference, long sequenceNumber, string batch, [System.Xml.Serialization.XmlElementAttribute(DataType = "base64Binary")] byte[] attachments)
        {

            // Authenticate username + passw: if not authenticated: log, ignore message and return failed do not retry
            if (!Authenticate(username, passwd))
            {
                Log(string.Format("User not authenticated: {0}", username), true);
                return BuildResponse(FAILED_DO_NOT_RETRY);
            }


            // Verify batch vs. XSD (Schema verification) - if fails: log the error and return failed do not retry
            if (!VerifyBatchSchema(batch))
            {
                return BuildResponse(FAILED_DO_NOT_RETRY);
            }

            //Payload payload = new Payload()
            //{
            //    Username = username,
            //    Password = passwd,
            //    ReceiverReference = receiversReference,
            //    SequenceNumber = sequenceNumber,
            //    Batch = batch,
            //    Attachments = attachments
            //};

            // Save or add to queue - if fail, tell to resend or if duplicate - tell to ignore
            //int ret = ReceiveMessage(payload);
            //if (ret == 1)
            //    return BuildResponse(FAILED);
            //else if (ret == 2)
            //    return BuildResponse(FAILED_DO_NOT_RETRY);

            return BuildResponse(OK);
        }


        private string BuildResponse(string respMessage)
        {
            //var response = new Response
            //{
            //    Result = new Result
            //    {
            //        Code = respMessage
            //    }
            //};

            //var xmlResponse = Response.SerializeAsXml(response);
            //VerifyVsSchema(xmlResponse, rschFilePath);

            //return Response.SerializeAsXml(response);
            return "tobe..";
        }


        private bool Authenticate(string username, string password)
        {
            // TODO
            return true;
        }

        private bool VerifyBatchSchema(string batchXML)
        {
            return schFilePath != null ? VerifyVsSchema(batchXML, schFilePath) : true;
        }
            
        //private int ReceiveMessage(Payload payload)
        //{
        //    // return 0 for OK, 1 to retry, 2 to ignore (duplicate)

        //    string recref = payload.ReceiverReference != null ? payload.ReceiverReference : "";
        //    string filepath = Path.Combine(inboxDirPath, "pl_" + payload.GetHashCode().ToString() + "_" + recref + ".xml");

        //    if (File.Exists(filepath))
        //    {
        //        Log(string.Format("Duplicate message received {0}", filepath), true, EventLogEntryType.Warning);
        //        return 2;
        //    }

        //    try
        //    {
        //        if (payload.Attachments != null && payload.Attachments.Length > 0)
        //        {
        //            string attfilepath = filepath.Replace(".xml", ".zip");
        //            File.WriteAllBytes(attfilepath, payload.Attachments);
        //            payload.Attachments = null;
        //        }
        //        Payload.SerializeAsXml(payload, filepath);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log(ex.Message, true);
        //        return 1;
        //    }

        //    return 0;
        //}


        private static void GetConfig()
        {
            inboxDirPath = ConfigurationManager.AppSettings["inbox"];
            if (inboxDirPath == null)
            {
                inboxDirPath = HttpContext.Current.Server.MapPath("~/Inbox");
                if (!Directory.Exists(inboxDirPath))
                {
                    Directory.CreateDirectory(inboxDirPath);
                }
            }
            
            string logDirPath = ConfigurationManager.AppSettings["logdir"];
            if (logDirPath == null)
                logDirPath = HttpContext.Current.Server.MapPath("~");
            logFilePath = Path.Combine(logDirPath, "log.txt");

            schFilePath = ConfigurationManager.AppSettings["batch_schema_path"];
            rschFilePath = ConfigurationManager.AppSettings["response_schema_path"];
            string str = ConfigurationManager.AppSettings["log_thresholdMB"];
            long lstr;
            if (long.TryParse(str, out lstr))
                logFileThresholdMB = lstr;
            else
                logFileThresholdMB = 5;

            appName = ConfigurationManager.AppSettings["appname"];
            if (appName == null)
                appName = "Mottak";
        }
        

        private static bool VerifyVsSchema(string xml, string xsdFilePath)
        {
            XDocument xdoc;

            try
            {
                xdoc = XDocument.Parse(xml);
            }
            catch (Exception ex)
            {
                Log(string.Format("Failed to parse Data XML: {0} : {1}", ex.Message, xml), true);
                return false;
            }
            var schema = new XmlSchemaSet();

            try
            {
                schema.Add("", xsdFilePath);
            }
            catch (Exception ex)
            {
                Log(string.Format("Failed to load XSD Schema: {0} : {1}", ex.Message, xsdFilePath), true);
                return false;
            }          

            Boolean result = true;
            xdoc.Validate(schema, (sender, e) =>
            {
                result = false;
                Log(string.Format("Invalid Schema detected: {0} : {1}", e.Message, xml), true);
            });

            return result;
        }


        private static void Log(string msg, bool logToEvent = false, EventLogEntryType logEntryType = EventLogEntryType.Error)
        {
            lock(semaphore)
            {
                if (File.Exists(logFilePath))
                {
                    FileInfo fi = new FileInfo(logFilePath);
                    if (fi.Length > logFileThresholdMB * 1024 * 1000)
                    {
                        DateTime dt = DateTime.Now;
                        File.Move(logFilePath, logFilePath.Replace("log.txt", string.Format("log - {0}-{1:00}-{2:00} {3:00}.{4:00}.{5:00}.{6:000}.txt", dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond)));
                    }
                }
                try
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(logFilePath, true))
                    {
                        file.WriteLine($"{DateTime.Now}:{msg}");
                        file.WriteLine();
                    }
                    if (logToEvent)
                        appLog.WriteEntry(msg, logEntryType);
                }
                catch (Exception ex)
                { }
            }            
        }


        [WebMethod]
        public string HelloWorld()
        {
            return $"Hello World Time is {DateTime.Now}";
        }
    }
}
