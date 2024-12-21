let dizel = 44.44;
let petrol = 44.33;
let gaz = 22.44;

let space ="\n";
let menu = "enter the type of fuel you want to buy" + space + "1- V/Max" + space + "2- Diesel" + space + "3- Gaz"

let choice = prompt(menu);

if (choice == "1" || choice == "2" || choice == "3"){
    if (choice == "1"){
        let balance=  Number(prompt("enter your balance"));
        if (balance >= dizel){
            let quantity = balance / dizel;
            alert("quantity :" + quantity);
        }else{
            alert("insufficient limit");
        }
    }else if (choice == "2") {
        let balance=  Number(prompt("enter your balance"));
        if (balance >= petrol){
            let quantity = balance / petrol;
            alert("quantity :" + quantity);
        }else{
            alert("insufficient limit");
        }
    }else{
        let balance=  Number(prompt("enter your balance"));
        if (balance >= gaz){
            let quantity = balance / gaz;
            alert("quantity :" + quantity);
        }else{
            alert("insufficient limit");
        }
    }
}else{
    alert("error");
}