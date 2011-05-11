using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace Kopera
{
    public partial class Admin : System.Web.UI.Page
    {
        static string kategoriaPub = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonDodaj_Click(object sender, EventArgs e)
        {
            PanelDodaj.Visible = true;
            PanelUsun.Visible = false;
        }

        protected void ButtonUsun_Click(object sender, EventArgs e)
        {
            PanelDodaj.Visible = false;
            PanelUsun.Visible = true;
            string kategoria = kategoriaPub;

            if (kategoria != null)
            {
                string connectionString="Data Source='KACZMARZ-EB27C1\\SQLEXPRESS';Integrated Security=True;Pooling=False;Initial Catalog='Kopera'";
                //SqlConnection objSqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("Select id, opis, cena, foto from " + kategoria+";", conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                GridViewKategoria.DataSource = dt;
                GridViewKategoria.DataBind();
                //Page_Load(sender, e);
                GridViewKategoria.Visible = true;

            }
            else
            {
                GridViewKategoria.Visible = false;
            }
        }

        protected void ListBoxKategoriaUsun_SelectedIndexChanged(object sender, EventArgs e)
        {
            kategoriaPub = ListBoxKategoriaUsun.SelectedItem.Value;
        }
    }
}