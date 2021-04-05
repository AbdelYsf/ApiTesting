using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace DemoRestsharp.DTO
{
    public class BaseDTO
    {
        [JsonIgnore]
        public  IRestResponse Response { get; set; }
    }
}
