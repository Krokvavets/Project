$(function get() {
    $("#sendBtn").click(function () {
        $.getJSON("/Topic/AddMessage");
        location.reload();
    });
});