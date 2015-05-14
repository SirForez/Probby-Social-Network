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
                    $('#messageList').append("<div class='message'>" +
                        '<div class="message-user-info">' + result[i].UserName + '</div>' +
                        '<div class="message-body">' + result[i].Text + '</div>' +
                        '</div>');
                }

                theForm.find('#messageText').val('');
            }).fail(function () {
                alert('Villa kom upp!');
            });
            return false;
        }
    });
});