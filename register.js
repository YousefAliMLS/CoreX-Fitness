// Get the form
const form = document.querySelector("form");

// Handle submit
form.addEventListener("submit", function(e) {
    // Get all field values
    const username = document.getElementById("username").value.trim();
    const email = document.getElementById("email").value.trim();
    const password = document.getElementById("password").value.trim();
    
    // For number fields, get them as numbers
    const weight = parseFloat(document.getElementById("weight").value);
    const height = parseFloat(document.getElementById("height").value);
    const age = parseInt(document.getElementById("age").value);

    // --- Validation Checks ---

    // Check username
    if (username.length < 3) {
        alert("Username must be at least 3 letters");
        e.preventDefault(); // Stop submit
        return;
    }

    // Check email
    if (!email.includes("@") || !email.includes(".")) {
        alert("Please enter a valid email");
        e.preventDefault();
        return;
    }

    // Check password
    if (password.length < 6) {
        alert("Password must be at least 6 characters");
        e.preventDefault();
        return;
    }

    // Check weight
    if (isNaN(weight) || weight <= 0) {
        alert("Please enter a valid weight (must be > 0)");
        e.preventDefault();
        return;
    }

    // Check height
    if (isNaN(height) || height <= 0) {
        alert("Please enter a valid height (must be > 0)");
        e.preventDefault();
        return;
    }

    // Check age
    if (isNaN(age) || age <= 1) {
        alert("Please enter a valid age (must be > 1)");
        e.preventDefault();
        return;
    }

    // If all checks pass:
    alert("Registration Successful!");
});