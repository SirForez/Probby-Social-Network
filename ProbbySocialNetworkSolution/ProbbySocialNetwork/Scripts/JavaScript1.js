var main = function () {

    
    $(".onClick").click(function () {

         $(".appendTo").append("<label for='url'>Enter URL:</label><input type='text' name='url' size='35' maxlength='255'/><input type='submit'name='submit' value='Submit' />");
         $(".onClick").hide();

     });

    $(".changeProfilePic").click(function () {

        $(".changeProfilePic").hide();
        $(".changePic").append("<label for='picLink'>New Picture</label><input type='text' id='newProfilePic' name='picLink' placeholder='Link to profile picture' /><button type='submit' name='submit' value='Submit' class='btn btn-primary'>Submit</button>"
            );
        });


}

$(document).ready(main);