using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using crm.webservice.Model;
using crm.webservice.CrmHelpers;
using Microsoft.Xrm.Sdk;
using crm.webservice.Map;

namespace crm.webservice
{
    /// <summary>
    /// Summary description for crmentegrations
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class crmentegrations : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<Contact> GetContactCollection()
        {
            string entityName = "contact";
            CrmHelper chelper = new CrmHelper();
            var contact = chelper.GetContactCollection(entityName);
            if (contact != null)
            {
                //Guid contactid = (Guid)contact[0].Id;
                return contact;

            }
            else
            {
                return null;// new EntityCollection();
            }
            
        }

        [WebMethod]
        public Contact GetContactSingleEntity(string entId)
        {
            string entityName = "contact";
            CrmHelper chelper = new CrmHelper();

            var en = chelper.GetContactSingleEntity(entityName, new Guid(entId));
            if (en != null)
            {
                return en;
            }
            else
            {
                return null;//new Entity();
            }

        }
        [WebMethod]
        public List<GeneralEntityValue> GetEntityValues(string entityName)
        {
            CrmHelper chelper = new CrmHelper();
            var gevs = chelper.GetEntityValues(entityName);
            if (gevs != null)
            {
                return gevs;
            }
            else
            {
                return null;//new Entity();
            }

        }

        [WebMethod]
        public Guid CreateContact(Contact contact)
        {
            Guid id = Guid.Empty;
            contact.Id = id;

            CrmHelper chelper = new CrmHelper();
            return  chelper.CreateContact(contact);
        }

        [WebMethod]
        public bool UpdateContact(Contact contact)
        {
            if (contact.Id == Guid.Empty)
            {
                return false;
                //"id olmayan kayıt guncellenemez"
            }
            CrmHelper chelper = new CrmHelper();
            return chelper.UpdateContact(contact);
        }

        [WebMethod]
        public bool DeleteSingleEntity(string entityName,string entityId)
        {
            CrmHelper chelper = new CrmHelper();
            return chelper.DeleteSingleEntity(entityName, entityId);
        }


    }


}
