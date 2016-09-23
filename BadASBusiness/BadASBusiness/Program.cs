using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BadASBusiness.GiveMeSome;
using BadASBusiness.HowYouDoin;
using BadASBusiness.Authenticate;


namespace BadASBusiness
{
    class Program
    {
        static void Main(string[] args)
        {

            var activeUser = 2;

            var ssn = activeUser == 1 ? "02057901988" : "27047800515";
            var password = activeUser == 1 ? "even02057901988" : "julius27047800515";
            var systemUserName = activeUser == 1 ? "9151" : "9166";
            var orgnr = activeUser == 1 ? "910293826" : "910294121";
            var systemPassword = activeUser == 1 ? "Testinator123" : "JTestinator123";

            var rand = new Random();
            using (var sendForm = new IntermediaryInboundExternalBasicClient())
            {
                var respons = sendForm.SubmitFormTaskBasic(systemUserName, systemPassword, null, null, null, null,
                    new FormTaskShipmentBE
                    {
                        Reportee = orgnr,
                        ExternalShipmentReference = rand.Next().ToString(),
                        FormTasks =
                            new FormTask
                            {
                                ServiceCode = "3811",
                                ServiceEdition = 201501,
                                Forms = new List<Form>
                                    {
                                        new Form {Completed = false, DataFormatId = "1521", DataFormatVersion = 10634,
                                            FormData ="<melding xmlns='http://seres.no/xsd/Kursdomene/LånesøknadJME_M/2011' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'><Innsender><søker><fødselsnummer>aaaaaaaaaaa</fødselsnummer><navn>Frau Knoblauch</navn></søker></Innsender></melding>",
                                            EndUserSystemReference = "987654321"}
                                    }.ToArray()
                            }
                    });

                var receiptId = respons.ReceiptId;


                Thread.Sleep(200);

                using (var receiptclient = new ReceiptExternalBasicClient())
                {
                    var receipt = receiptclient.GetReceiptBasic(systemUserName, systemPassword, new ReceiptSearchExternal { ReceiptId = receiptId });
                }

                var pin = 0;
                using (var authenticate = new SystemAuthenticationExternalClient())
                {
                    AuthenticationChallengeBE auth;
                    do
                    {
                        Console.Write("Autehtiser! ");
                        var input = Console.ReadLine();

                        var request = new AuthenticationChallengeRequestBE()
                        {
                            AuthMethod = "AltinnPin",
                            UserSSN = ssn,
                            UserPassword = input
                        };

                        auth = authenticate.GetAuthenticationChallenge(request);
                        pin = int.Parse(auth.Message.Split(' ')[2]);

                        Console.WriteLine(auth.Status + "  -> " + pin);

                    } while (auth.Status != ChallengeRequestResult.Ok);
                    Console.ReadLine();
                }

                using (var client = new ReporteeReallyRightRight.ReporteeElementListExternalBasicClient())
                {
                    Console.WriteLine("Kode: {0}", pin);
                    var kode = Console.ReadLine();
                    var response = client.GetCorrespondenceListForArchiveRefBasic(systemUserName, systemPassword, ssn, password, kode, "AltinnPin", "", "", DateTime.Now.AddDays(-7), DateTime.Now, 1044);
                }
            }
        }
    }
}
