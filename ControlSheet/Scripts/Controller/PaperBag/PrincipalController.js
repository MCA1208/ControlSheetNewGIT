var param = '';


$(document).ready(function () {

    LoadAllProfile();
    
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

    var fileSave = $('#file-perfil')[0].files[0];
    var fileSave1 = $('#file-pasion')[0].files[0];
    var fileSave2 = $('#file-algo')[0].files[0];


    if ($('#file-perfil')[0].files[0] !== undefined) {

        var FileSizePerfil = $('#file-perfil')[0].files[0].size / 1024;

        if (FileSizePerfil > 500) {

            alertify.error("El tamaño de la foto de perfil, debe ser menor a 500 KB");
            return;
        }

    }

    if ($('#file-pasion')[0].files[0] !== undefined) {

        var FileSizePasion = $('#file-pasion')[0].files[0].size / 1024;

        if (FileSizePasion > 500) {

            alertify.error("El tamaño de la foto de pasión, debe ser menor a 500 KB");
            return;
        }

    }

    if ($('#file-algo')[0].files[0] !== undefined) {

        var FileSizeAlgo = $('#file-pasion')[0].files[0].size / 1024;

        if (FileSizeAlgo > 500) {

            alertify.error("El tamaño de la foto de algo, debe ser menor a 500 KB");
            return;
        }

    }

    $.blockUI();

    var formData = new FormData();

    formData.append("filePerfil", $('#file-perfil')[0].files[0]);
    formData.append("filePasion", $('#file-pasion')[0].files[0]);
    formData.append("fileAlgo", $('#file-algo')[0].files[0]);

    formData.append("name", $('#txtName').val());
    formData.append("profession", $('#txtProfession').val());
    formData.append("academyData", $('#txtAcademyData').val());
    formData.append("experience", $('#txtExperience').val());
    formData.append("contact", $('#txtContact').val());


    var xhr = new XMLHttpRequest();
    xhr.open('POST', "ModifyPerfil", "PaperBag");
    xhr.send(formData);
    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200) {
            //alert(xhr.responseText);
            alertify.success("Se edito correctamente");
            LoadAllProfile();
            $.unblockUI();
        }     

    }

}
function LoadAllProfile() {

    $.blockUI();

    $.post(directories.paperBag.LoadAllProfile)
        .done(function (data) {
            if (data.status !== "error") {
                $('#tblPaperBag > tbody').html('');
                var _html = '';
                _html += '<tbody class="customtable" style= text-align:left;>';
                data = JSON.parse(data.result);
                $.each(data, function (key, value) {
                  
                    _html += '<tr><td><img width="90px" height="90px"  src="data:image/jpg;base64,' + value.imagePerfil + '"/></td><td><img width="90px" height="90px"  src="data:image/jpg;base64,' + value.imagePasion + '"/></td><td><img width="90px" height="90px"  src="data:image/jpg;base64,' + value.imageAlgo + '"/></td><td>' + value.names + '</td><td>' + value.profession + '</td><td>' + '<button type="button" class="btn btn-primary" onclick="showWatchProfileUser(' + value.idUsers + ');"><i class="fas fa-eye"></i> VER </button>' + '</td>';

                });


                _html += '</tbody >';

                $('#tblPaperBag').append(_html);

                $('#tblPaperBag').DataTable();

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


function showWatchProfileUser(id) {
    LoadProfileDetail(id);
   

    


}
function LoadProfileDetail(id) {

    $.blockUI();

    param = {
        Id: id
    };

    $.post(directories.paperBag.GetProfileForId, param)
        .done(function (data) {
            if (data.status !== "error") {

                data = JSON.parse(data.result);

                $('#imgPerfilWatch').attr('src', "data:image/jpg;base64," + data[0].imagePerfil);
                $('#imgPasionWatch').attr('src', "data:image/jpg;base64," + data[0].imagePasion);
                $('#imgAlgoWatch').attr('src', "data:image/jpg;base64," + data[0].imageAlgo);
                $('#txtNameWatch').val(data[0].names);
                $('#txtProfessionWatch').val(data[0].profession);
                $('#txtAcademyDataWatch').val(data[0].academyData);
                $('#txtExperienceWatch').val(data[0].experience);
                $('#txtContactWatch').val(data[0].contact);

                $('#WatchProfileUser').modal('show');

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

function ShowModifyProfile() {

    $('#ModifyProfileModal').modal('show');

    LoadProfileModify();
}

function LoadProfileModify() {

    //$.blockUI();

    param = {
        Id: null
    };

    $.post(directories.paperBag.GetProfileForId, param)
        .done(function (data) {
            if (data.status !== "error") {

                data = JSON.parse(data.result);

                $('#imgPerfil').attr('src', "data:image/jpg;base64," + data[0].imagePerfil);
                $('#imgPasion').attr('src', "data:image/jpg;base64," + data[0].imagePasion);
                $('#imgAlgo').attr('src', "data:image/jpg;base64," + data[0].imageAlgo);
                $('#txtName').val(data[0].names);
                $('#txtProfession').val(data[0].profession);
                $('#txtAcademyData').val(data[0].academyData);
                $('#txtExperience').val(data[0].experience);
                $('#txtContact').val(data[0].contact);

            }
            else {
                alertify.error(data.message);

            }

        })
        .fail(function (data) {
            alertify.error(data.statusText);
        })
        .always(function () {
            //$.unblockUI();
        });

}


function HasProfile() {

    $.post(directories.paperBag.HasProfile)
        .done(function (data) {
            data = JSON.parse(data.result);
            var datos = data[0].id;
            if (data[0].id !== 0) {

                return true;
            }
           

        })
        .fail(function (data) {
            alertify.error(data.statusText);
            return false;
        });


}