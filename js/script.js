var host = "https://localhost:";
var port = "7001/";
var stanoviEndpoint = "api/stanovi/";
var zgradeEndpoint = "api/zgrade/";
var statisticsEndpoint = "api/statistics";
var loginEndpoint = "api/authentication/login";
var registerEndpoint = "api/authentication/register";
var searchStanoviEndpoint = "api/pretraga";
var formAction = "Create";
var editingId;
var jwt_token;

function load() {
  var headers = {};
  if (jwt_token) {
    headers.Authorization = "Bearer " + jwt_token; // headers.Authorization = 'Bearer ' + sessionStorage.getItem(data.token);
  }
  loadStanovi();
  fetch(host + port + zgradeEndpoint, { headers: headers })
  .then((response) => {
    if (response.status === 200) {
      console.log("Successful action");
      response.json().then(setupZgrade);
    } else {
      console.log("Error occured with code " + response.status);
      alert("Desila se greska!");
    }
  })
  .catch((error) => console.log(error));
 
}


// prikaz forme za prijavu
function showLogin() {
  document.getElementById("formDiv").style.display = "none";
  document.getElementById("loginForm").style.display = "block";
  document.getElementById("registerForm").style.display = "none";
  document.getElementById("searchStanovi").style.display = "none";
  document.getElementById("data").style.display = "block";
  document.getElementById("logout").style.display = "none";
  document.getElementById("odustajanje").style.display = "block";
  document.getElementById("btnLogin").style.display = "none";
  document.getElementById("btnRegister").style.display = "none";
}

function validateRegisterForm(username, email, password, confirmPassword) {
  if (username.length === 0) {
    alert("Username field can not be empty.");
    return false;
  } else if (email.length === 0) {
    alert("Email field can not be empty.");
    return false;
  } else if (password.length === 0) {
    alert("Password field can not be empty.");
    return false;
  } else if (confirmPassword.length === 0) {
    alert("Confirm password field can not be empty.");
    return false;
  } else if (password !== confirmPassword) {
    alert("Password value and confirm password value should match.");
    return false;
  }
  return true;
}
function registerUser() {
  var username = document.getElementById("usernameRegister").value;
  var email = document.getElementById("emailRegister").value;
  var password = document.getElementById("passwordRegister").value;
  var confirmPassword = document.getElementById(
    "confirmPasswordRegister"
  ).value;

  if (validateRegisterForm(username, email, password, confirmPassword)) {
    var url = host + port + registerEndpoint;
    var sendData = { Username: username, Email: email, Password: password };
    fetch(url, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(sendData),
    })
      .then((response) => {
        if (response.status === 200) {
          console.log("Successful registration");
          alert("Successful registration");
          showLogin();
        } else {
          console.log("Error occured with code " + response.status);
          console.log(response);
          alert("Desila se greska!");
        }
      })
      .catch((error) => console.log(error));
  }
  return false;
}
function submitStanoviForm(){

	var brojStana = document.getElementById("brojStana").value;
    var tipStana = document.getElementById("tipStana").value;
    var brojKvadrata = document.getElementById("brojKvadrata").value;
    var cenaStana = document.getElementById("cenaStana").value;
    var zgrada = document.getElementById("zgrada").value;
	var httpAction;
	var sendData;
	var url;

	if (formAction === "Create") {
		httpAction = "POST";
		url = host + port + stanoviEndpoint;
		sendData = {
			"BrojStana": brojStana,
            "TipStana": tipStana,
            "BrojKvadrata": brojKvadrata,
            "CenaStana": cenaStana,
            "ZgradaId": zgrada
		};
	}
	else {
		httpAction = "PUT";
		url = host + port + stanoviEndpoint + editingId.toString();
		sendData = {
			"Id": editingId,
			"BrojStana": brojStana,
            "TipStana": tipStana,
            "BrojKvadrata": brojKvadrata,
            "CenaStana": cenaStana,
            "ZgradaId": zgrada
		};
	}

	console.log("Objekat za slanje");
	console.log(sendData);
	var headers = { 'Content-Type': 'application/json' };
	if (jwt_token) {
		headers.Authorization = 'Bearer ' + jwt_token;		// headers.Authorization = 'Bearer ' + sessionStorage.getItem(data.token);
	}
  if(validateStanoviForm(brojStana, tipStana, brojKvadrata, cenaStana))
	{
	fetch(url, { method: httpAction, headers: headers, body: JSON.stringify(sendData) })
		.then((response) => {
			if (response.status === 200 || response.status === 201) {
				console.log("Successful action");
				formAction = "Create";
				refreshTable();
			} else {
				console.log("Error occured with code " + response.status);
				alert("Desila se greska!");
			}
		})
		.catch(error => console.log(error));
  }
	return false;

}

function odustajanje() {

  var login = document.getElementById("loginForm").style.display;
  var registration = document.getElementById("registerForm").style.display;

  if(login === "block"){
    document.getElementById("loginForm").style.display = "none";
    document.getElementById("registerForm").style.display = "block";
    document.getElementById("btnLogin").style.display = "none";
    document.getElementById("btnRegister").style.display = "none";
  } else if(registration === "block"){
    document.getElementById("loginForm").style.display = "block";
    document.getElementById("registerForm").style.display = "none";
    document.getElementById("btnLogin").style.display = "none";
    document.getElementById("btnRegister").style.display = "none";
  }
}

// prikaz forme za registraciju
function showRegistration() {
  document.getElementById("formDiv").style.display = "none";
  document.getElementById("loginForm").style.display = "none";
  document.getElementById("registerForm").style.display = "block";
  document.getElementById("searchStanovi").style.display = "none";
  document.getElementById("data").style.display = "block";
  document.getElementById("logout").style.display = "none";
  document.getElementById("odustajanje").style.display = "block";
  document.getElementById("btnLogin").style.display = "none";
  document.getElementById("btnRegister").style.display = "none";
}
function validateStanoviForm(brojStana, tipStana, brojKvadrata, cenaStana) {
	if (brojStana.length === 0) {
		alert("Broj stana je obavezno polje.");
		return false;
	} else if (tipStana.length === 0) {
		alert("Tip stana je obavezno polje.");
		return false;    
	}
  else if (brojKvadrata === 0) {
		alert("Broj kvadrata je obavezno polje.");
		return false;    
	}
  else if (brojKvadrata <= 11 || brojKvadrata >= 300) {
		alert("Minimalna kvadrature je 11, a maksimalna 300.");
		return false;    
	} 
  else if (cenaStana <= 10000 || cenaStana >= 300000) {
		alert("Minimalna cena stana je 10000, a maksimalna 300000.");
		return false;    
	} 
  else if (cenaStana === 0) {
		alert("Cena stana je obavezno polje.");
		return false;    
	} 
	return true;
}

function validateLoginForm(username, password) {
  if (username.length === 0) {
    alert("Username field can not be empty.");
    return false;
  } else if (password.length === 0) {
    alert("Password field can not be empty.");
    return false;
  }
  return true;
}
function searchStanovi()
{
	var minCena = document.getElementById("minCena").value;
	var maxCena = document.getElementById("maxCena").value;

	var url = host + port + searchStanoviEndpoint;
	httpAction = "POST";
	sendData = {
		"minCena": minCena,
		"maxCena": maxCena
	};
	var headers = { 'Content-Type': 'application/json' };
	if (jwt_token) {
		headers.Authorization = 'Bearer ' + jwt_token;		// headers.Authorization = 'Bearer ' + sessionStorage.getItem(data.token);
	}
	fetch(url, { method: httpAction, headers: headers, body: JSON.stringify(sendData) })
		.then((response) => {
			if (response.status === 200 || response.status === 201) {
				response.json().then(setStanovi);
			} else {
				console.log("Error occured with code " + response.status);
				alert("Desila se greska!");
			}
		})
		.catch(error => console.log(error));
	return false;
}
function loginUser() {
  var username = document.getElementById("usernameLogin").value;
  var password = document.getElementById("passwordLogin").value;

  if (validateLoginForm(username, password)) {
    var url = host + port + loginEndpoint;
    var sendData = { Username: username, Password: password };
    fetch(url, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(sendData),
    })
      .then((response) => {
        if (response.status === 200) {
          console.log("Successful login");
          alert("Successful login");
          response.json().then(function (data) {
            console.log(data);
            document.getElementById("info").innerHTML =
              "Prijavljeni korisnik: <i>" + data.username + "<i/>.";
            document.getElementById("logout").style.display = "block";
            document.getElementById("btnLogin").style.display = "none";
            document.getElementById("loginForm").style.display = "none";
            document.getElementById("btnRegister").style.display = "none";
            jwt_token = data.token;
            loadStanovi();
          });
        } else {
          console.log("Error occured with code " + response.status);
          console.log(response);
          alert("Desila se greska!");
        }
      })
      .catch((error) => console.log(error));
  }
  return false;
}

// prikaz stanovi
function loadStanovi() {
  document.getElementById("data").style.display = "block";

  if (!jwt_token) {
    document.getElementById("loginForm").style.display = "none";
    document.getElementById("registerForm").style.display = "none";
  }

  // ucitavanje stanovi
  var requestUrl = host + port + stanoviEndpoint;
  console.log("URL zahteva: " + requestUrl);
  var headers = {};
  if (jwt_token) {
    headers.Authorization = "Bearer " + jwt_token; // headers.Authorization = 'Bearer ' + sessionStorage.getItem(data.token);
  }
  console.log(headers);
  fetch(requestUrl, { headers: headers })
    .then((response) => {
      if (response.status === 200) {
        response.json().then(setStanovi);
      } else {
        console.log("Error occured with code " + response.status);
        showError();
      }
    })
    .catch((error) => console.log(error));
}

function showError() {
  var container = document.getElementById("data");
  container.innerHTML = "";

  var div = document.createElement("div");
  var h1 = document.createElement("h1");
  var errorText = document.createTextNode("Greska prilikom preuzimanja Shop!");

  h1.appendChild(errorText);
  div.appendChild(h1);
  container.append(div);
}

// metoda za postavljanje autora u tabelu
function setStanovi(data) {
  var container = document.getElementById("data");
  container.innerHTML = "";

  console.log(data);

  // ispis naslova
  var div = document.createElement("div");
  var h1 = document.createElement("h1");
  var headingText = document.createTextNode("Stanovi");
  h1.appendChild(headingText);
  div.appendChild(h1);

  // ispis tabele
  var table = document.createElement("table");
  table.className = "table table-hover";
  var header = createHeader();
  table.append(header);

  var tableBody = document.createElement("tbody");

  for (var i = 0; i < data.length; i++) {
    // prikazujemo novi red u tabeli
    var row = document.createElement("tr");
    // prikaz podataka
    row.appendChild(createTableCell(data[i].tipStana));
    row.appendChild(createTableCell(data[i].brojKvadrata));
    row.appendChild(createTableCell(data[i].cenaStana));
    row.appendChild(createTableCell(data[i].zgradaAdresa));


    // prikaz forme
    if (jwt_token) {
      var stringId = data[i].id.toString();
      row.appendChild(createTableCell(data[i].brojStana));
      var buttonDelete = document.createElement("button");
      buttonDelete.className = "btn btn-secondary btn-sm";
      buttonDelete.name = stringId;
      buttonDelete.addEventListener("click", deleteStanovi);
      var buttonDeleteText = document.createTextNode("Delete");
      buttonDelete.appendChild(buttonDeleteText);
      var buttonDeleteCell = document.createElement("td");
      buttonDeleteCell.appendChild(buttonDelete);
      row.appendChild(buttonDeleteCell);
     

      document.getElementById("formDiv").style.display = "block";
      document.getElementById("searchStanovi").style.display = "block";

    }
    tableBody.appendChild(row);
  }
  table.appendChild(tableBody);
  div.appendChild(table);

  // ispis novog sadrzaja
  container.appendChild(div);
}
function cancel(){
    refreshTable();
}
function deleteStanovi() {
  // izvlacimo {id}
  var deleteID = this.name;
  // saljemo zahtev
  var url = host + port + stanoviEndpoint + deleteID.toString();
  var headers = { "Content-Type": "application/json" };
  if (jwt_token) {
    headers.Authorization = "Bearer " + jwt_token; // headers.Authorization = 'Bearer ' + sessionStorage.getItem(data.token);
  }
  fetch(url, { method: "DELETE", headers: headers })
    .then((response) => {
      if (response.status === 204) {
        console.log("Successful action");
        refreshTable();
      } else {
        console.log("Error occured with code " + response.status);
        alert("Desila se greska!");
      }
    })
    .catch((error) => console.log(error));
}
function createHeader() {
  var thead = document.createElement("thead");
  var row = document.createElement("tr");

  row.appendChild(createTableCell("Tip Stana"));
  row.appendChild(createTableCell("Broj kvadrata"));
  row.appendChild(createTableCell("Cena"));
  row.appendChild(createTableCell("Zgrada"));
  if (jwt_token) {
    row.appendChild(createTableCell("Stan"));
    row.appendChild(createTableCell("Delete"));
    // row.appendChild(createTableCell("Edit"));
  }
  thead.appendChild(row);
  return thead;
}
function createTableCell(text) {
  var cell = document.createElement("td");
  var cellText = document.createTextNode(text);
  cell.appendChild(cellText);
  return cell;
}

function setupZgrade(data) {
  var dropdown = document.getElementById("zgrada");
  dropdown.innerHTML = "";
  data.forEach((element) => {
    var option = document.createElement("option");
    option.value = element.id;
    var text = document.createTextNode(element.adresa);
    option.appendChild(text);
    dropdown.appendChild(option);
  });
}
function refreshTable() {
	// cistim formu
	document.getElementById("brojStana").value = "";
    document.getElementById("tipStana").value = "";
    document.getElementById("brojKvadrata").value = "";
    document.getElementById("cenaStana").value = "";
    document.getElementById("zgrada").value = "";
    document.getElementById("minCena").value = "";
    document.getElementById("maxCena").value = "";
    load();
	// osvezavam
	document.getElementById("loginForm").click();
};

function logout() {
	jwt_token = undefined;
	document.getElementById("info").innerHTML = "";
	document.getElementById("data").style.display = "block";
	document.getElementById("formDiv").style.display = "none";
  document.getElementById("searchStanovi").style.display = "none";
	document.getElementById("loginForm").style.display = "block";
	document.getElementById("registerForm").style.display = "none";
	document.getElementById("logout").style.display = "none";
	document.getElementById("btnLogin").style.display = "initial";
	document.getElementById("btnRegister").style.display = "initial";
}