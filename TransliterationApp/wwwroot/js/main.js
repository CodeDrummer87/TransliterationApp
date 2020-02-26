var currentPopup = null;
var elementForDelete = '';
var selectedRow = null;

$(document).ready(function () {
    var windowHeight = window.innerHeight;

    let headerHeight = windowHeight / 9;
    document.querySelector('header').style.height = headerHeight + "px";
    let footerHeight = windowHeight / 25;
    document.querySelector('footer').style.height = footerHeight + "px";
    let mainHeight = windowHeight - headerHeight - footerHeight - 50;
    document.querySelector('main').style.height = mainHeight + "px";

    $('body').on('contextmenu', false);
    $('#originalText').val(sessionStorage.getItem('content'));
    if (sessionStorage.getItem('currentMessage') != null) {
        showMessageForLeftBlock(sessionStorage.getItem('currentMessage'), true);
    }
    GenerateTable();

    $('body').on('click', '.nap', function () {
        HideNap();
    });

    $('.pop-up-cancel').on('click', 'span', function () {
        HideNap();
    });

    $('.pop-up-question').on('click', '#no', function () {
        $('.pop-up-question').css('display', 'none');
        $('.nap-for-confirm').css('display', 'none');
        elementForDelete = '';
        selectRow(selectedRow, false);
    }).on('click', '#yes', function () {
        DeleteSelectedSource(elementForDelete);
    });

    $('.left-block').on('click', '#loadSavedText', function () {
        ShowNap('.pop-up-sourceList');
        GetListSavedSourceTexts();
    }).on('click', '#clearOriginalText', function () {
        $('#originalText').val(" ");
        $('.displayInfo').css('color', '#15D5DD').text(".:: Input field cleared");
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
                $('.displayInfo').css('color', 'RED').text(".:: Name required");
                HideNap();
            }    
        }
        else {
            $('.displayInfo').css('color', 'RED').text(".:: Nothing to save");
            HideNap();
        }
    });

    $('tbody').on('mouseenter', 'tr', function () {
        $(this).css('color', '#15D5DD');
    }).on('mouseout', 'tr', function () {
        $(this).css('color', 'orange');
    }).on('mousedown', 'tr', function (event) {
        if (event.which == 1) {
            LoadSelectedSource(event.target);
        }
        if (event.which == 3) {
            $('.pop-up-question').css('display', 'block');
            $('.nap-for-confirm').css('display', 'block');
            elementForDelete = event.target.parentNode.children[0].innerText;   //.:: For 'pop-up-question'
            selectedRow = event.target;                                         //.:: also
            selectRow(selectedRow, true);       
        }
    });
});

function ShowNap(modal) {
    currentPopup = modal;
    $('.nap').css('display', 'block');
    $(modal).css('display', 'block');
}

function HideNap() {
    $(currentPopup).css('display', 'none');
    $('.nap').css('display', 'none');
}

function GenerateTable() {

    for (var i = 0; i < 20; i++) {
        var tr = document.createElement('tr');

        var td1 = document.createElement('td');
        td1.classList.add("table-th-textName");
        tr.appendChild(td1);

        var td2 = document.createElement('td');
        td2.classList.add("table-th-textDescription");
        tr.appendChild(td2);

        var td3 = document.createElement('td');
        td3.classList.add("table-th-saveDate");
        tr.appendChild(td3);

        document.getElementById('sourceList-table-body').appendChild(tr);
    }
}

function showMessageForLeftBlock(message, success) {
    if (success) {
        $('.displayInfo').css('color', '#15D5DD').text(message);
    }
    else {
        $('.displayInfo').css('color', 'RED').text(message);
    }
    sessionStorage.setItem('currentMessage', message);
    sessionStorage.setItem('content', $('#originalText').val());
}

function selectRow(row, selected) {
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
        url: "http://localhost:50860/sourcetext/post",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(text),
        success: function () {
            showMessageForLeftBlock(`.:: Text '${text.TextName}' saved successfully`, true);
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
        contentType: "application/json",
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
}

function GetDate(date) {
    var year = '';
    var month = '';
    var day = '';
    for (var i = 0; i < 10; i++) {
        if (i < 4) {
            year += date.charAt(i);
        }
        else if (i > 4 && i < 7) {
            month += date.charAt(i);
        }
        else if (i > 7 && i < 10) {
            day += date.charAt(i);
        }
    }
    return (day + " " + GetMonth(month) + " " + year);
}

function GetMonth(month) {
    switch (month) {
        case '01': return 'January';
        case '02': return 'February';
        case '03': return 'March';
        case '04': return 'April';
        case '05': return 'May';
        case '06': return 'June';
        case '07': return 'July';
        case '08': return 'August';
        case '09': return 'September';
        case '10': return 'October';
        case '11': return 'November';
        case '12': return 'December';
        default: return 'undefined';
    }
}