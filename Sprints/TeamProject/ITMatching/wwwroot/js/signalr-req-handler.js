var connection = new signalR.HubConnectionBuilder()
    .withUrl('/ChatHub')
    .build();

connection.on('receiveMessage', addMessageToChatRoom);

connection.on('onlineUsers', function (users) {
    let isOnline = users.filter(u => u !== CurrentUserId).length > 0;
    if (isOnline) {
        setStatus('The user has entered the chatroom.', true);
    }
});

connection.on('userOnline', function (userId) {
    let isOnline = userId !== CurrentUserId;
    if (isOnline) {
        setStatus('The user has entered the chatroom.', true);
    }
});

connection.on('userOffline', function (userId) {
    let isOffline = userId !== CurrentUserId;
    if (isOffline) {
        setStatus('The user has left the chatroom.', false);
    }
});

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
        joinRoom();
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

connection.onclose(start);

// Start the connection.
start();

function joinChatRoomToHub(room) {
    connection.invoke('joinChatRoom', room);
}

function leaveChatRoomToHub(room) {
    connection.invoke('leaveChatRoom', room);
}

function sendMessageToHub(message) {
    connection.invoke('sendMessage', message);
}