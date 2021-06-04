document.addEventListener('DOMContentLoaded', () => {
    const themeStylesheet = document.getElementById('theme');
    const themeToggle = document.getElementById('toggleButton')
    const storedTheme = localStorage.getItem('theme');
    const storedText = localStorage.getItem('toggleButton');
    var checkedStatus = localStorage.getItem('checkedStatus');

    if (storedTheme && checkedStatus) {
        themeStylesheet.href = storedTheme;
        if (checkedStatus == "true")
        {
            themeToggle.checked = true;
        }
        else {
            themeToggle.checked = false;
        }
    }
    themeToggle.addEventListener('click', () => {
        if (themeStylesheet.href.includes('dark')) {
            // toggle light mode from dark
            //$(body).fadeOut( function() {
            themeStylesheet.href = '/css/light-theme.css';
            themeToggle.checked = true;
            checkedStatus = "true";
            //$(this).fadeIn();
            //});
        }
        // toggle dark mode from light
        else{
           // $(body).fadeOut( function() {
                themeStylesheet.href = '/css/dark-theme.css';
                themeToggle.checked = false;
                checkedStatus = "false";
                //$(this).fadeIn();
            //});
        }
        localStorage.setItem('theme', themeStylesheet.href);
        localStorage.setItem('checkedStatus', checkedStatus);
    })
})