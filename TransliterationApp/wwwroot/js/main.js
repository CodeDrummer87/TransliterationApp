var currentPopup = null;

$(document).ready(function () {
    var windowHeight = window.innerHeight;

    let headerHeight = windowHeight / 9;
    document.querySelector('header').style.height = headerHeight + "px";
    let footerHeight = windowHeight / 25;
    document.querySelector('footer').style.height = footerHeight + "px";
    let mainHeight = windowHeight - headerHeight - footerHeight - 50;
    document.querySelector('main').style.height = mainHeight + "px";

    $('body').on('contextmenu', false);

    $('body').on('click', '.nap', function () {
        HideNap();
    });

    $('.pop-up-cancel').on('click', 'span', function () {
        HideNap();
    });
});

function CreateCellForTable(nameOfClass, row) {
    var td = document.createElement('td');
    td.classList.add(nameOfClass);
    row.appendChild(td);
}

function ShowNap(modal) {
    currentPopup = modal;
    $('.nap').css('display', 'block');
    $(modal).css('display', 'block');
}

function HideNap() {
    $(currentPopup).css('display', 'none');
    $('.nap').css('display', 'none');
}

function ShowConfirm(state) {
    if (state) {
        $('.pop-up-question').css('display', 'block');
        $('.nap-for-confirm').css('display', 'block');
    }
    else {
        $('.pop-up-question').css('display', 'none');
        $('.nap-for-confirm').css('display', 'none');
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

function showMessageForRightBlock(message, success) {
    if (success) {
        $('.displaySystemInfo').css('color', '#46FF04').text(message);
    }
    else {
        $('.displaySystemInfo').css('color', 'RED').text(message);
    }
}

function SetColorForCounter() {
    let counter = sessionStorage.getItem('count');
    let color = '#FFA900';
    if (counter > 10) {
        color = '#46FF04';
    }
    if (counter <= 10 && counter > 5) {
        color = '#F8F908';
    }
    else if (counter <= 5) {
        color = '#D00019';
    }
    return color;
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