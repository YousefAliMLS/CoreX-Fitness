// get form
const form = document.querySelector("form");

// handle submit
form.addEventListener("submit", function(e) {
    const username = document.getElementById("Username").value.trim();
    const email = document.getElementById("email").value.trim();
    const password = document.getElementById("password").value.trim();

    // check username
    if(username.length < 3){
        alert("Username must be at least 3 letters");
        e.preventDefault(); // stop submit
        return;
    }

    // check email
    if(!email.includes("@") || !email.includes(".")){
        alert("Please enter a valid email");
        e.preventDefault();
        return;
    }

    // check password
    if(password.length < 6){
        alert("Password must be at least 6 characters");
        e.preventDefault();
        return;
    }

    // if all good:
    alert("Login Successful");
});
