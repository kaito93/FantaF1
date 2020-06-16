﻿function singleFileSelected(elem) {
    document.getElementById("CsvPath").value = document.getElementById(elem.id).value.split('\\')[document.getElementById(elem.id).value.split('\\').length - 1];
}

function LoadIscrizioniUtentiSection() {

    var oParams = {
        "Url": "/Home/LoadIscrizioniUtenti",
        "oData": {},
        "dataType": "json",
        "Type": "GET",
        "CallBackFn": function (result) {
            document.getElementById("bodyContent").innerHTML = result.responseText;
        }
    }
    AsyncValidation(oParams);
}

function LoadPronosticiUtentiSection() {

    var oParams = {
        "Url": "/Home/LoadPronosticiUtenti",
        "oData": {},
        "dataType": "json",
        "Type": "GET",
        "CallBackFn": function (result) {
            document.getElementById("bodyContent").innerHTML = result.responseText;
        }
    }
    AsyncValidation(oParams);
}

function LoadCalcolaPronosticiGara() {

    var oParams = {
        "Url": "/Home/LoadCalcolaPronosticiGara",
        "oData": {},
        "dataType": "json",
        "Type": "GET",
        "CallBackFn": function (result) {

            document.getElementById("bodyContent").innerHTML = result.responseText;

            $(".selectPick").selectpicker({
                noneSelectedText: "Non selezionato",
                noneResultsText: "Nessun risultato",
                showTick: true
            });

            $("#FantaCampionatiList").selectpicker("val", "");
        }
    }
    AsyncValidation(oParams);
}

function LoadScaricaRisultatiPronosticiGara() {

    var oParams = {
        "Url": "/Home/LoadScaricaRisultatiPronosticiGara",
        "oData": {},
        "dataType": "json",
        "Type": "GET",
        "CallBackFn": function (result) {

            document.getElementById("bodyContent").innerHTML = result.responseText;

            $(".selectPick").selectpicker({
                noneSelectedText: "Non selezionato",
                noneResultsText: "Nessun risultato",
                showTick: true
            });

            $("#FantaCampionati").selectpicker("val", "");
        }
    }
    AsyncValidation(oParams);
}

function LoadRisultatiGaraSection() {

    var oParams = {
        "Url": "/Home/ShowSetResultRace",
        "oData": {},
        "dataType": "json",
        "Type": "GET",
        "CallBackFn": function (result) {
            document.getElementById("bodyContent").innerHTML = result.responseText;

            $(".selectPick").selectpicker({
                noneSelectedText: "Non selezionato",
                noneResultsText: "Nessun risultato",
                showTick: true
            });

            $(".selectPick").selectpicker("val", "");
        }
    }
    AsyncValidation(oParams);
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

    formData.append("idFantaCampionato", 4);

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
    });
}



function SendResultRace() {

    var iscrizioneId = parseInt($("#IscrizioneGP").val());
    var campionatoId = parseInt($("#InserisciCampionato").val());

    var dat = [];

    for (var i = 1; i < 21; i++) {

        var pilotaId = parseInt($("#Pilota" + i).val());
        var isDfn = $("#PilotaDFNInput" + i).prop("checked");
        var isGiroVeloce = $("#PilotaGiroVeloceInput" + i).prop("checked");
        var isPolePosition = $("#PilotaPolePositionInput" + i).prop("checked");

        var oData = {
            IdIscrizione: iscrizioneId,
            IdCampionato: campionatoId,
            PosizioneFinale: i,
            PilotaId: pilotaId,
            DFN: isDfn,
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
}

function CheckFileTypePronostici(e) {
    e.preventDefault();

    var formData = new FormData();
    var uploaders = $('input[type="file"]:visible');

    for (var u = 0; u < uploaders.length; u++) {
        if (uploaders[u].files[0] != null) {
            formData.append("fileCsv", uploaders[u].files[0], uploaders[u].files[0].name);
        }
    }

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

function ClickOnButtonCalcolaRisultatiPronostici() {

    var iscr = $("#CircuitiList").selectedOptions[0].value;

    if (iscr == "") {
        alert("Seleziona almeno una gara!");
    } else {
        var odat = JSON.stringify({ iscrizioneCircuitoCampionatoReale: iscr });

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

}

function ClickOnButtonScaricaRisultatiPronostici() {

    var fantaId = $("#FantaCampionati")[0].selectedOptions[0].value;

    if (fantaId == "") {
        alert("Seleziona almeno un fanta campionato!");
    } else {
        window.location.href = "/Home/GenerateResultsExcel?fantaCampionatoId="+fantaId;
    }
}

$(document).on("change", "#FantaCampionatiList", function () {

    var odat = JSON.stringify({ fantaCampionatoId: this.selectedOptions[0].value });

    var oParams = {
        "Url": "/Home/RetrieveCircuitiWithResultsForFantaCampionato",
        "oData": odat,
        "dataType": "json",
        "Type": "POST",
        "CallBackFn": function (result) {

            var circuiti = $("#CircuitiList");

            circuiti.find("option").remove();
            circuiti.find("selectedOptions").remove();


            if (result.responseJSON.length > 0) {
                $(result).each(function () {
                    $("<option value='" + this.Value + "'>" + this.Text + "</option>").appendTo(circuiti);
                });
            }

            $("#CircuitiList").selectpicker({
                noneSelectedText: "Non selezionato",
                noneResultsText: "Nessun risultato",
                showTick: true
            });

            setTimeout(function () {
                $("#CircuitiList").selectpicker('refresh');
                $("#CircuitiList").selectpicker("val", "");
            }, 100);


        }
    }

    AsyncValidation(oParams);

});

$(document).on("change", "#CircuitiList", function () {

    if (this.selectedOptions[0].value == "") {
        $("#buttonCalcola").prop("aria-disabled", true);
        $("#buttonCalcola").addClass("disabled");
    } else {
        $("#buttonCalcola").prop("aria-disabled", false);
        $("#buttonCalcola").removeClass("disabled");
    }

});

$(document).on("change", "#FantaCampionati", function () {

    if (this.selectedOptions[0].value == "") {
        $("#buttonCalcola").prop("aria-disabled", true);
        $("#buttonCalcola").addClass("disabled");
    } else {
        $("#buttonCalcola").prop("aria-disabled", false);
        $("#buttonCalcola").removeClass("disabled");
    }

});

$(document).on("change", "#InserisciCampionato", function () {

    var odat = JSON.stringify({ idCampionato: this.selectedOptions[0].value });

    var oParams = {
        "Url": "/Home/RetrieveGrandPrixForCampionatoReale",
        "oData": odat,
        "dataType": "json",
        "Type": "POST",
        "CallBackFn": function (result) {

            var gp = $("#IscrizioneGP");

            gp.find("option").remove();
            gp.find("selectedOptions").remove();

            if (result.responseJSON.length > 0) {
                $(result.responseJSON).each(function () {
                    $("<option value='" + this.Value + "'>" + this.Text + "</option>").appendTo(gp);
                });
            }

            $(".selectPick").selectpicker({
                noneSelectedText: "Non selezionato",
                noneResultsText: "Nessun risultato",
                showTick: true
            });

            setTimeout(function () {
                $("#IscrizioneGP").selectpicker('refresh');
                $("#IscrizioneGP").selectpicker("val", "");
            }, 100);


        }
    }

    AsyncValidation(oParams);

});