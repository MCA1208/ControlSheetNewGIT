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
            alert(xhr.responseText);
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
                  
                    _html += '<tr><td><img width="80px" height="80px"  src="data:image/jpg;base64,' + value.imagePerfil + '"/></td><td><img width="80px" height="80px"  src="data:image/jpg;base64,' + value.imagePasion + '"/></td><td><img width="80px" height="80px"  src="data:image/jpg;base64,' + value.imageAlgo + '"/></td><td>' + value.names + '</td><td>' + value.profession + '</td><td>' + '<button type="button" class="btn btn-primary" onclick="showWatchProfileUser(' + value.id + ');"><i class="fas fa-eye"></i> VER </button>' + '</td>';

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

    $('#WatchProfileUser').modal('show');
    LoadProfileDetail(id);

}
function LoadProfileDetail(id) {

    $.blockUI();

    $.post(directories.paperBag.LoadAllProfile)
        .done(function (data) {
            if (data.status !== "error") {

                data = JSON.parse(data.result);


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