using System;
using System.Data;
using changeorg.Helpers;
using System.Web.Services;
using System.Web;
using ASPSnippets.TwitterAPI;
using DotNetOpenAuth;
using DotNetOpenAuth.OpenId.RelyingParty;


namespace changeorg
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        FacebookIslemleri Face = new FacebookIslemleri();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Session["dt0"] + ""))
                logout.Visible = false;

            if (!String.IsNullOrEmpty(Request.QueryString["code"] + ""))
                check();

            if (!String.IsNullOrEmpty(Session["dt0"] + ""))
                loaded();

            if (!String.IsNullOrEmpty(Session["T_ses"] + ""))
                twittercheck();

        }
        protected void btnFacebookBaglan_Click(object sender, EventArgs e)
        {
            var Link = Face.CrateLoginUrl().ToString();
            Response.Redirect(Link);
        }
        protected void loaded()
        {
            DataTable dt = hm.sSelect("select * from users where USER_ID=" + Session["dt0"] + "");
            if (dt.Rows.Count > 0)
            {
                sesionclear();
                for (int i = 0; i < dt.Columns.Count; i++)
                    Session["dt" + i] = dt.Rows[0][i];

                DataTable dtimza = hm.sSelect("select IMZA_CONTENT from imza where USER_ID=" + Session["dt0"] + "");
                if (dtimza.Rows.Count > 0)
                {
                    Session["imzabirkere"] = null;
                    Session["dtimza"] = hm.StripHTML(hm.sqlSafe(dtimza.Rows[0][0] + ""));
                }

            }
        }
        protected void check()
        {
            try
            {

                string code = Request.QueryString["code"], state = "", type = "";
                dynamic token = Face.GetAccessToken(code, state, type);
                FacebookProfil Profil = Face.GetUserInfo(token);
                Session.Add("Profil", Profil);

                //  Profil.EMail;
                //  Profil.ID;
                //  Profil.KullaniciAdi;
                //  Profil.ProfilResmi;
                //  Profil.Konum

                DataTable dt = hm.sSelect("select * from users where USER_FACEBOOK_ID=" + Profil.ID + "");
                if (dt.Rows.Count > 0)
                {
                    sesionclear();
                    for (int i = 0; i < dt.Columns.Count; i++)
                        Session["dt" + i] = dt.Rows[0][i];

                    DataTable dtimza = hm.sSelect("select IMZA_CONTENT from imza where USER_ID=" + Profil.ID + "");
                    if (dtimza.Rows.Count > 0)
                    {
                        Session["imzabirkere"] = null;
                        Session["dtimza"] = hm.StripHTML(hm.sqlSafe(dtimza.Rows[0][0] + ""));
                    }

                    Response.Redirect("/Default.aspx");
                }
                else
                {
                    string sorgu = "insert into users(USER_NAME,USER_LOCATION,USER_FACEBOOK_ID,USER_EMAIL,USER_PIC) " +
                       "values('" + Profil.KullaniciAdi + "', '" + Profil.Konum + "', '" + Profil.ID + "', '" + Profil.EMail + "','" + Profil.ProfilResmi + "') ";

                    hm.sExec(sorgu);
                }
            }
            catch (Exception)
            {
                Response.Redirect("/Default.aspx");
            }
        }
        protected void twittercheck()
        {
           
            TwitterConnect.API_Key = "";
            TwitterConnect.API_Secret = "";

            if (TwitterConnect.IsAuthorized)
            {
                TwitterConnect twitter = new TwitterConnect();
                //LoggedIn User Twitter Profile Details
                DataTable dt_T = twitter.FetchProfile();
                string t_img = dt_T.Rows[0]["profile_image_url"] + "", t_name = dt_T.Rows[0]["name"] + "", t_id = dt_T.Rows[0]["id"] + "", t_location = dt_T.Rows[0]["location"] + "";

                DataTable dt = hm.sSelect("select * from users where USER_TWITTER_ID=" + hm.sqlSafe(t_id) + "");
                if (dt.Rows.Count > 0)
                {
                    sesionclear();

                    for (int i = 0; i < dt.Columns.Count; i++)
                        Session["dt" + i] = dt.Rows[0][i];

                    DataTable dtimza = hm.sSelect("select IMZA_CONTENT from imza where USER_ID=" + hm.sqlSafe(t_id) + "");
                    if (dtimza.Rows.Count > 0)
                    {
                        Session["imzabirkere"] = null;
                        Session["dtimza"] = hm.StripHTML(hm.sqlSafe(dtimza.Rows[0][0] + ""));
                    }

                    Response.Redirect("/Default.aspx");
                }
                else
                {
                    string sorgu = "insert into users(USER_NAME,USER_LOCATION,USER_TWITTER_ID,USER_EMAIL,USER_PIC) " +
                       "values('" + hm.sqlSafe(t_name) + "', '" + hm.sqlSafe(t_location) + "', '" + hm.sqlSafe(t_id) + "', '','" + hm.sqlSafe(t_img) + "') ";
                    hm.sExec(sorgu);

                    dt = hm.sSelect("select * from users where USER_TWITTER_ID=" + hm.sqlSafe(t_id) + "");
                    for (int i = 0; i < dt.Columns.Count; i++)
                        Session["dt" + i] = dt.Rows[0][i];

                    Response.Redirect("/Default.aspx");
                }
            }
            if (TwitterConnect.IsDenied)
                ClientScript.RegisterStartupScript(this.GetType(), "key", "alert('Kullanıcı giriş reddildi.')", true);

        }
        [WebMethod(EnableSession = true)]
        public static string googlecheck(string id, string img, string email, string name)
        {
            try
            {
                sesionclear();
                DataTable dt = hm.sSelect("select * from users where USER_GOOGLE_ID=" + hm.sqlSafe(id) + "");
                if (dt.Rows.Count > 0)
                {
                    sesionclear();

                    for (int i = 0; i < dt.Columns.Count; i++)
                        HttpContext.Current.Session["dt" + i] = dt.Rows[0][i];

                    DataTable dtimza = hm.sSelect("select IMZA_CONTENT from imza where USER_ID=" + hm.sqlSafe(id) + "");
                    if (dtimza.Rows.Count > 0)
                        HttpContext.Current.Session["dtimza"] = hm.StripHTML(hm.sqlSafe(dtimza.Rows[0][0] + ""));
                }
                else
                {
                    string sorgu = "insert into users(USER_NAME,USER_LOCATION,USER_GOOGLE_ID,USER_EMAIL,USER_PIC) " +
                       "values('" + hm.sqlSafe(name) + "', 'Türkiye', '" + hm.sqlSafe(id) + "', '" + hm.sqlSafe(email) + "','" + hm.sqlSafe(img) + "') ";

                    hm.sExec(sorgu);
                }
                return img + "(#%#%#)" + name;
            }
            catch (Exception)
            {
                return "";
            }
        }
        protected void btnTwitterLogin_Click(object sender, EventArgs e)
        {
            if (!TwitterConnect.IsAuthorized)
            {
                sesionclear();
                TwitterConnect twitter = new TwitterConnect();
                Session["T_ses"] = true;
                twittercheck();
                twitter.Authorize(Request.Url.AbsoluteUri.Split('?')[0]);
            }
            else
                twittercheck();
        }
        [WebMethod(EnableSession = true)]
        public static string imzasave(string id, string context)
        {
            try
            {
                string sorgu = "";
                DataTable dtuser = hm.sSelect("select USER_ID,USER_NAME,USER_LOCATION from users where USER_ID=" + hm.sqlSafe(id) + "");
                DataTable dt = hm.sSelect("select USER_ID,IMZA_NAME from imza where USER_ID=" + hm.sqlSafe(id) + "");

                if (dt.Rows.Count > 0)
                {
                    HttpContext.Current.Session["imzabirkere"] = null;
                    return "Her kullanıcı bir kere imzalıyabilir!!!";
                }
                else
                {
                    string location = (string.IsNullOrWhiteSpace(hm.StripHTML(hm.sqlSafe(dtuser.Rows[0]["USER_LOCATION"] + ""))) ? "Türkiye" : hm.StripHTML(hm.sqlSafe(dtuser.Rows[0]["USER_LOCATION"] + "")));

                    sorgu = "insert into imza (USER_ID,IMZA_CONTENT,IMZA_DATE,IMZA_NAME,IMZA_LOCATION) values('" + hm.sqlSafe(id) + "',N'" + hm.StripHTML(hm.sqlSafe(context)) + "',CONVERT(VARCHAR(19),GETDATE(),120),N'" + hm.StripHTML(hm.sqlSafe(dtuser.Rows[0]["USER_NAME"] + "")) + "',N'" + location + "')";
                    HttpContext.Current.Session["imzabirkere"] = "1";
                    hm.sExec(sorgu);
                }
                imzacontentload();
                imzausernameload();
                return hm.StripHTML(hm.sqlSafe(context));
            }
            catch (Exception)
            {
                return "Bir hata oluştu :( :(";
            }
        }
        [WebMethod(EnableSession = true)]
        public static string imzaload()
        {
            try
            {
                DataTable dt = hm.sSelect("select USER_ID from users");
                return dt.Rows.Count + "";
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static string imzacontent = "";
        [WebMethod]
        public static string imzacontentload()
        {
            try
            {
                imzacontent = "";
                DataTable dtimza = hm.sSelect("select USER_ID,IMZA_CONTENT,IMZA_DATE,IMZA_NAME,IMZA_LOCATION from imza order by IMZA_NAME ASC");
                if (dtimza.Rows.Count > 0)
                {
                    for (int i = 0; i < dtimza.Rows.Count; i++)
                    {
                        if (!String.IsNullOrWhiteSpace(dtimza.Rows[i]["IMZA_CONTENT"] + ""))
                        {
                            imzacontent += "<div class='col-md-12 brbottom pr0 pl0' id='" + (dtimza.Rows[i]["USER_ID"] + "") + "'>" +
                                        "<div class='icerik'>" + hm.StripHTML(hm.sqlSafe(dtimza.Rows[i]["IMZA_CONTENT"] + "")) + "</div>" +
                                        "<div class='imzasahibi'>" +
                                        "<span class='imzaadi'>" + hm.StripHTML(hm.sqlSafe(dtimza.Rows[i]["IMZA_NAME"] + "")) + "</span>," +
                                        "<span class='imzayeri'>" + hm.StripHTML(hm.sqlSafe(dtimza.Rows[i]["IMZA_LOCATION"] + "")) + "</span></div>" +
                                        "<span class='imzatarih'>" + hm.StripHTML(hm.sqlSafe(dtimza.Rows[i]["IMZA_DATE"] + "")) + "</span></div>" +
                                        "<div class='col-md-12'><hr style='display: block;float: left;width: 100%;margin-top: 20px;' /></div>";
                        }
                    }
                    return imzacontent;
                }
                else
                    return imzacontent;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static string imzalayanlar = "";
        [WebMethod]
        public static string imzausernameload()
        {
            try
            {
                imzalayanlar = "";
                DataTable dtimzaname = hm.sSelect("select USER_NAME from users order by USER_NAME ASC");
                if (dtimzaname.Rows.Count > 0)
                {
                    for (int i = 0; i < dtimzaname.Rows.Count; i++)
                        imzalayanlar += "<div class='imzasahibi'><span class='imzaadi'>" + hm.StripHTML(hm.sqlSafe(dtimzaname.Rows[i]["USER_NAME"] + "")) + "</span></div>";
                }
                return imzalayanlar;
            }
            catch (Exception)
            {
                return "";
            }
        }
        [WebMethod]
        public static string usercreate(string name, string phone, string email, string responseValue)
        {
            try
            {
                string EncodedResponse = hm.sqlSafe(responseValue);
                bool checkout = true;
                bool IsCaptchaValid = (ReCaptchaClass.Validate(EncodedResponse) == "True" ? true : false);

                checkout = (IsCaptchaValid == true ? true : false);
                if (checkout == false) return "false(#%#%#)Lütfen reCAPTCHA'yi doldurunuz. !!!";

                checkout = (!string.IsNullOrWhiteSpace(hm.sqlSafe(name)) && !string.IsNullOrWhiteSpace(hm.sqlSafe(email)));
                if (checkout == false) return "false(#%#%#)Telefon harici boş geçilemez !!!";

                checkout = (hm.IsValid(hm.sqlSafe(email + "").ToString()) == true);
                if (checkout == false) return "false(#%#%#)Email adresiniz geçersizdir !!!";


                DataTable dtemail = hm.sSelect("select USER_EMAIL from users where USER_EMAIL = '" + hm.sqlSafe(email) + "'");
                if (dtemail.Rows.Count == 0)
                {
                    hm.sExec("insert into users(USER_NAME,USER_EMAIL,USER_PHONE,USER_LOCATION) values('" + hm.sqlSafe(name) + "','" + hm.sqlSafe(email) + "', '" + hm.sqlSafe(phone) + "','Türkiye')");

                    DataTable dt = hm.sSelect("select top 1 * from users where USER_EMAIL='" + hm.sqlSafe(email + "") + "' order by USER_ID asc ");
                    HttpContext.Current.Session["dt0"] = hm.sqlSafe(dt.Rows[0]["USER_ID"] + "");
                    HttpContext.Current.Session["dt1"] = hm.sqlSafe(dt.Rows[0]["USER_NAME"] + "");
                    HttpContext.Current.Session["dt2"] = "Türkiye";
                    HttpContext.Current.Session["dt5"] = hm.sqlSafe(dt.Rows[0]["USER_EMAIL"] + "");
                    HttpContext.Current.Session["dt7"] = "/img/default_profile_normal.png";
                    return "true(#%#%#)Kullanıcı kaydı oluşturulmuştur.";
                }
                else
                    return "false(#%#%#)E-Mail başka bir kullanıcı tarafından alınmıştır.Eğer bir yanlışlık olduğunu düşünüyorsanız lütfen bizimle iletişime geçiniz.";

            }
            catch (Exception)
            {
                return "false(#%#%#)Bir hata oluştu !!!";
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            var Link = Face.CreateLogOuturl().ToString();
            Session["dt0"] = null;
            logout.Visible = false;
        }
        public static void sesionclear()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}