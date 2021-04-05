using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoRestsharp.DTO;
using DemoRestsharp.Helpers;
using Newtonsoft.Json;
using RestSharp;

namespace DemoRestsharp
{
    public class APIHandler<T>
    {

        public T GetRequest(string endpoint)
        {
            var user = new APIHelper<T>();
            var url = user.SetUrl(endpoint);
            var request = user.CreateGetRequest();
            var response = user.GetResponse(url, request);
            var content = user.GetContent<T>(response);
            return content;
        }

        public T PostRequest(string endpoint, dynamic payload)
        {
            var helper = new APIHelper<T>();
            var url = helper.SetUrl(endpoint);
            var jsonReq = helper.Serialize(payload);
            var request = helper.CreatePostRequest(payload);
            var response = helper.GetResponse(url, request);
            var content = helper.GetContent<T>(response);
            content.Response = response;
            return content;
        }
    }
}
