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
                    console.warn(data);
                    let html = '';
                    html += "<table border='1' cellpadding='1' cellspacing='1' width='500'>";
                    html += "<tr bgcolor='#ffd400'>";
                    html += "<td class='text-center'>id</td>"
                    html += "<td class='text-center'>name</td>";
                    html += "</tr>";
                    $.each(data, function (i, item) {
                        html += "<tr><td>" + item.id + "</td>" +
                            "<td>" + item.name + "</td></tr>";
                    });
                    html += "</table >";
                    $("#divTest").html(html);
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