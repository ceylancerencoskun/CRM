using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCrm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////OAuthConnect oAuth = new OAuthConnect();
            CrmHelper chelper = new CrmHelper();
            //CrmServiceClient service = chelper.ConnectCrm();

            //if (service.IsReady)
            //{


            //    //var qe = new QueryExpression() { EntityName = "contact", ColumnSet = new ColumnSet(true) };
            //    //var res = service.RetrieveMultiple(qe);



            //    var contact = CrmHelper.GetEntityCollection(service, "contact");
            //    Guid contactid = (Guid)contact[0].Id;

            //    Console.WriteLine(contactid);

            //    Console.Read();
            //}
            //else
            //{
            //    Console.WriteLine("Bağlanmadı!!!");
            //    Console.Read();
            //}
            Console.WriteLine(Guid.Empty);

            var contact = chelper.GetEntityCollection("contact");
            if(contact!=null)
            {
                Guid contactid = (Guid)contact[0].Id;
                string contactName = contact[0]["firstname"].ToString();

                Console.WriteLine(contactName);
                //var log = contact.Entities[0].KeyAttributes;
                //Console.WriteLine(log);
                foreach (var item in contact.Entities[0].Attributes.Keys)
                {
                    Console.WriteLine(item.ToString());
                }
                

            }
            else
            {
                Console.WriteLine("No Record");
            }
                
            Console.Read();
        }
    }
}
