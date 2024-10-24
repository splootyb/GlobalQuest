using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest.Models.Late2018
{
    public class NotifyMessage
    {
        public MessageTypes type { get; set; }
        public string invocationId { get; set; } = Guid.NewGuid().ToString();
        public bool nonblocking { get; set; }
        public string target { get; set; } = "Notification";
        public object[] arguments { get; set; } = new object[0];
        public object item { get; set; } = "";
        public object result { get; set; } = "";
        public string error { get; set; } = "";
    }

    public enum MessageTypes
    {
        Handshake,
        Invocation,
        StreamItem,
        Completion,
        StreamInvocation,
        CancelInvocation,
        Ping,
        Close
    }
}
