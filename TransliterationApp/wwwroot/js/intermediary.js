var cellForDelete = '';
selectedCell = null;

$(document).ready(function () {

    GenerateTableForTranslitSystems();

    $('.left-block').on('click', '#chooseTranslitSystem', function () {
        ShowNap('.pop-up-translitSystemList');
        GetTranslitSystemList();
    });

    $('.pop-up-question').on('click', '#no', function () {
        $('.pop-up-question').css('display', 'none');
        $('.nap-for-confirm').css('display', 'none');
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
            $('.pop-up-question').css('display', 'block');
            $('.nap-for-confirm').css('display', 'block');
            cellForDelete = event.target.innerText;
            selectedCell = event.target;
            SelectCell(selectedCell, true);
        }
    });

});

function GenerateTableForTranslitSystems() {

    for (var i = 0; i < 15; i++) {
        var tr = document.createElement('tr');

        var td1 = document.createElement('td');
        td1.classList.add("table-td-translitSystem");
        tr.appendChild(td1);

        var td2 = document.createElement('td');
        td2.classList.add("table-td-translitSystem");
        tr.appendChild(td2);

        var td3 = document.createElement('td');
        td3.classList.add("table-td-translitSystem");
        tr.appendChild(td3);

        var td4 = document.createElement('td');
        td4.classList.add("table-td-translitSystem");
        tr.appendChild(td4);

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
    var cells, index = 0;

    for (var i = 0; i < data.length; i++) {
        if (i % 4 == 0) {
            cells = rows[i].children;
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