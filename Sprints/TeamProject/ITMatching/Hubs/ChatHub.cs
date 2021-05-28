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
        private static readonly Dictionary<int, Dictionary<int, List<string>>> OnlineUsers = new Dictionary<int, Dictionary<int, List<string>>>();

        public async Task JoinChatRoom(Room room)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, Convert.ToString(room.MeetingId));
            var isOnline = OnJoinChatRoom(room.MeetingId, room.UserId, Context.ConnectionId);
            if (isOnline)
            { await Clients.Group(Convert.ToString(room.MeetingId)).SendAsync("userOnline", room.UserId); }
            await Clients.Caller.SendAsync("onlineUsers", GetOnlineUserIds(room.MeetingId));
        }

        public async Task LeaveChatRoom(Room room)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, Convert.ToString(room.MeetingId));
            var isOffline = OnLeaveChatRoom(room.MeetingId, room.UserId, Context.ConnectionId);
            if (isOffline)
            { await Clients.Group(Convert.ToString(room.MeetingId)).SendAsync("userOffline", room.UserId); }
        }

        public async Task SendMessage(Message message) =>
            await Clients.Group(Convert.ToString(message.MeetingId)).SendAsync("receiveMessage", message);

        private bool OnJoinChatRoom(int meetingId, int userId, string connectionId)
        {
            bool isOnline = false;
            lock (OnlineUsers)
            {
                if (!OnlineUsers.ContainsKey(meetingId))
                {
                    OnlineUsers.Add(meetingId, new Dictionary<int, List<string>>());
                }

                isOnline = OnUserConnected(OnlineUsers[meetingId], userId, connectionId);
            }

            return isOnline;
        }

        public bool OnUserConnected(Dictionary<int, List<string>> dic, int userId, string connectionId)
        {
            bool isOnline = false;

            if (dic.ContainsKey(userId))
            {
                dic[userId].Add(connectionId);
            }
            else
            {
                dic.Add(userId, new List<string> { connectionId });
                isOnline = true;
            }

            return isOnline;
        }

        private bool OnLeaveChatRoom(int meetingId, int userId, string connectionId)
        {
            bool isOffline = false;
            lock (OnlineUsers)
            {
                if (OnlineUsers.ContainsKey(meetingId))
                {
                    isOffline = OnUserDisconnected(OnlineUsers[meetingId], userId, connectionId);
                    if (OnlineUsers[meetingId].Count == 0)
                    { OnlineUsers.Remove(meetingId); }
                }
            }

            return isOffline;
        }

        private bool OnUserDisconnected(Dictionary<int, List<string>> dic, int userId, string connectionId)
        {
            bool isOffline = false;
            if (dic.ContainsKey(userId))
            {
                dic[userId].Remove(connectionId);
                if (dic[userId].Count == 0)
                {
                    dic.Remove(userId);
                    isOffline = true;
                }
            }

            return isOffline;
        }

        public int[] GetOnlineUserIds(int meetingId)
        {
            int[] onlineUserIds;
            lock (OnlineUsers)
            { onlineUserIds = OnlineUsers.Where(k => k.Key == meetingId).SelectMany(k => k.Value.OrderBy(vk => vk.Key).Select(vk => vk.Key)).ToArray(); }

            return onlineUserIds;
        }
    }

    public class Room
    {
        public int MeetingId { get; set; }
        public int UserId { get; set; } // Itmuser.Id of sender
    }
}
