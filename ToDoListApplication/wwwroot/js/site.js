// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
let arrOfClicked = [];
let isClicked = false;
const btn = document.getElementById('btn');
const trelement = document.getElementsByClassName('trelement');

function handleClick(val) {
    isClicked = !isClicked;
    let data = JSON.parse(val);
    if (isClicked) {
        btn.textContent = "Show Completed";
        for (let j = 0; j < trelement.length; j++) {
            for (let i = 0; i < data.length; i++) {
                if (data[j].Status == "Completed") {
                    trelement[j].style = "display:none";
                    arrOfClicked.push(j);
                }
            }
        }
    } else {
        btn.textContent = "Hide Completed";
        arrOfClicked.forEach(el => {
            trelement[el].style = "";
        })
        arrOfClicked = [];
    }
}

let clickedArr = [];
let clicked = false;
const button = document.getElementById('button');

function handleClickDueToday(val) {
    clicked = !clicked;
    let json = JSON.parse(val);
    if (clicked) {
        button.textContent = "Due Any Day";
        for (let j = 0; j < trelement.length; j++) {
            for (let i = 0; i < json.length; i++) {
                const date1 = new Date(json[j].DueDate);
                const date2 = new Date();
                if (date1.getDate() != date2.getDate() ||
                    date1.getMonth() != date2.getMonth()) {
                    trelement[j].style = "display:none";
                    clickedArr.push(j);
                }
            }
        }
    } else {
        button.textContent = "Due Today";
        clickedArr.forEach(el => {
            trelement[el].style = "";
        })
        clickedArr = [];
    }
}
