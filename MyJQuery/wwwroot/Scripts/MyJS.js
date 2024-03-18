$(document).ready(function () {
    $("#myButton").click(function () {
        // var value = $("#tbTest").val();
        // //console.log(value);
        // $("#divTest").html('<b>' + value + '</b>');
        // alert(value);
        // $.ajax
        //     ({
        //         type: "GET",
        //         url: "http://localhost:5099/test/sayhello/step",
        //         success: function (data) {
        //             console.log(data);
        //         },
        //         error: function () {
        //             console.log("error")
        //         }
        //     });
        $.ajax
            ({
                type: "GET",
                url: "test/getCityAll",
                success: function (data) {
                    console.log(data);
                },
                error: function () {
                    console.log("error")
                }
            });

    });

    $("#myButton2").click(function () {
        var st = `<table border='1'>`;
        st += '<tr bgcolor="#ffd400"><td class="text-center">id</td><td class="text-center">name</td></tr>';
        st += '<tr><td>1</td><td>Алматы</td></tr>';
        st += '<tr><td>2</td><td>Астана</td></tr>';
        st += '</table>';
        $("#divTest").html(st);

    });
})
function F1() {
    alert('hello step');
}