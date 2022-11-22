using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk;
using Microsoft.Xrm.Tooling.Connector;

namespace Crm.TestProject
{
    public class CrmHelper
    {

        public CrmServiceClient ConnectCrm()
        {
            //readonly string _username = "testtest@democrm038.onmicrosoft.com";
            //readonly string _password = "Testhesap11";
            //readonly string _url = "https://orgefccab19.api.crm4.dynamics.com/XRMServices/2011/Organization.svc";



            string authType = "OAuth";
            string username = "testtest@democrm038.onmicrosoft.com";
            string password = "Testhesap11";
            string url = "https://orgefccab19.api.crm4.dynamics.com/XRMServices/2011/Organization.svc";
            string redirectUrl = "https://localhost/";
            string loginPrompt = "Auto";
            string ConnectionString =string.Format("AuthType={0};Username={1};Password={2};Url={3};RedirectUrl={4};LoginPrompt={5}",
                                        authType,username,password,url,redirectUrl,loginPrompt);

            CrmServiceClient svc = new CrmServiceClient(ConnectionString);
            return svc;
        }
    }
}
