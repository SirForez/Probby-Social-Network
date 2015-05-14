$(function () {
    $('body').on('keypress', '.commentTextbox', function (e) {
        var keyCode = e.which || e.keyCode;
        if (e.keyCode == 13) {
            alert('testing');
            var theForm = $(this);

            $.ajax({
                type: 'POST',
                url: theForm.attr('action'),
                data: theForm.serialize(),
            }).done(function (result) {

                console.log(result);

                $('#commentList blockquote').remove();

                for (var i = 0; i < result.Reviews.length; i++) {
                    $('#commentList').append('<blockquote>' +
                    '<p>' + result.Reviews[i].Username + ' | ' + result.Reviews[i].Text + '</p>' + '</blockquote>');
                }

                theForm.find('#reviewtext').val('');
            }).fail(function () {
                alert('Villa kom upp!');
            });
        }
        return false;
    });
})