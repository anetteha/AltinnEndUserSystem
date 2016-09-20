using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BadASBusiness
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var sendForm = new GiveMeSome.IntermediaryInboundExternalBasicClient())
            {
                var respons = sendForm.SubmitFormTaskBasic("9151", "Testinator123", null, null, null, null, null);

            }
        }
    }
}
