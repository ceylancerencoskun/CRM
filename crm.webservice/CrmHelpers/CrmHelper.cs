using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using crm.webservice.Map;
using crm.webservice.Model;
using System.Collections;
using System.IdentityModel.Metadata;

namespace crm.webservice.CrmHelpers
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
        public Contact GetContactSingleEntity(string entityName, Guid EntId)
        {
            try
            {
                var connectCrmService = ConnectCrmService();
                var ent = connectCrmService.Retrieve(entityName, EntId, new ColumnSet(true));

                if (ent != null)
                {
                    return EntityMap.GetEntity(ent);
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

        public List<Contact> GetContactCollection(string entityName)
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
                    return EntityMap.GetEntityCol(entityName, connectCrmService.RetrieveMultiple(query));
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

        public List<GeneralEntityValue> GetEntityValues(string entityName)
        {
            try
            {
                var connectCrmService = ConnectCrmService();
                var ents = connectCrmService.RetrieveMultiple(new QueryExpression { EntityName = entityName, ColumnSet = new ColumnSet(true) });

                if (ents != null)
                {
                    var gevs = new List<GeneralEntityValue>();
                    foreach (var items in ents.Entities)
                    {
                        foreach (var item in items.Attributes.Keys)
                        {
                            var gev = new GeneralEntityValue();
                            gev.KeyValue = item.ToString();
                            if (items[item.ToString()].ToString() == "Microsoft.Xrm.Sdk.OptionSetValue")
                            {
                                var ops = items.GetAttributeValue<OptionSetValue>(item.ToString());
                                gev.ContextValue = ops.ToString();
                            }
                            else
                            {
                                gev.ContextValue = items[item.ToString()].ToString();
                            }

                            gevs.Add(gev);
                        }
                    }


                    return gevs;
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

        public Guid CreateContact(Contact contact)
        {
            var connectCrmService = ConnectCrmService();
            if (connectCrmService != null)
            {
                return connectCrmService.Create(EntityMap.ContactToEntity(contact));
            }
            else
            {
                return Guid.Empty;
            }
        }

        public bool UpdateContact(Contact contact)
        {
            var connectCrmService = ConnectCrmService();
            if (connectCrmService != null)
            {
                try
                {
                    connectCrmService.Update(EntityMap.ContactToEntity(contact));
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool DeleteSingleEntity(string entityName,string entityId)
        {
            var connectCrmService = ConnectCrmService();
            if (connectCrmService != null)
            {
                try
                {
                    connectCrmService.Delete(entityName, new Guid(entityId));
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


    }
}
