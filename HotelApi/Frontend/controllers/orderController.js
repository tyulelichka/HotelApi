async function displayOrders() {
  let orders = await getOrder();

  let ordersTable = document.getElementById("getOrder");

  for (let order of orders) {
    const { id, userId, roomId, spaId, menuId } = order;

    const row = document.createElement("tr");

    const idEl = document.createElement("td");
    const userIdEl = document.createElement("td");
    const roomIdEl = document.createElement("td");
    const spaIdEl = document.createElement("td");
    const menuIdEl = document.createElement("td");

    idEl.classList.add("order-element");
    userIdEl.classList.add("order-element");
    roomIdEl.classList.add("order-element");
    spaIdEl.classList.add("order-element");
    menuIdEl.classList.add("order-element");

    idEl.innerText = id;
    userIdEl.innerText = userId;
    roomIdEl.innerText = roomId;
    spaIdEl.innerText = spaId;
    menuIdEl.innerText = menuId;

    row.append(idEl, userIdEl, roomIdEl, spaIdEl, menuIdEl);

    ordersTable.append(row);
  }
}

async function addOrder(event) {
  event.preventDefault();
  const form = event.target;
  const { id, userId, roomId, spaId, menuId } = form.elements;
  await insertOrder(
    id.value,
    userId.value,
    roomId.value,
    spaId.value,
    menuId.value
  );

  location.reload();
}

async function updateOrder(event) {
  event.preventDefault();
  const form = event.target;
  const { id, userId, roomId, spaId, menuId } = form.elements;
  await newversionOrder(
    id.value,
    userId.value,
    roomId.value,
    spaId.value,
    menuId.value
  );

  location.reload();
}

async function removeOrder(event) {
  event.preventDefault();
  const form = event.target;
  const { id } = form.elements;
  await deleteOrder(id.value);
  location.reload();
}

// in the bottom

displayOrders();

document.querySelector("#add-order-form").addEventListener("submit", addOrder);
document
  .getElementById("delete-order-form")
  .addEventListener("submit", removeOrder);
document
  .getElementById("update-order-form")
  .addEventListener("submit", updateOrder);
