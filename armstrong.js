let number = prompt("enter a number");
let total = 0;
for (i = 0; i < number.length; i++)
{
    let control = number.charAt(i);
    total += control * control * control;
}
if (Number(number) === total){
    true;
}else{
    false;
}