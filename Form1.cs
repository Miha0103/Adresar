using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;



namespace adresar
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=adresar;Integrated Security=True");
        SqlDataReader dr;
        SqlCommand cmd;
        SqlDataAdapter adapter;
       

        private Kontakt[] adresar = new Kontakt[1];



        public Form1()
        {
            InitializeComponent();


        }


       

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            Kontakt obj = new Kontakt();
            obj.Ime = txtIme.Text;
            obj.Prezime = txtPrezime.Text;
            obj.Broj = txtBroj.Text;
            obj.Id = txtId.Text;

            SqlConnection ss = new SqlConnection("Data Source=.;Initial Catalog=adresar;Integrated Security=True");

            ss.Open();

            SqlDataAdapter aa = new SqlDataAdapter("KorisniciInset", ss);
            aa.SelectCommand.CommandType = CommandType.StoredProcedure;
            aa.SelectCommand.Parameters.Add("@ime", SqlDbType.VarChar, (50)).Value = txtIme.Text;
            aa.SelectCommand.Parameters.Add("@prezime", SqlDbType.VarChar, (50)).Value = txtPrezime.Text;
            aa.SelectCommand.Parameters.Add("@broj_telefona", SqlDbType.VarChar, (50)).Value = txtBroj.Text;
            aa.SelectCommand.Parameters.Add("@id", SqlDbType.VarChar, (50)).Value = txtId.Text;
            aa.SelectCommand.ExecuteNonQuery();
            ss.Close();
            MessageBox.Show("Uspesno ste uneli novi kontakt");

        }



        private void Form1_Load(object sender, EventArgs e)
        {



        }

    
       
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtIme.Text = "";
            this.txtBroj.Text = "";
            this.txtPrezime.Text = "";
            this.txtId.Text = "";
            MessageBox.Show("Uspesno ste resetovali polja.");
        }

        private void btnPrikazi_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select * from Nemanja";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lstKontakti.Items.Add(dr["Id"]);
                lstKontakti.Items.Add(dr["Ime"]);
                lstKontakti.Items.Add(dr["Prezime"]);
                lstKontakti.Items.Add(dr["Broj_telefona"]);
            }
            con.Close();
        }

        private void Obrisi(string id, string ime, string prezime, string broj)
        {
            String sql = "DELETE FROM Nemanja WHERE Id='" + id + "',Prezime+'" + prezime + "',Broj_telefona='" + broj + "',ime='" + ime + "'";
            cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                adapter = new SqlDataAdapter(cmd);
                adapter.DeleteCommand = con.CreateCommand();
                adapter.DeleteCommand.CommandText = sql;

                if (MessageBox.Show("Sigurni ste?", "Obrisi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult)
                {
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        txtId.Text = "";
                        txtIme.Text = "";
                        txtPrezime.Text = "";
                        txtBroj.Text = "";
                        MessageBox.Show("Uspesno su obrisani");
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            string id = lstKontakti.SelectedItem.ToString();
            string ime = lstKontakti.SelectedItem.ToString();
            string prezime = lstKontakti.SelectedItem.ToString();
            string broj = lstKontakti.SelectedItem.ToString();
            Obrisi(id, ime, prezime, broj);

        }





        private void update(string id,string novoPrezime,string novibroj_telefona,string novoIme)
        {
            string sql = "Update Nemanja SET Ime='" + novoIme + "',Prezime='" + novoPrezime + "',Broj_telefona='" + novibroj_telefona + "' WHERE Id='" + id + "'";
            cmd = new SqlCommand(sql, con);
            
            try
            {
                con.Open();
                adapter = new SqlDataAdapter(cmd);
                adapter.UpdateCommand = con.CreateCommand();
                adapter.UpdateCommand.CommandText = sql;
                if(adapter.UpdateCommand.ExecuteNonQuery()>0)
                {
                    txtIme.Text = "";
                    MessageBox.Show("Uspesno");
                }
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

      

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String id = lstKontakti.SelectedItem.ToString();
            string novoIme = txtIme.Text;
            string novoPrezime = txtPrezime.Text;
            string novibroj_telefona = txtBroj.Text;

            update(id,novoPrezime,novibroj_telefona, novoIme);
        }

        private void txtBroj_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char chr = e.KeyChar;
            if (!Char.IsDigit(chr) && chr != 8)
            {
                e.Handled = true;
                MessageBox.Show("Unesite ispravan broj telefona");
            }
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void txtIme_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBroj_TextChanged(object sender, KeyPressEventArgs e)
        {
           
        }

        private void lstKontakti_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}

