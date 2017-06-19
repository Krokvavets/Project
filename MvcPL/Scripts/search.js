$(function () {
    $("#search").keyup(function () {
        var search = $("#search").val();
        $.getJSON("/Home/Search", { "name": search } , getResult);
        });
});
function getResult(result) {
    $("#divaa").empty();
    $.each(result, function (n) {
        $("#divaa").append("<a href = '/Topic/Topic?id"+this.Id+"'>" + this.Name + "</a><br/>");
    });
};
