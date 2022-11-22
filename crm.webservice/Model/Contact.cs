using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crm.webservice.Model
{
    public class Contact
    {

        public Guid? Id { get; set; } = Guid.Empty;
        public string Firstname { get; set; } = "";
        public string Lastname { get; set; } = "";
    }
}