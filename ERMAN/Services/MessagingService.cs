using Newtonsoft.Json;
using System;
using System.Net.WebSockets;
using System.Text;

namespace ERMAN.Services
{
    public class MessagingService
    {
        public Dictionary<int, NotificationListener> listeners;

        public MessagingService() {
            this.listeners = new Dictionary<int, NotificationListener>();
        }

        public async Task sendMessage(int from, int to, String message) {
            if (this.listeners.ContainsKey(to)) {
                await this.listeners[to].notify(from.ToString(), message);
            }
        }

        public void register(NotificationListener listener, int userId) {
            listeners[userId] = listener;
        }
    }
    public class WSMessage {
        String from;
        String message;

        public WSMessage(String from, String message) {
            this.from = from;
            this.message = message;
        }
    }

    public class NotificationListener
    {
        private WebSocket websocket;


        public NotificationListener(WebSocket websocket)
        {
            this.websocket = websocket;
        }

        public async Task notify(String from, String message) {
            var msg = new WSMessage(from, message);
            var serialized = JsonConvert.SerializeObject(msg);
            var encoded = Encoding.UTF8.GetBytes(serialized);
            var buffer = new ArraySegment<Byte>(encoded, 0, encoded.Length);

            await this.websocket.SendAsync(
                buffer,
                WebSocketMessageType.Text,
                true,
                CancellationToken.None);
        }
    }
}
