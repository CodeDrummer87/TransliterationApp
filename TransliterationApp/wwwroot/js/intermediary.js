﻿var cellForDelete = '';
selectedCell = null;

$(document).ready(function () {

    GenerateTableForTranslitSystems();

    $('.left-block').on('click', '#chooseTranslitSystem', function () {
        ShowNap('.pop-up-translitSystemList');
        GetTranslitSystemList();
    });

    $('.pop-up-creatingNewSystem').on('click', '#createNewSystemCancel', function () {
        NapOverNap(false);
        ClearInputFields();
    }).on('click', '#createNewSystemReset', function () {
        ClearInputFields();
    }).on('click', '#createNewSystemSave', function () {
        if ($('#newSystemName').val() != '') {
            SaveNewTransliterationSystem();
            NapOverNap(false);
            HideNap();
            ClearInputFields();
        }
        else {
            $('#systemSaveError').css('color', 'RED').text("Name required for new transliteration system");
        }
    });

    $('.pop-up-question').on('click', '#no', function () {
        ShowConfirm(false);
        cellForDelete = '';
        if (selectedCell != null) {
            SelectCell(selectedCell, false);
        }
    }).on('click', '#yes', function () {
        if (cellForDelete != '') {
            DeleteSelectedTransliterationSystem(cellForDelete);
        }
    });

    $('.pop-up-translitSystemList').on('mousedown', 'tr', function (event) {
        if (event.which == 1) {

        }
        else if (event.which == 3) {
            ShowConfirm(true);
            cellForDelete = event.target.innerText;
            selectedCell = event.target;
            SelectCell(selectedCell, true);
        }
    }).on('mouseenter', 'img', function () {
        $(this).attr('src', '/images/addNewSystem_hover.png');
    }).on('mouseout', 'img', function () {
        $(this).attr('src', '/images/addNewSystem.png');
    }).on('click', 'img', function () {
        NapOverNap(true);
        $('#newSystemName').focus();
    });;

});

function GenerateTableForTranslitSystems() {

    for (var i = 0; i < 10; i++) {
        var tr = document.createElement('tr');

        CreateCellForTable("table-td-translitSystem", tr);
        CreateCellForTable("table-td-translitSystem", tr);
        CreateCellForTable("table-td-translitSystem", tr);
        CreateCellForTable("table-td-translitSystem", tr);

        document.getElementById('translitSystem-table-body').appendChild(tr);
    }
}

function SelectCell(cell, selected) {
    if (selected) {
        $(cell).css('background-color', '#5C4C4C');
    }
    else {
        $(cell).css('background-color', 'inherit');
    }
}

function NapOverNap(state) {
    if (state) {
        $('.nap-for-creatingSystem').css('display', 'block');
        $('.pop-up-creatingNewSystem').css('display', 'block');
    }
    else {
        $('.nap-for-creatingSystem').css('display', 'none');
        $('.pop-up-creatingNewSystem').css('display', 'none');
    }
}

function ClearInputFields() {
    $('.addChar').val('');
    $('#newSystemName').val('');
    $('#systemSaveError').text('');
}

function GetTranslitSystemList() {
    $.ajax({
        url: "http://localhost:50860/translitSystem/GetTranslitSystemList",
        method: "GET",
        cache: false,
        success: function (data) {
            DisplayAvailabeTranslitSystems(data);
            showMessageForLeftBlock(".:: Transliteration systems list uploaded successfully", true);
        },
        error: function () {
            showMessageForLeftBlock(".:: Error loading list of available transliteration systems", false);
        }
    });
}

function DisplayAvailabeTranslitSystems(data) {

    var tbody = document.querySelector('#translitSystem-table-body');
    var rows = tbody.children;
    var cells, index;
    var rowCounter = 0;
    for (var i = 0; i < data.length; i++) {
        if (i % 4 == 0) {
            cells = rows[rowCounter++].children;
            index = 0;
        }
        cells[index++].innerText = data[i].systemName;
    }
}

function DeleteSelectedTransliterationSystem(translitSystem) {
    if (translitSystem != null) {
        $.ajax({
            url: "http://localhost:50860/translitSystem/deleteSelectedTranslitSystem",
            method: "POST",
            contentType: "application/json",
            dataType: 'text',
            data: JSON.stringify(translitSystem),
            success: function(message) {
                HideNap();
                showMessageForLeftBlock(message, true);
                window.location = window.location.href = "http://localhost:50860/";
            },
            error: function () {
                showMessageForLeftBlock(".:: The request failed", false);
            }
        });
    }
    else {
        showMessageForLeftBlock(".:: Error of deleting", false);
    }
}

function SaveNewTransliterationSystem() {

    var newSystem = GetNewSystem();

    $.ajax({
        url: "http://localhost:50860/TranslitSystem/SaveNewTransliterationSystem",
        method: "POST",
        contentType: "application/json",
        dataType: "text",
        data: JSON.stringify(newSystem),
        success: function (message) {
            showMessageForLeftBlock(message, true);
        },
        error: function () {
            showMessageForLeftBlock(".:: Server error! New transliteration system has not been saved", false);
        }
    });
}

function GetNewSystem() {
    var input = document.getElementsByClassName('addChar');
    var system = [];

    for (var i = 0; i < input.length; i++) {
        system.push(input[i].value);
    }

    var systemName = $('#newSystemName').val();
    system.push(systemName);

    return system;
}