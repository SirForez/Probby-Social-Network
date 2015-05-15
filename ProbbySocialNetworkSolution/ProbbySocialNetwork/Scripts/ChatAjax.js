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

                //this clear the messagelist
                $('#messageList').html('');
                //this returns the new messages
                for (var i = 0; i < result.length; i++) {
                    $('#messageList').append('<div class="messageWrapper">' +
                                '<div class="lhsMessage">' +
                                '<div class="message-info">' +
                                '<img src="' + data[i].UserProfilePic + '" alt="' + data[i].UserName + '" class="MessageUserProfilePic" id="MessageUserProfilePic" />' +
                                '</div>' +
                                '<div class="Message-UserName">' +
                                data[i].UserName +
                                '</div>' +
                                '</div>' +
                                '<div class="rhsMessage">' +
                                '<div class="message-body">' +
                                '<div class="panel panel-default">' +
                                '<div class="panel-body">' +
                                data[i].Text +
                                '</div>' +
                                '</div>' +
                                '</div>' +
                                '</div>' +
                                '</div>');
                }
                theForm.find('#messageText').val('');
                //$('#messageText').val('');
            }).fail(function () {
                //alert('Villa kom upp!');
            });
            return false;
        }
    });
});
