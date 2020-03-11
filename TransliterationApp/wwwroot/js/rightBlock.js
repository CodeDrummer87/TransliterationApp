var formatFileAsPdf = false;
var themeIsDark;
var langIsEng;

if (localStorage.getItem('theme') != null) {
    if (localStorage.getItem('theme') == 'darkTheme') {
        themeIsDark = true;
    }
    else {
        themeIsDark = false;
    }
}
else {
    themeIsDark = true;
}

if (localStorage.getItem('language') != null) {
    if (localStorage.getItem('language') == 'English') {
        langIsEng = true;
    }
    else {
        langIsEng = false;
    }
}
else {
    langIsEng = true;
}

$(document).ready(function () {

    if (themeIsDark) {
        ChooseSetting('#darkTheme', '#lightTheme');
        GetTheme(themeIsDark);
    }
    else {
        ChooseSetting('#lightTheme', '#darkTheme');
        GetTheme(themeIsDark);
    }

    if (formatFileAsPdf) {
        ChooseFormat('.rightSpan', '.leftSpan');
    }
    else {
        ChooseFormat('.leftSpan', '.rightSpan');
    }

    $('.pop-up-settings').on('click', '#darkTheme', function () {
        themeIsDark = true;
        localStorage.setItem('theme', 'darkTheme');
        ChooseSetting('#darkTheme', '#lightTheme');
        GetTheme(themeIsDark);
    }).on('click', '#lightTheme', function () {
        themeIsDark = false;
        localStorage.setItem('theme', 'lightTheme');
        ChooseSetting('#lightTheme', '#darkTheme');
        GetTheme(themeIsDark);
    }).on('click', '#engLang', function () {
        langIsEng = true;
        localStorage.setItem('language', 'English');
        ChooseSetting('#engLang', '#rusLang');
    }).on('click', '#rusLang', function () {
        langIsEng = false;
        localStorage.setItem('language', 'Russian');
        ChooseSetting('#rusLang', '#engLang');
    });

    $('.right-block-button').on('click', '#saveTranslatedText', function () {
        if ($('#translatedText').val() != '') {
            ShowNap('.pop-up-saveTranslatedText');
        }
        else {
            if (langIsEng) {
                showMessageForLeftBlock(".:: Cannot save empty file", false);
            }
            else {
                showMessageForLeftBlock(".:: Нельзя сохранять пустой файл", false);
            }
        }
    });

    $('.pop-up-saveTranslatedText').on('click', '#saveToFile', function () {
        if ($('#inputTranslatedTextName').val() != '') {
            HideNap();
            SaveTranslatedText();
            $('#textNameError').text('');
        }
        else {
            if (langIsEng) {
                $('#textNameError').css('color', 'RED').text("Requiring file name");
            }
            else {
                $('#textNameError').css('color', 'RED').text("Требуется имя для файла");
            }
        }       
    });

    $('.pop-up-saveTranslatedText > h3').on('click', '.leftSpan', function () {      
        formatFileAsPdf = false;
        ChooseFormat('.leftSpan', '.rightSpan');
    }).on('click', '.rightSpan', function () {
        formatFileAsPdf = true;
        ChooseFormat('.rightSpan', '.leftSpan');
    });
});

function SaveTranslatedText() {
    var translatedData = {
        fileName: $('#inputTranslatedTextName').val(),
        translatedText: $('#translatedText').val(),
        asPdf: formatFileAsPdf
    };

    $.ajax({
        url: "http://localhost:50860/TranslatedText/SaveAsFileTranslatedText",
        method: "POST",
        contentType: "application/json",
        data: JSON.stringify(translatedData),
        success: function (message) {
            showMessageForLeftBlock(message, true);
        },
        error: function () {
            if (langIsEng) {
                showMessageForLeftBlock(".:: File download request error", false);
            }
            else {
                showMessageForLeftBlock(".:: Ошибка запроса на сохранение файла", false);
            }
        }
    });
}

function ChooseFormat(active, inactive) {
    if (themeIsDark) {
        $(active).css('color', '#000000').css('background-color', '#FFC873').css('box-shadow', '0px 0px 7px 3px #FFC873');
        $(inactive).css('color', '#FFA900').css('background-color', '#000000').css('box-shadow', 'none');
    }
    else {
        $(active).css('color', '#000000').css('background-color', '#FFFFFF').css('box-shadow', '0px 0px 7px 3px #FFFFFF');
        $(inactive).css('color', '#000000').css('background-color', '#BCF5A9').css('box-shadow', 'none');
    }
}

function ChooseSetting(active, inactive) {
    if (themeIsDark) {
        $(active).css('color', '#024306').css('background-color', '#7CE1E5').css('box-shadow', '0px 0px 7px 3px #7CE1E5');
        $(inactive).css('color', '#15D5DD').css('background-color', '').css('box-shadow', 'none');
    }
    else {
        $(active).css('color', '#024306').css('background-color', '#90EE90').css('box-shadow', '0px 0px 7px 3px #98FB98');
        $(inactive).css('color', '#FFFFFF').css('background-color', '').css('box-shadow', 'none');
    }
}

function GetTheme(theme) {
    if (theme) {
        SetDarkTheme();
    }
    else {
        SetLightTheme();
    }
}

function SetDarkTheme() {
    $('body').css('color', '#FFA900').css('background-color', '#000000');
    $('html').css('color', '#FFA900').css('background-color', '#000000');
    $('textarea').css('background-color', '#FFA900').css('color', '#000000');
    $('#originalText, #translatedText').css('color', '#FFA900').css('background-color', '#282626');
    $('input').css('background-color', '#FFC873');
    $('.pop-up-saveSourceText > textarea').css('background-color', '#FFC873');
    $('hr').css('background-color', '#FFA900');
    $('button').css('color', '#000000').css('background-color', '#FFA900').hover(function () {
        $(this).css('color', '#D00019').css('background-color', '#FFC873').css('box-shadow', '0px 0px 7px 3px #FFC873');
    }).mouseout(function () {
        $(this).css('color', '#000000').css('background-color', '#FFA900').css('box-shadow', 'none');
    });
    $('.left-block').css('border-color', '#FFA900');
    ChooseSetting('#darkTheme', '#lightTheme');
    if (langIsEng) {
        ChooseSetting('#engLang', '#rusLang');
    }
    else {
        ChooseSetting('#rusLang', '#engLang');
    }
    $('.displayInfo').css('color', '#15D5DD');
    $('.pop-up-saveSourceText, .pop-up-question, .pop-up-saveTranslatedText').css('background-color', '#000000');
    $('.pop-up-sourceList').css('color', '#FFA900');
    $('.pop-up-saveSourceText, .pop-up-question, .pop-up-saveTranslatedText')
        .css('box-shadow', '0px 0px 7px 3px #FFC873')
        .css('border', '3px inset #FFA900');
    $('th, .limit-counter').css('color', '#20F8F0');
    $('.pop-up-translitSystemList').css('color', '#FFA900');
    $('#translitSystem-table-body').css('color', '#5BBD10');
    ChooseFormat('.leftSpan', '.rightSpan');
    $('.displaySystemInfo').css('color', '#46FF04');
    $('#star').attr('src', '/images/star87.png');
    $('#cogwheels').attr('src', '/images/cogwheel.png');
    $('.pop-up-translitSystemList > img').attr('src', '/images/addNewSystem.png');
    $('.pop-up-creatingNewSystem').css('color', '#FFA900');
    $('.td-addChar').css('border-color', 'ORANGE');
}

function SetLightTheme() {
    $('body').css('color', '#000000').css('background-color', '#BCF5A9');
    $('html').css('color', '#000000').css('background-color', '#BCF5A9');
    $('textarea, input').css('color', '#000000').css('background-color', '#FFFFFF');
    $('hr').css('background-color', '#000000');
    $('button').css('color', '#FFFF00').css('background-color', '#04B404').hover(function () {
        $(this).css('color', '#31B404').css('background-color', '#F7FE2E').css('box-shadow', '0px 0px 7px 3px #F3F781');
    }).mouseout(function () {
        $(this).css('color', '#FFFF00').css('background-color', '#04B404').css('box-shadow', 'none');
    });
    $('.left-block').css('border-color', '#000000');
    ChooseSetting('#lightTheme', '#darkTheme');
    if (langIsEng) {
        ChooseSetting('#engLang', '#rusLang');
    }
    else {
        ChooseSetting('#rusLang', '#engLang');
    }
    $('.displayInfo').css('color', '#298A08');
    $('.pop-up-saveSourceText, .pop-up-question, .pop-up-saveTranslatedText').css('background-color', '#BCF5A9');
    $('.pop-up-sourceList, #translitSystem-table-body').css('color', '#FFFFFF');
    $('.pop-up-saveSourceText, .pop-up-question, .pop-up-saveTranslatedText')
        .css('box-shadow', '0px 0px 7px 3px #82FA58')
        .css('border', '3px inset #01DF01');
    $('th, .limit-counter, .pop-up-translitSystemList').css('color', '#3ADF00');
    ChooseFormat('.leftSpan', '.rightSpan');
    $('.displaySystemInfo').css('color', '#0000CD');
    $('#star').attr('src', '/images/star87_lightTheme.png');
    $('#cogwheels').attr('src', '/images/cogwheel_black.png');
    $('.pop-up-translitSystemList > img').attr('src', '/images/addNewSystem_light.png');
    $('.pop-up-creatingNewSystem').css('color', '#0BC119');
    $('.td-addChar').css('border-color', '#0BC119');
}