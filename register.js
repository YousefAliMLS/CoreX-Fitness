
const form = document.querySelector("form");


form.addEventListener("submit", async function(e) {
    e.preventDefault(); //stopping form from submitting by default.
    const username = document.getElementById("username").value.trim();
    const email = document.getElementById("email").value.trim();
    const password = document.getElementById("password").value.trim();
    
    const weight = parseFloat(document.getElementById("weight").value);
    const height = parseFloat(document.getElementById("height").value);
    const age = parseInt(document.getElementById("age").value);


    if (username.length < 3) {
        alert("Username must be at least 3 letters");
        e.preventDefault(); 
        return;
    }

    if (!email.includes("@") || !email.includes(".")) {
        alert("Please enter a valid email");
        e.preventDefault();
        return;
    }

    if (password.length < 6) {
        alert("Password must be at least 6 characters");
        e.preventDefault();
        return;
    }

    if (isNaN(weight) || weight <= 0) {
        alert("Please enter a valid weight (must be > 0)");
        e.preventDefault();
        return;
    }

    if (isNaN(height) || height <= 0) {
        alert("Please enter a valid height (must be > 0)");
        e.preventDefault();
        return;
    }

    if (isNaN(age) || age <= 1) {
        alert("Please enter a valid age (must be > 1)");
        e.preventDefault();
        return;
    }
    console.log("test1");
    try{
        const respone = await fetch("https://192.168.1.101:7019/api/Authentication/register", {
            method:"POST",
            headers: {"Content-Type":"application/json"},
            body: JSON.stringify({
                username:username,
                email:email,
                password:password,
                weight:weight,
                height:height,
                age:age
            })
        });
        console.log("test2");
        if(respone.ok){
            alert("Registeration success! ");
            window.location.href = "login Page.html"
        }else{
            alert("Invalid credentials! ");
        }
    }catch(error){
            console.log(error);
        }
});
