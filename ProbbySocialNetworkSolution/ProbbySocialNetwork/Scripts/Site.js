var main = function () {
    $(".onClick").click(function () {
        $(".appendTo").append("<input type='text' name='url' size='35' maxlength='255' placeholder='Insert IMG url here'/>");
        $(".onClick").hide();
    });


    $("#hideChangePic").hide();
    $(".changeProfilePic").click(function () {

        $(".changeProfilePic").hide();
        $("#hideChangePic").show();
    });

}
$(document).ready(main);

function validateHobby(form) {
    if ($("#hobbyName").val() == '') {
        alert("You must provide a hobby name!");
        return false;
    }
    else {
        var testRegex = /^([a-zA-Z0-9]+)$/g.exec($("#hobbyName").val());
        if (testRegex == null) {
            alert("Hobby name must consist only of letters and numbers!");
            return false;
        }
    }
    return true;
}

function validateGroup(form) {


    if ($("#groupName").val() == '') {
        alert("You must provide a group name!");
        return false;
    }

    else if ($("#groupName").val().length > 3) {
    
        alert("Group name can not be longer than 70 characters!");
            return false;
    }
        
    return true;

}


function validateHobbiesForStatuses() {
    var checkedAtLeastOne = false;
    $('input[type="checkbox"].hobbyCheckboxes').each(function () {
        if ($(this).is(":checked")) {
            checkedAtLeastOne = true;
        }
    });

    if (checkedAtLeastOne == false) {
        alert("You must select a hobby");
        return false;
    }
    return true;
}
    

