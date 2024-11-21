using Hospital_Management_System.Services.ChatServices;
using Hospital_Management_System.Services.MessageServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace Hospital_Management_System.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private static readonly ConcurrentDictionary<string, string> UserConnections = new();
        private readonly IChatService _chatService;
        private readonly IMessageService _messageService;

        public ChatHub(IChatService chatService, IMessageService messageService)
        {
            _chatService = chatService;
            _messageService = messageService;
        }

        public override async Task OnConnectedAsync()
        {
            var userId = Context.User?.Claims.FirstOrDefault(c => c.Type == "userId")?.Value ?? throw new ArgumentNullException("User ID claim is missing or null.");
            UserConnections[userId] = Context.ConnectionId;
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var userId = Context.User?.Claims.FirstOrDefault(c => c.Type == "userId")?.Value ?? throw new ArgumentNullException("User ID claim is missing or null.");
            UserConnections.TryRemove(userId, out _);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task StartPrivateChat(string recipientUserId)
        {
            var userId = Context.User?.Claims.FirstOrDefault(c => c.Type == "userId")?.Value ?? throw new ArgumentNullException("User ID claim is missing or null.");

            var groupName = GetGroupName(userId, recipientUserId);

            await _chatService.CreateChat(userId, groupName);

            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task SendMessageToUser(string recipientUserId, string message)
        {
            var userId = Context.User?.Claims.FirstOrDefault(c => c.Type == "userId")?.Value ?? throw new ArgumentNullException("User ID claim is missing or null.");

            var groupName = GetGroupName(userId, recipientUserId);

            await _messageService.AddMessage(message, userId, recipientUserId, groupName);

            await Clients.Group(groupName).SendAsync("ReceiveMessage", userId, message);
        }

        private string GetGroupName(string userId1, string userId2)
        {
            return string.CompareOrdinal(userId1, userId2) < 0 ? $"{userId1}-{userId2}" : $"{userId2}-{userId1}";
        }
    }
}
