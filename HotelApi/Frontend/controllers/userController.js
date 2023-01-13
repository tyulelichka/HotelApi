async function displayUsers() {
  let users = await getUser();

  let usersTable = document.getElementById("getUser");

  for (let user of users) {
    const { id, fullName, email, password } = user;

    const row = document.createElement("tr");

    const idEl = document.createElement("td");
    const fullNameEl = document.createElement("td");
    const emailEl = document.createElement("td");
    const passwordEl = document.createElement("td");

    idEl.classList.add("user-element");
    fullNameEl.classList.add("user-element");
    emailEl.classList.add("user-element");
    passwordEl.classList.add("user-element");

    idEl.innerText = id;
    fullNameEl.innerText = fullName;
    emailEl.innerText = email;

    passwordEl.innerText = password;

    row.append(idEl, fullNameEl, emailEl, passwordEl);

    usersTable.append(row);
  }
}

async function addUser(event) {
  event.preventDefault();
  const form = event.target;
  const { id, fullName, email, password } = form.elements;
  await insertUser(id.value, fullName.value, email.value, password.value);

  location.reload();
}

async function updateUser(event) {
  event.preventDefault();
  const form = event.target;
  const { id, fullName, email, password } = form.elements;
  await newversionUser(id.value, fullName.value, email.value, password.value);

  location.reload();
}

async function removeUser(event) {
  event.preventDefault();
  const form = event.target;
  const { id } = form.elements;
  await deleteUser(id.value);
  location.reload();
}

// in the bottom

displayUsers();

document.querySelector("#add-user-form").addEventListener("submit", addUser);
document
  .getElementById("delete-user-form")
  .addEventListener("submit", removeUser);
document
  .getElementById("update-user-form")
  .addEventListener("submit", updateUser);
