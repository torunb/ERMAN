using ERMAN.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;

namespace ERMAN.Controllers
{
    // Because this is a websocket controller it needs to be ignored
    // otherwise Swagger will complain about not knowning which HTTP verb
    // Get() below corresponds to
    [ApiExplorerSettings(IgnoreApi = true)]
    public class MessagingController : ControllerBase
    {
        private MessagingService _messagingService;

        public MessagingController(MessagingService messagingService) {
            _messagingService = messagingService;
        }

        [Route("/ws")]
        [Authorize(Roles = "Student, Coordinator")]
        public async Task Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                var userId = HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "userID");
                await Echo(webSocket, Convert.ToInt32(userId.Value));
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }

        private class ConnectionRequest {
            public String version;
        }

        private class MessageRequest
        {
            public String message;
            public int to; // id of the user to send to
        }


        private async Task Echo(WebSocket webSocket, int userId)
        {
            var listener = new NotificationListener(webSocket);
            _messagingService.registerListener(listener, userId);
            var buffer = new byte[1024 * 4];
            var receiveResult = await webSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None);

            var connectionMessage = JsonConvert.DeserializeObject<ConnectionRequest>(receiveResult.ToJson());
            Console.WriteLine("got conn message for ws");
            Console.WriteLine("userId is: " + userId.ToString());

            while (webSocket.State == WebSocketState.Open)
            {
                receiveResult = await webSocket.ReceiveAsync(
                    new ArraySegment<byte>(buffer), CancellationToken.None);

                string jsonStr = Encoding.UTF8.GetString(buffer);

                Console.WriteLine(jsonStr);
                var messageRequest = JsonConvert.DeserializeObject<MessageRequest>(jsonStr);
                Console.WriteLine("msg: " + messageRequest.message + "to " + messageRequest.to);
                // if messageRequest is null frontend sent malformed json, handle that case

                foreach (KeyValuePair<int, NotificationListener> kvp in _messagingService.listeners)
                {
                    //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                    Console.WriteLine(string.Format("Key = {0}, Value = {1}", kvp.Key, kvp.Value));
                }

                Console.WriteLine("to: " + messageRequest.to + " from: " + userId);

                await _messagingService.sendMessage(userId, messageRequest.to, messageRequest.message);
            }
        }
    }
}