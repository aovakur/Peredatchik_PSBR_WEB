using authWF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Default : Page
    {

        public static string BD { get; set; }
        public static string login { get; set; }
        public static string password { get; set; }

        public static string  access { get; set; }

        protected void Button1_Click(object sender, EventArgs e)
        {
            login = TextBox1.Text;
            BD = "Users";
            password = TextBox2.Text;
            access = GetAccess();

            if (login != null && password != null)
            {
                if (CheckPswd() == password && (access== "Admin" || access == "SuperUser"))
                {
                    Response.Redirect($"/all/WebForm1.aspx?login={login}&mode={access}");
                }

                else
                {
                  Label1.Visible = true;
                  Label1.Text = "Ошибка пароля или логина";
                }
            }

            
        }

        private string CheckPswd()
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conn;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = $"Select Password FROM {BD} WHERE Login='{login}'";
            string passfrombase = Base64Decode(Convert.ToString(sqlCmd.ExecuteScalar()));
            conn.Close();
            return passfrombase;

        }


        private string GetAccess()
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            conn.Open();
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conn;
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = $"Select Accesses FROM {BD} WHERE Login='{login}'";
            string Accesses = Convert.ToString(sqlCmd.ExecuteScalar());
            conn.Close();
            return Accesses;
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}