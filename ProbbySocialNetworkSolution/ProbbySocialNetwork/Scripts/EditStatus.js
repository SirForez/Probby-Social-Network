$(document).ready(function () {
    $(".statusContent2").show();
});

function editStatus(id) {
    $("#statusText" + id).hide();
    $("#statusPic" + id).hide();
    $("#statusTextForm" + id).show();
};

function editComment(id) {
    $("#commentText" + id).toggle();
    $("#commentTextForm" + id).toggle();
};