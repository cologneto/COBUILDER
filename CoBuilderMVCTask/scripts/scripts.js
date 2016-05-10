
$('.delete').each(function (index) {
    $(this).on("click", function () {
        var id = $(this).attr('data-id');
        $('.modal-dialog').load("DeletePopUp/" + id);
        $('#myModal').modal('show'); 
    });
});
//refresh the page
$('#myModal').on('hidden.bs.modal', function () {
    document.location.reload();
    $.get("/Banner/BannerList", 
    function (data, textStatus, jqXHR) {
        console.log(data);
    }
    
);
})

$(document).ready(function () {
    $('#bannerTable').DataTable();
});
$(function () {
    $('.datetimePicker').datetimepicker();
});

//var count = 1;
//$("#aFile_upload").on("change", function (e) {

//    var files = e.currentTarget.files; // puts all files into an array

//    // call them as such files[0].size will get you the file size of the 0th file
//    for (var x in files) {

//        var filesize = ((files[x].size / 1024) / 1024).toFixed(4); // MB

//        if (files[x].name != "item" && typeof files[x].name != "undefined" && filesize <= 10) {



//            if (count > 1) {

//                approvedHTML += ", " + files[x].name;
//            }
//            else {

//                approvedHTML += files[x].name;
//            }

//            count++;
//        }
//    }
//});

//$("#approvedFiles").val(approvedHTML);