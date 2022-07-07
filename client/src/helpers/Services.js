export async function getAllUsers() {
  try {
    const response = await fetch("/api/users");
    return await response.json();
  } catch (error) {
    return [];
  }
}
