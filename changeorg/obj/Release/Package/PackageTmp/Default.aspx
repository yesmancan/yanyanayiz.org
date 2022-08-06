<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="changeorg.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div id="fb-root"></div>
    <script>
        (function (d, s, id) {
            var js, fjs = d.getElementsByTagName(s)[0];
            if (d.getElementById(id)) return;
            js = d.createElement(s); js.id = id;
            js.src = "//connect.facebook.net/tr_TR/sdk.js#xfbml=1&version=v2.9&appId=1317401415034638";
            fjs.parentNode.insertBefore(js, fjs);
        }(document, 'script', 'facebook-jssdk'));
    </script>
    <div class="container">
        <div class="row">
            <div id="data-area" class="col-md-8">
                <h1 id="baslik_h1" class="col-md-12 ">YAN YANAYIZ, BİRARADAYIZ!
                    <br />
                </h1>
                <div class="col-md-12">
                    <div id="content" class="col-md-12">
                        <img src="/img/banner.jpg" style="width: 100%; text-align: center; margin: 0 auto 15px;" />
                        <div id="content-text" class="col-md-12 pr0 pl0">
                            <h3 style="font-weight: 600; margin-bottom: 10px; font-size: 24px; line-height: normal; letter-spacing: normal;">Bu toprakların ortak sahibi olan bizler; </h3>
                            <p>
                                ortak yaşamı kurmak, korumak, geliştirmek için, 
                                <strong style="font-weight: 400; border-bottom: 1px solid #a4a4a4;">siyasî parti, ideolojik aidiyet, inanç, din, mezhep, milliyet, cinsiyet ayrımı gözetmeksizin 
                                </strong>
                                80 milyona sesleniyoruz
                            </p>
                            <h3 style="font-weight: 600; margin-bottom: 10px; font-size: 24px; line-height: normal; letter-spacing: normal;">Bizler kutuplaşmak, birbirimize düşmanlaşmak, Türk-Kürt, dindar-laik, 
                                evetçi-hayırcı diye bölünmek, onlar-bunlar diye ayrıştırılmak istemiyoruz.
                            </h3>
                            <p>İnancımızı, dinimizi, dilimizi, kültürümüzü, hayat tarzımızı kendi seçtiğimiz gibi, özgür, eşit, korkusuz, huzur içinde yaşamak; birbirimize güvenmek, dayanışmak istiyoruz...</p>
                            <p>Savaşa sürüklenmekten, çatışmacı ortamdan, nefret dilinden, hukuk ihlallerinden, haklarımızın özgürlüğümüzün kısıtlanmasından, can ve mal güvenliğimizden, toplumun vicdanını yitirmesinden, ahlâk aşınmasından, toplumsal duyarsızlıktan endişe duyuyoruz.  </p>
                            <p>Tek adam rejimi ve partili devlete, adaletsizlik ve hukuksuzluğa, meclisin etkisizleştirilmesine, </p>
                            <p>her çeşit muhalefetin baskı ve tehditle sindirilmesine karşıyız.</p>
                            <p>Yüzbinlerle kamu çalışanını, siyasetçiyi, akademisyeni, medya, yargı ve güvenlik mensuplarını haksız, hukuksuz keyfî uygulamalarla, tutuklamalarla, baskılarla tasfiye eden despotik siyasetin yarattığı bütün mağduriyetlere hayır diyoruz!</p>
                            <p>
                                <strong style="font-weight: 600; margin-bottom: 10px; font-size: 22px; line-height: normal; letter-spacing: normal;">Geleceğimizi karartan bu anlayışı anayasallaştırmaya çalışan referandumun şaibeli sonuçlarını ve halk iradesinin yasalar yok sayılarak açıkça çiğnenmesini kabul etmiyoruz.
                                </strong>
                            </p>
                            <h3 style="font-weight: 600; margin-bottom: 10px; font-size: 24px; line-height: normal; letter-spacing: normal;">Birarada güven içinde yaşamak için, acilen:</h3>
                            <ul>
                                <li>Hukuk ihlallerine yol açan OHAL’in kaldırılmasını,  </li>
                                <li>Toplumun tümüne yayılan mağduriyetlere karşı adalet ve hukuk güvenliğinin sağlanmasını, </li>
                                <li>Meclisin yasama ve denetleme yetkisinin güçlendirilerek iadesini, </li>
                                <li>Hesap veren, anayasal, şeffaf devlet için kararlı adımlar atılmasını, </li>
                                <li>Gizli oy ve şeffaf sayım temelli sandık güvenliğinin sağlanmasını istiyoruz. </li>
                            </ul>

                            <h3 style="font-weight: 600; margin-bottom: 10px; font-size: 24px; line-height: normal; letter-spacing: normal;">Korku, gerilim ve kutuplaştırma siyasetinden güç devşirenlere karşı; 
                                ülkemizin geleceğinden sorumlu tüm yurttaşları, farklı kanaat önderlerini, 
                                sivil girişimleri, siyasi partileri güç birliğine çağırıyoruz!
                            </h3>

                            <ul>
                                <li>Adaletli, hakkaniyetli, tarafsız ve bağımsız yargı ilkesine dayalı <em>“hukuk devleti”</em>nin,</li>
                                <li>Bireysel ve toplumsal insan haklarını tam uygulayan eşitlikçi,  çoğulcu demokrasi anlayışının, </li>
                                <li>Başta yerel yönetimlerde olmak üzere katılımcılığı teşvik edecek bir idari yapının, </li>
                                <li>İdeolojik dayatmacı, cinsiyetçi, ayrımcı olmayan; özerk ve eleştirel düşünceye dayalı bir eğitim sisteminin, </li>
                                <li>Bölge halkları ve dünya ülkeleriyle eşit haklı işbirliğini gözeten barışçı bir siyasetin, egemen kılınması için,
                                    <h2 style="margin-top: 10px; font-size: 34px; font-weight: 600;">güçlerimizi ortaklaştırmaya çağırıyoruz...</h2>
                                </li>
                            </ul>
                        </div>
                        <div style="float: left; width: 100%; border: 1px solid #e0e0e0; padding: 20px; border-radius: 5px; box-shadow: 2px 1px 6px #e0e0e0;" id="get_imza">
                            <div class="pl0 col-md-12 imzala">
                                <h3 class="imzala_h3">Bu kampanyayı imzala 
                                    <span class="imzacount_kampanya">şu anda 
                                    <span style="font-family: 'Kanit', sans-serif;">1460</span>
                                        &nbsp;kişi imzalamıştır,
                                    <br />
                                        <strong style="font-family: 'Kanit', sans-serif; font-weight: bold; font-size: 51px; color: #25addd;">HEDEF 10.000 İMZA</strong>
                                    </span>
                                </h3>
                                <div class="progress mb10">
                                    <div class="progress-bar" role="progressbar" aria-valuemin="0" aria-valuemax="100" style="width: 100%">
                                        <span></span>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6 col-sm-6 col-xs-12 pr15 pl5 " style="float: right;">
                                <div class="btn_imzala_area">
                                    <span data-toggle="modal" data-target="#login_area">İMZALA</span>
                                    <div id="login_area" class="modal fade" role="dialog">
                                        <div class="modal-dialog">

                                            <div class="modal-content  col-md-12">
                                                <div class="modal-header  col-md-12">
                                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                    <%if (string.IsNullOrEmpty(Session["dt0"] + ""))
                                                        { %>
                                                    <h4 class="modal-title">Giriş Yap</h4>
                                                    <%}
                                                        else
                                                        {%>
                                                    <h3 class="modal-title" style="font-weight: 400; font-family: 'PT Sans', sans-serif !important;">Bildiriyi başarılı bir şekilde imzaladınız dilerseniz imzalama nedeninizi belirtebilirsiniz</h3>
                                                    <% } %>
                                                </div>
                                                <%if (string.IsNullOrEmpty(Session["dt0"] + ""))
                                                    { %>
                                                <div class="modal-body  col-md-12">

                                                    <span class="facebook_button_area col-md-6 pr5 pl5">
                                                        <asp:Button ID="btnFacebookBaglan" runat="server" Text=" Facebook  ile imzala" CssClass="presbtn" OnClick="btnFacebookBaglan_Click" />
                                                    </span>

                                                    <span class="twitter_button_area col-md-6 pr5 pl5">
                                                        <asp:Button ID="btnTwitterLogin" runat="server" Text=" Twitter ile imzala" CssClass="presbtn" OnClick="btnTwitterLogin_Click" />
                                                    </span>
                                                    <div id="maillog" class="modal-title col-md-6 pr5 pl5">
                                                        <div class="pressbtn" onclick="$('.onimzamail').css('display')=='block'?$('.onimzamail').css('display', 'none'):$('.onimzamail').css('display', 'block');">E-mail ile imzala</div>
                                                    </div>
                                                    <script>
                                                        var googleUser = {};
                                                        var startApp = function () {
                                                            gapi.load('auth2', function () {
                                                                //google login için app code
                                                                auth2 = gapi.auth2.init({
                                                                    client_id: '320925940419-qb9fkb86vpeje7nbbmaodh9bstkvcs3g.apps.googleusercontent.com',
                                                                    cookiepolicy: 'single_host_origin',
                                                                });
                                                                attachSignin(document.getElementById('customBtn'));
                                                            });
                                                        };
                                                        function attachSignin(element) {
                                                            auth2.attachClickHandler(element, {},
                                                                function (googleUser) {
                                                                    var data = {};
                                                                    data.id = googleUser.El;
                                                                    data.img = googleUser.w3.Paa;
                                                                    data.email = googleUser.w3.U3;
                                                                    data.name = googleUser.w3.ig;
                                                                    $.ajax({
                                                                        type: 'post',
                                                                        data: JSON.stringify(data),
                                                                        contentType: 'application/json',
                                                                        url: '/Default.aspx/googlecheck',
                                                                        success: function (data) {
                                                                            window.location.href = "/Default.aspx";
                                                                        }
                                                                    });
                                                                }, function (error) {
                                                                    window.location.href = "/Default.aspx";
                                                                });
                                                        }
                                                    </script>
                                                    <script>startApp();</script>
                                                    <div id="gSignInWrapper" class="col-md-6 pr5 pl5">
                                                        <div id="customBtn" class="customGPlusSignIn">
                                                            <span><span class="icon"></span>Gmail ile giriş yap</span>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12 pr5 pl5">
                                                        <div id="create_modal_body">

                                                            <div class="onimzamail" style="display: none;">
                                                                <label for="modal_name_create" class="col-md-6 pr5 pl5">
                                                                    <input id="modal_name_create" placeholder="Adınızı giriniz..." required="required" type="text" />
                                                                </label>
                                                                <label for="modal_surname_create" class="col-md-6 pr5 pl5">
                                                                    <input id="modal_surname_create" placeholder="Soyadınızı giriniz..." type="text" required="required" />
                                                                </label>
                                                                <label for="modal_phone_create" class="col-md-6 pr5 pl5">
                                                                    <input id="modal_phone_create" placeholder="05 (xxx) xx xx" type="text" onkeypress='return event.charCode >= 48 && event.charCode <= 57' />
                                                                </label>
                                                                <label for="modal_email_create" class="col-md-6 pr5 pl5">

                                                                    <input id="modal_email_create" placeholder="Mail adresinizi giriniz..." type="text" required="required" />
                                                                </label>
                                                                <div class="col-md-12" id="g-area">
                                                                    <div class="g-recaptcha" data-sitekey="6LedpRITAAAAAEM920UdXnlgtJhjkO7QYkKGdiZk" style="z-index: 9999;"></div>
                                                                </div>
                                                                <div class="login_hide form-control mt5">
                                                                    <input type="button" value="İmzalamak İçin Tıklayınız" class="login_hide_input_btn" id="kayitol" />
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>

                                                </div>
                                                <%} %>
                                                <div class="modal-body  col-md-12">
                                                    <%if (!string.IsNullOrEmpty(Session["dt0"] + ""))
                                                        { %>
                                                    <div id="status" class="col-md-12 pr0 pl0">

                                                        <div class="user_only col-md-5">
                                                            <span class="owner-img fl" style="background-image: url('<%=Session["dt7"]%>');"></span>
                                                            <span class="owner-name"><span><%=Session["dt1"]%></span><br />
                                                                <span class="owner-location"><%=Session["dt2"]%></span>
                                                            </span>
                                                        </div>
                                                        <%if (string.IsNullOrEmpty(Session["dtimza"] + "") && string.IsNullOrEmpty(Session["imzabirkere"] + ""))
                                                            { %>
                                                        <div class="col-md-6 fr p0 m0 fr">
                                                            <textarea class="textareawow" aria-label="İmzalıyorum Çünkü..." placeholder="İmzalıyorum Çünkü..."><%=Session["dtimza"] %></textarea>
                                                            <input type="button" class="presbtn" id="imzalabtn" data-id="<%=Session["dt0"]%>" value="GÖNDER" />
                                                        </div>
                                                        <%}
                                                            else
                                                            {%>
                                                        <%if (!string.IsNullOrEmpty(Session["dtimza"] + "") && string.IsNullOrEmpty(Session["imzabirkere"] + ""))
                                                            { %>
                                                        <div class="col-md-6 fr p0 m0 fr">
                                                            <div class="textareawow" aria-label="İmzalıyorum Çünkü..."><%=Session["dtimza"] %></div>
                                                        </div>
                                                        <%}%>
                                                        <%}%>

                                                        <div class="col-md-12 pr0 pl0 text-center mt30">
                                                            <div style="font-size: 24px; font-weight: 300; color: #444; border-bottom: 1px solid; width: 275px; margin: 0 auto; float: none;">Paylaş ve destek ol</div>
                                                            <div class="col-md-4">
                                                                <div class="fb-share-button"
                                                                    data-href="http://www.yanyanayiz.com/Default.aspx"
                                                                    data-layout="button_count"
                                                                    style="margin: 15px 0 0; float: left; width: 100%; line-height: .8;">
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4">
                                                                <div style="background: #ffffff; border-radius: 5px; border: 1px solid #eeeeee; margin: 20px auto 0; height: 30px; float: none; width: 90px; line-height: .2;">
                                                                    <a href="https://twitter.com/intent/tweet?hashtags=yanyanayiz&amp;original_referer=http://www.yanyanayiz.com/Default.aspx&amp;ref_src=http://www.yanyanayiz.com/Default.aspx&amp;related=http://www.yanyanayiz.com/Default.aspx&amp;text=yeniden hep beraber&amp;tw_p=tweetbutton&amp;url=http://www.yanyanayiz.com/Default.aspx&amp;">
                                                                        <span style="font-size: 14px;"><i class="fa fa-twitter"></i>Paylaş</span>
                                                                    </a>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-4 googleplus">
                                                                <div class="g-plus" data-action="share" data-height="30" data-href="http://www.yanyanayiz.com/Default.aspx"></div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                    <%} %>
                                                </div>
                                                <div class="modal-footer col-md-12 pt0">
                                                    <div class="col-md-12 text-center logout">
                                                        <span id="usernamesurname"><%=Session["dt1"]+"" %></span>
                                                        <asp:Button Text="" OnClick="logout_Click" ID="logout" runat="server" />
                                                        <a href="/oneriformu.aspx">Öneri ve Görüşlerinizi Bize Bildirin. </a>
                                                        <script>
                                                            $(document).ready(function () {
                                                                $(".logout > input").val($(".logout > span").text() + " değilseniz çıkış yapmak için tıklayınız");
                                                            });
                                                        </script>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="girisyapilmis col-md-6 col-sm-6 col-xs-12 pr5 pl0">
                                <div class="col-md-12 pr0 pl0 text-center">
                                    <div style="font-size: 18px; font-weight: 600; color: #444; text-decoration: underline;">Paylaş ve destek ol</div>
                                    <div class="col-md-4 p10">
                                        <div class="fb-share-button"
                                            data-href="http://www.yanyanayiz.com/Default.aspx"
                                            data-layout="button_count">
                                        </div>
                                    </div>
                                    <div class="col-md-4 p10">
                                        <div style="background: #ffffff; border-radius: 5px; border: 1px solid #eeeeee">
                                            <a href="https://twitter.com/intent/tweet?hashtags=yanyanayiz&amp;original_referer=http://www.yanyanayiz.com/Default.aspx&amp;ref_src=http://www.yanyanayiz.com/Default.aspx&amp;related=http://www.yanyanayiz.com/Default.aspx&amp;text=yeniden hep beraber&amp;tw_p=tweetbutton&amp;url=http://www.yanyanayiz.com/Default.aspx&amp;">
                                                <span style="font-size: 14px;"><i class="fa fa-twitter"></i>Paylaş</span>
                                            </a>
                                        </div>
                                    </div>
                                    <div class="col-md-4 p10">
                                        <div class="g-plus" data-action="share" data-height="24" data-href="http://www.yanyanayiz.com/Default.aspx"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12 text-center mt15 mobilfl mobilWFull">
                                <a href="/oneriformu.aspx">Öneri ve Görüşlerinizi Bize Bildirin. </a>
                            </div>
                        </div>
                        <div id="imzalayanlar" class="col-md-12 pr0 pl0">
                            <h3 id="imzalayanlari_h3">İMZALAYANLAR
                                <span style="text-align: right; float: right; font-size: 18px;">
                                    <span class="gosterarea">
                                        <span class="gosterclass">
                                            <i class="gosterup" aria-hidden="true"></i>
                                            <span>Göster</span>
                                        </span>
                                        <span class="gizleclass" style="display: none;">
                                            <i class="gosterdown" aria-hidden="true"></i>
                                            <span>Gizle</span>
                                        </span>
                                    </span>
                                </span>
                            </h3>
                            <div id="imzalayanlar_allimza" class="col-md-12 pr0 pl0 mt10" style="display: none;">
                            </div>
                        </div>
                        <div id="imzalamasebebleri" class="col-md-12 pr0 pl0">
                            <h3 id="imzalayanlaricontent_h3">İMZALIYORUM ÇÜNKÜ;
                                  <span style="text-align: right; float: right; font-size: 18px;">
                                      <span class="gosterarea">
                                          <span class="gosterclass">
                                              <i class="gosterup" aria-hidden="true"></i>
                                              <span>Göster</span>
                                          </span>
                                          <span class="gizleclass" style="display: none;">
                                              <i class="gosterdown" aria-hidden="true"></i>
                                              <span>Gizle</span>
                                          </span>
                                      </span>
                                  </span>
                            </h3>
                            <div id="allimza" class="col-md-12 pr0 pl0 mt10" style="display: none;">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%if (!string.IsNullOrEmpty(Session["dt0"] + ""))
            { %>
        <script>
            $(document).ready(function () {
                window.location.href = "/Default.aspx#get_imza";
                $(".btn_imzala_area > span").trigger("click");
            });
        </script>
        <%}%>

        <script src="scripts/site.js"></script>
    </div>
</asp:Content>

