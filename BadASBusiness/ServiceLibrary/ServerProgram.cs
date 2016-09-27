using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;


namespace ServiceLibrary
{    public class ServerProgram
    {
        static void Main(string[] arguments)
        {
            Type serviceType = typeof(OnlineBatchReceiverSoap);
            ServiceHost myHost = new ServiceHost(serviceType);

            using (myHost)
            {
                myHost.Open();
                Console.WriteLine("Press enter to close..");
                Console.ReadLine();
                myHost.Close();

            }
        }
    }
}
