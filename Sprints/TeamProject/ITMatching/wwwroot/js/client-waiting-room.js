var timeOutRefreshPage;

function refreshPage() {
        location.reload();
}

function autoRefresh() {
        timeOutRefreshPage = setInterval(refreshPage, 5000); //5 secs
}

$(document).ready(function () {
    autoRefresh();
});
