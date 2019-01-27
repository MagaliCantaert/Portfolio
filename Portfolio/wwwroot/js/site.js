$(function () {
    $('[data-toggle="tooltip"]').tooltip({ trigger: 'manual' }).tooltip('show');
});

 $( window ).scroll(function() {   
 if($( window ).scrollTop() > 15){  // scroll down abit and get the action   
$(".progress-bar").each(function () {
    each_bar_width = $(this).attr('aria-valuenow');
    $(this).width(each_bar_width + '%');
});

   }  
});


$(window).scroll(function () {
    if ($(this).scrollTop() > 150) { // If the scroll equal 150px
        $(".gotop").css({ width: "40px", borderRadius: "50" }); // Show the button by give it (width 40px and border-radius 0px)
    } else { // else (if the scroll <= 150px )
        $(".gotop").css({ width: "0", borderRadius: "50% 50%" }); // Return button style to default
    }
});
$('.gotop').click(function () { // When user click on the button
    $('body,html').animate({
        scrollTop: 0
    }, 800);
    return false;
});



  