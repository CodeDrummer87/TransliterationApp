var currentPopup = null;

$(document).ready(function () {
    var windowHeight = window.innerHeight;

    let headerHeight = windowHeight / 9;
    document.querySelector('header').style.height = headerHeight + "px";
    let footerHeight = windowHeight / 25;
    document.querySelector('footer').style.height = footerHeight + "px";
    let mainHeight = windowHeight - headerHeight - footerHeight - 50;
    document.querySelector('main').style.height = mainHeight + "px";

    var settingsLeft = window.innerWidth - window.innerWidth / 30;
    var settingsTop = windowHeight / 30;
    $('#cogwheels').css('left', settingsLeft + "px").css('top', settingsTop + 'px');

    SetPageLanguage();

    $('body').on('contextmenu', false)
        .on('mouseenter', '#cogwheels', function () {
            $(this).attr('src', '/images/cogwheel_hover.png');
        }).on('mouseout', '#cogwheels', function () {
            if (themeIsDark) {
                $(this).attr('src', '/images/cogwheel.png');
            }
            else {
                $(this).attr('src', '/images/cogwheel_black.png');
            }
        }).on('click', '#cogwheels', function () {
            ShowNap('.pop-up-settings');
        });

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
        if (themeIsDark) {
            $('.displayInfo').css('color', '#15D5DD').text(message);
        }
        else {
            $('.displayInfo').css('color', '#298A08').text(message);
        }
    }
    else {
        $('.displayInfo').css('color', '#DF0101').text(message);
    }
    sessionStorage.setItem('currentMessage', message);
    sessionStorage.setItem('content', $('#originalText').val());
}

function showMessageForRightBlock(message, success) {
    if (success) {
        if (themeIsDark) {
            $('.displaySystemInfo').css('color', '#46FF04').text(message);
        }
        else {
            $('.displaySystemInfo').css('color', '#0000CD').text(message);
        }
    }
    else {
        $('.displaySystemInfo').css('color', 'RED').text(message);
    }
    sessionStorage.setItem('currentSystem', message);
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
    if (langIsEng) {
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
    else {
        switch (month) {
            case '01': return 'Января';
            case '02': return 'Февраля';
            case '03': return 'Марта';
            case '04': return 'Апреля';
            case '05': return 'Мая';
            case '06': return 'Июня';
            case '07': return 'Июля';
            case '08': return 'Августа';
            case '09': return 'Сентября';
            case '10': return 'Октября';
            case '11': return 'Ноября';
            case '12': return 'Декабря';
            default: return 'undefined';
        }
    }
}

function SetPageLanguage () {
    var title = document.querySelector('title');
    var img = document.querySelectorAll('img');

    if (langIsEng) {
        title.innerText = "TRANSLITERATION";
        img[0].setAttribute('title', 'Settings');
        img[1].setAttribute('title', 'Create a new Transliteration System');
    }
    else {
        title.innerText = "ТРАНСЛИТЕРАЦИЯ";
        img[0].setAttribute('title', 'Настройки');
        img[1].setAttribute('title', 'Создать новую систему транслитерации');
    }

    SetHeadersLanguage();
    SetButtonsLanguage();
    SetParagraphLanguage();
    SetSpanLanguage();
    SetTableHeadLanguage();
    SetInputLanguage();
}

function SetButtonsLanguage() {
    var button = document.querySelectorAll('button');
    if (langIsEng) {
        button[0].innerHTML = "Saved Texts";
        button[1].innerHTML = "Select Transliteration System";
        button[2].innerHTML = "Apply";
        button[3].innerHTML = "Clear";
        button[4].innerHTML = "Save Text";
        button[5].innerHTML = "Save as";
        button[6].innerHTML = "Save";
        button[7].innerHTML = "Cancel";
        button[8].innerHTML = "Reset";
        button[9].innerHTML = "Save";
        button[10].innerHTML = "Yes";
        button[11].innerHTML = "No";
        button[12].innerHTML = "Save";
    }
    else {
        button[0].innerHTML = "Оригиналы";
        button[1].innerHTML = "Выбрать систему перевода";
        button[2].innerHTML = "Перевести";
        button[3].innerHTML = "Очистить";
        button[4].innerHTML = "Сохранить";
        button[5].innerHTML = "Сохранить";
        button[6].innerHTML = "Сохранить";
        button[7].innerHTML = "Отмена";
        button[8].innerHTML = "Сбросить";
        button[9].innerHTML = "Сохранить";
        button[10].innerHTML = "Да";
        button[11].innerHTML = "Нет";
        button[12].innerHTML = "Сохранить";
    }
}

function SetParagraphLanguage() {
    var pArray = document.querySelectorAll('p');

    var span1 = document.createElement('span');
    span1.classList.add('displaySystemInfo');

    pArray[72].innerHTML = '';
    var span = document.createElement('span');
    span.setAttribute('title', 'code.drummer87@gmail.com');
    var img = document.createElement('img');
    if (themeIsDark) {
        img.setAttribute('src', '/images/star87.png');
    }
    else {
        img.setAttribute('src', '/images/star87_lightTheme.png');
    }
    img.setAttribute('id', 'star');
    img.setAttribute('alt', 'star87');
    let city;
    if (langIsEng) {
        city = document.createTextNode("Omsk-2020");
    }
    else {
        city = document.createTextNode("Омск-2020");
    }

    if (langIsEng) {
        pArray[1].innerHTML = "Current System: ";
        pArray[4].innerHTML = "* To save a special character, use the hexadecimal code of this character: \\u0000";
        span.innerHTML = "Andrei Bodrov";
        pArray[72].appendChild(span);
        pArray[72].appendChild(img);
    }
    else {
        pArray[1].innerHTML = "Текущая Система: ";
        pArray[4].innerHTML = "* Чтобы сохранить спец.символы, используйте шестандцатеричный код этих символов: \\u0000";
        span.innerHTML = "Андрей Бодров";
        pArray[72].appendChild(span);
        pArray[72].appendChild(img);
    }
    pArray[1].appendChild(span1);
    pArray[72].appendChild(city);
}

function SetHeadersLanguage() {
    var headers_h1 = document.querySelectorAll('h1');
    var headers_h2 = document.querySelectorAll('h2');
    var headers_h3 = document.querySelectorAll('h3');
    var headers_h4 = document.querySelectorAll('h4');

    if (langIsEng) {
        //.:: h1
        headers_h1[0].innerHTML = "TRANSLATION TRANSLITERATION";
        headers_h1[1].innerHTML = "Original";
        headers_h1[2].innerHTML = "Translated";
        headers_h1[3].setAttribute('title', 'Places to save');
        //.:: h2
        headers_h2[0].innerHTML = "Save Source Text";
        headers_h2[1].innerHTML = "Current Limit for Save";
        headers_h2[2].innerHTML = "Available Transliteration Systems";
        headers_h2[3].innerHTML = "Setting new Transliteration System";
        headers_h2[4].innerHTML = "Save Translated Text";
        //.:: h3
        headers_h3[0].innerHTML = "Delete it?";
        //.:: h4
        headers_h4[0].innerHTML = "Theme";
        headers_h4[1].innerHTML = "Language";
    }
    else {
        //.:: h1
        headers_h1[0].innerHTML = "ПЕРЕВОД ТРАНСЛИТЕРАЦИИ";
        headers_h1[1].innerHTML = "Оригинал";
        headers_h1[2].innerHTML = "Перевод";
        headers_h1[3].setAttribute('title', 'Мест для сохранения');
        //.:: h2
        headers_h2[0].innerHTML = "Сохранить оригинальный текст";
        headers_h2[1].innerHTML = "Текущий Лимит Сохранений";
        headers_h2[2].innerHTML = "Доступные Системы Транслитерации";
        headers_h2[3].innerHTML = "Настройка новой Системы Транслитерации";
        headers_h2[4].innerHTML = "Сохранить перевод";
        //.:: h3
        headers_h3[0].innerHTML = "Удалить";
        //.:: h4
        headers_h4[0].innerHTML = "Тема";
        headers_h4[1].innerHTML = "Язык";
    }
}

function SetSpanLanguage() {
    var span = document.querySelectorAll('span');

    if (langIsEng) {
        span[1].innerHTML = ":::::::: Dark :::::::: ";
        span[2].innerHTML = ":::::::: Light :::::::: ";
        span[3].innerHTML = "::::: English ::::: ";
        span[4].innerHTML = "::::: Russian ::::: ";
        span[5].innerHTML = "Cancel";
        span[6].innerHTML = "Cancel";
        span[7].setAttribute('title', 'Save as .txt file');
        span[8].setAttribute('title', 'Save as .pdf file');
    }
    else {
        span[1].innerHTML = "::::: Тёмная :::::";
        span[2].innerHTML = "::::: Светлая :::::";
        span[3].innerHTML = "::: Английский :::";
        span[4].innerHTML = "::: Русский :::";
        span[5].innerHTML = "Отмена";
        span[6].innerHTML = "Отмена";
        span[7].setAttribute('title', 'Сохранить как .txt файл');
        span[8].setAttribute('title', 'Сохранить как .pdf файл');
    }
    span[1].setAttribute('id', 'darkTheme');
    span[2].setAttribute('id', 'lightTheme');
    span[3].setAttribute('id', 'engLang');
    span[4].setAttribute('id', 'rusLang');
}

function SetTableHeadLanguage() {
    var th = document.querySelectorAll('th');

    if (langIsEng) {
        th[0].innerHTML = "Text Name";
        th[1].innerHTML = "Summary";
        th[2].innerHTML = "Save date";
    }
    else {
        th[0].innerHTML = "Имя текста";
        th[1].innerHTML = "Описание";
        th[2].innerHTML = "Дата сохранения";
    }
    th[0].classList.add('table-th-textName');
    th[1].classList.add('table-th-textDescription');
    th[2].classList.add('table-th-saveDate');
}

function SetInputLanguage() {
    var input = document.querySelectorAll('input');

    if (langIsEng) {
        input[0].setAttribute('placeholder', 'Save as');
        input[65].setAttribute('placeholder', 'Enter name for new system');
        input[66].setAttribute('placeholder', 'Save as');
    }
    else {
        input[0].setAttribute('placeholder', 'Сохранить как');
        input[65].setAttribute('placeholder', 'Введите имя для новой системы');
        input[66].setAttribute('placeholder', 'Сохранить как');
    }
}