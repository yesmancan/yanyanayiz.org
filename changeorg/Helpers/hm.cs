using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace changeorg.Helpers
{
    public class hm
    {
        public static SqlConnection connect()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["cs"];
            string connection = settings.ConnectionString;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connection);

            builder.DataSource = "";
            builder.InitialCatalog = "";
            builder.UserID = "";
            builder.Password = "";

            return new SqlConnection(builder.ConnectionString);

        }
        public hm()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string sortVer(string sortNe)
        {
            if (sortNe == ListSortDirection.Descending.ToString())
                return " DESC";
            else
                return " ASC";
        }
        public static bool IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        public static DataTable sSelect(string sorgu)
        {

            SqlConnection conn = new SqlConnection(@"");
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(sorgu, conn);
            DataTable dt = new DataTable();

            da.Fill(dt);
            da.Dispose();
            conn.Close();
            return dt;
        }
        public static void sExec(string sorgu)
        {
            SqlConnection conn = new SqlConnection(@"");
            conn.Open();
            SqlCommand da = new SqlCommand(sorgu, conn);
            da.ExecuteNonQuery();
            da.Dispose();
            conn.Close();
        }
        private static void openCon()
        {
            if (connect().State == ConnectionState.Closed)
            {
                connect().Open();
            }
        }
        public static string tarihVer(DateTime date)
        {
            string nDate = date.ToString("yyyyMMdd");
            return nDate;
        }
        public static string ConvertSqlDate(DateTime date)
        {
            string d = date.ToString("dd");
            string m = date.ToString("MM");
            string y = date.Year.ToString();
            string time = date.TimeOfDay.ToString();
            return (y + "-" + m + "-" + d + time).ToString();
        }
        public static string mTarihVer(DateTime date)
        {
            string ndate = date.ToString("yyyyMMdd HH:mm:ss");
            return ndate;
        }
        public static string sqlSafe(string metin)
        {
            string tmpDuz = metin;
            if (tmpDuz == null) { tmpDuz = ""; }
            string finalDuz = tmpDuz.Replace("'", "''");
            finalDuz = finalDuz.Replace("=", "");
            return finalDuz;
        }
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
                strBuilder.Append(result[i].ToString("x2"));

            return strBuilder.ToString();
        }
        public static bool IsValid(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public static string StripHTML(string input)
        {
            return System.Text.RegularExpressions.Regex.Replace(input, "<.*?>", String.Empty);
        }
    }

}