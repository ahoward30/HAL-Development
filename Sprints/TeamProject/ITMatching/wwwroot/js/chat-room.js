class Message {
    constructor(meetingId, sentBy, sentTime, text, fileUrl) {
        this.meetingId = parseInt(meetingId);
        this.sentBy = parseInt(sentBy);
        this.sentTime = new Date(sentTime);
        this.text = text;
        this.fileUrl = fileUrl;
    }

    get sentTimeDB() {
        return moment(this.sentTime).format('YYYYMMDDHHmmss');
    }
}

class Room {
    constructor(meetingId, userId) {
        this.meetingId = parseInt(meetingId);
        this.userId = parseInt(userId);
    }
}

const chatBox = document.getElementById('chat-box');
const MESSAGE_FORM = 'postMessage-';
const FILE_FORM = 'uploadFile-';
var roomDetail = null;

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

function setImages() {
    $('[data-img-src]').each(function () {
        $(this).onload = function () { window.onImageLoaded(); };
        $(this).onerror = function () { window.reloadImage(this); };
        $(this).attr('src', $(this).attr('data-img-src'));
    });
}

function scrollToBottom() {
    chatBox.scrollTop = chatBox.scrollHeight;
}

function onImageLoaded() {
    scrollToBottom();
}

function reloadImage(obj) {
    let src = obj.src;
    if (!obj.cnt || obj.cnt <= 3) {
        obj.cnt++;
        obj.src = null;
        obj.src = src;
    } else {
        obj.onerror = null;
    }
}

function joinRoom() {
    roomDetail = new Room($('#' + MESSAGE_FORM + 'meetingId').val(), $('#' + MESSAGE_FORM + 'sentBy').val());
    joinChatRoomToHub(roomDetail);
}

function setStatus(text, isOnline) {
    $('#status-text').html(text);
    $('#status-text').attr('class', isOnline ? 'text-blue' : 'text-danger');

    $('#status-badge').html(isOnline ? 'Online' : 'Offline');
    $('#status-badge').attr('class', 'p-2 badge badge-pill ' + (isOnline ? 'badge-blue' : 'badge-danger'));
}

$(document).ready(function () {
    $('#fileInput').on('change', function () {
        const value = $(this).val();
        if (value) {
            $('#' + FILE_FORM + 'sentTime').val(new Date().toJSON());
            $('#' + FILE_FORM + 'text').val('File Attachment');
            $('#sendFileButton').submit();
        }
    });
    $('#sendFile').click(function () {
        $('#fileInput').val(null);
        $('#fileInput').click();
    });
    $('#sendButton').click(function () {
        $('#' + MESSAGE_FORM + 'sentTime').val(new Date().toJSON());
    });
    $('#' + MESSAGE_FORM + 'text').on('keyup', function () {
        const value = $(this).val();
        if (value != '') {
            $('#sendButton').attr('disabled', false);
        } else {
            $('#sendButton').attr('disabled', true);
        }
    });
    $('#sendButton').attr('disabled', true);
    setInterval(refreshDateTime, 5000);
    refreshDateTime();
    setImages();
    scrollToBottom();
    setStatus('Waiting for the user to join room.', false);
});

window.addEventListener("beforeunload", function (event) {
    leaveChatRoomToHub(roomDetail);
});

function clearInputField() {
    $('#' + MESSAGE_FORM + 'text').val('');
    $('#sendButton').attr('disabled', true);
}

function sendMessageFailure(xhr) {
    alert(xhr.responseText);
}

function sendMessage(message) {
    sendMessageToHub(message);
}

function addMessageToChatRoom(message) {
    message = Object.assign(new Message, message);

    let isCurrentUserMessage = message.sentBy === CurrentUserId;

    let container = document.createElement('div');
    container.className = 'media w-50 mb-3' + (isCurrentUserMessage ? '  ml-auto' : '');

    let mbody = document.createElement('div');
    mbody.className = 'media-body';

    let content = document.createElement('div');
    content.className = 'rounded py-2 px-3 mb-2 ' + (isCurrentUserMessage ? 'bg-primary' : 'bg-light');

    if (!message.fileUrl) {
        let text = document.createElement('p');
        text.className = 'text-small mb-0 ' + (isCurrentUserMessage ? 'text-white' : 'text-muted');
        text.innerHTML = message.text;
        content.appendChild(text);
    } else {
        let text = document.createElement('small');
        text.className = 'font-italic mb-0 ' + (isCurrentUserMessage ? 'text-white' : 'text-muted');
        text.innerHTML = message.text;
        content.appendChild(text);

        let imgDiv = document.createElement('div');
        imgDiv.className = 'img-thumbnail img-wrapper mb-2';
        let img = document.createElement('img');
        img.alt = `${message.text} - ${message.sentTimeDB}`;
        img.onload = function () { window.onImageLoaded(); };
        img.onerror = function () { window.reloadImage(this); };
        img.src = message.fileUrl;
        imgDiv.appendChild(img);
        content.appendChild(imgDiv);
    }

    let sentTime = document.createElement('p');
    sentTime.className = 'small text-muted';
    sentTime.setAttribute('data-utcdate', message.sentTime);
    sentTime.innerHTML = dateTimeDisplay(message.sentTime);

    mbody.appendChild(content);
    mbody.appendChild(sentTime);
    container.appendChild(mbody);
    chatBox.appendChild(container);

    scrollToBottom();
}