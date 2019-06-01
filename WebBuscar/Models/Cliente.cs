using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBuscar.Models
{
    public partial class Client
    {
        public string id { get; set; }
        public string username { get; set; }
        public string givenName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }

    }
}