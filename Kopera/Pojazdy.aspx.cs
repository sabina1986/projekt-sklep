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
            //PanelPojazdy.Controls.Add(new LiteralControl("<head>"));

            /*PanelPojazdy.Controls.Add(new LiteralControl("<script type=\"text/javascript\" src=\"http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js\"></script>"
                +"<script>!window.jQuery && document.write('<script src=\"Scripts/jquery.fancybox-1.3.4/jquery-1.4.3.min.js\"></script>');</script>"+
                "<script type=\"text/javascript\" src=\"Scripts/jquery.fancybox-1.3.4/fancybox/jquery.mousewheel-3.0.4.pack.js\"></script>" +
                "<script type=\"text/javascript\" src=\"Scripts/jquery.fancybox-1.3.4/fancybox/jquery.fancybox-1.3.4.pack.js\"></script>" +
                "<link rel=\"stylesheet\" type=\"text/css\" href=\"Scripts/jquery.fancybox-1.3.4/fancybox/jquery.fancybox-1.3.4.css\" media=\"screen\" />" +
                "<link rel=\"stylesheet\" href=\"Scripts/jquery.fancybox-1.3.4/style.css\" />"));

            PanelPojazdy.Controls.Add(new LiteralControl("<script type=\"text/javascript\">" +
            "$(document).ready(function() {" +

            "$(\"a#example1\").fancybox();" +

            "$(\"a#example2\").fancybox({" +
            "	'overlayShow'	: false," +
            "	'transitionIn'	: 'elastic'," +
            "	'transitionOut'	: 'elastic'" +
            "});"+
            "$(\"a[rel=example_group]\").fancybox({"+
			"	'transitionIn'		: 'none',"+
			"	'transitionOut'		: 'none',"+
			"	'titlePosition' 	: 'over',"+
			"	'titleFormat'		: function(title, currentArray, currentIndex, currentOpts) {"+
			"		return '<span id=\"fancybox-title-over\">Image ' + (currentIndex + 1) + ' / ' + currentArray.length + (title.length ? ' &nbsp; ' + title : '') + '</span>';"+
			"	}"+
			"});"+
            "</script>"));

            //PanelPojazdy.Controls.Add(new LiteralControl("</head><body>"));
      
      PanelPojazdy.Controls.Add(new LiteralControl("<div id=\"content\">"+
	"<p> Different animations<br />"+

		"<a id=\"example1\" href=\"Scripts/jquery.fancybox-1.3.4/example/1_b.jpg\"><img alt=\"example1\" src=\"Scripts/jquery.fancybox-1.3.4/example/1_s.jpg\" /></a>"+
        
     "</p>"+
     
     "<p> Image gallery (ps, try using mouse scroll wheel)<br />"+
	 "<a rel=\"example_group\" href=\"Scripts/jquery.fancybox-1.3.4/example/9_b.jpg\" title=\"Lorem ipsum dolor sit amet\"><img alt=\"\" src=\"Scripts/jquery.fancybox-1.3.4/example/9_s.jpg\" /></a>"+
     "<a rel=\"example_group\" href=\"Scripts/jquery.fancybox-1.3.4/example/10_b.jpg\" title=\"\"><img alt=\"\" src=\"Scripts/jquery.fancybox-1.3.4/example/10_s.jpg\" /></a>"+
	 "<a rel=\"example_group\" href=\"Scripts/jquery.fancybox-1.3.4/example/11_b.jpg\" title=\"\"><img alt=\"\" src=\"Scripts/jquery.fancybox-1.3.4/example/11_s.jpg\" /></a>"+
	 "<a rel=\"example_group\" href=\"Scripts/jquery.fancybox-1.3.4/example/12_b.jpg\" title=\"\"><img class=\"last\" alt=\"\" src=\"Scripts/jquery.fancybox-1.3.4/example/12_s.jpg\" /></a>"+
	"</p>"     
     ));*/

            PanelPojazdy.Controls.Add(new LiteralControl("<script type=\"text/javascript\">"+
                "function wielkosc(typ, zdjecie) {"+
                "if (typ == 1) {"+
                    "zdjecie.width = \"600\";"+
                    "zdjecie.height = \"500\";"+
                    "zdjecie.onclick = 'wielkosc(0, this)';"+
                    "zdjecie.id = 'aa';"+
                    "document.getElementById(\"bb\").width = \"300\";"+
                    "document.getElementById(\"bb\").height = \"210\";"+
                    "zdjecie.id = 'bb';"+
                "}"+
                "else {"+
                    "zdjecie.width = \"300\";"+
                    "zdjecie.height = \"210\";"+
                    "zdjecie.onclick = 'wielkosc(1, this)';"+
                "}"+ 
            "}"+
        "</script>")); 

            Label labelOpis;
            Label labelCena;
            Image image;

           

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

                for (int j = 0; j < nameFile.Count; ++j)
                {
                    image = new Image();
                    image.ID = "image" + i + "" + j;

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
                        image.ImageUrl = sciezka;
                        image.AlternateText = "cos zezarlo obraz";
                        PanelPojazdy.Controls.Add( new LiteralControl("<img src=\"" + sciezka + "\" id=\"bb\" width=\"300\" height=\"210\" onclick=\"wielkosc(1, this)\" style =\"cursor:hand\">"));
                    }
                    else
                    {
                        image.AlternateText = "cos zezarlo obraz";
                    }

                    image.Width = 395;
                    image.Height = 350;
                    if (j % 2 == 0)
                    {
                        PanelPojazdy.Controls.Add(new LiteralControl("<br/><br/>"));
                        
                    }
                    
                    PanelPojazdy.Controls.Add(image);
                    PanelPojazdy.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;"));
                    
                }
                PanelPojazdy.Controls.Add(new LiteralControl("<br/><br/>"));
                PanelPojazdy.Controls.Add(new LiteralControl("<table border=\"1\" width=\"98%\">"));
                PanelPojazdy.Controls.Add(new LiteralControl("<tr>"));
                PanelPojazdy.Controls.Add(new LiteralControl("<td>"));
                PanelPojazdy.Controls.Add(labelOpis);
                PanelPojazdy.Controls.Add(new LiteralControl("</td>"));
                PanelPojazdy.Controls.Add(new LiteralControl("</tr>"));
                PanelPojazdy.Controls.Add(new LiteralControl("<tr>"));
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