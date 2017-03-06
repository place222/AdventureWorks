// Write your Javascript code.
var coreweb = (function ($) {

    var serviceUrl = "http://localhost:17799";

    return {
        servicesUrl: serviceUrl
    }
})($);

//目录操作
//加入一个点击所有目录的load局部刷新的ajax操作 然后再看看pjax
$(function () {
    $("#department")
        .click(function () {
            $('li.active').removeClass('active');
            $(".content").load('/Department/Index');
            $(this).parent().addClass('active');
        });
    $("#employee")
        .click(function () {
            $('li.active').removeClass('active');
            $(".content").load('/Employee/Index');
            $(this).parent().addClass('active');
        });
});
