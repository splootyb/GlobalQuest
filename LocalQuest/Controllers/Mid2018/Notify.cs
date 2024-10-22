using LocalQuest.Models.Mid2018;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LocalQuest.Controllers.Mid2018
{
    public static class Notify
    {
        static WebSocket? Current;
        public static async void ConnectNotify(WebSocketContext Context)
        {
            Current = Context.WebSocket;

            while (Current.State == WebSocketState.Open)
            {
                byte[] Buffer = new byte[1024];
                WebSocketReceiveResult Received = await Current.ReceiveAsync(Buffer, CancellationToken.None);
                if(Received.MessageType == WebSocketMessageType.Close)
                {
                    await Current.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                    return;
                }
                string NotifyString = Encoding.UTF8.GetString(Buffer);
                if(NotifyString.Contains("heartbeat2"))
                {
                    Log.Info("Requested heartbeat");
                    if (CurrentPresence != null)
                    {
                        await SendNotification(new Notification()
                        {
                            Id = NotificationType.PresenceHeartbeatResponse,
                            Msg = CurrentPresence
                        });
                    }
                }
                if(NotifyString.Contains("playerSubscriptions/v1/update"))
                {
                    Log.Info("Requested update subscriptions");
                    if (CurrentPresence != null)
                    {
                        await SendNotification(new Notification()
                        {
                            Id = NotificationType.SubscriptionUpdatePresence,
                            Msg = CurrentPresence
                        });
                    }
                }
                else
                {
                    await Current.SendAsync(Buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
        }

        public static PlayerPresence? CurrentPresence;

        public static async Task SendNotification(Notification Message)
        {
            if(Current == null)
            {
                return;
            }
            string MessageString = JsonSerializer.Serialize(Message);

            await Current.SendAsync(Encoding.UTF8.GetBytes(MessageString), WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}
