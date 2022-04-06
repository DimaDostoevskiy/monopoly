function ClickOnElement(event, name) {

  var card = document.getElementById("cardInfo");
  var elem = document.getElementById(name.id);

  console.log("name: " + name.id);
  console.log(card);

  var url = "https://localhost:7232/Game/Info?name=" + name.id;

  var response = httpGet(url);

  var arrJson = JSON.parse('[' + response + ']');

  card.innerText = arrJson[0].name;

  card.style.left = parseInt(elem.style.left) + 25 + "px";
  card.style.top  = parseInt(elem.style.top) + 25 + "px"

  console.log("response: " +  response);
  // document.body.appendChild(card);
}

function ClickOnArea(event) {

  var hero = document.getElementById("hero");
  var e = event;
  let der = "";

  var heroX = parseInt(hero.style.left);
  var heroY = parseInt(hero.style.top);

  var cursorX = e.clientX;
  var cursorY = e.clientY;

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

  var moveUrl = "https://localhost:7232/Game/Move?derection=" + der + "&name=" + hero.id;

  var response = httpGet(moveUrl);
  var arrJson = JSON.parse("[" + response + "]");

  hero.style.left = arrJson[0].positionX + "px";
  hero.style.top = arrJson[0].positionY + "px";

  console.log(response);

  if (arrJson[0].getUrl != null) {
    window.location.href = arrJson[0].getUrl;
  }

  console.log(arrJson[0].getUrl);
}

function httpGet(url) {
  var xmlHttp = new XMLHttpRequest();
  xmlHttp.open("GET", url, false);
  xmlHttp.send(null);
  return xmlHttp.responseText;
}

// function rightclick() {
//   var rightclick;
//   var e = window.event;
//   if (e.which) rightclick = (e.which == 3);
//   else if (e.button) rightclick = (e.button == 2);
//   alert(rightclick); // true or false, you can trap right click here by if comparison
// }
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