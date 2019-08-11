var param = "";

$(document).ready(function () {


    GetGraphicByType();



});

function GetGraphicByType() {
    $.blockUI();

    var oilCanvas = document.getElementById("oilChart");

    Chart.defaults.global.defaultFontFamily = "Lato";
    Chart.defaults.global.defaultFontSize = 18;

    param = {
        dateBegin: $('#dateBegin').val(),
        dateEnd: $('#dateEnd').val(),
        Estado: $('#Estado').val()

    };


    $.post(directories.reports.LoadReportGraphicByType, param)
        .done(function (data) {
            data = JSON.parse(data.result);

            if (data.status !== "error") {

                var sumaTotal = data[0].HorasDesarrollo + data[0].HorasIncidencia + data[0].HorasMejora + data[0].HorasAdministracion;
                var desa = (100 * data[0].HorasDesarrollo) / sumaTotal;
                var inc = (100 * data[0].HorasIncidencia) / sumaTotal;
                var mej = (100 * data[0].HorasMejora) / sumaTotal;
                var adm = (100 * data[0].HorasAdministracion) / sumaTotal;

                var oilData = {
                    labels: [
                        "Proyectos: " + data[0].HorasDesarrollo + ' hs - %' + desa.toFixed(2),
                        "Incidentes: " + data[0].HorasIncidencia + ' hs - %' + inc.toFixed(2),
                        "Mejoras: " + data[0].HorasMejora + ' hs - %' + mej.toFixed(2),
                        "Administración: " + data[0].HorasAdministracion + ' hs - %' + adm.toFixed(2)

                    ],
                    datasets: [
                        {
                            data: [data[0].HorasDesarrollo, data[0].HorasIncidencia, data[0].HorasMejora, data[0].HorasAdministracion],
                            backgroundColor: [
                                "#FF6384",
                                "#6384FF",
                                "#84FF63",
                                "#8463FF"
                            ]
                        }]
                };

                var pieChart = new Chart(oilCanvas, {
                    type: 'pie',
                    data: oilData
                });

            }
            else {

                alertify.error(data.message);

            }

        })
        .fail(function (data) {
            alertify.error(data.statusText);
        })
        .always(function () {

            $.unblockUI();
        });

}