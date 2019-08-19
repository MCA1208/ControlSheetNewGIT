var param = '';


$(document).ready(function () {

    
    //PERFIL
    $('#file-perfil').change(function (e) {
        addImagePerfil(e);
    });

    function addImagePerfil(e) {
        var file = e.target.files[0],
            imageType = /image.*/;

        if (!file.type.match(imageType))
            return;

        var reader = new FileReader();
        reader.onload = fileOnloadPerfil;
        reader.readAsDataURL(file);
    }

    function fileOnloadPerfil(e) {
        var result = e.target.result;
        $('#imgPerfil').attr("src", result);
    }

    //PASION
    $('#file-pasion').change(function (e) {
        addImagePasion(e);
    });

    function addImagePasion(e) {
        var file = e.target.files[0],
            imageType = /image.*/;

        if (!file.type.match(imageType))
            return;

        var reader = new FileReader();
        reader.onload = fileOnloadPasion;
        reader.readAsDataURL(file);
    }

    function fileOnloadPasion(e) {
        var result = e.target.result;
        $('#imgPasion').attr("src", result);
    }

    //ALGO
    $('#file-algo').change(function (e) {
        addImageAlgo(e);
    });

    function addImageAlgo(e) {
        var file = e.target.files[0],
            imageType = /image.*/;

        if (!file.type.match(imageType))
            return;

        var reader = new FileReader();
        reader.onload = fileOnloadAlgo;
        reader.readAsDataURL(file);
    }

    function fileOnloadAlgo(e) {
        var result = e.target.result;
        $('#imgAlgo').attr("src", result);
    }


    

});

function savePerfilData() {

    var formData = new FormData();

    formData.append("filePerfil", $('#file-perfil')[0].files);


    param = {
        filePerfil: $('#file-perfil')[0].files[0]

    };

    $.post(directories.paperBag.ModifyPerfil, formData)
        .done(function (data) {
            if (data.status !== "error") {

                alertify.success("Se creo el proyecto");

                }
            else {
                alertify.error(data.message);

            }

        })
        .fail(function (data) {
            alertify.error(data.statusText);
        });

}