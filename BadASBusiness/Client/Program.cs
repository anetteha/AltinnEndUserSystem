using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client;

namespace Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (SvcRef.OnlineBatchReceiverSoapClient proxy = new SvcRef.OnlineBatchReceiverSoapClient())
            {
                var result = proxy.ReceiveOnlineBatchExternalAttachment("username", "password123", "refMe", 123, "batch", null);

            }
        }
    }
}
