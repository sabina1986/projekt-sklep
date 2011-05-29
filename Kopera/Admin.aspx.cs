using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Kopera
{
    public partial class Admin : System.Web.UI.Page
    {
        static string kategoriaPub = null;
        static string KategoriaTabelaFoto;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonDodaj_Click(object sender, EventArgs e)
        {
            PanelDodaj.Visible = true;
            PanelUsun.Visible = false;
            ButtonDodajZdjecie.Visible = false;
            FileUploadZdjecie.Visible = false;

            


        }

        protected void ButtonUsun_Click(object sender, EventArgs e)
        {
            PanelDodaj.Visible = false;
            PanelUsun.Visible = true;
           
        }

        protected void WczytajDoUsuniecia()
        {
            string kategoria = kategoriaPub;

            if (kategoria != null)
            {
                //string connectionString = "Data Source='KACZMARZ-EB27C1\\SQLEXPRESS';Integrated Security=True;Pooling=False;Initial Catalog='Kopera'";
                //SqlConnection objSqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                string connectionString="Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Kopera.mdf;Integrated Security=True;User Instance=True";
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                /*SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string sqlQuery = "delete from foto where id_foto = 'Pojazd_3';";
                cmd.CommandText = sqlQuery;
                cmd.ExecuteScalar();
                conn.Close();*/

                SqlCommand cmd = new SqlCommand("Select id, opis, cena, foto from " + kategoria + ";", conn);
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
            WczytajDoUsuniecia();
        }

        protected void ButtonDodajZdjecie_Click(object sender, EventArgs e)
        {
            //string connectionString = "Data Source='KACZMARZ-EB27C1\\SQLEXPRESS'; Integrated Security=True; Pooling=False; Initial Catalog='Kopera';";
            string connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Kopera.mdf;Integrated Security=True;User Instance=True";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

           
            string Kategoria = ListBoxKategoriaDodaj.SelectedItem.Text;
            string sqlQuery = "Insert into Foto (id_foto, name) values(@id_foto, @name)";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection= conn;
            cmd.CommandText=sqlQuery;

            cmd.Parameters.AddWithValue("@id_foto",KategoriaTabelaFoto);
            cmd.Parameters.AddWithValue("@name",FileUploadZdjecie.FileName);
            cmd.ExecuteScalar();
            conn.Close();

            string nameFile = FileUploadZdjecie.FileName;
            //FileUploadZdjecie.PostedFile.SaveAs(Server.MapPath("~/"+Kategoria+"/"+nameFile));
            FileUploadZdjecie.SaveAs(Server.MapPath("~/" + Kategoria + "/" + nameFile));


        }

        protected void ButtonAkceptuj_Click(object sender, EventArgs e)
        {
           
            if (ListBoxKategoriaDodaj.SelectedItem==null)
            {
                labelKategoria.Text = "Wybierz Kategorie!!!";
            }
            else
            {
                labelKategoria.Text = "";
                //string connectionString = "Data Source='KACZMARZ-EB27C1\\SQLEXPRESS'; Integrated Security=True; Pooling=False; Initial Catalog='Kopera'";
                string connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Kopera.mdf;Integrated Security=True;User Instance=True";
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                string Kategoria = ListBoxKategoriaDodaj.SelectedItem.Text;
                string sqlQuery_id = "select max(id) from " + Kategoria + ";";
                string sqlQuery = "insert into " + Kategoria + "(opis, cena, foto) values(@opis, @cena, @foto)";
                string sqlRows = "select count(*) from " + Kategoria + ";";

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = conn;
                
                cmd.CommandText = sqlRows;
                int id = (int)cmd.ExecuteScalar();
                id = id + 1;

                cmd.CommandText = sqlRows;

                int rows = (int)cmd.ExecuteScalar();
                string id_foto = Kategoria + "_" + rows+"_"+id;
                KategoriaTabelaFoto = id_foto;

                cmd.CommandText = sqlQuery;

                //cmd.Parameters.AddWithValue("@id", 1);
                cmd.Parameters.AddWithValue("@opis", TextBoxOpis.Text);
                cmd.Parameters.AddWithValue("@cena", Double.Parse(TextBoxCena.Text));
                cmd.Parameters.AddWithValue("foto", id_foto);

                cmd.ExecuteScalar();
                conn.Close();
                ButtonDodajZdjecie.Visible = true;
                FileUploadZdjecie.Visible = true;
                              
                
            }
           
        }

        protected void GridViewKategoria_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            
            int row = e.NewSelectedIndex;
            TableCellCollection zm = GridViewKategoria.Rows[row].Cells;
            TableCell id_t = zm[0];
            TableCell foto_t = zm[3];
            string id = id_t.Text;
            string id_foto = foto_t.Text;

            //string connectionString = "Data Source='KACZMARZ-EB27C1\\SQLEXPRESS'; Integrated Security=True; Pooling=False; Initial Catalog='Kopera'";
            string connectionString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Kopera.mdf;Integrated Security=True;User Instance=True";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string Kategoria = ListBoxKategoriaUsun.SelectedItem.Text;
            string sqlQuery = "delete from " + Kategoria + " where id=" + id;
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = conn;
            cmd.CommandText = sqlQuery;
            cmd.ExecuteScalar();

            
            sqlQuery = "select name from Foto where id_foto =  '" + id_foto + "';";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlQuery, connectionString);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds, "Foto");
            DataTable dt = ds.Tables["Foto"];

            for(int i=0; i<dt.Rows.Count; ++i)
            {

                object[] nameFile = dt.Rows[i].ItemArray;
                                
                File.Delete(Server.MapPath("~/" + Kategoria + "/" + (string)nameFile[0]));
            }

            sqlQuery = "delete from foto where id_foto = '"+id_foto+"';";
            cmd.CommandText = sqlQuery;
            cmd.ExecuteScalar();

            conn.Close();

            WczytajDoUsuniecia();
           
               

        }

        
        

        
    }
}