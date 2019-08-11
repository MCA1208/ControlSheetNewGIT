

$(document).ready(function () {

    LoadUser();

});


var param = "";


function createNewUserOperator(){
    if ($('#txtEmail').val() === "" ) {

        alertify.alert('<strong>Usuario</strong>',"Debe ingresar un EMail");

        return;
    }

    param = {
        EMail: $('#txtEmail').val()
    };

    $.post(directories.user.CreateNewUserOperator, param)
        .done(function (data) {
            if (data.status !== "error") {

                alertify.success(data.message);
                $('#txtEmail').val("");
                LoadUser();

            }
            else {
                alertify.error(data.message);

            }

        })
        .fail(function (data) {
            alertify.error(data.statusText);
        });

}

function changePassword() {

    if ($('#txtNewPass').val() !== $('#txtRepeatNewPass').val()) {

        alertify.alert('<strong>Usuario</strong>', "No son iguales las contraseñas ingresadas");

        return;
    }

    param = {
        Pass: $('#txtNewPass').val()
    };

    $.post(directories.user.ChangePassword, param)
        .done(function (data) {
            if (data.status !== "error") {

                alertify.success(data.message);
                $('#txtNewPass').val('');
                $('#txtRepeatNewPass').val('');

            }
            else {
                alertify.error(data.message);

            }

        })
        .fail(function (data) {
            alertify.error(data.statusText);
        });

}
function LoadUser() {

    $.post(directories.user.LoadUser)
        .done(function (data) {
            if (data.status !== "error") {

                $('#tblUser > tbody').html('');
                var _html = '';
                _html += '<tbody class="customtable" style= text-align:left;>';
                data = JSON.parse(data.result);
                $.each(data, function (key, value) {

                    _html += '<tr><td>' + value.email + '</td><td>' + value.creationDate + '</td><td>' + '<button type="button" class="btn btn-primary" onclick="deleteUser(' + value.id + ');"><i class="fas fa-trash-alt"></i> Eliminar </button>' + '</td>';

                });

                _html += '</tbody >';

                $('#tblUser').append(_html);
                $('#tblUser').DataTable();

            }
            else {
                alertify.error(data.message);

            }

        })
        .fail(function (data) {
            alertify.error(data.statusText);
        });

}


function deleteUser(idUser) {

    alertify.confirm('Usuario', 'Confirma Eliminar el usuario?', function () {

        param = {
            idUser: idUser
        };

        $.post(directories.user.DeleteUser, param)
            .done(function (data) {
                if (data.status !== "error") {

                    alertify.success(data.message);
                    LoadUser();
                }
                else {
                    alertify.error(data.message);

                }

            })
            .fail(function (data) {
                alertify.error(data.statusText);
            });
    },
    function () {
        alertify.error('Se canceló la operación');
    });

}