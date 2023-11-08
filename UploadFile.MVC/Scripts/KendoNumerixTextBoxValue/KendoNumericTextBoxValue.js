$(document).ready(function () {   
    var numerictextbox = $("#numerictextbox").data("kendoNumericTextBox");


    var getValue = $(".Clear_Numeric_TXT").val();

    $('.Clear_Numeric_TXT').each(function (i, obj) {

        var txt_value = $(this).val();

        if (txt_value === "0") {
            $(this).val("");
        } else {
            return;
        }
    });
});