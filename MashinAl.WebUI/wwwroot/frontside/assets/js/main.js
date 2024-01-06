let btnHamburger = document.querySelector('.btnHamburger');
let btnNavClose = document.querySelector('.btnNavClose');
let mobileNav = document.querySelector('.mobile-navigation-section');

btnHamburger.addEventListener('click', ()=> {
    mobileNav.classList.add('opened');
});

btnNavClose.addEventListener('click', ()=> {
    mobileNav.classList.remove('opened');
});