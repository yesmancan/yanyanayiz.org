$(document).ready(function () {

    $('#bayi-login').click(function (e) {
        memberLogin('bayi-', '1');
        return false;
    });
});

var formMap = new Array();
function memberLogin(idPrefix, isVendor) {

    var username = $('#txtKod').val();
    var password = $('#txtSifre').val();

    if (username == '' || password == '') {
        $('#' + formMap['message']).html(l_arr['eposta_sifre_bos']);
        $('#' + formMap['password'])
        return false;
    }

    
    $.ajax({
        type: "POST",
        url: "http://hedefimonline.com/ajax.php",
        data: "m=Member&fn=memberLogin&user=" + username + '&pass=' + password + '&vendor=1&rm=' + false,
        success: function (json) {
            var data = $.parseJSON(json);
            var elId = '';

            if (data.isLogin == 0) {
                $('#' + formMap['message']).html(stripslashes(data.msg));
                $('#' + formMap['username']).focus();

                $('#' + formMap['login']).css('display', 'block !important');
                $('#' + formMap['loading']).hide();
            }
            else
                if (data.isLogin == 1) {
                    if (data.hash != '') {
                        location.hash = data.hash;
                        location.reload(true);
                    }
                    else
                        if (data.redirectionUrl != '')
                            location.href = data.redirectionUrl;
                        else
                            if (strpos(location.href, 'Cikis', 0) !== false)
                                location.href = location.href.replace('?B=Cikis', '');
                            else
                                location.reload();
                }
        }
    });
    return false;
}

