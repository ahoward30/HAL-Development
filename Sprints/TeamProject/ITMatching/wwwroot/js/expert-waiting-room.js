var timeOutRefreshPage;

function refreshPage() {
        location.reload();
}

function getRequests() {
    let isAvailable = $(hdnIsAvailable).val() === 'true';
    if (isAvailable) {
        timeOutRefreshPage = setInterval(refreshPage, 20000); //20 secs
    }
}

$(document).ready(function () {
    getRequests();
});
