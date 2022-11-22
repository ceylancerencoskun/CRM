using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;

namespace ConsoleAppCrm
{
    public class CrmHelper
    {
        public CrmServiceClient ConnectCrmService()
        {
            string authType = "OAuth";
            string username = "testtest@democrm038.onmicrosoft.com";
            string password = "Testhesap11";
            string url = "https://orgefccab19.crm4.dynamics.com";
            string aplicationId = "bf1e9002-54b3-4476-aae8-bb31e80600d1";
            string redirectUrl = "https://localhost/";
            string loginPrompt = "Auto";

            string ConnectionString = string.Format("AuthType={0};Username={1};Password={2};Url={3};AppId={4};RedirectUri={5};LoginPrompt={6}",
                                        authType, username, password, url, aplicationId, redirectUrl, loginPrompt);

            CrmServiceClient svc = new CrmServiceClient(ConnectionString);
            
            if (svc.IsReady)
            {

                return svc;
            }
            else
            {
                return null;
            }
        }
        public EntityCollection GetEntityCollection(string entityName)
        {
            try
            {
                QueryExpression query = new QueryExpression
                {
                    EntityName = entityName,
                    ColumnSet = new ColumnSet(true),
                    Criteria = new FilterExpression
                    {
                        Conditions =
                    {
                        //new ConditionExpression
                        //{
                        //    AttributeName = attributeName,
                        //    Operator = ConditionOperator.Equal,
                        //    Values = { attributeValue }
                        //}
                    }
                    }
                };
                var connectCrmService = ConnectCrmService();
                if (connectCrmService != null)
                {
                    return connectCrmService.RetrieveMultiple(query);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
            
        }


    }
}
