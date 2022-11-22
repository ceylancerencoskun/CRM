using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace crm.console
{
    internal class ConnectionHelper
    {
        readonly string _connectionName = string.Empty;
        readonly string _username = "testtest@democrm038.onmicrosoft.com";
        readonly string _password = "Testhesap11";
        readonly string _url = "https://orgefccab19.api.crm4.dynamics.com/XRMServices/2011/Organization.svc";

        public ConnectionHelper(string connectionName)
        {
            _connectionName = connectionName;
        }
        public IOrganizationService GetIOrganizationService(Guid? callerId = null)
        {
            IOrganizationService iOrganizationService = null;

            var crmConnection = GetCrmServiceClient(callerId);
            if(crmConnection!=null && crmConnection.IsReady)
            { 
                if(crmConnection.OrganizationServiceProxy != null)
                {
                    iOrganizationService = (IOrganizationService)crmConnection.OrganizationServiceProxy;
                }
                else if (crmConnection.OrganizationWebProxyClient != null)
                {
                    iOrganizationService = (IOrganizationService)crmConnection.OrganizationWebProxyClient;
                }
            }

            return iOrganizationService;
        }

        public CrmServiceClient GetCrmServiceClient(Guid? callerId = null)
        {
            CrmServiceClient crmServiceClient = null;

            //var connectionString =  Properties.Settings.Default[_connectionName].ToString();
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[_connectionName].ConnectionString;

            if(!string.IsNullOrEmpty(connectionString))
            {
                crmServiceClient = new CrmServiceClient(connectionString);

                if(callerId.HasValue && callerId.Value.Equals(Guid.Empty))
                {
                    crmServiceClient.CallerId = callerId.Value;
                }
            }

            return crmServiceClient;
        }

        public IOrganizationService Alternate()
        {
            IOrganizationService iOrganizationService = null;
            ClientCredentials clientCredentials = new ClientCredentials();
            clientCredentials.UserName.UserName = _username;
            clientCredentials.UserName.Password = _password;

            Uri organizationServiceUri = new Uri(_url);

            OrganizationServiceProxy organizationServiceProxy = new OrganizationServiceProxy(organizationServiceUri, null, clientCredentials, null);

            iOrganizationService = (IOrganizationService)organizationServiceProxy;

            return iOrganizationService;
        }
    }
}
