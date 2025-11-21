//get form
const form = document.querySelector("form");

//handle submit
form.addEventListener("submit", async function(e) {
    e.preventDefault();
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

    try{
        const respone = await fetch("https://192.168.1.101:7019/api/Authentication/Login", {
            method: "POST",
            headers: {"Content-Type":"application/json"},
            body: JSON.stringify({
                username: username,
                email:email,
                password:password
            })
        });
        if(respone.ok){
            // if all good:
            alert("Login Successful");
            window.location.href = "profile page.html"
        }else{
            alert("Invalid username or password! ");
        }
    }catch(error){
        console.log(error);
    }
});
