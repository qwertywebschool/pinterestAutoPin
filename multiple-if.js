
let name = prompt("name");
let number = Number(prompt("number"));
if (name == ''){
    console.log("error")
}else{
    check(number);
}

function check(number){
    if (number.length == 11){
        console.log("control")
    }else {
        console.log("number error");
    }
}