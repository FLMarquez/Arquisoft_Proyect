// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function getAction(targetElement) {
    const elementClass = targetElement.className;
    const classList = elementClass.split(" "); 

    let results = {};

    results.url = classList
        .filter(className => className.startsWith('url='))
        .map(className => className.replace('url=', '').replace(/_/g, '/'))[0];

    results.action = classList
        .filter(className => className.startsWith('action='))
        .map(className => className.replace('action=', ''))[0];

    results.url = results.url.toLowerCase();
    results.action = results.action.toLowerCase();

    console.log('Resultados:', results);
    return results;
}
function changeButton(targetElement, trueCaseText, falseCaseText, trueCaseClass, falseCaseClass) {

    const elementClass = targetElement.className;
    const classList = elementClass.split(" ");

    let state = classList
        .filter(className => className.startsWith('state='))
        .map(className => className.replace('state=', ''));

    console.log(`Estado: ${state}`);
    console.log(`TrueCaseText and TrueCaseClass: ${trueCaseText} ${trueCaseClass}`);
    console.log(`TrueCaseText and TrueCaseClass: ${falseCaseText} ${falseCaseClass}`);


    if (state === true) {
        targetElement.innerText = trueCaseText;
        targetElement.classList.remove(falseCaseClass);
        targetElement.classList.add(trueCaseClass);
    } else {
        targetElement.innerText = falseCaseText;
        targetElement.classList.remove(trueCaseClass);
        targetElement.classList.add(falseCaseClass);

    }
}

function performPost(targetElement, url) {
    var modelData = targetElement.getAttribute("data-model");

    fetch("/" + url, {
        method: "POST",
        body: modelData,
        headers: {
            'Content-Type': 'application/json',
        }
    })
        .then(response => {
            console.log("Solicitud POST exitosa");
            return response.json();
        })
        .then(data => {
            console.log("Respuesta del servidor:", data);
            window.location.href = data.redirectUrl;
        })
        .catch(error => {
            console.error('Error en la solicitud fetch:', error);
        });
}

function performGet(url) {

    fetch("/" + url, {
        method: "GET",
        headers: {
            'Content-Type': 'application/json',
        }
    })
        .then(response => response.json())
        .then(data => {
            console.log("Datos recibidos:", data);
        })
        .catch(error => {
            console.error('Error en la solicitud fetch:', error);
        });

}
