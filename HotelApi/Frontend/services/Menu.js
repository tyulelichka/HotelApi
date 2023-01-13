async function getMenu() {
  const response = await fetch("https://localhost:7156/Menu", {
    method: "GET",
  });
  const result = await response.json();
  console.log(result);
  return result;
}

async function insertMenu(id, name, description, price) {
  try {
    const body = JSON.stringify({ id, name, description, price });
    const response = await fetch("https://localhost:7156/Menu", {
      method: "POST",
      body,
      headers: { "Content-Type": "application/json" },
    });
    if (!response.ok) {
      throw new Error("Error");
    }
    console.log("Menu was successfully added!");
  } catch (error) {
    console.log(error.message);
  }
}

async function newversionMenu(id, name, description, price) {
  try {
    const body = JSON.stringify({ id, name, description, price });
    const response = await fetch("https://localhost:7156/Menu", {
      method: "PUT",
      body,
      headers: { "Content-Type": "application/json" },
    });
    if (!response.ok) {
      throw new Error("Error");
    }
    console.log("Menu was successfully update!");
  } catch (error) {
    console.log(error.message);
  }
}

async function deleteMenu(id) {
  try {
    const response = await fetch(`https://localhost:7156/Menu/${id}`, {
      method: "DELETE",
    });
    if (!response.ok) {
      throw new Error("Error");
    }
    console.log("Menu was successfully delete!");
  } catch (error) {
    console.log(error.message);
  }
}
