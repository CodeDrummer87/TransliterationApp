$(document).ready(function () {

    GenerateTableForTranslitSystems();

    $('.left-block').on('click', '#chooseTranslitSystem', function () {
        ShowNap('.pop-up-translitSystemList');
        GetTranslitSystemList();
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