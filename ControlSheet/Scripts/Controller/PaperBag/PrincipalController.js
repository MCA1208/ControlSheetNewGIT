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

    formData.append("personalData", $('#txtPersonalData').val());
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

                   // _html += '<tr><td><img width="80px" height="80px"  src="data:image/jpg:base64,' + value.imagePerfil + '"/></td><td>' + value.imagePasion + '</td><td>' + value.imageAlgo + '</td><td>' + value.personalData + '</td><td>' + value.academyData + '</td><td>' + '<button type="button" class="btn btn-primary" onclick="showModalEditProyect(' + value.id + ',' + `'${value.proyectName}'` + ');"><i class="fas fa-edit"></i> Editar </button>' + '</td>';
                    _html += '<tr><td><img width="80px" height="80px"  src=""/></td><td>' + value.imagePasion + '</td><td>' + value.imageAlgo + '</td><td>' + value.personalData + '</td><td>' + value.academyData + '</td><td>' + '<button type="button" class="btn btn-primary" onclick="showModalEditProyect(' + value.id + ',' + `'${value.proyectName}'` + ');"><i class="fas fa-edit"></i> Editar </button>' + '</td>';

                });
                //[imagePerfil][image] NULL,
                //[imagePasion][image] NULL,
                //[imageAlgo][image] NULL,
                //[personalData][nvarchar](200) NULL,
                //[academyData][nvarchar](200) NULL,
                //[experience][nvarchar](200) NULL,
                //[contact][nvarchar](200) NULL,

                _html += '</tbody >';

                $('#tblPaperBag').append(_html);

                $('#tblPaperBag').DataTable({
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