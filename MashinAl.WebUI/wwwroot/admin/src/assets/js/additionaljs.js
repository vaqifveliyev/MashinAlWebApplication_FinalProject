window.addEventListener('load', function () {

    let element = document.querySelector(`.sidebar-link a[href='${window.location.pathname}']`);

    if (element != null) {
        element.parentElement.classList.add('active');
/*        element.parentElement.closest('li.pcoded-hasmenu').classList.add('active', 'pcoded-trigger');*/
    }

})


/* Spinner */
window.addEventListener('load', function () {
    setTimeout(function () {
        var preloader = document.getElementById('preloader-container');
        preloader.style.display = 'none';
    }, 1000);
});
