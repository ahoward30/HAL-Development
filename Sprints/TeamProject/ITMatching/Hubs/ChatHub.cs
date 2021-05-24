using ITMatching.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITMatching.Hubs
{
    public class ChatHub : Hub
    {
        public async Task JoinChatRoom(int meetingId) =>
            await Groups.AddToGroupAsync(Context.ConnectionId, Convert.ToString(meetingId));

        public async Task LeaveChatRoom(int meetingId) =>
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, Convert.ToString(meetingId));

        public async Task SendMessage(Message message) =>
            await Clients.Group(Convert.ToString(message.MeetingId)).SendAsync("receiveMessage", message);
    }
}
