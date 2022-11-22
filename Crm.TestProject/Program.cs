using Crm.TestProject;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace crm.console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //OAuthConnect oAuth = new OAuthConnect();
            CrmHelper chelper = new CrmHelper();
            CrmServiceClient service = chelper.ConnectCrm();

            if (service.IsReady)
            {
                Console.WriteLine("Bağlandı");
            }else
            {
                Console.WriteLine("Bağlanmadı!!!");

            }
        }
    }
}
