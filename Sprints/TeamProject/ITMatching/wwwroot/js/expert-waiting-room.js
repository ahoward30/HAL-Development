var timeOutRefreshPage;

function refreshPage() {
    location.reload(); 
}

function getRequests() {
    let isAvailable = $(hdnIsAvailable).val() === 'true';
    if (isAvailable) {
        timeOutRefreshPage = setTimeout(refreshPage, 30000); //30 secs
    }
}

$(document).ready(function () {
    getRequests();
});
