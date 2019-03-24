function setPrice() {
    let cost = Number(document.getElementById('Cost').value);
	let count = Number(document.getElementById('Count').value);
	let bikes = Number(document.getElementById('Bicycles').value);
	let discount = 1;

	if (bikes >= 3) {
		discount *= 0.7;
	}

	let price = cost * count * bikes * discount;

	document.getElementById('Price').innerHTML = price.toFixed(2);
}