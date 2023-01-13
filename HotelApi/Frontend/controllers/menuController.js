async function displayMenus() {
  let menus = await getMenu();

  let menusTable = document.getElementById("getMenu");

  for (let menu of menus) {
    const { id, name, description, price } = menu;

    const row = document.createElement("tr");

    const idEl = document.createElement("td");
    const nameEl = document.createElement("td");
    const descriptionEl = document.createElement("td");
    const priceEl = document.createElement("td");

    idEl.classList.add("menu-element");
    nameEl.classList.add("menu-element");
    descriptionEl.classList.add("menu-element");
    priceEl.classList.add("menu-element");

    idEl.innerText = id;
    nameEl.innerText = name;
    descriptionEl.innerText = description;
    priceEl.innerText = price;

    row.append(idEl, nameEl, descriptionEl, priceEl);

    menusTable.append(row);
  }
}

async function addMenu(event) {
  event.preventDefault();
  const form = event.target;
  const { id, name, description, price } = form.elements;
  await insertMenu(id.value, name.value, description.value, price.value);

  location.reload();
}

async function updateMenu(event) {
  event.preventDefault();
  const form = event.target;
  const { id, name, description, price } = form.elements;
  await newversionMenu(id.value, name.value, description.value, price.value);

  location.reload();
}

async function removeMenu(event) {
  event.preventDefault();
  const form = event.target;
  const { id } = form.elements;
  await deleteMenu(id.value);
  location.reload();
}

// in the bottom

displayMenus();

document.querySelector("#add-menu-form").addEventListener("submit", addMenu);
document
  .getElementById("delete-menu-form")
  .addEventListener("submit", removeMenu);
document
  .getElementById("update-menu-form")
  .addEventListener("submit", updateMenu);
