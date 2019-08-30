 //Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
 //for details on configuring this project to bundle and minify static web assets.

 //Write your JavaScript code.


$(document).ready(function ()
{
    // AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
    var GenreOption = $("#booksDropdownGenres :selected").val();
    if (GenreOption != '-2') {
        //$.ajax
        //    ({
        //        type: "GET",
        //        url: "/Reservation/getGenre",
        //        data: "{}",
        //        success: function (data, GenreOption) {
        //            var m = '<option value="-1">Please Select a Book</option>';
        //            var GenreOption = $("#booksDropdownGenres :selected").text();
        //            for (var i = 0; i < data.length; i++) {
        //                if (data[i].Genre == GenreOption)
        //                    m += '<option value="' + data[i].Id + '">' + data[i].Title + '</option>';
        //            }
        //            var TitleOption = $("#booksDropdownTitle :selected").text();
                    
        //            $("#booksDropdownTitle").html(m);
        //            $('#booksDropdownTitle').val(TitleOption);
        //        }
        //    });
    }   
    else {
        $("#myForm2").hide();
    }
    $("#booksDropdownGenres").change(function ()
    {
        var GenreOption = $("#booksDropdownGenres :selected").val();
        
        if (GenreOption == '-2')
            $("#myForm2").hide();
        else
            $("#myForm2").fadeIn().show();
        $.ajax
            ({
                type: "GET",
                url: "/Reservation/getGenre",
                data: "{}",
                success: function (data, GenreOption) {
                    var m = '<option value="-1">Please Select a Book</option>';
                    var GenreOption = $("#booksDropdownGenres :selected").text();
                    for (var i = 0; i < data.length; i++) {
                        if (data[i].Genre == GenreOption)
                            m += '<option value="' + data[i].Id + '">' + data[i].Title + '</option>';
                    }
                    $("#booksDropdownTitle").html(m);
                }
                
            });
        
    });
    //$("#submitBtn").click(function () {
    //    //alert(" 1 phase ");
    //    var idofbook = $("#booksDropdownTitle :selected").attr('id');

    //    //$.post("/Reservation/New", { A: genrebookajax }, function (data) {
    //    //    alert(data.toString());
    //    //},);
    //    //$.post("/Reservation/New", { B: titlebookajax }, function (data) {
    //    //    alert(data.toString());
    //    //},);
    //    //$.ajax({
    //    //    type: "POST",
    //    //    url: "/Reservation/New",
    //    //    data: JSON.stringify({ BookId : idofbook}),
    //    //    dataType: 'json',
    //    //    success: function () {
    //    //        alert("Done!");
    //    //    }
    //    //});
    //});
});


