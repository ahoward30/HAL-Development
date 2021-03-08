document.addEventListener('DOMContentLoaded', () => {
    const themeStylesheet = document.getElementById('theme');
    const themeToggle = document.getElementById('toggleButton')
    const storedTheme = localStorage.getItem('theme');
    const storedText = localStorage.getItem('toggleButton');
    if (storedTheme && storedText) {
        themeStylesheet.href = storedTheme;
        themeToggle.innerText = storedText;
    }
    themeToggle.addEventListener('click', () => {
        // toggle dark mode from light
        if (themeStylesheet.href.includes('light')) {
           // $(body).fadeOut( function() {
                themeStylesheet.href = '/css/dark-theme.css';
                themeToggle.innerText = 'Toggle Light Mode';
                //$(this).fadeIn();
            //});
        }
        else {
            // toggle light mode from dark
            //$(body).fadeOut( function() {
                themeStylesheet.href = '/css/light-theme.css';
                themeToggle.innerText = 'Toggle Dark Mode';
                //$(this).fadeIn();
            //});
        }
        localStorage.setItem('theme', themeStylesheet.href);
        localStorage.setItem('toggleButton', themeToggle.innerText);
    })
})