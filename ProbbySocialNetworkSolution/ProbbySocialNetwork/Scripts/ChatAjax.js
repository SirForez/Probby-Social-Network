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

                console.log(result);

                $('#messageList').html('');
                for (var i = 0; i < result.length; i++) {
                    $('#messageList').append('<div class="messageWrapper">' +
                                '<div class="lhsMessage">' +
                                '<div class="message-info">' +
                                '<img src="' + result[i].UserProfilePic + '" alt="' + result[i].UserName + '" class="MessageUserProfilePic" id="MessageUserProfilePic" />' +
                                '</div>' +
                                '<div class="Message-UserName">' +
                                result[i].UserName +
                                '</div>' +
                                '</div>' +
                                '<div class="rhsMessage">' +
                                '<div class="message-body">' +
                                '<div class="panel panel-default">' +
                                '<div class="panel-body">' +
                                result[i].Text +
                                '</div>' +
                                '</div>' +
                                '</div>' +
                                '</div>' +
                                '</div>');
                }

                $('#messageText').val("");

            }).fail(function () {
            });
            return false;
        }
    });
});
