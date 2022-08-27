// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('.navbar-menu').find('[href="' + window.location.pathname + '"]').closest('a').addClass('active');
});

function loadTowns() {
    let regionDropdownEl = document.getElementById('region-dropdown');
    let regionId = regionDropdownEl.value;

    let xhr = new XMLHttpRequest();
    xhr.addEventListener('load', () => {
        requestHandler(xhr.response, '#town-dropdown');
    });

    xhr.open('GET', 'https://localhost:44349/Listings/ListTownsByRegionId?regionId=' + regionId);
    xhr.send();
}

function loadModels() {
    let makeDropdownEl = document.getElementById('make-dropdown')
    let makeId = makeDropdownEl.value;

    let xhr = new XMLHttpRequest();

    xhr.addEventListener('load', () => {
        requestHandler(xhr.response, '#model-dropdown');
    });

    xhr.open('GET', 'https://localhost:44349/Listings/ListModelsByMakeId?makeId=' + makeId);
    xhr.send();
}

function requestHandler(response, dropdownID) {
    let modelList = JSON.parse(response);
    $(dropdownID).empty();
    $(dropdownID).append($('<option>' + '</option>'));
    for (let model of modelList) {
        $(dropdownID).append($('<option value="' + model.id + '">' + model.name + '</option>'));
    }
}