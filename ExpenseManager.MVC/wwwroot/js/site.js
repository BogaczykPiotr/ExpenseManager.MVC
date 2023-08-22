let links = document.querySelectorAll('.link')

for (let i = 0; i < links.length; i++) {
	if (links[i].href === window.location.href) {
		links[i].classList.add('actual-page')
		links[i].classList.remove('link')
	}
}

if (window.location.pathname === '/') {
	let canvas = document.querySelector('.dashboard-chart')

	let chartSelector = document.querySelector('.chart-selector')
	let timeSelector = document.querySelector('.time-selector')

	let data = {
		labels: ['0', '4', '8', '12', '16', '20', '24'],
		datasets: [
			{
				data: [12, 19, 3, 5, 2, 3, 12, 3, 14, 5, 6, 12],
				borderColor: 'rgba(255, 140, 0, 1)',
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

	let chart = new Chart(canvas, {
		type: 'line',
		data: data,
		options: options,
	})

	chartSelector.addEventListener('change', function () {
		if (chartSelector.value === 'Total Amount') {
			data.datasets[0].data = [12, 19, 3, 5, 2, 3, 12, 3, 14, 5, 6, 12]
		} else if (chartSelector.value === 'Spent') {
			data.datasets[0].data = [5, 8, 2, 10, 6, 4, 3, 1, 9, 5, 4, 6]
		} else if (chartSelector.value === 'Left') {
			data.datasets[0].data = [9, 5, 14, 7, 2, 6, 13, 3, 8, 10, 4, 9]
		} else if (chartSelector.value === 'Saving Goal') {
			data.datasets[0].data = [12, 3, 5, 9, 7, 4, 13, 6, 8, 2, 10, 9]
		}
		chart.update()
	})

	timeSelector.addEventListener('change', function () {
		if (timeSelector.value === '1 day') {
			data.labels = ['0', '4', '8', '12', '16', '20', '24']
		} else if (timeSelector.value === '1 week') {
			data.labels = ['1', '2', '3', '4', '5', '6', '7']
		} else if (timeSelector.value === '1 month') {
			data.labels = [
				'1',
				'2',
				'3',
				'4',
				'5',
				'6',
				'7',
				'8',
				'9',
				'10',
				'11',
				'12',
				'13',
				'14',
				'15',
				'16',
				'17',
				'18',
				'19',
				'20',
				'21',
				'22',
				'23',
				'24',
				'25',
				'26',
				'27',
				'28',
				'29',
				'30',
				'31',
			]
		} else if (timeSelector.value === '1 year') {
			data.labels = ['jan', 'feb', 'mar', 'apr', 'may', 'jun', 'jul', 'aug', 'sep', 'oct', 'nov', 'dec']
		}
		if (data.labels.length > data.datasets[0].data.length) {
			let dataLabelsLength = data.labels.length
			let dataLength = data.datasets[0].data.length
			for (let i = dataLength; i < dataLabelsLength; i++) {
				data.datasets[0].data.push(0)
			}
		}
		chart.update()
	})
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
		} else {
			switchText.innerText = 'Outgoing'

		}
	})
}
