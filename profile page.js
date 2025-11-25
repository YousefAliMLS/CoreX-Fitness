
console.log("Testing the js here. ");
console.log("This means the js is working! ");
const form = document.querySelector("form");


form.addEventListener("submit", async function (e) {
    e.preventDefault();

    const username = document.getElementById("username").value.trim();
    console.log("This means the js is working! ");
    const email = document.getElementById("new-email").value.trim()
    console.log("This means the js is working! ");
    const currentEmail = document.getElementById("email").value.trim();
    console.log("This means the js is working! ");
    const age = Number(document.getElementById("age").value.trim());
    console.log("This means the js is working! ");
    const weight = Number(document.getElementById("weight").value.trim());
    console.log("This means the js is working! ");
    const height = Number(document.getElementById("height").value.trim());
    console.log("This means the js is working! ");
    const Current_Password = document.getElementById("password").value.trim();
    console.log("This means the js is working! ");
    const New_Password = document.getElementById("new-password").value.trim();
    console.log("This means the js is working! ");
    const Confirm_Password = document.getElementById("confirm-password").value.trim();
    console.log("This means the js is working! ");



    if(New_Password !== Confirm_Password){
        alert("The Confirm Password mismatches the new Password! please re-enter them again. ");
        return; //stopping the function here, so we do not send to the backend useless response.
    }

    try{
        const response = await fetch("https://127.0.0.1:7019/api/Authentication/PasswordChecker", {
            method: "POST",
            headers: {"Content-Type":"application/json"},
            body:JSON.stringify({
                PasswordChecker: Current_Password,
                CurrentEmail:currentEmail 
            })
        });
        if(response.ok)
            console.log("Checking is Done! ");
        else{
            console.log("Checking countred a problem! ");
            return ;
        }
    }catch(error){
        console.log(error);
        return;
    }

    try{
        const response = await fetch("https://127.0.0.1:7019/api/Authentication/updateUserInformation", {
            method: "POST",
            headers: {"Content-Type":"application/json"},
            body: JSON.stringify({
                userName:username,
                currentEmail:currentEmail,
                email: email,   
                age:parseInt(age),
                weight:parseFloat(weight),
                height:parseFloat(height),
                password: New_Password
            })
        });
        console.log("API IS WORKING. "); 
        if(response.ok){
            alert("Details changed successfully! ");
            console.log("API IS WORKING. ");   
        }//200
        
        else{
            alert("Invalid credentials! "); //400
            console.log("API IS WORKING. "); 
        }
    }catch(error){
        console.log(error);//500 (api)
        return;
    }


})