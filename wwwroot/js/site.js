// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Reservation/getGenre",
        data: "{}",
        success: function (data) {
            var s = '<option value="-1">Please Select a Genre</option>';
            for (var i = 0; i < data.length; i++) {
                s += '<option value="' + data[i].Genre + '">' + data[i].Genre + '</option>';
            }
            $("#booksDropdown").html(s);
           // var GenreOption = document.getElementById("#booksDropdown");
            var GenreOption = $("#booksDropdown :selected").val();
           // var GenreOption = $("#booksDropdown").val();

            var m = '<option value="-1">Please Select a Genre</option>';
            for (var i = 0; i < data.length; i++) {
                if (data[i].Genre == GenreOption) {
                    m += '<option value="' + data[i].Title + '">' + data[i].Title + '</option>';
                }
                
            }
            $("#booksDropdownTitle").html(m);
        }
    });
    
});  