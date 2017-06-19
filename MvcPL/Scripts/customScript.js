$(function get() {
    $("#getPeople").click(function () {
        $.getJSON("/Management/Users", null, getPeople);
    });
});
function getPeople(people) {
    $("#Table").empty();
    $("#btn").empty();
    $.each(people, function (n) {
        $("#Table").append("<tr id = id" + n + "><td><a href='/Profile/Edit?id=" + this.Id + "'>edit</a><a class ='del' href='/Management/DeleteUser?id=" + this.Id + "'>delet</a></td><td>" + this.Nickname + "</td> <td>" + this.Email + "</td>");
        $.each(this.Roles, function (i) {
            $("#id"+n).append("<td class ='role'>" + this.Name + "</td>");
        });

    });
}
$(function getSectionLink() {
        $("#getSection").click(function () {
            $.getJSON("/Management/Section", null, getSection);
        });
    });
    function getSection(section) {
        $("#Table").empty();
        $("#btn").empty();
        $("#btn").append("<a href ='/Management/CreateSection'>Create new Section</a>");
        $.each(section, function (n) {
            $("#Table").append("<tr><td><a href='/Management/EditSection?id=" + this.Id + "'>edit</a><a class ='del' href='/Management/DeleteSection?id=" + this.Id + "'>delet</a></td><td>" + this.Name + "</td>");
        });
    }