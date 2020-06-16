function singleFileSelected(elem) {
    document.getElementById("CsvPath").value = document.getElementById(elem.id).value.split('\\')[document.getElementById(elem.id).value.split('\\').length - 1];

    var name = elem.id.replace('file', '');
}

function CheckFileType(e) {
    e.preventDefault();

    var formData = new FormData();
    var uploaders = $('input[type="file"]:visible');

    for (var u = 0; u < uploaders.length; u++) {
        if (uploaders[u].files[0] != null) {
            formData.append("fileCsv", uploaders[u].files[0], "prova", "prova");
        }
    }

    formData.append("idFantaCampionato", 4)

    $.ajax({
        url: "/Home/SetPartecipantiFantaCampionatoFromCsv",
        type: "POST",
        contentType: false,
        dataType: "json",
        processData: false,
        data: formData,
        success: function (response) {

        }
    });

}

function AsyncValidation(oParams) {
    $.ajax({
        url: oParams.Url,
        data: oParams.oData,
        type: oParams.Type,
        contentType: "application/json; charset=utf-8",
        complete: function (response) {
            oParams.CallBackFn(response);
        }
    })
}

function ClickOnButtonIscriviGiocatori() {
    if ($("#iscrizioniutenti").is(":visible")) {
        $("#iscrizioniutenti").hide();
    }
    else {
        $("#iscrizioniutenti").show();
    }
}

function ClickOnButtonRisultatiGara() {
    if ($("#insertResultRace").is(":visible")) {
        $("#insertResultRace").hide();
    }
    else {

        var oParams = {
            "Url": "/Home/ShowSetResultRace",
            "oData": {},
            "dataType": "json",
            "Type": "GET",
            "CallBackFn": function (result) {
                document.getElementById("insertResultRace").innerHTML = result.responseText;
                $("#insertResultRace").show();
            }
        }
        AsyncValidation(oParams);
    }
}

function SendResultRace() {

    var circuitoId = parseInt($("#Circuito").val());
    var campionatoId = parseInt($("#Campionato").val());

    var dat = [];

    for (var i = 1; i < 21; i++) {

        var pilotaId = parseInt($("#Pilota" + i).val());
        var isDFN = $("#PilotaDFNInput" + i).prop("checked");
        var isGiroVeloce = $("#PilotaGiroVeloceInput" + i).prop("checked");
        var isPolePosition = $("#PilotaPolePositionInput" + i).prop("checked");

        var oData = {
            IdCircuito: circuitoId,
            IdCampionato: campionatoId,
            PosizioneFinale: i,
            PilotaId: pilotaId,
            DFN: isDFN,
            GiroVeloce: isGiroVeloce,
            PolePosition: isPolePosition
        }

        dat.push(oData);

    }

    var odat = JSON.stringify({ listResultRace: dat });

    var oParams = {
        "Url": "/Home/SetRaceResult",
        "oData": odat,
        "dataType": "json",
        "Type": "POST",
        "CallBackFn": function (result) {

        }
    }
    AsyncValidation(oParams);


}

function singleFileSelectedPronostici(elem) {
    document.getElementById("CsvPathPronostici").value = document.getElementById(elem.id).value.split('\\')[document.getElementById(elem.id).value.split('\\').length - 1];

    var name = elem.id.replace('file', '');
}

function CheckFileTypePronostici(e) {
    e.preventDefault();

    var formData = new FormData();
    var uploaders = $('input[type="file"]:visible');

    for (var u = 0; u < uploaders.length; u++) {
        if (uploaders[u].files[0] != null) {
            formData.append("fileCsv", uploaders[u].files[0], "prova", "prova");
        }
    }

    formData.append("idFantaCampionato", 4)
    formData.append("idCircuito", 1)

    $.ajax({
        url: "/Home/LoadPronostici",
        type: "POST",
        contentType: false,
        dataType: "json",
        processData: false,
        data: formData,
        success: function (response) {

        }
    });

}

function ClickOnButtonInserisciPronostici() {
    if ($("#pronosticiutenti").is(":visible")) {
        $("#pronosticiutenti").hide();
    }
    else {
        $("#pronosticiutenti").show();
    }
}

function ClickOnButtonCalcolaRisultatiPronostici() {

    var odat = JSON.stringify({ iscrizioneCircuitoCampionatoReale: 1 });

    var oParams = {
        "Url": "/Home/CalculateScorePronostici",
        "oData": odat,
        "dataType": "json",
        "Type": "POST",
        "CallBackFn": function (result) {

        }
    }
    AsyncValidation(oParams);
}