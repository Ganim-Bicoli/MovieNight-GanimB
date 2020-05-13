$(document).ready(function(){
  $("input[type=submit]").hover(function(){
      $(this).css("background-color", "#5be7f9");
      $(this).css("box-shadow", "0px 5px 0px rgb(91, 201, 226)");
    }, function(){
        $(this).css("background-color", "");  //returns to previous value.
        $(this).css("box-shadow", "");
  });
});