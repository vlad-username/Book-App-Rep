﻿// //Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// //for details on configuring this project to bundle and minify static web assets.

// //Write your JavaScript code.


//$(document).ready(function ()
//{
    
//    var GenreOption = $("#booksDropdownGenres :selected").val();
//    if (GenreOption != 'All') {
//        $.ajax
//            ({
//                type: "GET",
//                url: "/Reservation/getGenre",
//                data: "{}",
//                success: function (data, GenreOption) {
//                    var m = '<option value="-1">Please Select a Book</option>';
//                    var GenreOption = $("#booksDropdownGenres :selected").text();
//                    for (var i = 0; i < data.length; i++) {
//                        if (data[i].Genre == GenreOption)
//                            m += '<option id="' + data[i].Id + '" value="' + data[i].Genre + '">' + data[i].Title + '</option>';
//                    }
//                    $("#booksDropdownTitle").html(m);
//                }
//            });
//    }   
//    else {
//        $("#myForm2").hide();
//    }
//    $("#booksDropdownGenres").change(function ()
//    {
//        var GenreOption = $("#booksDropdownGenres :selected").val();
//        if (GenreOption == 'All')
//            $("#myForm2").hide();
//        else
//            $("#myForm2").fadeIn().show();
//        $.ajax
//            ({
//                type: "GET",
//                url: "/Reservation/getGenre",
//                data: "{}",
//                success: function (data, GenreOption) {
//                    var m = '<option value="-1">Please Select a Book</option>';
//                    var GenreOption = $("#booksDropdownGenres :selected").text();
//                    for (var i = 0; i < data.length; i++) {
//                        if (data[i].Genre == GenreOption)
//                            m += '<option id="' + data[i].Id + '" value="' + data[i].Genre + '">' + data[i].Title + '</option>';
//                    }
//                    $("#booksDropdownTitle").html(m);
//                }
//            });
//    });

//    $("#submitBtn").click(function () {
//        //alert(" 1 phase ");
//        var titlebookajax = $("#booksDropdownTitle :selected").text();

//        //$.post("/Reservation/New", { A: genrebookajax }, function (data) {
//        //    alert(data.toString());
//        //},);
//        //$.post("/Reservation/New", { B: titlebookajax }, function (data) {
//        //    alert(data.toString());
//        //},);
//        $.ajax({
//            type: "POST",
//            url: "/Reservation/New",
//            data: { Title: titlebookajax},
//            dataType: 'json',
//            success: function () {
//                alert("Done!");
//            }
//        });
//    });
//});


