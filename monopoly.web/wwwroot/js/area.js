function ClickOnElement(id) {

  var card = document.getElementById("cardInfo");
  var xhr = new XMLHttpRequest();

  card.hidden = false;

  var url = "https://localhost:7232/Game/Info/" + id;

  xhr.open("GET", url, false);
  xhr.send(null);

  var response = xhr.responseText;
  var arrJson = JSON.parse('[' + response + ']');

  card.innerText = arrJson[0].name;

  console.log("Info: " +  arrJson[0].name);
  document.body.appendChild(card);
}

function ClickOnArea(event) {

  var hero = document.getElementById("hero");
  var e = event;

  var heroX = parseInt(hero.style.left);
  var heroY = parseInt(hero.style.top);
  var cursorX = e.clientX;
  var cursorY = e.clientY;

  var der = "";

  console.log("CursorX: " + cursorX);
  console.log("CursorY: " + cursorY);
  console.log("HeroX: " + heroX);
  console.log("HeroY: " + heroY);

  if(cursorX > heroX) {
    der += "up";
  }
  else {
    der += "down";
  }
  if(cursorY > heroY) {
    der += "left";
  }
  else {
    der += "reight";
  }``

  var moveUrl = "https://localhost:7232/Game/Move?derection=" + der + "&id=" + 4;

  var response = httpGet(moveUrl);
  console.log(response);

  var arrJson = JSON.parse("[" + response + "]");

  console.log(arrJson[0].name);
  console.log(arrJson[0].positionX);
  console.log(arrJson[0].positionY);

  hero.style.left = arrJson[0].positionY + "px";
  hero.style.top = arrJson[0].positionX + "px";
}

function httpGet(url) {
  var xmlHttp = new XMLHttpRequest();
  xmlHttp.open("GET", url, false);
  xmlHttp.send(null);
  return xmlHttp.responseText;
}

// function printMousePos(event) {
//   document.body.textContent =
//     "clientX: " + event.clientX +
//     " - clientY: " + event.clientY;
// }

document.addEventListener("click", ClickOnArea);

// function httpPost(url, object) {
//   var result = "";
//   xmlhttp = new XMLHttpRequest();
//   xmlhttp.open("POST", url, true);

//   xmlhttp.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
//   xmlhttp.onreadystatechange = function () { //Call a function when the state changes.
//     if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
//       alert(xmlhttp.responseText);
//       result = xmlHttp.responseTex;
//     }
//   }
//   // var parameters = JSON.stringify(object);
//   xmlHttp.send("Id=1&lName=Smith")
//   // xmlhttp.send(object);
//   // console.log("send: " + parameters);
//   console.log("response: " + xmlhttp.responseTex);
//   return result;
// }