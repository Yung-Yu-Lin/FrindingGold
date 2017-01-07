//jQuery to collapse the navbar on scroll
$(window).scroll(function() {
    if ($(".navbar").offset().top > 50) {
        $(".navbar-fixed-top").addClass("top-nav-collapse");
    } else {
        $(".navbar-fixed-top").removeClass("top-nav-collapse");
    }
});

//jQuery for page scrolling feature - requires jQuery Easing plugin
$(function() {
    $('a.page-scroll').bind('click', function(event) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: $($anchor.attr('href')).offset().top
        }, 1500, 'easeInOutExpo');
        event.preventDefault();
    });
});


$(document).ready(function () {
    //觸動影片分類 data filter 事件
    $(".all-portfolios").isotope({
        itemSelector: '.single-portfolio',
        layoutMode: 'fitRows',
    });
    // 觸動點擊分類圖片效果
    $('ul.filter li').click(function () {
        $("ul.filter li").removeClass("active");
        $(this).addClass("active");

        var selector = $(this).attr('data-filter');
        $(".all-portfolios").isotope({
            filter: selector,
            animationOptions: {
                duration: 750,
                easing: 'linear',
                queue: false,
            }
        });
        return false;
    });
});