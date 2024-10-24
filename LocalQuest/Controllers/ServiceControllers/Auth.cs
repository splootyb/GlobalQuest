using LocalQuest.Models._2020;
using QuerryNetworking.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Controllers.ServiceControllers
{
    public class Auth : ClientRequest
    {
        [Get("/cachedlogin/forplatformid/{var}/{var}")]
        public List<CachedLogin> GetLogins(string Platform, string PlatformId)
        {
            return new List<CachedLogin>()
            {
                new CachedLogin()
            };
        }

        [Get("/eac/challenge")]
        public string EacChallenge()
        {
            return "\"" + Guid.NewGuid().ToString() + "\"";
        }
    }
}
