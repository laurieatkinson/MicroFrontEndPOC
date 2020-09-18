(function () {
    // Subscribe to global event from another app
    document.addEventListener('refresh-data', (e) => {
        let alert = document.querySelector('#webapp1 #event-alert');
        alert.innerText = e.extraInfo;
        alert.style.display = "block";
        window.setTimeout(() => {
            alert.style.display = "none";
        }, 4000);
    }, false);
})();
