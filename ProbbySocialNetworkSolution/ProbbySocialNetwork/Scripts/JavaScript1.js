var main = function () {

    $(".imageUrl").hide();

    $("#uploadImage").click(function () {


        $(".imageUrl").toggle();
        $(".imageUrl").show();
    });




}

$(document).ready(main);