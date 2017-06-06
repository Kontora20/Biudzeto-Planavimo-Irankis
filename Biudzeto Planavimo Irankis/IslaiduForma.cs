using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Biudzeto_Planavimo_Irankis
{
    public partial class FormIslaidos : Form
    {
        string connString;


        public FormIslaidos()
        {
            InitializeComponent();
            connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Arnas\Documents\visual studio 2015\Projects\Biudzeto Planavimo Irankis\Biudzeto Planavimo Irankis\BiudzetoDatabase.mdf ; Integrated Security = True";
            PopulateVartotojai();
        }
        private void PopulateVartotojai()
        {
            SqlConnection connection = new SqlConnection(connString);
            try
            {
                connection.Open();
                DataTable vartotojaiTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Vartotojai", connection);

                adapter.Fill(vartotojaiTable);
                cmbVartotojai.DisplayMember = "Vardas";
                cmbVartotojai.ValueMember = "ID";
                cmbVartotojai.DataSource = vartotojaiTable;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void buttonPrideti_Click(object sender, EventArgs e)
        {
            connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Arnas\Documents\visual studio 2015\Projects\Biudzeto Planavimo Irankis\Biudzeto Planavimo Irankis\BiudzetoDatabase.mdf ; Integrated Security = True";

            SqlConnection connection = new SqlConnection(connString);

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT into Islaidos values (@VartotojoID, @Suma, @Pavadinimas, @Menesis)", connection);
                cmd.Parameters.AddWithValue("@VartotojoID", cmbVartotojai.SelectedValue);
                cmd.Parameters.AddWithValue("@Suma", Convert.ToDecimal(txtSuma.Text));
                cmd.Parameters.AddWithValue("@Pavadinimas", txtPav.Text);
                cmd.Parameters.AddWithValue("@Menesis", cmbMenesis.Text);
                cmd.ExecuteNonQuery();
                                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                connection.Close();
                MessageBox.Show("Įrašas sėkmingai pridėtas");
            }
        }

    }
}
