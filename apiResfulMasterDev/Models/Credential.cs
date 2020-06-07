using System;
using System.Collections.Generic;

namespace apiResfulMasterDev.Models
{
    public partial class Credential
    {
        public int Id { get; set; }
        public string Userkey { get; set; }
        public string Sharedsecret { get; set; }
    }
}
