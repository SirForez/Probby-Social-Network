var main = function () {
    $(".onClick").click(function () {
        $(".appendTo").append("<input type='text' name='url' size='35' maxlength='255' placeholder='Insert IMG url here'/>");
        $(".onClick").hide();
    });
}
$(document).ready(main);