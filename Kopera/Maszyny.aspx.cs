﻿using System;
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
    public partial class Maszyny : System.Web.UI.Page
    {
        
        //public string connectionString="Data Source='KACZMARZ-EB27C1\\SQLEXPRESS';Integrated Security=True;Pooling=False;Initial Catalog='Kopera'";
        public string connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Kopera.mdf;Integrated Security=True;User Instance=True";
        public static DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {

            LoadMaszyny();
            DodajKontrolki();
        }
        

        private void DodajKontrolki()
        {
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

                List<string> nameFile = LoadNameFotoOpony((string)table[3]);

                PanelMaszyny.Controls.Add(new LiteralControl(
                "<center><div id=\"Maszyny" + i + "\">" +
                "<p>"
                ));

                for (int j = 0; j < nameFile.Count; ++j)
                {
                    //image = new Image();
                    //image.ID = "image" + i + "" + j;

                    string sciezka = Server.MapPath("~/Maszyny/" + nameFile[j]);

                    FileInfo file = new FileInfo(sciezka);
                    if (file.Exists)
                    {
                        //image.ImageUrl = sciezka;
                        //image.AlternateText = "cos zezarlo obraz";
                        PanelMaszyny.Controls.Add(new LiteralControl(
                        "<a rel=\"example_group\" href=" + sciezka + " title=\"Exit (click on thema)\"><img alt=\"\" src=" + sciezka + " width=\"150\" height=\"150\"/></a>"
                        ));
                    }
                    else
                    {
                        //image.AlternateText = "cos zezarlo obraz";
                    }

                    //PanelMaszyny.Controls.Add(new LiteralControl("<br/><br/>"));
                    //PanelMaszyny.Controls.Add(image);
                    //PanelMaszyny.Controls.Add(new LiteralControl("<br/><br/>"));
                }
                PanelMaszyny.Controls.Add(new LiteralControl("</p></div></center><br/>"));

                PanelMaszyny.Controls.Add(new LiteralControl("<table>"));
                PanelMaszyny.Controls.Add(new LiteralControl("<tr>"));
                PanelMaszyny.Controls.Add(new LiteralControl("<td>Opis: "));
                PanelMaszyny.Controls.Add(new LiteralControl("</td>"));
                PanelMaszyny.Controls.Add(new LiteralControl("<td> "));
                PanelMaszyny.Controls.Add(labelOpis);
                PanelMaszyny.Controls.Add(new LiteralControl("</td>"));
                PanelMaszyny.Controls.Add(new LiteralControl("</tr>"));
                PanelMaszyny.Controls.Add(new LiteralControl("<tr>"));
                PanelMaszyny.Controls.Add(new LiteralControl("<td>Cena: "));
                PanelMaszyny.Controls.Add(new LiteralControl("</td>"));
                PanelMaszyny.Controls.Add(new LiteralControl("<td>"));
                PanelMaszyny.Controls.Add(labelCena);
                PanelMaszyny.Controls.Add(new LiteralControl("</td>"));
                PanelMaszyny.Controls.Add(new LiteralControl("</tr>"));
                PanelMaszyny.Controls.Add(new LiteralControl("</table>"));
                PanelMaszyny.Controls.Add(new LiteralControl("<br/><br/>"));
                PanelMaszyny.Controls.Add(new LiteralControl("<br/><br/>"));

                
            }
        }


        private void LoadMaszyny()
        {
            string commandString = "SELECT * FROM Maszyny";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(commandString, connectionString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "Maszyny");
            dt = ds.Tables["Maszyny"];
        }
        private List<string> LoadNameFotoOpony(string id_foto)
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