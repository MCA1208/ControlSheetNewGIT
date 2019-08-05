
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