window.addEventListener('load', function () {

    let element = document.querySelector(`.pcoded-navbar a[href='${window.location.pathname}']`);

    if (element != null) {
        element.parentElement.classList.add('active');
        element.parentElement.closest('li.pcoded-hasmenu').classList.add('active', 'pcoded-trigger');
    }

})
