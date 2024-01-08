function updateLeftRectangleVisibility() {
    const leftRectangle = document.querySelector('.left-rectangle');
    if (window.innerWidth <= 767) {
        leftRectangle.classList.remove('show');
    } else {
        leftRectangle.classList.add('show');
    }
}

updateLeftRectangleVisibility();

window.addEventListener('resize', updateLeftRectangleVisibility);






let links = document.querySelectorAll('.link')

for (let i = 0; i < links.length; i++) {
	if (links[i].href === window.location.href) {
		links[i].classList.add('actual-page')
		links[i].classList.remove('link')
	}
}

if (window.location.pathname === '/ExpenseManager/Create') {
    let switchBtn = document.querySelector('#switch')
    let switchText = document.querySelector('.switch-text')

    switchBtn.addEventListener('change', function () {
        if (switchBtn.checked) {
            switchText.innerText = 'Ingoing'
            switchBtn.value = "true"
        } else {
            switchText.innerText = 'Outgoing'
            switchBtn.value = "false"
        }
    })
}

           