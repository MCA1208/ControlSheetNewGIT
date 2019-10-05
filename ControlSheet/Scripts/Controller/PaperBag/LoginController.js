
function Login() {
    var User = $('#txtUser').val();
    var Pass = $('#txtPass').val();

    if (User === "" || Pass === "") {

        alertify.alert('<strong>Login</strong>', 'Debe cargar los campos de usuario y contraseña', function () { });

        return;
    }

    var data = {
        user: $('#txtUser').val(),
        pass: $('#txtPass').val()

    };

    $.blockUI();


    $.post(directories.paperBag.LoginUser, data)
        .done(function (data) {

            if (data.status !== "error") {
                //alertify.success(data.message);
                location = data.url;

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

function createUser() {

    if ($('#txtNewEmail') === "" || $('#txtNewPass').val() === "" || $('#txtNewPassRepeat').val() === "") {

        alertify.alert("Crear Usuario", "Todos los campos son obligatorios", "");
        return;
    }

    if ($('#txtNewPass').val() !== $('#txtNewPassRepeat').val()) {

        alertify.alert("Crear Usuario", "No coincide las contraseñas ingresadas", "");
        return;
    }

    data = {       
        eMail: $('#txtNewEmail').val(),
        pass: $('#txtNewPass').val()
    };

    $.post(directories.paperBag.CreateUser, data)
        .done(function (data) {

            if (data.status !== "error") {
                alertify.success('Se creo con exito el usuario');
            }
            else {
                alertify.error(data.message);
            }

        })
        .fail(function (data) {

            alertify.error(data.statusText);
        });


}

function SendPasswordMail() {

    if ($('#txtEmailRecoveryPass').val() === "") {
        alertify.alert("Usuario", "Es requerido el campo Email", "");
        return;
    }

    data = {
        EMail: $('#txtEmailRecoveryPass').val()
    };

    $.post(directories.paperBag.SendRecoveryPasswordPaper, data)
        .done(function (data) {

            if (data.status !== "error") {
                alertify.success('Se envió la contraseña por email');
            }
            else {
                alertify.error(data.message);
            }

        })
        .fail(function (data) {

            alertify.error(data.statusText);
        });

}