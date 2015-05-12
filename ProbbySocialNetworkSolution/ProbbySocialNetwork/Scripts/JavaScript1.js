var main = function () {

    
    $(".onClick").click(function () {

         $(".appendTo").append("<label for='url'>Enter URL:</label><input type='text' name='url' size='35' maxlength='255'/><input type='submit'name='submit' value='Submit' />");
         $(".onClick").hide();

     });



}

$(document).ready(main);