// JavaScript Document


var txt = $('.writer').text();
var timeOut;
var txtLen = txt.length;
var char = 0;
$('.writer').text('|');
(function typeIt() {   
    var humanize = Math.round(Math.random() * (200 - 30)) + 30;
    timeOut = setTimeout(function() {
        char++;
        var type = txt.substring(0, char);
        $('.writer').text(type + '|');
        typeIt();

        if (char == txtLen) {
            $('.writer').text($('.writer').text().slice(0, -1)); // remove the '|'
            clearTimeout(timeOut);
        }

    }, humanize);
}());