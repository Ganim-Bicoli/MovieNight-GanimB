
function ShowTrailer() {
    document.getElementById("ytLink").style.display = "Block";
    document.getElementById("shadowBackground").style.display = "Block";
}

function BackToChoice() {
    document.getElementById("ytLink").style.display = "none";
    document.getElementById("shadowBackground").style.display = "none";
}


   
function getLocation() {
    var x = document.getElementById("demo"); //Hämtad från w3 school. https://www.w3schools.com/html/html5_geolocation.asp
  if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition);
    } else {
        x.innerHTML = "Geolocationx  is not supported by this browser.";
    }
  }
  
function showPosition(position) {
    var x = document.getElementById("demo"); 
    if (position.coords.latitude > 40) {   //kollar ifall användaren är inom ett vist område, om hen är ändras färgen på användarens namn
        document.getElementById("demo").style.color = "orange";
    }
    else {

        document.getElementById("demo").style.color = "#2DCAEF";
    }
    }



