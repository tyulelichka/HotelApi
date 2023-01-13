async function getUser() {
  const response = await fetch("https://localhost:7156/User", {
    method: "GET",
  });
  const resulf = await response.json();
  console.log(resulf);
  return resulf;
}

async function insertUser(id, fullName, email, password) {
  try {
    const body = JSON.stringify({ id, fullName, email, password });
    const response = await fetch("https://localhost:7156/User", {
      method: "POST",
      body,
      headers: { "Content-Type": "application/json" },
    });
    if (!response.ok) {
      throw new Error("Error");
    }
    console.log("Order was successfully added!");
  } catch (error) {
    console.log(error.message);
  }
}

async function newversionUser(id, fullName, email, password) {
  try {
    const body = JSON.stringify({ id, fullName, email, password });
    const response = await fetch("https://localhost:7156/User", {
      method: "PUT",
      body,
      headers: { "Content-Type": "application/json" },
    });
    if (!response.ok) {
      throw new Error("Error");
    }
    console.log("User was successfully update!");
  } catch (error) {
    console.log(error.message);
  }
}

async function deleteUser(id) {
  try {
    const response = await fetch(`https://localhost:7156/User/${id}`, {
      method: "DELETE",
    });
    if (!response.ok) {
      throw new Error("Error");
    }
    console.log("User was successfully delete!");
  } catch (error) {
    console.log(error.message);
  }
}
