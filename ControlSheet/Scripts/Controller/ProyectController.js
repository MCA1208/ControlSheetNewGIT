
$(document).ready(function () {

    LoadProyect();
   
});

var data = "";

function LoadProyect() {

    $.post(directories.home.LoadProyectActive)
        .done(function (data) {
            if (data.status !== "error") {
                $('#tblProyect > tbody').html('');
                var _html = '';
                _html += '<tbody class="customtable">';
                data = JSON.parse(data.result);
                $.each(data, function (key, value) {

                    _html += '<tr><td>' + value.proyectName + '</td><td>' + value.datebegin + '</td><td>' + value.dateend + '</td>';
                });

                _html += '</tbody >';

                $('#tblProyect').append(_html);

                $('#tblProyect').DataTable({
                    destroy: true,
                    retrieve: true,
                    dom: 'Bfrtip',
                    buttons: [
                        { "extend": 'excel', "text": '<span class="fas fa-file-excel"></span>' },
                        { "extend": 'pdf', "text": '<span class="fas fa-file-pdf"></span>' },
                        { "extend": 'print', "text":  '<span class="fas fa-print"></span>' }
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

  

}