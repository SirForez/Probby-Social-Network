$(document).ready(function () {
    $(".statusContent2").show();
});

function editStatus(id) {
    $("#statusText" + id).hide();
    $("#statusPic" + id).hide();
    $("#statusTextForm" + id).show();
    $("#statusPicForm" + id).show();
}; 