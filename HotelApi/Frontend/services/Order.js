async function getOrder() {
  const response = await fetch("https://localhost:7156/Order", {
    method: "GET",
  });
  const result = await response.json();
  return result;
}

async function insertOrder(id, userId, roomId, spaId, menuId) {
  try {
    const body = JSON.stringify({ id, userId, roomId, spaId, menuId });
    const response = await fetch("https://localhost:7156/Order", {
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

async function newversionOrder(id, userId, roomId, spaId, menuId) {
  try {
    const body = JSON.stringify({ id, userId, roomId, spaId, menuId });
    const response = await fetch("https://localhost:7156/Order", {
      method: "PUT",
      body,
      headers: { "Content-Type": "application/json" },
    });
    if (!response.ok) {
      throw new Error("Error");
    }
    console.log("Order was successfully update!");
  } catch (error) {
    console.log(error.message);
  }
}

async function deleteOrder(id) {
  try {
    const response = await fetch(`https://localhost:7156/Order/${id}`, {
      method: "DELETE",
    });
    if (!response.ok) {
      throw new Error("Error");
    }
    console.log("Room was successfully delete!");
  } catch (error) {
    console.log(error.message);
  }
}
