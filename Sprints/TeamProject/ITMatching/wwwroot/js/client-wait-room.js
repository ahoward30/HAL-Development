function refreshPage() {
    if (document.hasFocus()) {
        location.reload();
    }
}

function getRequests() {
    let isAvailable = $(hdnIsAvailable).val() === 'true';
    if (isAvailable) {
        timeOutRefreshPage = setInterval(refreshPage, 30000); //30 secs
    }
}

$(document).ready(function () {
    getRequests();
});
