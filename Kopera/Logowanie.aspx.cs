using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Kopera
{
    public partial class Logowanie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLoguj_Click(object sender, EventArgs e)
        {
            if (TextBoxLogin.Text != "" && TextBoxHaslo.Text != "")
            {
                //string connectionString = "Data Source='KACZMARZ-EB27C1\\SQLEXPRESS';Integrated Security=True;Pooling=False;Initial Catalog='Kopera'";
                string connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Kopera.mdf;Integrated Security=True;User Instance=True";
                //SqlConnection objSqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                string sqlQuery_Rows = "select count(*) from Login where uzytkownik= '" + TextBoxLogin.Text + "';";
                cmd.Connection = conn;
                cmd.CommandText = sqlQuery_Rows;
                int exist = (int)cmd.ExecuteScalar();

                string haslo = null;

                if (exist != 0)
                {
                    string sqlQuery = "select haslo from Login where uzytkownik= '" + TextBoxLogin.Text + "';";

                    cmd.Connection = conn;
                    cmd.CommandText = sqlQuery;
                    haslo = (string)cmd.ExecuteScalar();
                }
                               

                

                if (haslo == TextBoxHaslo.Text)
                {
                    Response.Redirect("Admin.aspx");
                }
               else
                {
                    LabelOstrzezenie.Text = "Niepoprawny login lub haslo!!!";
                }
            }
            else
            {
                LabelOstrzezenie.Text = "Nie podano loginu lub hasla!!!";
            }

        }
    }
}