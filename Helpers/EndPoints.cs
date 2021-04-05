using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.IO;

namespace DemoRestsharp.Helpers
{
    public class EndPoints
    {
        private static readonly string BASE_URL = "https://reqres.in";
        public static readonly string USERS_ENDPOINT = $"{BASE_URL}/api/users";


    }
}
