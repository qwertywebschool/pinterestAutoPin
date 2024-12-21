let number1 = Number(prompt("Number"));
let number2 = Number(prompt("Number"));
let number3 = Number(prompt("Number"));

let total = (number1 * 0.3) + (number2 * 0.3) + (number3 * 0.4);

if (total < 45){
    alert("limit");
}else if (total > 45 && total < 75){
    alert("averaj");
}else{
    alert("success");
}
