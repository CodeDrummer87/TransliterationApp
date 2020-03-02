var rowForDelete = '';
var selectedRow = null;

$(document).ready(function () {
    GetCurrentCounter();

    $('#originalText').val(sessionStorage.getItem('content'));
    if (sessionStorage.getItem('currentMessage') != null) {
        showMessageForLeftBlock(sessionStorage.getItem('currentMessage'), true);
    }
    GenerateTableForSourceList();

    $('.pop-up-question').on('click', '#no', function () {
        $('.pop-up-question').css('display', 'none');
        $('.nap-for-confirm').css('display', 'none');
        rowForDelete = '';
        if (selectedRow != null) {
            SelectRow(selectedRow, false);
        }
    }).on('click', '#yes', function () {
        if (rowForDelete != '') {
            DeleteSelectedSource(rowForDelete);
        }
    });

    $('.left-block').on('click', '#loadSavedText', function () {
        ShowNap('.pop-up-sourceList');
        GetListSavedSourceTexts();
    }).on('click', '#clearOriginalText', function () {
        $('#originalText').val('');
        showMessageForLeftBlock(".:: Input field cleared", true);
    }).on('click', '#saveSourceText', function () {
        ShowNap('.pop-up-saveSourceText');
        $('#inputSourceTextName').focus();
    });

    $('.pop-up-saveSourceText').on('click', '#saveSourceTextInDb', function () {

        let sourceText = $('#originalText').val();
        if (sourceText !== '') {

            let textName = $('#inputSourceTextName').val();
            if (textName !== '') {
                var text = {
                    TextName: textName,
                    TextDescription: $('#inputSourceTextDescription').val(),
                    TextContent: sourceText
                };
                SaveSourceTextInDb(text);

                $('#inputSourceTextName').val('');
                $('#inputSourceTextDescription').val('');
            }
            else {
                showMessageForLeftBlock(".:: Name required", false);
                HideNap();
            }
        }
        else {
            showMessageForLeftBlock(".:: Nothing to save", false)
            HideNap();
        }
    });

    $('.pop-up-sourceList').on('mousedown', 'tr', function (event) {
        if (event.which == 1) {
            LoadSelectedSource(event.target);
        }
        if (event.which == 3) {
            $('.pop-up-question').css('display', 'block');
            $('.nap-for-confirm').css('display', 'block');
            rowForDelete = event.target.parentNode.children[0].innerText;   //.:: For 'pop-up-question'
            selectedRow = event.target;                                     //.:: also
            SelectRow(selectedRow, true);
        }
    });
});

function GenerateTableForSourceList() {

    for (var i = 0; i < 20; i++) {
        var tr = document.createElement('tr');

        CreateCellForTable("table-th-textName", tr);
        CreateCellForTable("table-th-textDescription", tr);
        CreateCellForTable("table-th-saveDate", tr);

        document.getElementById('sourceList-table-body').appendChild(tr);
    }
}

function SelectRow(row, selected) {
    if (selected) {
        $(row.parentNode).css('background-color', '#5C4C4C');
    }
    else {
        $(row.parentNode).css('background-color', 'inherit');
    }
}

function LoadSelectedSource(row) {
    var textName = row.parentNode.children[0].innerText;
    $.ajax({
        url: "http://localhost:50860/sourcetext/getSelectedSource",
        method: "POST",
        contentType: "application/json",
        dataType: 'text',
        data: JSON.stringify(textName),
        success: function (data) {
            LoadSource(data);
        },
        error: function () {
            showMessageForLeftBlock(".:: Error loading source", false);
        }
    });
}

function DeleteSelectedSource(textName) {
    if (textName != null) {
        $.ajax({
            url: "http://localhost:50860/sourcetext/deleteSelectedSource",
            method: "POST",
            contentType: "application/json",
            dataType: 'text',
            data: JSON.stringify(textName),
            success: function (message) {
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

function LoadSource(text) {
    if (text != "undefined") {
        HideNap();
        data = JSON.parse(text);
        $.each(data, function (index, value) {
            $('#originalText').val(value.textContent);
            showMessageForLeftBlock(`.:: '${value.textName}' uploaded successfully`, true);
        });
    }
    else {
        showMessageForLeftBlock(".:: Unable to load source", false);
    }
}

function SaveSourceTextInDb(text) {
    $.ajax({
        url: "http://localhost:50860/sourcetext/saveSource",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(text),
        success: function (response) {
            GetCurrentCounter();
            if (response == 1) {
                showMessageForLeftBlock(`.:: Text '${text.TextName}' saved successfully`, true);
            }
            else if (response == -1) {
                showMessageForLeftBlock(".:: Text not saved. Storage limit for sources exceeded", false);
            }
            else if (response == -2) {
                showMessageForLeftBlock(".:: Source with the same name already exists. Enter a unique name", false);
            }
            else {
                showMessageForLeftBlock(".:: Save data was not sent", false);
            }
        },
        error: function () {
            showMessageForLeftBlock(`.:: Text '${text.TextName}' not saved`, false);
        }
    });
    HideNap();
}

function GetListSavedSourceTexts() {
    $.ajax({
        url: "http://localhost:50860/sourceText/GetListSourceText",
        method: "GET",
        success: function (data) {
            DisplaySourceList(data);
            showMessageForLeftBlock(".:: Source list uploaded", true);
        },
        error: function () {
            showMessageForLeftBlock(".:: Error loading source list", false);
        }
    });
}

function DisplaySourceList(list) {

    var tbody = document.querySelector('#sourceList-table-body');
    var rows = tbody.children;

    $.each(list, function (index, value) {
        var cells = rows[index].children;
        cells[0].innerText = value.textName;
        cells[1].innerText = value.textDescription;
        cells[2].innerHTML = GetDate(value.uploadDate);
    });

    GetCurrentCounter();
    let color = SetColorForCounter();
    $('.limit-counter > h1').css('color', color).text(sessionStorage.getItem('count'));
}

function GetCurrentCounter() {
    $.ajax({
        url: "http://localhost:50860/sourceText/getCurrentLimit",
        method: "POST",
        contentType: "application/json",
        success: function (data) {
            sessionStorage.setItem('count', data);
        },
        error: function () {
            showMessageForLeftBlock(".:: Error loading counter sources", false);
        }
    });
}