
var param = "";

$(document).ready(function () {

   // $('#tblReportPrincipal').DataTable();

});


function LoadReportprincipal() {
    $.blockUI();

    param = {
        dateBegin: $('#dateBegin').val(), 
        dateEnd: $('#dateEnd').val(),
        Estado: $('#Estado').val()
    };

    $.post(directories.reports.LoadReportPrincipal, param)
        .done(function (data) {
            if (data.status !== "error") {
                $('#tblReportPrincipal > tbody').html('');
                var _html = '';
                _html += '<tbody class="customtable" style= text-align:left;>';
                data = JSON.parse(data.result);
                $.each(data, function (key, value) {

                    _html += '<tr><td>' + value.proyectName + '</td><td>' + value.descriptions + '</td><td>' + value.dateCreate + '</td><td>' + value.hourEstimated + '</td><td>' + value.hourDedicated + '</td><td>' + value.dateEstimated + '</td><td>' + value.email + '</td><td>' + value.active + '</td>';

                });

                _html += '</tbody >';

                $('#tblReportPrincipal').append(_html);

                $('#tblReportPrincipal').DataTable({
                    destroy: true,
                    retrieve: true,
                    dom: 'Bfrtip',
                    buttons: [
                        { "extend": 'excel', "text": '<span data-toggle="tooltip" data-placement="top" title="Exportar Excel" class="fas fa-file-excel fa-2x"></span>' },
                        { "extend": 'pdf', "text": '<span data-toggle="tooltip" data-placement="top" title="Exportar PDF" class="fas fa-file-pdf fa-2x" ></span>' },
                        { "extend": 'print', "text": '<span data-toggle="tooltip" data-placement="top" title="Imprimir" class="fas fa-print fa-2x"></span>' }
                    ]

                });
                $.unblockUI();
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