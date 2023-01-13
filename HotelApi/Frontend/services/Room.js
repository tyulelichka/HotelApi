async function getRoom() {
  const response = await fetch("https://localhost:7156/Room", {
    method: "GET",
  });
  const result = await response.json();
  return result;
}

async function insertRoom(id, price, number, count) {
  try {
    const body = JSON.stringify({ id, price, number, count });
    const response = await fetch("https://localhost:7156/Room", {
      method: "POST",
      body,
      headers: { "Content-Type": "application/json" },
    });
    if (!response.ok) {
      throw new Error("Error");
    }
    console.log("Room was successfully added!");
  } catch (error) {
    console.log(error.message);
  }
}

async function newversionRoom(id, price, number, count) {
  try {
    const body = JSON.stringify({ id, price, number, count });
    const response = await fetch("https://localhost:7156/Room", {
      method: "PUT",
      body,
      headers: { "Content-Type": "application/json" },
    });
    if (!response.ok) {
      throw new Error("Error");
    }
    console.log("Room was successfully update!");
  } catch (error) {
    console.log(error.message);
  }
}

async function deleteRoom(id) {
  try {
    const response = await fetch(`https://localhost:7156/Room/${id}`, {
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
