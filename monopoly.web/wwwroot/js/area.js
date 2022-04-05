function ClickOnElement(event, name) {
  
  var card = document.getElementById("cardInfo");
  var elem = document.getElementById(name.id);

  card.hidden = true;
  console.log("name: " + name.id);

  var url = "https://localhost:7232/Game/Info?name=" + name.id;

  var response = httpGet(url);
  
  var arrJson = JSON.parse('[' + response + ']');

  card.innerText = arrJson[0].name;

  card.style.left = elem.style.left;
  card.style.top  = elem.style.top;

  console.log("response: " +  response);
  document.body.appendChild(card);
}

function ClickOnArea(event) {

  var hero = document.getElementById("hero");
  var card = document.getElementById("cardInfo");
  card.hidden = false;
  var e = event;
  let der = "";

  var heroX = parseInt(hero.style.left);
  var heroY = parseInt(hero.style.top);
  var cursorX = e.clientX;
  var cursorY = e.clientY;

  // console.log("CursorX: " + cursorX);
  // console.log("CursorY: " + cursorY);
  // console.log("HeroX: " + heroX);
  // console.log("HeroY: " + heroY);
  
  if(cursorX > heroX) {
    der += "2";
  }
  else {
    der += "4";
  }
  if(cursorY > heroY) {
    der += "3";
  }
  else {
    der += "1";
  }

  var a = hero.id;

  var moveUrl = "https://localhost:7232/Game/Move?derection=" + der + "&name=" + a;

  var response = httpGet(moveUrl);
  // console.log(response);

  var arrJson = JSON.parse("[" + response + "]");

  hero.style.left = arrJson[0].positionX + "px";
  hero.style.top = arrJson[0].positionY + "px";
}

function httpGet(url) {
  var xmlHttp = new XMLHttpRequest();
  xmlHttp.open("GET", url, false);
  xmlHttp.send(null);
  return xmlHttp.responseText;
}

function rightclick() {
  var rightclick;
  var e = window.event;
  if (e.which) rightclick = (e.which == 3);
  else if (e.button) rightclick = (e.button == 2);
  alert(rightclick); // true or false, you can trap right click here by if comparison
}
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
//   xmlHttp.send(parameters)
//   return result;
// }