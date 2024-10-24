using LocalQuest.Models.Mid2018;
using LocalQuest.Models.MidLate2018;
using QuerryNetworking.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LocalQuest.Controllers.MidLate2018
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
                try
                {
                    WebSocketReceiveResult Received = await Current.ReceiveAsync(Buffer, CancellationToken.None);
                    if (Received.MessageType == WebSocketMessageType.Close)
                    {
                        await Current.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                        return;
                    }
                    string NotifyString = Encoding.UTF8.GetString(Buffer);
                    if (NotifyString.Contains("heartbeat2"))
                    {
                        Log.Info("Requested heartbeat");
                        if (CurrentPresence != null)
                        {
                            await SendNotification(new Notification()
                            {
                                Id = Models.MidLate2018.NotificationType.PresenceHeartbeatResponse,
                                Msg = CurrentPresence
                            });
                            await SendNotification(new Notification()
                            {
                                Id = Models.MidLate2018.NotificationType.SubscriptionUpdateRoom,
                                Msg = new RoomDetails(RoomManager.AllRooms.FirstOrDefault(A => A.RoomId == CurrentPresence.GameSession.RoomId))
                            });
                        }
                    }
                    if (NotifyString.Contains("playerSubscriptions/v1/update"))
                    {
                        Log.Info("Requested update subscriptions");
                        if (CurrentPresence != null)
                        {
                            await SendNotification(new Notification()
                            {
                                Id = Models.MidLate2018.NotificationType.SubscriptionUpdatePresence,
                                Msg = CurrentPresence
                            });
                        }
                    }
                    else if(!NotifyString.Contains("api"))
                    {
                        await Current.SendAsync(Buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                    }
                }
                catch
                {
                    Log.Warn("Websocket failure?!");
                    await Current.CloseAsync(WebSocketCloseStatus.InternalServerError, "", CancellationToken.None);
                    return;
                }
            }
        }

        public static Models.MidLate2018.Presence? CurrentPresence;

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
