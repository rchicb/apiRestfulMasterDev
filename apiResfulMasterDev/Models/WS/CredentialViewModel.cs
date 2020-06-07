using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiResfulMasterDev.Models.WS
{
    public class CredentialViewModel
    {
        public int Id { get; set; }
        public string UserKey { get; set; }
        public string SharedSecret { get; set; }
    }
}
