
$(document).ready(function () {

    LoadProyect();


    var t = $('#tableAddRow').DataTable();
    
    var counter = 1;

    $('#addRow').on('click', function () {
        t.row.add([
            //counter + '.1',
            //counter + '.2',
            //counter + '.3',
            //counter + '.4',
            //counter + '.5'
            $('#txtModuleName').val(),
            $('#txtProyectDescription').val(),
            $('#txtHourProyect').val(),
            '',
            '',
            '<button class="btn btn-primary" id="btnEditProyect" type="button" data-toggle="modal" data-target="#EditDetailProyectModal"> Editar </button>'

        ]).draw(false);

        counter++;
    });

    // Automatically add a first row of data
    $('#addRow').click();
   
});

var data = "";

function LoadProyect() {
    $.blockUI();

    $.post(directories.home.LoadProyectActive)
        .done(function (data) {
            if (data.status !== "error") {
                $('#tblProyect > tbody').html('');
                var _html = '';
                _html += '<tbody class="customtable">';
                data = JSON.parse(data.result);
                $.each(data, function (key, value) {

                    //_html += '<tr><td>' + value.proyectName + '</td><td>' + value.dateBegin + '</td><td>' + value.dateEstimated + '</td><td>' + value.dateEnd + '</td><td>' + '<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#EditProyectModal"><i class="fas fa-edit"></i> Editar </button>' + '</td>';
                    _html += '<tr><td>' + value.proyectName + '</td><td>' + value.dateBegin + '</td><td>' + value.dateEstimated + '</td><td>' + value.dateEnd + '</td><td>' + '<button type="button" class="btn btn-primary" onclick="showModal();"><i class="fas fa-edit"></i> Editar </button>' + '</td>';
                    //_html += '<tr><td>' + value.proyectName + '</td><td>' + value.dateBegin + '</td><td>' + value.dateEstimated + '</td><td>' + value.dateEnd + '</td>';
                });

                _html += '</tbody >';

                $('#tblProyect').append(_html);

                $('#tblProyect').DataTable({
                    destroy: true,
                    retrieve: true,
                    dom: 'Bfrtip',
                    buttons: [
                        { "extend": 'excel', "text":    '<span data-toggle="tooltip" data-placement="top" title="Exportar Excel" class="fas fa-file-excel fa-2x"></span>' },
                        { "extend": 'pdf', "text":      '<span data-toggle="tooltip" data-placement="top" title="Exportar PDF" class="fas fa-file-pdf fa-2x" ></span>' },
                        { "extend": 'print', "text":    '<span data-toggle="tooltip" data-placement="top" title="Imprimir" class="fas fa-print fa-2x"></span>' }
                    ]
  
                });
        
            }
            else {
                alertify.error(data.message);

            }

        })
        .fail(function (data) {
            alertify.error(data.statusText);
        });

    $.unblockUI();

}

function showModal()
{
    $('#EditProyectModal').modal('show');
}