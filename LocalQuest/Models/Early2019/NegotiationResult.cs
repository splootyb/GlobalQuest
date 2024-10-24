using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Early2019
{
    public class NegotiationResult
    {
        public string ConnectionId { get; set; } = Guid.NewGuid().ToString();
        public List<SupportedTransport> SupportedTransports { get; set; } = new List<SupportedTransport>();
        public Uri Url { get; set; } = new Uri("http://localhost:16512");
        public string AccessToken { get; set; } = "Token like rec room?!";
    }

    public class SupportedTransport
    {
        public string Name { get; set; } = "TransportName";
        public List<string> SupportedFormats { get; set; } = new List<string>();
    }
}
