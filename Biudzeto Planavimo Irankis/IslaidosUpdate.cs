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

namespace Biudzeto_Planavimo_Irankis
{
    public partial class IslaidosUpdate : Form
    {        

        string connString;
        string reiksme;

        public string GautiReiksme
        {
            get { return reiksme; }
            set { reiksme = value; }
        }



        public IslaidosUpdate()
        {           
            InitializeComponent();
            connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Arnas\Documents\visual studio 2015\Projects\Biudzeto Planavimo Irankis\Biudzeto Planavimo Irankis\BiudzetoDatabase.mdf ; Integrated Security = True";

        }

        private void btnIssaugoti_Click(object sender, EventArgs e)
        {
            connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Arnas\Documents\visual studio 2015\Projects\Biudzeto Planavimo Irankis\Biudzeto Planavimo Irankis\BiudzetoDatabase.mdf ; Integrated Security = True";
            SqlConnection connection = new SqlConnection(connString);

            try
            {   
                            
                connection.Open();                
                SqlCommand cmd = new SqlCommand("UPDATE Islaidos set Suma = @naujaSuma," +
                    "Pavadinimas = @naujasPavadinimas," +
                    "Menesis = @naujasMenesis " +
                    " WHERE Pavadinimas = @txtPavadinimas" , connection);
                cmd.Parameters.AddWithValue("@naujaSuma", Convert.ToDecimal(txtSuma.Text));
                cmd.Parameters.AddWithValue("@naujasPavadinimas", txtPavadinimas.Text);
                cmd.Parameters.AddWithValue("@naujasMenesis", cmbMenesiai.Text);
                cmd.Parameters.AddWithValue("@txtPavadinimas", reiksme.ToString());
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                connection.Close();
                MessageBox.Show("Įrašas sėkmingai redaguotas");
            }
        }
    }
}
