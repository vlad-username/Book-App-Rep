// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Reservation/getGenre",
        data: "{}",
        success: function (data, GenreOption) {
            var s = '<option value="-1">Please Select a Genre</option>';
            var usedNames = [];
            $("#myForm2").hide();
            for (var i = 0; i < data.length; i++) {
                if (usedNames.indexOf(data[i].Genre) == -1)
                    s += '<option value="' + data[i].Genre + '">' + data[i].Genre + '</option>';
                usedNames.push(data[i].Genre);
            }
            $("#booksDropdown").html(s);
            
            $("#booksDropdown").change(function () {
                var GenreOption = $("#booksDropdown :selected").text();
                if (GenreOption == 'Please Select a Genre')
                    $("#myForm2").hide();
                else
                    $("#myForm2").show();
                
                    var m = '<option value="-1">Please Select a Book</option>';
                    for (var i = 0; i < data.length; i++) {
                        if (data[i].Genre == GenreOption) {
                            m += '<option id="' + data[i].Genre + '" value="' + data[i].Id + '">' + data[i].Title + '</option>';
                        }
                    }
                    $("#booksDropdownTitle").html(m);
            });
            $("#submitBtn").click(function () {
            //alert(" 1 phase ");
                
                var genrebookajax = $("#booksDropdown :selected").val();
                var titlebookajax = $("#booksDropdownTitle :selected").text();
                //$.post("/Reservation/New", { genrebookres: "text" }, function (data) {
                //    alert(data.toString());
                //},);
                //$.post("/Reservation/New", { titlebookres: titlebookajax }, function (data) {
                //    alert(data.toString());
                //},);
                $.ajax({
                    type: "POST",
                    url: '/Reservation/New")',
                    data: { genrebookres: genrebookajax, titlebookres: titlebookajax },
                    success: function () {
                        alert("Done!");
                    }
                });
            });
        }
    });
});  