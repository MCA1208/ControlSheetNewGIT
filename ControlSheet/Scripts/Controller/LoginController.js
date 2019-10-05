var data = "";

$(document).ready(function () {



});


function Login() {
   
    var User = $('#txtUser').val();
    var Pass = $('#txtPass').val();

    if (User === "" || Pass === "") {

        alertify.alert('<strong>Login</strong>', 'Debe cargar los campos de usuario y contraseña', function () {});

        return;
    }

    var data = {
        user: $('#txtUser').val(),
        pass: $('#txtPass').val()

    };

    $.blockUI();

    $.post(directories.home.loginUser, data)
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




function createUserAdmin() {

    if ($('#txtCompany').val() === "" || $('#txtNewEmail') === "" || $('#txtNewPass').val() === "" || $('#txtNewPassRepeat').val() === "") {

        alertify.alert("Crear Usuario", "Todos los campos son obligatorios", "");
        return;
    }

    if ($('#txtNewPass').val() !== $('#txtNewPassRepeat').val()){

        alertify.alert("Crear Usuario", "No coincide las contraseñas ingresadas", "");
        return;
    }

    data = {
        nameCompany: $('#txtCompany').val(),
        eMail: $('#txtNewEmail').val(),
        pass: $('#txtNewPass').val()
    };

    $.post(directories.home.createUserAdmin, data)
        .done(function (data) {

            if (data.status !== "error") {
                alertify.success('Se creo con exito el usuario Administrador');
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

    $.post(directories.home.SendRecoveryPassword, data)
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