
var data = '';


function Login() {

    var User = $('#txtUser').val();
    var Pass = $('#txtPass').val();

    if (User === "" || Pass === "") {

        alertify.alert('<strong>Login</strong>', 'Debe cargar los campos de usuario y contraseña', function () {});

        return;
    }

    var data = {
        user: $('#txtUser').val(), pass: $('#txtPass').val(),

    }

    $.post(directories.user.loginUser, data)    
        .done(function (data) {
             debugger;
            if (data.status != "error") {
                alertify.success('Ingreso Exitoso');
            }
            else {
                alertify.error(data.message)
            }

        })
        .fail(function (data) {
            debugger;
            alertify.error(data.statusText)
        })
   
}


//function getJSON(messageSuccessFul) {

//    var data = {
//        user: 'milton.amado10@gmail.com', pass: '123',

//    }

//    $.get('Login/LoginUser', data)

//        .done(function (data) {
//            debugger
//            alertify.success(messageSuccessFul);
//        })
//        .fail(function (data) {

//        })


//}

function createUserAdmin() {

    if ($('#txtNewPass').val() != $('#txtNewPassRepeat').val()){

        alertify.alert("Crear Usuario", "No coincide las contraseñas ingresadas", "")
        return;
    }

    data = {
        nameCompany: $('#txtCompany').val(),
        eMail: $('#txtNewEmail').val(),
        pass: $('#txtNewPass').val()
    }

    $.post(directories.user.createUserAdmin, data)
    .done(function (data) {
        debugger;
        if (data.status != "error") {
            alertify.success('Se creo con exito el usuario Administrador');
        }
        else {
            alertify.error(data.message)
        }

    })
    .fail(function (data) {
        debugger;
        alertify.error(data.statusText)
    })


}

