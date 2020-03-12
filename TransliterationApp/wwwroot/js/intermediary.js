var cellForDelete = '';
selectedCell = null;

$(document).ready(function () {

    if (sessionStorage.getItem('currentSystem') != null) {
        showMessageForRightBlock(sessionStorage.getItem('currentSystem'), true);
    }

    GenerateTableForTranslitSystems();

    $('.left-block').on('click', '#chooseTranslitSystem', function () {
        ShowNap('.pop-up-translitSystemList');
        GetTranslitSystemList();
    }).on('click', '#applyTranslitSystem', function () {
        GetTranslate();
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
            if (langIsEng) {
                $('#systemSaveError').css('color', 'RED').text("Name required for new transliteration system");
            }
            else {
                $('#systemSaveError').css('color', 'RED').text("Требуется имя для новой системы транслитерации");
            }
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
            LoadSelectedTransliterationSystem(event.target);
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
        if (themeIsDark) {
            $(this).attr('src', '/images/addNewSystem.png');
        }
        else {
            $(this).attr('src', '/images/addNewSystem_light.png');
        }
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
            if (langIsEng) {
                showMessageForLeftBlock(".:: Transliteration systems list uploaded successfully", true);
            }
            else {
                showMessageForLeftBlock(".:: Список систем транслитерации загружен успешно", true);
            }
        },
        error: function () {
            if (langIsEng) {
                showMessageForLeftBlock(".:: Error loading list of available transliteration systems", false);
            }
            else {
                showMessageForLeftBlock(".:: Ошибка загрузки списка доступных систем транслитерации", false);
            }
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
            success: function (response) {
                ShowConfirm(false);
                HideNap();
                if (response == 3) {
                    if (langIsEng) {
                        showMessageForLeftBlock(".:: The transliteration system has been deleted previously", false);
                    }
                    else {
                        showMessageForLeftBlock(".:: Эта система транслитерации была удалена ранее", false);
                    }
                }
                else if (response == 0) {
                    if (langIsEng) {
                        showMessageForLeftBlock(".:: The transliteration system doesn't exist", false);
                    }
                    else {
                        showMessageForLeftBlock(".:: Такой системы транслитерации не существует", false);
                    }
                }
                else if (response == 1) {
                    sessionStorage.setItem('currentSystem', '');
                    if (langIsEng) {
                        showMessageForLeftBlock(`.:: The transliteration system '${translitSystem}' deleted successfully`, true);
                    }
                    else {
                        showMessageForLeftBlock(`.:: Система транслитерации '${translitSystem}' успешно удалена`, true);
                    }
                    window.location.href = "http://localhost:50860/";
                }
                else if (response == 2) {
                    if (langIsEng) {
                        showMessageForLeftBlock(".:: This transliteration system is protected against deletion", false);
                    }
                    else {
                        showMessageForLeftBlock(".:: Эта система транслитерации защищена от удаления", false);
                    }
                }
            },
            error: function () {
                if (langIsEng) {
                    showMessageForLeftBlock(".:: Request error", false);
                }
                else {
                    showMessageForLeftBlock(".:: Ошибка запроса", false);
                }
            }
        });
    }
    else {
        if (langIsEng) {
            showMessageForLeftBlock(".:: Error of deleting", false);
        }
        else {
            showMessageForLeftBlock(".:: Ошибка удаления", false);
        }
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
        success: function (response) {
            if (response == 0) {
                if (langIsEng) {
                    showMessageForLeftBlock(".:: User transliteration system not defined", false);
                }
                else {
                    showMessageForLeftBlock(".:: Пользовательская система транслитерации не определена", false);
                }
            }
            else if (response == 1) {
                if (langIsEng) {
                    showMessageForLeftBlock(`.:: User transliteration system '${newSystem[64]}' saved`, true);
                }
                else {
                    showMessageForLeftBlock(`.:: Пользовательская система транслитерации '${newSystem[64]}' сохранена`, true);
                }
            }
            else if (response == 2) {
                if (langIsEng) {
                    showMessageForLeftBlock(".:: The system not saved because storage is full", false);
                }
                else {
                    showMessageForLeftBlock(".:: Система не сохранена, так как хранилище переполнено", false);
                }
            }
            else if (response == 3) {
                if (langIsEng) {
                    showMessageForLeftBlock(`.:: A transliteration system named '${newSystem[64]}' already exists`, false);
                }
                else {
                    showMessageForLeftBlock(`.:: Система транслитерации с именем '${newSystem[64]}' уже существует`, false);
                }
            }
        },
        error: function () {
            if (langIsEng) {
                showMessageForLeftBlock(".:: Request error! New transliteration system has not been saved", false);
            }
            else {
                showMessageForLeftBlock(".:: Ошибка запроса. Новая система транслитерации не сохранилась.", false);
            }
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

function LoadSelectedTransliterationSystem(selectedSystem) {
    var systemName = selectedSystem.innerText;
    $.ajax({
        url: "http://localhost:50860/Translator/chooseThisSystem",
        method: 'POST',
        contentType: 'application/json',
        dataType: 'text',
        data: JSON.stringify(systemName),
        success: function (response) {
            HideNap();
            if (response == 0) {
                if (langIsEng) {
                    showMessageForLeftBlock(".:: System not defined", false);
                }
                else {
                    showMessageForLeftBlock(".:: Система не определена", false);
                }
            }
            else if (response == 1) {
                if (langIsEng) {
                    showMessageForLeftBlock(`.:: '${systemName}' system selected for translation`, true);
                }
                else {
                    showMessageForLeftBlock(`.:: Система '${systemName}' выбрана для перевода`, true);
                }
            }
            showMessageForRightBlock(systemName, true);
        },
        error: function () {
            HideNap();
            if (langIsEng) {
                showMessageForLeftBlock(".:: Error loading selected transliteration system", false);
                showMessageForRightBlock(" System not defined", false);
            }
            else {
                showMessageForLeftBlock(".:: Ошибка загрузки выбранной системы транслитерации", false);
                showMessageForRightBlock(" Система перевода не выбрана", false);
            }
        }
    });
}

function GetTranslate() {
    var text = $('#originalText').val();
    if (text != '') {
        $.ajax({
            url: "http://localhost:50860/Translator/TryToTranslate",
            method: "POST",
            contentType: "application/json",
            dataType: "text",
            data: JSON.stringify(text),
            success: function (translatedText) {
                if (translatedText != null) {
                    $('#translatedText').val(translatedText);
                    if (langIsEng) {
                        showMessageForLeftBlock(`.:: Text translated by system '${sessionStorage.getItem('currentSystem')}'`, true);
                    }
                    else {
                        showMessageForLeftBlock(`.:: Текст переведён системой '${sessionStorage.getItem('currentSystem')}'`, true);
                    }
                }
                else {
                    if (langIsEng) {
                        $('#translatedText').val("No transliteration system selected");
                        showMessageForLeftBlock(".:: Select a transliteration system", false);
                    }
                    else {
                        $('#translatedText').val("Не выбрана система транслитерации");
                        showMessageForLeftBlock(".:: Выберите систему перевода", false);
                    }
                }
            },
            error: function () {
                if (langIsEng) {
                    showMessageForLeftBlock(".:: The request failed", false);
                }
                else {
                    showMessageForLeftBlock(".:: Ошибка запроса", false);
                }
            }
        });
    }
    else {
        if (langIsEng) {
            showMessageForLeftBlock(".:: Nothing to translate", false);
        }
        else {
            showMessageForLeftBlock(".:: Нечего переводить", false);
        }
        document.querySelector('#originalText').focus();
    }
}