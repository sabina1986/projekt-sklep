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
        //public string connectionString="Data Source='KACZMARZ-EB27C1\\SQLEXPRESS';Integrated Security=True;Pooling=False;Initial Catalog='Kopera'";

        public string connectionString="Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Kopera.mdf;Integrated Security=True;User Instance=True";

        public static DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadPojazdy();
            DodajKontrolki();
        }
        

        private void DodajKontrolki()
        {
           
            /*PanelPojazdy.Controls.Add(new LiteralControl(
            "<div id=\"main\">"+
            "<p>" +
            "Image gallery (ps, try using mouse scroll wheel)<br />" +
            "<a rel=\"example_group\" href=\"Scripts/jquery/example/9_b.jpg\" title=\"Lorem ipsum dolor sit amet\"><img alt=\"\" src=\"Scripts/jquery/example/9_s.jpg\" /></a>" +
            "<a rel=\"example_group\" href=\"Scripts/jquery/example/10_b.jpg\" title=\"\"><img alt=\"\" src=\"Scripts/jquery/example/10_s.jpg\" /></a>" +
            "<a rel=\"example_group\" href=\"Scripts/jquery/example/11_b.jpg\" title=\"\"><img alt=\"\" src=\"Scripts/jquery/example/11_s.jpg\" /></a>" +
            "<a rel=\"example_group\" href=\"Scripts/jquery/example/11_b.jpg\" title=\"\"><img alt=\"\" src=\"Scripts/jquery/example/11_b.jpg\" width=\"75\" height=\"75\"   /></a>" +
            "<a rel=\"example_group\" href=\"Scripts/jquery/example/12_b.jpg\" title=\"\"><img class=\"last\" alt=\"\" src=\"Scripts/jquery/example/12_s.jpg\" /></a>" +
            "</p>"+
            "</div>"
            ));*/


            Label labelOpis;
            Label labelCena;
            //Image image;

           

            //List<string> nameFile = LoadNameFotoPojazdy(dt[i].);

            for (int i = 0; i < dt.Rows.Count; ++i)
            {
                labelOpis = new Label();
                labelCena = new Label();
                

                labelOpis.ID = "labelOpis"+i;
                labelCena.ID = "labelcena"+i;

                object[] table = dt.Rows[i].ItemArray;
                labelOpis.Text = (string)table[1];
                labelCena.Text = table[2].ToString();

                List<string> nameFile = LoadNameFotoPojazdy((string)table[3]);

                PanelPojazdy.Controls.Add(new LiteralControl(
                "<center><div id=\"Pojazdy"+i+"\">" +
                "<p>" 
                ));

                for (int j = 0; j < nameFile.Count; ++j)
                {
                    //image = new Image();
                    //image.ID = "image" + i + "" + j;

                    //wersja firefoxa
                    //string name = nameFile[j];
                    //string nameExt = name.Substring(0, name.Length - 4) + ".JPEG";
                    //string sciezka = Server.MapPath("~/Pojazdy/" + nameExt);
                    //koniec wersji firefox
                    //string sciezka = Server.MapPath("~/Pojazdy/" + nameFile[j]);
                    string sciezka = Server.MapPath("~\\Pojazdy\\" + nameFile[j]);

                    FileInfo file = new FileInfo(sciezka);
                    if (file.Exists)
                    {
                        PanelPojazdy.Controls.Add(new LiteralControl(
                        "<a rel=\"example_group\" href="+sciezka+" title=\"Exit (click on thema)\"><img alt=\"\" src="+sciezka+" width=\"150\" height=\"150\"/></a>"
                        ));
                        /*PanelPojazdy.Controls.Add(new LiteralControl(
                        "<a id=\"example1\" href="+sciezka+" title=\"Lorem ipsum dolor sit amet\"><img alt=\"\" src="+sciezka+" width=\"75\" height=\"75\"/></a>"
                        ));*/
                        
                        //image.ImageUrl = sciezka;
                        //image.AlternateText = "cos zezarlo obraz";
                        //PanelPojazdy.Controls.Add( new LiteralControl("<img src=\"" + sciezka + "\" id=\"bb\" width=\"300\" height=\"210\" onclick=\"wielkosc(1, this)\" style =\"cursor:hand\">"));

                    }
                    else
                    {
                        //image.AlternateText = "cos zezarlo obraz";
                    }

                    //image.Width = 395;
                    //image.Height = 350;
                    //if (j % 2 == 0)
                    //{
                        //PanelPojazdy.Controls.Add(new LiteralControl("<br/><br/>"));
                        
                    //}
                    
                    //PanelPojazdy.Controls.Add(image);
                    //PanelPojazdy.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;"));
                    
                }
                PanelPojazdy.Controls.Add(new LiteralControl("</p></div></center><br/>"));
                
                PanelPojazdy.Controls.Add(new LiteralControl("<table>"));
                PanelPojazdy.Controls.Add(new LiteralControl("<tr>"));
                PanelPojazdy.Controls.Add(new LiteralControl("<td>Opis: "));
                PanelPojazdy.Controls.Add(new LiteralControl("</td>"));
                PanelPojazdy.Controls.Add(new LiteralControl("<td> "));
                PanelPojazdy.Controls.Add(labelOpis);
                PanelPojazdy.Controls.Add(new LiteralControl("</td>"));
                PanelPojazdy.Controls.Add(new LiteralControl("</tr>"));
                PanelPojazdy.Controls.Add(new LiteralControl("<tr>"));
                PanelPojazdy.Controls.Add(new LiteralControl("<td>Cena: "));
                PanelPojazdy.Controls.Add(new LiteralControl("</td>"));
                PanelPojazdy.Controls.Add(new LiteralControl("<td>"));
                PanelPojazdy.Controls.Add(labelCena);
                PanelPojazdy.Controls.Add(new LiteralControl("</td>"));
                PanelPojazdy.Controls.Add(new LiteralControl("</tr>"));
                PanelPojazdy.Controls.Add(new LiteralControl("</table>"));
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
        private List<string> LoadNameFotoPojazdy(string id_foto)
        {
            List<string> nameFile = new List<string>();
            string sqlQuery = "select name from Foto where id_foto='" + id_foto +"';";
            SqlDataAdapter dataAdapterFoto = new SqlDataAdapter(sqlQuery, connectionString);
            DataSet dsFoto = new DataSet();
            dataAdapterFoto.Fill(dsFoto, "Foto");
            DataTable dtFoto = dsFoto.Tables["Foto"];

            for (int i = 0; i < dtFoto.Rows.Count; ++i)
            {
                object[] name = dtFoto.Rows[i].ItemArray;
                nameFile.Add((string)name[0]);
            }

           return nameFile;
        }
    }
}