async function displayRooms() {
  let rooms = await getRoom();

  let roomsTable = document.getElementById("getRoom");

  for (let room of rooms) {
    const { id, price, number, count } = room;

    const row = document.createElement("tr");

    const idEl = document.createElement("td");
    const priceEl = document.createElement("td");
    const numberEl = document.createElement("td");
    const countEl = document.createElement("td");

    idEl.classList.add("room-element");
    priceEl.classList.add("room-element");
    numberEl.classList.add("room-element");
    countEl.classList.add("room-element");

    idEl.innerText = id;
    priceEl.innerText = price;
    numberEl.innerText = number;
    countEl.innerText = count;

    row.append(idEl, priceEl, numberEl, countEl);

    roomsTable.append(row);
  }
}

async function addRoom(event) {
  event.preventDefault();
  const form = event.target;
  const { id, price, number, count } = form.elements;
  await insertRoom(id.value, price.value, number.value, count.value);

  location.reload();
}

async function updateRoom(event) {
  event.preventDefault();
  const form = event.target;
  const { id, price, number, count } = form.elements;
  await newversionRoom(id.value, price.value, number.value, count.value);

  location.reload();
}

async function removeRoom(event) {
  event.preventDefault();
  const form = event.target;
  const { id } = form.elements;
  await deleteRoom(id.value);
  location.reload();
}
displayRooms();

document.querySelector("#add-room-form").addEventListener("submit", addRoom);
document
  .getElementById("delete-room-form")
  .addEventListener("submit", removeRoom);
document
  .getElementById("update-room-form")
  .addEventListener("submit", updateRoom);
