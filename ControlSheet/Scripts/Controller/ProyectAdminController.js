
$(document).ready(function () {

    LoadProyect();


});

var param = "";

function LoadProyect() {
    $.blockUI();

    $.post(directories.home.LoadProyectActive)
        .done(function (data) {
            if (data.status !== "error") {
                $('#tblProyect > tbody').html('');
                var _html = '';
                _html += '<tbody class="customtable" style= text-align:left;>';
                data = JSON.parse(data.result);
                $.each(data, function (key, value) {

                    _html += '<tr><td>' + value.proyectName + '</td><td data-type="date" data-format-string="Do MMMM YYYY">' + value.dateBegin + '</td><td>' + value.dateEnd + '</td><td>' + value.email + '</td><td>' +'<button type="button" class="btn btn-primary" onclick="showModalEditProyect(' + value.id + ',' + `'${value.proyectName}'` + ');"><i class="fas fa-edit"></i> Editar </button>' + '</td><td>'

                        + '<button class="btn btn-danger" id="btnDeleteProyect" type="button" onclick="deleteProyect(' + value.id + ');"><i class="fas fa-trash-alt"></i> Eliminar </button>' + '</td>';


                });

                _html += '</tbody >';

                $('#tblProyect').append(_html);

                $('#tblProyect').DataTable({
                    destroy: true,
                    retrieve: true,
                    dom: 'Bfrtip',
                    buttons: [
                        { "extend": 'excel', "text": '<span data-toggle="tooltip" data-placement="top" title="Exportar Excel" class="fas fa-file-excel fa-2x"></span>' },
                        { "extend": 'pdf', "text": '<span data-toggle="tooltip" data-placement="top" title="Exportar PDF" class="fas fa-file-pdf fa-2x" ></span>' },
                        { "extend": 'print', "text": '<span data-toggle="tooltip" data-placement="top" title="Imprimir" class="fas fa-print fa-2x"></span>' }
                    ]

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

function showModalEditProyect(id, proyectName) {

    $('#EditProyectModal').modal('show');
    $('#txtIdProyect').val(id);
    $('#titleEditProyectModal').text('Editar Proyecto: ' + proyectName);
    LoadProyectDetail(id);

}

function createNewProyect() {

    if ($('#txtProyectName').val() === "") {

        alertify.alert("Ingrese el Nombre del Proyecto");

        return;
    }

    param = {
        proyectName: $('#txtProyectName').val()
    };

    $.post(directories.controlSheet.CreateNewProyect, param)
        .done(function (data) {
            if (data.status !== "error") {

                alertify.success("Se creo el proyecto");

                LoadProyect();

            }
            else {
                alertify.error(data.message);

            }

        })
        .fail(function (data) {
            alertify.error(data.statusText);
        });

}

function addRowTable() {

    if ($('#txtModuleName').val() === "" || $('#txtProyectDescription').val() === ""
        || $('#txtHourEstimatedProyect').val() === "" || $('#txtDateEstimated').val() === "") {

        alertify.alert("Crear detalle módulo", "Todos los campos son obligatorios");
        return;
    }

    param = {
        moduleName: $('#txtModuleName').val(),
        proyectDescription: $('#txtProyectDescription').val(),
        hourEstimated: $('#txtHourEstimatedProyect').val(),
        dateEstimatedEnd: $('#txtDateEstimated').val(),
        idProyect: $('#txtIdProyect').val()
    };

    $.post(directories.controlSheet.InsertProyectDetail, param)
        .done(function (data) {
            if (data.status !== "error") {

                alertify.success("Se creo la tarea del proyecto");

                LoadProyectDetail(param.idProyect);

            }
            else {
                alertify.error(data.message);

            }

        })
        .fail(function (data) {
            alertify.error(data.statusText);
        });


    //AGREGA REGISTRO EN LA TABLE
    //var t = $('#tableAddRow').DataTable();

    //t.row.add([
    //    $('#txtModuleName').val(),
    //    $('#txtProyectDescription').val(),
    //    $('#txtHourEstimatedProyect').val(),
    //    '',
    //    $('#txtDateEnd').val(),
    //    '',
    //    '<button class="btn btn-primary" id="btnEditProyect" type="button" data-toggle="modal" data-target="#EditDetailProyectModal"> Editar Tarea </button>'

    //]).draw(false);


}

function LoadProyectDetail(id) {
    $.blockUI();
    param = { id: id };

    $.post(directories.controlSheet.LoadProyectDetail, param)
        .done(function (data) {
            if (data.status !== "error") {
                $('#tableAddRow > tbody').html('');
                var _html = '';
                _html += '<tbody class="customtable" style= text-align:left;>';
                data = JSON.parse(data.result);
                $.each(data, function (key, value) {

                    _html += '<tr><td>' + value.moduleName + '</td><td>' + value.descriptions + '</td><td>' + value.hourEstimated + '</td><td>' + value.hourDedicated + '</td><td>' + value.dateEstimated + '</td><td>'
                        + '<button class="btn btn-primary" id="btnEditProyect" type="button" onclick="showModalEditProyectDetail(' + $('#txtIdProyect').val() + ',' + value.id + ');"><i class="fas fa-edit"></i> Editar Tarea </button>' + '</td>';


                });
                //id, moduleName, descriptions, hourEstimated, hourDedicated, dateCreate, dateEnd
                _html += '</tbody >';

                $('#tableAddRow').append(_html);

                $('#tableAddRow').DataTable();

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
function showModalEditProyectDetail(idProyect, idProyectDetail) {

    $('#EditDetailProyectModal').modal('show');

    loadEditProyectDetail(idProyect, idProyectDetail);


}

function loadEditProyectDetail(idProyect, idProyectDetail) {
    param = { idProyect: idProyect, idProyectDetail: idProyectDetail };

    $.post(directories.controlSheet.LoadEditProyectDetail, param)
        .done(function (data) {
            if (data.status !== "error") {

                var result = JSON.parse(data.result);

                $('#txtIdProyectDetail').val(result[0]["id"]);
                $('#txtModuleNameD').val(result[0]["moduleName"]);
                $('#txtModuleDescription').val(result[0]["descriptions"]);
                $('#txtHourEstimated').val(result[0]["hourEstimated"]);
                $('#txtDateEstimatedEdit').val(result[0]["dateEstimated"]);
                $('#txtHourConsumed').val(result[0]["hourDedicated"]);

            }
            else {
                alertify.error(data.message);

            }

        })
        .fail(function (data) {
            alertify.error(data.statusText);
        });

}

function editDetailproyect() {

    param = {
        idProyect: $('#txtIdProyect').val(), idProyectDetail: $('#txtIdProyectDetail').val(),
        moduleName: $('#txtModuleNameD').val(), descriptions: $('#txtModuleDescription').val(), dateEstimated: $('#txtDateEstimatedEdit').val(), hourEstimated: $('#txtHourEstimated').val(), hourDedicated: $('#txtHourConsumed').val()
    };

    $.post(directories.controlSheet.EditProyectDetail, param)
        .done(function (data) {
            if (data.status !== "error") {

                alertify.success("Se edito correctamente");
                $('#EditDetailProyectModal').modal('hide');
                //loadEditProyectDetail($('#txtIdProyect').val(), $('#txtIdProyectDetail').val());
                //showModalEditProyectDetail($('#txtIdProyect').val(), $('#txtIdProyectDetail').val());
                LoadProyectDetail($('#txtIdProyect').val());
            }
            else {
                alertify.error(data.message);

            }

        })
        .fail(function (data) {
            alertify.error(data.statusText);
        });

}

function deleteProyect(idProyect) {

    alertify.confirm('Confirm Title', 'Confirm Message', function () {
        alertify.success('Ok')
    }
        , function () {
            alertify.error('Cancel')
        });



    alertify.confirm('Proyectos', 'Confirma Eliminar el Proyecto?', function () {

        param = {
            idProyect: idProyect
        };

        $.post(directories.controlSheet.DeleteProyect, param)
            .done(function (data) {
                if (data.status !== "error") {

                    if (data.result === "1") {
                        alertify.success("Se eliminó correctamente");
                        LoadProyect();
                    }
                    else {

                        alertify.error("No se pudo eliminar el proyecto");
                    }


                }
                else {
                    alertify.error(data.message);

                }

            })
            .fail(function (data) {
                alertify.error(data.statusText);
            });

    }
        , function () {
            alertify.error('Se canceló la operación');
        });

}