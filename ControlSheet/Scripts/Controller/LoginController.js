﻿var data = "";

$(document).ready(function () {


    // $.blockUI();

    
});


function Login() {
    $.blockUI();
    var User = $('#txtUser').val();
    var Pass = $('#txtPass').val();

    if (User === "" || Pass === "") {

        alertify.alert('<strong>Login</strong>', 'Debe cargar los campos de usuario y contraseña', function () {});

        return;
    }

    var data = {
        user: $('#txtUser').val(), pass: $('#txtPass').val()

    };

   // $.post(directories.user.loginUser, data)
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
        });
    $.unblockUI();
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

