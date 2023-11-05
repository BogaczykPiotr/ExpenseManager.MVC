let links = document.querySelectorAll('.link')

for (let i = 0; i < links.length; i++) {
	if (links[i].href === window.location.href) {
		links[i].classList.add('actual-page')
		links[i].classList.remove('link')
	}
}

if (window.location.pathname === '/') {
    
}

if (window.location.pathname === '/ExpenseManager/Savings') { 


	const canvas = document.querySelector('.progress-chart')

	const value = document.querySelector('.saving-goal-value')
	const plus = document.querySelector('.add-goal')
	const minus = document.querySelector('.remove-goal')
	const summary = document.querySelector('.summary')
	const lastGoal = document.querySelector('.last-goal')
	const goalText = document.querySelector('.goal-text')
	const inputValue = document.querySelector('.input-value')
	let newValue
	plus.addEventListener('click', function () {
		let currentValue = parseInt(value.textContent)
		newValue = currentValue + 50
		value.textContent = newValue
		inputValue.value = newValue
	})
	minus.addEventListener('click', function () {
		let currentValue = parseInt(value.textContent)
		newValue = currentValue - 50
		if (newValue >= 0) {
			value.textContent = newValue
			inputValue.value = newValue
		}
	})
	if (parseInt(lastGoal.textContent) < 300) {
		// for ASP edit
		summary.classList.add('failed')
		summary.classList.remove('completed')
		goalText.innerText = 'Try in next month'
	} else {
		summary.classList.add('completed')
		summary.classList.remove('failed')
		goalText.innerText = 'Congratulations'
	}

	function updateValues() {
		let currentValue = parseInt(value.textContent)
		let inputNumber = parseInt(inputValue.value)

		if (!isNaN(inputNumber)) {
			if (inputNumber >= 0) {
				value.textContent = inputNumber
			} else {
				inputValue.value = currentValue
			}
		} else {
			inputValue.value = currentValue
		}
	}
	updateValues()

	inputValue.addEventListener('input', updateValues)

	let data = {
		labels: ['jan', 'feb', 'mar', 'apr', 'may', 'jun', 'july', 'aug', 'sep', 'oct', 'nov', 'dec'],
		datasets: [
			{
				data: [100, 150, 200, 250, 300, 350, 400, 450, 500, 550, 600, 650],
				borderColor: 'rgba(255, 255, 0, 1)',
				borderWidth: 3,
			},
		],
	}

	let options = {
		scales: {
			y: {
				beginAtZero: true,
			},
		},
		plugins: {
			legend: {
				display: false,
			},
		},
	}

	let progressChart = new Chart(canvas, {
		type: 'line',
		data: data,
		options: options,
	})
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
