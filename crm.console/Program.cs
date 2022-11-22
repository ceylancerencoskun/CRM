using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
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
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            IOrganizationService organizationService = null;
            ConnectionHelper connectionHelper = new ConnectionHelper("CRMServer");

            //organizationService = connectionHelper.Alternate("crm.demo.1@outlook.com", "Demo.1234", "https://org1de0b20c.api.crm4.dynamics.com/XRMServices/2011/Organization.svc");
            //organizationService = connectionHelper.Alternate("crm.demo.1@org1de0b20c.onmicrosoft.com", "Demo.1234", "https://org1de0b20c.api.crm4.dynamics.com/XRMServices/2011/Organization.svc");
            //organizationService = connectionHelper.Alternate("admin@org1de0b20c.onmicrosoft.com", "Demo.1234", "https://org1de0b20c.api.crm4.dynamics.com/XRMServices/2011/Organization.svc");
            //var res=organizationService.Retrieve("contact", new Guid("678c7b32-3f72-ea11-a811-000d3a1b1f2c"),new Microsoft.Xrm.Sdk.Query.ColumnSet("contactid"));
            //organizationService = connectionHelper.Alternate("ceylancorbaci@hotmail.com", "627@Tuyap.WrmymWCEQ9C", "https://org2640067e.api.crm4.dynamics.com/XRMServices/2011/Organization.svc");

            organizationService = connectionHelper.Alternate();

            
            //retrive
            var qe = new QueryExpression() { EntityName = "contact", ColumnSet=new ColumnSet(true) };
            var res = organizationService.RetrieveMultiple(qe);
            res.ToString();

            //create
            Entity entity = new Entity();
            entity.LogicalName = "contact";
            entity.Attributes["firstname"] = "ceylan";
            organizationService.Create(entity);

            //update
            Entity entity2 = new Entity();
            entity.LogicalName = "contact";
            entity.Id = new Guid("asdsasadsads");
            entity.Attributes["firstname"] = "ceylan";
            organizationService.Update(entity);


            Console.WriteLine("success");

            //organizationService=connectionHelper.GetCrmServiceClient();

            //if(organizationService !=null)
            //{
            //    WhoAmIRequest whoAmIRequest = new WhoAmIRequest();
            //    WhoAmIResponse whoAmIResponse = new WhoAmIResponse();

            //    if (whoAmIRequest != null )
            //    {
            //        try
            //        {
            //            whoAmIResponse = (WhoAmIResponse)organizationService.Execute(whoAmIRequest);
            //        }
            //        catch (Exception)
            //        {
            //            //organizationService = connectionHelper.Alternate("crm.demo.1@outlook.com", "Demo.1234", "https://org1de0b20c.api.crm4.dynamics.com/XRMServices/2011/Organization.svc");
            //            organizationService = connectionHelper.Alternate("admin@org1de0b20c.onmicrosoft.com", "Demo.1234", "https://org1de0b20c.api.crm4.dynamics.com/XRMServices/2011/Organization.svc");
            //            whoAmIResponse = (WhoAmIResponse)organizationService.Execute(whoAmIRequest);
            //        }

            //    }




            //    Console.WriteLine($"User ID : { whoAmIResponse.UserId }");
            //    Console.WriteLine($"BusinessUnit ID : {whoAmIResponse.BusinessUnitId}");
            //    Console.WriteLine($"OrganizationId ID : {whoAmIResponse.OrganizationId}");
            //}

            Console.Read();
        }
    }
}
