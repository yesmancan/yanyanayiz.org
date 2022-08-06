$(document).ready(function () {
    $(".datepicker").datepicker({
        dateFormat:"dd.mm.yy"
    });
    CheckToKeepSessionAlive();
});


function ShowLoading(content) {

    $(content).css("display", "none");
    $(content).after("<div data-tag='"+content+"' class='ldng text-center p30'><img src='/img/loading.gif' /> </div>");
}

function HideLoading(content) {
   
    $(".ldng[data-tag='"+content+"']").remove();
    $(content).css("display", "block");

}

function CheckToKeepSessionAlive() {
    $(function () { window.setInterval("keepSessionAlive()", 300000); });
}

function keepSessionAlive() {
    $.post("/Default.aspx/KeepSessionAlive");
}
function ConvertJsonDateTime(item) {

    var regex = /Date\((.*)\)/i
    var arr = regex.exec(item);
    var datetime = RegExp.$1;
    var formatMe = new Date(parseInt(datetime));
    var lastDate = formatMe.toLocaleDateString();
    return lastDate;

}

function GetMonthName(number) {
    switch(number){
        case 1:
            return "Ocak";
            break;
        case 2:
            return "Şubat";
            break;
        case 3:
            return "Mart";
            break;
        case 4:
            return "Nisan";
            break;
        case 5:
            return "Mayıs";
            break;
        case 6:
            return "Haziran";
            break;
        case 7:
            return "Temmuz";
            break;
        case 8:
            return "Ağustos";
            break;
        case 9:
            return "Eylül";
            break;
        case 10:
            return "Ekim";
            break;
        case 11:
            return "Kasım";
            break;
        case 12:
            return "Aralık";
            break;
    }
}


