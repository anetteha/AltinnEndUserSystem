﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BadASBusiness.GiveMeSome;
using BadASBusiness.HowYouDoin;
using BadASBusiness.Authenticate;
using BadASBusiness.ReporteeReallyRightRight;


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
            ReceiptExternal receipt;
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

                var archiveId = "";
                using (var receiptclient = new ReceiptExternalBasicClient())
                {
                    receipt = receiptclient.GetReceiptBasic(systemUserName, systemPassword, new ReceiptSearchExternal { ReceiptId = receiptId });
                    foreach (var reference in receipt.References.Where(reference => reference.ReferenceTypeName == ReferenceType.ArchiveReference))
                    {
                        archiveId = reference.ReferenceValue;
                    }
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

                using (var client = new ReporteeElementListExternalBasicClient())
                {
                    Console.WriteLine("Kode: {0}", pin);
                    var kode = Console.ReadLine();
                    var correspondances = client.GetReporteeElementListBasicV2(systemUserName, systemPassword, ssn, null, null,// , password, kode,
                           "AltinnPin", new ExternalSearchBEV2
                           {
                               Reportee = orgnr,
                               ToDate = DateTime.Now,
                               ArchiveReference = archiveId
                           }, 1044);

                    //..men var det nå denne:
                    //var response = client.GetCorrespondenceListForArchiveRefBasic(systemUserName, systemPassword, ssn, null, null, "AltinnPin", orgnr, archiveId, DateTime.Now, DateTime.Now.AddDays(10), 1044);
                }
            }
        }
    }
}
