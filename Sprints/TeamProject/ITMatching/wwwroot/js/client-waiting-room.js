var timeOutRefreshPage;

function refreshPage() {
    if (document.hasFocus()) {
        location.reload();
    }
}

function autoRefresh() {
        timeOutRefreshPage = setInterval(refreshPage, 5000); //5 secs
}

$(document).ready(function () {
    autoRefresh();
});
