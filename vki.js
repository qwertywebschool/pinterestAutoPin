let weight = Number(prompt("please enter your weight"));
let height = Number(prompt("please enter your height"));

let total = weight/(height*2);

if (total < 18.5){
    console.log("body mass index less");
}else if (total >= 18.5 && total <= 24.9){
    console.log("average body mass index");
}else if (total >= 30 && total <= 39.9){
    console.log("average body mass index");
}else if (total >= 40){
    console.log("body mass index too high");
}else{
    console.log("error");
}
