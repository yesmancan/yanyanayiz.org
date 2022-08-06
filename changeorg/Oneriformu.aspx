<%@ Page Title="" Debug="true" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Oneriformu.aspx.cs" Inherits="changeorg.Oneriformu" EnableEventValidation="true" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h2 id="onerivegorusformu_h1">Öneri ve Görüşlerinizi Bize Bildirin.</h2>
                <div class="col-md-12" id="onerivegorusformu">

                    <div class="col-md-12 pl0 pr0">
                        <span class="col-md-1 pr0 pl0">Ad Soyad 
                            <span style="float: right;" class="pr10 ">:</span></span>
                        <span class="col-md-3 pr0 pl0">
                            <input value="" id="nameandsurname" name="name" type="text" class="form-control" placeholder="Adınız ve soyadınızı giriniz ..." />
                        </span>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-12 pl0 pr0">
                        <span class="col-md-1 pr0 pl0">E-mail 
                            <span style="float: right;" class="pr10 ">:</span></span>
                        <span class="col-md-3 pr0 pl0">
                            <input value="" id="email_contact" name="email" type="text" class="form-control" placeholder="E-mail Adresiniz ..." />
                        </span>
                    </div>
                    <br />
                    <br />
                    <div class="col-md-12 pl0 pr0">
                        <span class="col-md-1 pr0 pl0">Mesajınız 
                            <span style="float: right;" class="pr10 ">:</span></span>
                        <span class="col-md-3 pr0 pl0">
                            <textarea id="seninmesajin" name="icerik" class="form-control" placeholder="Mesajınız...  "></textarea>
                        </span>
                    </div>
                    <br />

                    <div class="col-md-12 btn-area">
                        <div class="g-recaptcha" data-sitekey="6LedpRITAAAAAEM920UdXnlgtJhjkO7QYkKGdiZk" style="z-index: 9999; float: left;"></div>
                        <asp:Button Text="Gönder" runat="server" ID="gonderbtn" OnClick="gonderbtn_Click" />
                        <asp:Label Text="" runat="server" ID="lblmssg" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $.ajax({
                type: 'POST',
                contentType: 'application/json',
                url: '/Default.aspx/imzaload',
                async: true,
                success: function (data) {
                    $('span.imzacount > span').text(data.d);
                }
            });
        });
    </script>
    <style>
        #onerivegorusformu_h1 {
            text-align: left;
            color: #222;
            font-weight: 100;
            text-transform: uppercase;
            padding: 0 10px 5px;
        }

        #onerivegorusformu span {
            color: #222;
            font-weight: 400;
            font-size: 14px;
            padding-bottom: 10px;
        }

        #onerivegorusformu input {
            border: 1px solid #d3d3d3;
            color: #222;
        }

        #onerivegorusformu textarea {
            border: 1px solid #d3d3d3;
            width: 500px;
            height: 235px;
            padding: 10px;
            color: #222;
            font-size: 15px;
        }

        .btn-area > input {
            border: 0 !important;
            border-radius: 3px;
            background-color: #25addd;
            color: #fff !important;
            padding: 10px 25px;
            text-align: center;
            margin: 0 auto;
            display: list-item;
            list-style: none;
            font-size: 18px;
            margin-top: 25px;
        }

        .btn-area > span {
            text-align: center;
            margin: 10px auto 0;
            display: list-item;
            list-style: none;
        }
    </style>
</asp:Content>
