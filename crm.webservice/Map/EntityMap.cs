using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using crm.webservice.Model;
using System.IdentityModel.Metadata;

namespace crm.webservice.Map
{
    public class EntityMap
    {
        public static List<Contact> GetEntityCol(string EntName, EntityCollection col)
        {
            List<Contact> contactList = new List<Contact>();
            if (EntName == "contact")
            {
                foreach (var item in col.Entities)
                {
                    Contact ct = new Contact();

                    ct.Id = item.Id;
                    ct.Firstname = item.GetAttributeValue<string>("firstname");
                    ct.Lastname= item["lastname"].ToString();

                    contactList.Add(ct);
                }
            }
            return contactList;
        }
        public static Contact GetEntity(Entity entity)
        {
            if (entity.LogicalName == "contact")
            {
                Contact contact = new Contact();

                contact.Id = entity.Id;
                contact.Firstname = entity.GetAttributeValue<string>("firstname");
                contact.Lastname = entity["lastname"].ToString();
                return contact;
            }
            else
            {
                return null;
            }
        }

        public static Entity ContactToEntity(Contact contact)
        {
            var contactEnt = new Entity("contact");
            contactEnt.Id = (Guid)(contact.Id != Guid.Empty|| contact.Id==null|| contact.Id.ToString()=="" ? contact.Id : Guid.Empty);
            contactEnt["firstname"] = !string.IsNullOrEmpty(contact.Firstname) ? contact.Firstname : string.Empty;
            contactEnt["lastname"] = !string.IsNullOrEmpty(contact.Lastname) ? contact.Lastname : string.Empty;

            return contactEnt;
        }

        
    }
}