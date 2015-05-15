$(function () {
    $('body').on('click', '.upvoteButton', function () {

        var url = '/Status/UpvoteStatus';
        var statusid = $(this).siblings("statusIdForKarma");
        

        $.ajax({
            type: 'POST',
            url: url,
            data: {
                statusID: statusid
            }
        }).done(function (data) {
            if(data == "") { }
            else {
                alert("done!!!!!");
                var karmaId = '#karmaDisplay' + data.ID.toString();
                $(karmaId).html(data.Karma);
            }
        }).fail(function () {
            alert('Villa kom upp!');
        });

        return false;
            
    })
});




        var url = '/Status/UpvoteStatus';
        alert("sjomli!!!!!");
        $.ajax({
            type: 'POST',
            url: url,
            data: {
                movieId: movie,
            }

        }).done(function (data) {
            alert("done!!!!!");
            var karmaId = '#karmaDisplay' + data.ID.toString();
            $(karmaId).html(data.Karma);
        }).fail(function () {
            alert('Villa kom upp!');
        });

        return false;
    });
});
