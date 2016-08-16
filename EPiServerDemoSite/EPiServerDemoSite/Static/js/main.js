$("#ddlLanguage").change(function () {
    if ($("#ddlLanguage").val() == 'en') {
        var location = window.location.href.replace('/sv/', '/en/');
        window.location = location;
        $("#ddlLanguage").val('en');
    }
    else {
        var location = window.location.href.replace('/en/', '/sv/');
        window.location = location;
        $("#ddlLanguage").val('sv');
    }
});

$(document).ready(function () {
    if (window.location.href.indexOf('/sv/') > 0) {
        $("#ddlLanguage").val('sv');
    }
    else {
        $("#ddlLanguage").val('en');
    }
});