async function getSpa() {
  const response = await fetch("https://localhost:7156/Spa", {
    method: "GET",
  });
  const result = await response.json();
  return result;
}

async function insertSpa(id, name, price) {
  try {
    const body = JSON.stringify({ id, name, price });
    const response = await fetch("https://localhost:7156/Spa", {
      method: "POST",
      body,
      headers: { "Content-Type": "application/json" },
    });
    if (!response.ok) {
      throw new Error("Error");
    }
    console.log("Spa was successfully added!");
  } catch (error) {
    console.log(error.message);
  }
}

async function newversionSpa(id, name, price) {
  try {
    const body = JSON.stringify({ id, name, price });
    const response = await fetch("https://localhost:7156/Spa", {
      method: "PUT",
      body,
      headers: { "Content-Type": "application/json" },
    });
    if (!response.ok) {
      throw new Error("Error");
    }
    console.log("Spa was successfully update!");
  } catch (error) {
    console.log(error.message);
  }
}

async function deleteSpa(id) {
  try {
    const response = await fetch(`https://localhost:7156/Spa/${id}`, {
      method: "DELETE",
    });
    if (!response.ok) {
      throw new Error("Error");
    }
    console.log("Spa was successfully delete!");
  } catch (error) {
    console.log(error.message);
  }
}
