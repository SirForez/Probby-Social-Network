$(function () {
    $('body').on('keypress', '#commentInputBox', function (e) {
        var keyCode = e.which || e.keyCode;
        if (e.keyCode == 13) {
            var theForm = $(this).parents('form');

            $.ajax({
                type: 'POST',
                url: theForm.attr('action'),
                data: theForm.serialize(),
            }).done(function (result) {
                console.log(result);
                var statusid = result[0].StatusID;
                var commentHtmlId = '#commentForStatus' + statusid.toString();
                $(commentHtmlId).html('');
       
                for (var i = 0; i < result.length; i++) {
                    $(commentHtmlId).append(
                        '<div class="comment">' +
                        '<h5 id="commentText' + result[i].ID + '" class="commentContent2">' + result[i].Body + '</h5>' +
                        '<form action="/Status/EditComment" id="' + result[i].ID +'" method="post">' +
                        '<input type="hidden" name="commentId" value="'+ result[i].ID + '"/>' +
                        '<div id="commentTextForm'+ result[i].ID + '" class="editForm">' +
                        '<label for="commentTextbox'+ result[i].ID + '">Comment:</label>' +
                        '<br>' + 
                        '<input type="text" name="commentTextbox id="commentInputBox"'+ result[i].ID + '" placeholder="Write a comment"/>' +
                        '<br>' +
                        '<button type="submit" class="btn btn-primary">Confirm Edit</button>' +
                        '</div></form>' +                                           
                        '<a href="/Home/Profile?username=' + result[i].UserName + '">' + result[i].UserName + '</a> | ' + result[i].DisplayDate +
                        '<span> | </span>' +
                        '<a class="editLink" onclick="editComment('+ result[i].ID+')">Edit</a>' +
                        '<span> | </span>' +
                        '<a href="/Status/RemoveComment/'+ result[i].ID +'">Remove</a></div>'); 
                        
            }
            
                theForm.find('#commentInputBox').val('');
            }).fail(function () {
                alert('Villa kom upp!');
            });

            return false;
        }
    });

    $('body').on('click', '.editLink', function () {
        
        alert('testing');
        /*
        var theForm = $(this).parents('form');

        $.ajax({
            type: 'POST',
            url: theForm.attr('action'),
            data: theForm.serialize(),
        }).done(function (result) {
    
        });
        */
    });
})