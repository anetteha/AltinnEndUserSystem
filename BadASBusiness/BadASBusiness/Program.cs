﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BadASBusiness.GiveMeSome;


namespace BadASBusiness
{
    class Program
    {
        static void Main(string[] args)
        {
            var rand = new Random();
            using (var sendForm = new GiveMeSome.IntermediaryInboundExternalBasicClient())
            {
                var respons = sendForm.SubmitFormTaskBasic("9151", "Testinator123", null, null, null, null,
                    new FormTaskShipmentBE
                    {
                        Reportee = "910293826",
                        ExternalShipmentReference = rand.Next().ToString(),
                        FormTasks =
                            new FormTask
                            {
                                ServiceCode = "3811",
                                ServiceEdition = 201501,
                                Forms = new List<Form>
                                    {
                                        new Form {Completed = false, DataFormatId = "1521", DataFormatVersion = 10634,
                                            FormData ="<![CDATA[<melding xmlns='http://seres.no/xsd/Kursdomene/LånesøknadJME_M/2011' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'><Innsender><søker><fødselsnummer>aaaaaaaaaaa</fødselsnummer><navn>String</navn></søker></Innsender></melding>]]>",
                                            EndUserSystemReference = "987654321"}
                                    }.ToArray()
                            }
                    });

                var receiptId = respons.ReceiptId;

                Thread.Sleep(200);
            }
        }
    }
}
