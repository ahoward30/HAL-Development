var connection = new signalR.HubConnectionBuilder()
    .withUrl('/ChatHub')
    .build();

connection.on('receiveMessage', addMessageToChatRoom);

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

function joinChatRoomToHub(meetingId) {
    connection.invoke('joinChatRoom', meetingId);
}

function leaveChatRoomToHub(meetingId) {
    connection.invoke('leaveChatRoom', meetingId);
}

function sendMessageToHub(message) {
    connection.invoke('sendMessage', message);
}