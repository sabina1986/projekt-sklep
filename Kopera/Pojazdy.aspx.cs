using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;

namespace Kopera
{
    public partial class Pojazdy : System.Web.UI.Page
    {
        public string connectionString="Data Source='KACZMARZ-EB27C1\\SQLEXPRESS';Integrated Security=True;Pooling=False;Initial Catalog='Kopera'";
        public static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadPojazdy();
            DodajKontrolki();
        }
        

        private void DodajKontrolki()
        {
            Label labelOpis;
            Label labelCena;
            Image image;

            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                labelOpis = new Label();
                labelCena = new Label();
                image = new Image();

                labelOpis.ID = "labelOpis"+i;
                labelCena.ID = "labelcena"+i;
                image.ID = "image"+i;
                object[] table = dt.Rows[i].ItemArray;
                labelOpis.Text = (string)table[1];
                labelCena.Text = table[2].ToString();
                string nazwaPliku = (string)table[3];
                string sciezka = Server.MapPath("~/Pojazdy/" + nazwaPliku);
                FileInfo file = new FileInfo(sciezka);
                if (file.Exists)
                {
                    image.ImageUrl = sciezka;
                    image.AlternateText = "cos zezarlo obraz";
                }
                else
                {
                    image.AlternateText = "cos zezarlo obraz";
                }

                PanelPojazdy.Controls.Add(new LiteralControl("<br/><br/>"));
                PanelPojazdy.Controls.Add(image);
                PanelPojazdy.Controls.Add(new LiteralControl("<br/><br/>"));
                PanelPojazdy.Controls.Add(new LiteralControl("<br/><br/>"));
                PanelPojazdy.Controls.Add(labelOpis);
                PanelPojazdy.Controls.Add(new LiteralControl("<br/><br/>"));
                PanelPojazdy.Controls.Add(labelCena);
                PanelPojazdy.Controls.Add(new LiteralControl("<br/><br/>"));
                PanelPojazdy.Controls.Add(new LiteralControl("<br/><br/>"));
            }
        }


        private void LoadPojazdy()
        {
            string commandString = "SELECT * FROM Pojazdy";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(commandString, connectionString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "Pojazdy");
            dt = ds.Tables["Pojazdy"];
        }
    }
}