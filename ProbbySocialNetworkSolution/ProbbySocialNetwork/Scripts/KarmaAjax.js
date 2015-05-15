$(function () {
    $('body').on('click', '.upvoteButton', function () {

        var url = '/Status/UpvoteStatus';
        var statusid = $(this).siblings("statusId");
        var karma = $(".karmaCount").val();

        $.ajax({
            type: 'POST',
            url: url,
            data: {
                statusID: statusid,
                Karma: karma,
            }
        }).done(function (data) {
            if (data == "") { }
            else {
                $(".karmaCount").html(data.Karma);
            }
        }).fail(function () {
            alert('Villa kom upp!');
        });

        return false;

    })

    $('body').on('click', '.downvoteButton', function () {

        var url = '/Status/DownvoteStatus';
        var statusid = $(this).siblings("statusIdForKarma");

        alert("Yo");
        $.ajax({
            type: 'POST',
            url: url,
            data: {
                statusID: statusid
            }
        }).done(function (data) {
            if (data == "") { }
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
