$(function () {
    $('body').on('keypress', '#messageText', function (e) {
        var keyCode = e.which || e.keyCode;
        if (e.keyCode == 13) {
            var theForm = $(this).parents('form');

            $.ajax({
                type: 'POST',
                url: theForm.attr('action'),
                data: theForm.serialize(),
            }).done(function (result) {
            
            }
        }
    });
});