class Message {
    constructor(meetingId, sentBy, sentTime, text) {
        this.meetingId = parseInt(meetingId);
        this.sentBy = parseInt(sentBy);
        this.sentTime = new Date(sentTime);
        this.text = text;
    }
}

const messagesQueue = [];
const chatBox = document.getElementById('chat-box');

function dateTimeDisplay(date) {
    var d = moment(date);
    return d.format('lll') + ' • ' + d.fromNow()
}

function refreshDateTime() {
    $('[data-utcdate]').each(function () {
        let localTime = moment.utc($(this).attr('data-utcdate')).toDate();
        $(this).html(dateTimeDisplay(localTime));
    });
}

function scrollToBottom() {
    chatBox.scrollTop = chatBox.scrollHeight;
}

function joinRoom() {
    joinChatRoomToHub(parseInt($('#meetingId').val()));
}

$(document).ready(function () {
    $('#sendButton').attr('disabled', true);
    $('#text').on('keyup', function () {
        const value = $(this).val();
        if (value != '') {
            $('#sendButton').attr('disabled', false);
        } else {
            $('#sendButton').attr('disabled', true);
        }
    });
    setInterval(refreshDateTime, 5000);
    refreshDateTime();
    scrollToBottom();
});

window.addEventListener("beforeunload", function (event) {
    leaveChatRoomToHub(parseInt($('#meetingId').val()));
});

$('#sendButton').click(function () {
    $('#sentTime').val(new Date().toJSON());
});

function clearInputField() {
    const message = new Message($('#meetingId').val(), $('#sentBy').val(), $('#sentTime').val(), $('#text').val());
    messagesQueue.push(message);
    $('#text').val('');
    $('#sendButton').attr('disabled', true);
}

function sendMessage() {
    const message = messagesQueue.shift();
    sendMessageToHub(message);
}

function addMessageToChatRoom(message) {
    let isCurrentUserMessage = message.sentBy === CurrentUserId;

    let container = document.createElement('div');
    container.className = 'media w-50 mb-3' + (isCurrentUserMessage ? '  ml-auto' : '');

    let mbody = document.createElement('div');
    mbody.className = 'media-body';

    let content = document.createElement('div');
    content.className = 'rounded py-2 px-3 mb-2 ' + (isCurrentUserMessage ? 'bg-primary' : 'bg-light');

    let text = document.createElement('p');
    text.className = 'text-small mb-0 ' + (isCurrentUserMessage ? 'text-white' : 'text-muted');
    text.innerHTML = message.text;

    let sentTime = document.createElement('p');
    sentTime.className = 'small text-muted';
    sentTime.setAttribute('data-utcdate', message.sentTime);
    sentTime.innerHTML = dateTimeDisplay(message.sentTime);

    content.appendChild(text);
    mbody.appendChild(content);
    mbody.appendChild(sentTime);
    container.appendChild(mbody);
    chatBox.appendChild(container);

    scrollToBottom();
}