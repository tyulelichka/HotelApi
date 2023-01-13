async function displaySpas() {
  let spas = await getSpa();

  let spasTable = document.getElementById("getSpa");

  for (let spa of spas) {
    const { id, name, price } = spa;

    const row = document.createElement("tr");

    const idEl = document.createElement("td");
    const nameEl = document.createElement("td");
    const priceEl = document.createElement("td");

    idEl.classList.add("spa-element");
    nameEl.classList.add("spa-element");
    priceEl.classList.add("spa-element");

    idEl.innerText = id;
    nameEl.innerText = name;
    priceEl.innerText = price;

    row.append(idEl, nameEl, priceEl);

    spasTable.append(row);
  }
}

async function addSpa(event) {
  event.preventDefault();
  const form = event.target;
  const { id, name, price } = form.elements;
  await insertSpa(id.value, name.value, price.value);

  location.reload();
}

async function updateSpa(event) {
  event.preventDefault();
  const form = event.target;
  const { id, name, price } = form.elements;
  await newversionSpa(id.value, name.value, price.value);
  location.reload();
}

async function removeSpa(event) {
  event.preventDefault();
  const form = event.target;
  const { id } = form.elements;
  await deleteSpa(id.value);
  location.reload();
}

displaySpas();

document.querySelector("#add-spa-form").addEventListener("submit", addSpa);
document
  .getElementById("update-spa-form")
  .addEventListener("submit", updateSpa);
document
  .getElementById("delete-spa-form")
  .addEventListener("submit", removeSpa);
