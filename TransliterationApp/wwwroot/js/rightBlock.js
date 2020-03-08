$(document).ready(function () {

    $('.right-block-button').on('click', '#saveTranslatedText', function () {
        ShowNap('.pop-up-saveTranslatedText');
    });

    $('.right-side').on('click', '#saveToFile', function () {
        HideNap();
        SaveTranslatedText();
    });
});

function SaveTranslatedText() {
    var translatedData = {
        fileName: $('#inputTranslatedTextName').val(),
        path: $('#inputPathSavingTranslatedText').val(),
        translatedText: $('#translatedText').val()
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