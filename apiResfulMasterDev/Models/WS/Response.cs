using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiResfulMasterDev.Models.WS
{
    public class Response
    {
        public int Result { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}
