using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace changeorg
{
    public class FacebookIslemleri
    {
        string AppID = "";
        string AppSecret = "";

        string CallBackUrl = "http://yanyanayiz.com/Default.aspx";
        /*
         
         Facebook Login için kullanıcıyı Facebook'a yönlendirirsiniz.Daha sonra
         kullanıcı gerekli izinleri verdikten sonra Facebook o kullanıcıyı size
         yeniden yönlendirecektir.CallBackUrl değeri ile Facebook'a, kullanıcı
         izin verdikten ve senle işi bittikten sonra şu adresime yönlendir.
         
         */

        string Scope = "public_profile,email,user_location";
        //, user_birthday, user_hometown, user_website, offline_access, read_stream, publish_stream, read_friendlists
        /*
         
         Kullanıcının hangi bilgilerine ihtiyaç duyduğunuzu Scope ile belirtirsiniz.
         Başka bir deyişle kullanıcının hangi bilgilerine ulaşmak istiyorsanız
         o bilgileri size ulaştıracak anahtar sözcükleri Scope'a yazarsınız.
         
         Tabi kullanıcı onayı olmadan buradaki bilgilerin hiçbirine ulaşım söz
         konusu değildir.
         
        */

        FacebookClient FacebookIslem = new FacebookClient();
        //FacebookClient SDK'nın sağladığı sınıftır.

        public Uri CrateLoginUrl()
        {
            /*
             
             Bu metot da kullanıcıdan Facebook login talebi geldinğinde
             kullanıcıyı yönlendireceğimiz Facebook linkini oluşturuyoruz.
             
             */

            return FacebookIslem.GetLoginUrl(
                                new
                                {
                                    client_id = AppID,
                                    client_secret = AppSecret,
                                    redirect_uri = CallBackUrl,
                                    response_type = "code",
                                    scope = Scope,

                                });
        }
        public Uri CreateLogOuturl()
        {
            return FacebookIslem.GetLogoutUrl(
                                new
                                {
                                    client_id = AppID,
                                    client_secret = AppSecret,
                                    redirect_uri = CallBackUrl,
                                    response_type = "code",
                                    scope = Scope,

                                });
        }
        public dynamic GetAccessToken(string code, string state, string type)
        {
            /*

             AccessToken Facebook'un size verdiği erişim kodudur.OAuth
             konusuna bakarsak ne olduğunu daha iyi anlayabiliriz.
             En kısa tanımla OAuth, kullanıcıların üyesi oldukları
             bir site yada platformun şifresini üye oldukları başka
             bir web sitesi yada platformla paylaşmadan, izin verdiği
             bilgilere diğer site tarafından ulaşılmasını sağlayan
             bir kimlik doğrulama protokolüdür.

             Yani, AccessToken kodu ile istediğimiz kullanıcı bilgilerini
             çekebiliyoruz.Ne de olsa bu kod, kullanıcının istediğimiz
             bilgilerini elde etmemize izin verdiğini gösteriyor.

             */

            dynamic result = FacebookIslem.Post("oauth/access_token",
                                          new
                                          {
                                              client_id = AppID,
                                              client_secret = AppSecret,
                                              redirect_uri = CallBackUrl,
                                              code = code
                                          });
            return result.access_token;
        }

        public FacebookProfil GetUserInfo(dynamic accessToken)
        {
            //Kullanıcı bilgilerini çektiğimiz metod.

            var client = new FacebookClient(accessToken);
            var profile = new FacebookProfil();

            dynamic me = client.Get("/me");
            /*

             "/me" yerine kullanıcının Facebook ID'sini de yazabilirsiniz."me"
             o anki kullanıcıyı temsil etmektedir.Yani değişen birşey yok.

             */


            ///*  Bunlarda ek  */
            //Facebook.JsonObject Gelen = (Facebook.JsonObject)me;
            //for (int i = 0; i < Gelen.Count; i++)
            //{
            //    HttpContext.Current.Response.Write("<br>");
            //    HttpContext.Current.Response.Write(Gelen[i]);
            //}
            ///*  Bunlarda ek  */


            profile.KullaniciAdi = me.name;
            profile.ID = me.id;
            profile.EMail = me.email;
            profile.Konum = me.location;
            profile.ProfilResmi = string.Format("https://graph.facebook.com/{0}/picture", profile.ID);
            return profile;
        }
    }
}