using ERMAN.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Net.WebSockets;

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
        [Authorize(Roles = "student")]
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
            _messagingService.register(listener, userId);
            var buffer = new byte[1024 * 4];
            var receiveResult = await webSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None);

            var connectionMessage = JsonConvert.DeserializeObject<ConnectionRequest>(receiveResult.ToJson());

            while (!receiveResult.CloseStatus.HasValue)
            {
                receiveResult = await webSocket.ReceiveAsync(
                    new ArraySegment<byte>(buffer), CancellationToken.None);

                var messageRequest = JsonConvert.DeserializeObject<MessageRequest>(receiveResult.ToJson());
                // if messageRequest is null frontend sent malformed json, handle that case

                _messagingService.sendMessage(Convert.ToInt32(userId), messageRequest.to, messageRequest.message);
            }
        }
    }
}