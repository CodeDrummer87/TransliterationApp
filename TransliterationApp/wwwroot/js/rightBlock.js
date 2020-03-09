var formatFileAsPdf = false;

$(document).ready(function () {

    if (formatFileAsPdf) {
        ChooseFormat('.rightSpan', '.leftSpan');
    }
    else {
        ChooseFormat('.leftSpan', '.rightSpan');
    }

    $('.right-block-button').on('click', '#saveTranslatedText', function () {
        if ($('#translatedText').val() != '') {
            ShowNap('.pop-up-saveTranslatedText');
        }
        else {
            showMessageForLeftBlock(".:: Cannot save empty file", false);
        }
    });

    $('.pop-up-saveTranslatedText').on('click', '#saveToFile', function () {
        if ($('#inputTranslatedTextName').val() != '') {
            HideNap();
            SaveTranslatedText();
            $('#textNameError').text('');
        }
        else {
            $('#textNameError').css('color', 'RED').text("Requiring file name");
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
            showMessageForLeftBlock(".:: File download request error", false);
        }
    });
}

function ChooseFormat(active, inactive) {
    $(active).css('color', 'black').css('background-color', '#FFC873').css('box-shadow', '0px 0px 7px 3px #FFC873');
    $(inactive).css('color', '#FFA900').css('background-color', '#000000').css('box-shadow', 'none');
}