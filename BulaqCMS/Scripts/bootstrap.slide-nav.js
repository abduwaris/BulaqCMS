$(function () {
    $('.slide-nav-item').click(function () {
        if ($(this).hasClass('active')) {
            $(this).find('.slide-nav-icon').removeClass('glyphicon-menu-down').addClass('glyphicon-menu-left');
            $(this).removeClass('active').siblings('ul').slideUp();
        } else {
            $(this).addClass('active').siblings('ul').slideDown();
            $(this).find('.slide-nav-icon').removeClass('glyphicon-menu-left').addClass('glyphicon-menu-down');
        }
    });
    $('.slide-nav a').click(function () {
        var par = $(this).parents('.slide-nav');
        par.find('a.active').removeClass('active');
        $(this).addClass('active');
    });
    $('.slide-nav-head .glyphicon').click(function () {
        if ($('.slide-nav').hasClass('slide-nav-list')) {
            $('.slide-nav-list [data-toggle="tooltip"]').not('.slide-nav-head [data-toggle="tooltip"]').tooltip('destroy');
            $('.slide-nav').removeClass('slide-nav-list').addClass('slide-nav-list-w');
            setTimeout(function () {
                $('.slide-nav').removeClass('slide-nav-list-w');
            }, 500);
            $('.container-main').css('padding-right', '265px');
        } else {
            $('.slide-nav').addClass('slide-nav-list');
            $('.slide-nav-list [data-toggle="tooltip"]').not('.slide-nav-head [data-toggle="tooltip"]').tooltip();
            $('.container-main').css('padding-right', '45px');
        }
    });

    $('.slide-nav-list [data-toggle="tooltip"]').add('.slide-nav-head [data-toggle="tooltip"]').tooltip();
})