$(document).ready(function () {
    $.ajax({
        type: 'POST',
        contentType: 'application/json',
        url: '/Default.aspx/imzaload',
        async: true,
        success: function (data) {
            var hedef = 10000;
            var sonuc = (data.d / hedef) * 100;
            $('.hedef').html(hedef);
            $('.progress .progress-bar').attr('style', "width:" + sonuc + "%");
            $('span.imzacount > span').text(data.d);
            $('span.imzacount_kampanya > span').text(data.d);
            $('.imza_sayisi').text(data.d);
            $('#get_imza .progress .progress-bar > span').text("İmza Sayısı : " + data.d);
        }
    });
});
$('#resave').on('click', function (e) {
    var data = {};
    data.id = $('#resave').data('id');
    data.name = $('#adiniz').val();
    data.email = $('#email').val();
    data.location = $('#location').val();
    $.ajax({
        type: 'post',
        data: JSON.stringify(data),
        contentType: 'application/json',
        url: '/Default.aspx/resave',
        success: function (data) {
            data.d = data.d.split('(#%#%#)');
            goster();
            $('#status .owner-name').html(data.d[0] + "<span class='owner-location'>" + data.d[1] + "</span>")
        }
    });
    e.preventDefault();
});
$('#imzalabtn').on('click', function (e) {
    var data = {};
    data.id = $('#imzalabtn').data('id');
    data.context = $('.textareawow').val();
    $.ajax({
        type: 'post',
        data: JSON.stringify(data),
        contentType: 'application/json',
        url: '/Default.aspx/imzasave',
        success: function (data) {
            $('#status .textareawow').val(data.d);
            $("<div>İmzanız kayıt edilmiştir.</div>").dialog();
            window.location.href = "/Default.aspx";
        }, error: function (err) {
            console.log(err);
        }
    });
    e.preventDefault();
});


$('#imzalayanlari_h3').on('click', function (e) {
    if ($('#imzalayanlar_allimza').css('display') == 'block') {
        $('#imzalayanlar_allimza').css('display', 'none');
        $('#imzalayanlari_h3 .gosterclass').css('display', 'block');
        $('#imzalayanlari_h3 .gizleclass').css('display', 'none');
    } else {
        $('#imzalayanlar_allimza').css('display', 'block');
        $('#imzalayanlari_h3 .gosterclass').css('display', 'none');
        $('#imzalayanlari_h3 .gizleclass').css('display', 'block');
    }
    e.preventDefault();
});
$('#imzalayanlaricontent_h3').on('click', function (e) {
    if ($('#allimza').css('display') == 'block') {
        $('#allimza').css('display', 'none');
        $('#imzalayanlaricontent_h3 .gosterclass').css('display', 'block');
        $('#imzalayanlaricontent_h3 .gizleclass').css('display', 'none');
    } else {
        $('#allimza').css('display', 'block');
        $('#imzalayanlaricontent_h3 .gosterclass').css('display', 'none');
        $('#imzalayanlaricontent_h3 .gizleclass').css('display', 'block');
    }
    e.preventDefault();
});


//mail ile giriş function
$('#kayitol').on('click', function (e) {
    var namesurname = $('#modal_name_create').val() + " " + $('#modal_surname_create').val();
    var data = {};
    data.name = namesurname;
    data.phone = $('#modal_phone_create').val();
    data.email = $('#modal_email_create').val();
    data.responseValue = grecaptcha.getResponse()
    $.ajax({
        type: 'post',
        data: JSON.stringify(data),
        contentType: 'application/json; charset=utf-8',
        url: '/Default.aspx/usercreate',
        success: function (data) {
            var arr = data.d.split('(#%#%#)');
            if (arr[0] == "false") {
                grecaptcha.reset();
                $("<div title='Hata!'>" + arr[1] + "Eğer bir yanlışlık olduğunu düşünüyorsanız aşağıdaki bağlantıya tıklayınız<br><br><a href='/Oneriformu.aspx'>İletişime Geç</a></div>").dialog();
            }
            else
                window.location.href = "/Default.aspx";
        }
    });
    e.preventDefault();
});
//mail ile giriş function end

$('#imzalayanlari_h3 .gosterclass').on('click', function (e) {
    $.ajax({
        type: 'POST',
        contentType: 'application/json',
        url: '/Default.aspx/imzausernameload',
        async: true,
        beforeSend: function () {
            $('#imzalayanlar #imzalayanlar_allimza').html("<img id='loading' src='./img/loading.gif'/>");
        },
        success: function (data) {
            $('#loading').remove();
            $('#imzalayanlar #imzalayanlar_allimza').html(data.d);
        }, error(err) {
            $('#loading').remove();
            console.log(err);
        }
    });
});
$('#imzalayanlaricontent_h3 .gosterclass').on('click', function (e) {
    $.ajax({
        type: 'POST',
        contentType: 'application/json',
        url: '/Default.aspx/imzacontentload',
        async: true,
        beforeSend: function () {
            $('#allimza').html("<img id='loading' src='./img/loading.gif'/>");
        },
        success: function (data) {
            $('#loading').remove();
            $('#allimza').html(data.d);
        }, error(err) {
            $('#loading').remove();
            console.log(err);
        }
    });
});