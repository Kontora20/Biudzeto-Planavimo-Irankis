using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace Biudzeto_Planavimo_Irankis
{
    public partial class Form1 : Form
    {
        string connString;

        public Form1()
        {
            InitializeComponent();
            /* Norint kad veiktu kitame kompiuteryje, reikia pakeisti connString direktorija*/
            connString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Arnas\Documents\Visual Studio 2015\Projects\Biudzeto Planavimo Irankis\Biudzeto Planavimo Irankis\BiudzetoDatabase.mdf ; Integrated Security = True";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateVartotojai();
        }

        // FUNCKIJOS DUOMENIMS APDOROTI ---------------------------------------------------------------

        private void PopulateIslaidos()
        {
            string query = "SELECT a.Suma FROM Islaidos a " +
                "INNER JOIN Vartotojai b ON a.VartotojoID = b.ID " +
                "WHERE a.VartotojoID = @ID";

            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", listVartotojai.SelectedValue);
            try
            {
                connection.Open();
                DataTable islaidosTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(islaidosTable);
                listBoxIslaidos.DisplayMember = "Suma";
                listBoxIslaidos.ValueMember = "Suma";
                listBoxIslaidos.DataSource = islaidosTable;

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

        // ---------------------------------KITA FUNKCIJA-----------------------------------------------------

        private void PopulateBalansas()
        {
            string query = "SELECT a.Suma FROM Balansas a " +
                "INNER JOIN Vartotojai b ON a.VartotojoID = b.ID " +
                "WHERE a.VartotojoID = @ID";

            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", listVartotojaiInfo.SelectedValue);
            try
            {
                connection.Open();
                DataTable balansasTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(balansasTable);
                listVartotojoBalansas.DisplayMember = "Suma";
                listVartotojoBalansas.ValueMember = "Suma";
                listVartotojoBalansas.DataSource = balansasTable;

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

        // ---------------------------------KITA FUNKCIJA-----------------------------------------------------

        private void PopulateVartotojai()
        {
            SqlConnection connection = new SqlConnection(connString);
            try
            {
                connection.Open();
                DataTable vartotojaiTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Vartotojai", connection);

                adapter.Fill(vartotojaiTable);
                listVartotojai.DisplayMember = "Vardas";
                listVartotojai.ValueMember = "ID";
                listVartotojai.DataSource = vartotojaiTable;

                listVartotojaiIplaukos.DisplayMember = "Vardas";
                listVartotojaiIplaukos.ValueMember = "ID";
                listVartotojaiIplaukos.DataSource = vartotojaiTable;

                listVartotojaiInfo.DisplayMember = "Vardas";
                listVartotojaiInfo.ValueMember = "ID";
                listVartotojaiInfo.DataSource = vartotojaiTable;

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

        // --------------------------------KITA FUNKCIJA------------------------------------------------------------

        private void PopulateIplaukos()
        {
            string query = "SELECT a.Suma FROM Iplaukos a " +
                "INNER JOIN Vartotojai b ON a.VartotojoID = b.ID " +
                "WHERE a.VartotojoID = @ID";

            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", listVartotojaiIplaukos.SelectedValue);
            try
            {
                connection.Open();
                DataTable iplaukosTable = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(iplaukosTable);
                listVartotojoIplaukos.DisplayMember = "Suma";
                listVartotojoIplaukos.ValueMember = "Suma";
                listVartotojoIplaukos.DataSource = iplaukosTable;
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

        // ----------------------------KITA FUNKCIJA-------------------------------------------------------------

        private void MenesioIslaidos()
        {
            string query = "SELECT sum(Suma) as Total FROM Islaidos WHERE Menesis = @pasirinktasMen AND VartotojoID = @pasirinktasID";
            string suma;

            SqlConnection connection = new SqlConnection(connString);

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@pasirinktasMen", cmbMenesiaiIslaidos.Text);
            cmd.Parameters.AddWithValue("@pasirinktasID", Convert.ToInt32(listVartotojai.SelectedValue));

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                if (cmbMenesiaiIslaidos.SelectedItem == null)
                {
                    MessageBox.Show("Pirma pasirinkite mėnesį");
                }
                else
                {
                    suma = Convert.ToString((decimal)cmd.ExecuteScalar());
                    label8.Text = suma.ToString() + " Eu";
                }
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

        // ----------------------------KITA FUNKCIJA----------------------------------------------------------

        private void MenesioIplaukos()
        {
            string query = "SELECT sum(Suma) as Total2 FROM Iplaukos WHERE Menesis = @pasirinktasMen AND VartotojoID = @pasirinktasID";
            string suma;

            SqlConnection connection = new SqlConnection(connString);

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@pasirinktasMen", cmbMenesiaiIplaukos.Text);
            cmd.Parameters.AddWithValue("@pasirinktasID", Convert.ToInt32(listVartotojaiIplaukos.SelectedValue));

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                if (cmbMenesiaiIplaukos.SelectedItem == null)
                {
                    MessageBox.Show("Pirma pasirinkite mėnesį");
                }
                else
                {
                    suma = Convert.ToString((decimal)cmd.ExecuteScalar());
                    label10.Text = suma.ToString() + " Eu";
                }
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

        // ------------------------KITA FUNKCIJA----------------------------------------------------

        private void SkaiciuotiBalansa()
        {

            string query = "SELECT A.SumCol1 - B.SumCol2 as Total " +
            "FROM(SELECT SUM(Suma) SumCol1 from Iplaukos WHERE VartotojoID = @ID and Menesis = @Menesis) A CROSS JOIN " +
            "(SELECT SUM(Suma) SumCol2 from Islaidos WHERE VartotojoID = @ID and Menesis = @Menesis) B";
            string balansas;

            string query2 = "IF NOT EXISTS " +
             "(SELECT VartotojoID FROM Balansas WHERE Menesis = @Menesis AND Suma = @Suma) " +
             "BEGIN " +
             "INSERT Balansas VALUES (@ID, @Menesis, @Suma) " +
             "END; ";

            SqlConnection connection = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlCommand cmd2 = new SqlCommand(query2, connection);
            cmd.Parameters.AddWithValue("@ID", listVartotojaiInfo.SelectedValue);
            cmd.Parameters.AddWithValue("@Menesis", cmbMenesiaiInfo.Text);

            try
            {
                connection.Open();
                if (cmbMenesiaiInfo.SelectedItem == null)
                {
                    MessageBox.Show("Pirma pasirinkite menesi");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    balansas = Convert.ToString((decimal)cmd.ExecuteScalar());
                    label12.Text = "Vartotojo mėnesio balansas " + balansas.ToString() + " Eu";
                    cmd2.Parameters.AddWithValue("@ID", listVartotojaiInfo.SelectedValue);
                    cmd2.Parameters.AddWithValue("@Menesis", cmbMenesiaiInfo.Text);
                    cmd2.Parameters.AddWithValue("@Suma", Convert.ToDecimal(balansas));
                    cmd2.ExecuteNonQuery();

                }
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

        // ------------------------KITA FUNKCIJA----------------------------------------------------

        private void MaxMenIslaida()
        {
            string query = "SELECT max(Suma) as Total FROM Islaidos WHERE Menesis = @pasirinktasMen AND VartotojoID = @pasirinktasID";
            string suma;

            SqlConnection connection = new SqlConnection(connString);

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@pasirinktasMen", cmbMenesiaiIslaidos.Text);
            cmd.Parameters.AddWithValue("@pasirinktasID", Convert.ToInt32(listVartotojai.SelectedValue));

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                if (cmbMenesiaiIslaidos.SelectedItem == null)
                {
                    MessageBox.Show("Pirma pasirinkite mėnesį");
                }
                else
                {
                    suma = Convert.ToString((decimal)cmd.ExecuteScalar());
                    label13.Text = suma.ToString() + " Eu";
                }
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

        // ------------------------KITA FUNKCIJA----------------------------------------------------

        private void MinMenIslaida()
        {
            string query = "SELECT min(Suma) as Total FROM Islaidos WHERE Menesis = @pasirinktasMen AND VartotojoID = @pasirinktasID";
            string suma;

            SqlConnection connection = new SqlConnection(connString);

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@pasirinktasMen", cmbMenesiaiIslaidos.Text);
            cmd.Parameters.AddWithValue("@pasirinktasID", Convert.ToInt32(listVartotojai.SelectedValue));

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                if (cmbMenesiaiIslaidos.SelectedItem == null)
                {
                    MessageBox.Show("Pirma pasirinkite mėnesį");
                }
                else
                {
                    suma = Convert.ToString((decimal)cmd.ExecuteScalar());
                    label14.Text = suma.ToString() + " Eu";
                }
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

        // ------------------------KITA FUNKCIJA----------------------------------------------------

        private void MaxMenIplaukos()
        {
            string query = "SELECT max(Suma) as Total FROM Iplaukos WHERE Menesis = @pasirinktasMen AND VartotojoID = @pasirinktasID";
            string suma;

            SqlConnection connection = new SqlConnection(connString);

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@pasirinktasMen", cmbMenesiaiIplaukos.Text);
            cmd.Parameters.AddWithValue("@pasirinktasID", Convert.ToInt32(listVartotojaiIplaukos.SelectedValue));

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                if (cmbMenesiaiIplaukos.SelectedItem == null)
                {
                    MessageBox.Show("Pirma pasirinkite mėnesį");
                }
                else
                {
                    suma = Convert.ToString((decimal)cmd.ExecuteScalar());
                    label15.Text = suma.ToString() + " Eu";
                }
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

        // ------------------------KITA FUNKCIJA----------------------------------------------------

        private void MinMenIplaukos()
        {
            string query = "SELECT min(Suma) as Total FROM Iplaukos WHERE Menesis = @pasirinktasMen AND VartotojoID = @pasirinktasID";
            string suma;

            SqlConnection connection = new SqlConnection(connString);

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@pasirinktasMen", cmbMenesiaiIplaukos.Text);
            cmd.Parameters.AddWithValue("@pasirinktasID", Convert.ToInt32(listVartotojaiIplaukos.SelectedValue));

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                if (cmbMenesiaiIplaukos.SelectedItem == null)
                {
                    MessageBox.Show("Pirma pasirinkite mėnesį");
                }
                else
                {
                    suma = Convert.ToString((decimal)cmd.ExecuteScalar());
                    label16.Text = suma.ToString() + " Eu";
                }
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

        //
        //FUNKCIJU PABAIGA
        //


        //MYGTUKAI ARBA LISTBOXU PASPAUDIMAI ---------------

        private void listVartotojai_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateIslaidos();
        }

        // ---------------------------------KITAS PASPAUDIMAS--------------        

        private void listBoxIslaidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT Pavadinimas FROM Islaidos WHERE Suma = @AtitinkamaSuma";
            string queryMen = "SELECT Menesis FROM Islaidos WHERE Suma = @AtitinkamaSuma";
            string pavadinimas;
            string pavadinimasMen;
            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand(query, connection);
            SqlCommand commandMen = new SqlCommand(queryMen, connection);
            command.Parameters.AddWithValue("@AtitinkamaSuma", listBoxIslaidos.SelectedValue);
            commandMen.Parameters.AddWithValue("@AtitinkamaSuma", listBoxIslaidos.SelectedValue);


            try
            {
                connection.Open();
                pavadinimas = (string)command.ExecuteScalar();
                textBox1.Text = pavadinimas.ToString();
                pavadinimasMen = (string)commandMen.ExecuteScalar();
                txtIslaidosMenesis.Text = pavadinimasMen.ToString();
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
        //-------------------------KITAS MYGTUKAS-------------------------------------

        private void button1_Click(object sender, EventArgs e)
        {
            FormIslaidos forma = new FormIslaidos();
            forma.Show();
        }

        //-------------------------KITAS PASPAUDIMAS-------------------------------------

        private void listVartotojaiIplaukos_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateIplaukos();
        }

        //-------------------------KITAS PASPAUDIMAS-------------------------------------

        private void listVartotojoIplaukos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT Pavadinimas FROM Iplaukos WHERE Suma = @AtitinkamaSuma";
            string queryMen = "SELECT Menesis FROM Iplaukos WHERE Suma = @AtitinkamaSuma";
            string pavadinimas;
            string pavadinimasMen;
            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand(query, connection);
            SqlCommand commandMen = new SqlCommand(queryMen, connection);
            command.Parameters.AddWithValue("@AtitinkamaSuma", listVartotojoIplaukos.SelectedValue);
            commandMen.Parameters.AddWithValue("@AtitinkamaSuma", listVartotojoIplaukos.SelectedValue);

            try
            {
                connection.Open();
                pavadinimas = (string)command.ExecuteScalar();
                txtIplaukosPav.Text = pavadinimas.ToString();
                pavadinimasMen = (string)commandMen.ExecuteScalar();
                txtIplaukosMenesis.Text = pavadinimasMen.ToString();
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

        //-------------------------KITAS MYGTUKAS-------------------------------------

        private void button2_Click(object sender, EventArgs e)
        {
            IplaukuForma iplaukos = new IplaukuForma();
            iplaukos.Show();
        }

        //-------------------------KITAS MYGTUKAS-------------------------------------

        private void btnIstrintiIslaida_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Islaidos WHERE Suma = @AtitinkamaSuma";
            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AtitinkamaSuma", listBoxIslaidos.SelectedValue);
            try
            {
                if (listBoxIslaidos.Items.Count > 0)
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    PopulateIslaidos();
                    textBox1.Clear();
                    txtIslaidosMenesis.Clear();
                    label8.Hide();
                }
                else
                {
                    MessageBox.Show("Nėra įrašų,kuriuos būtų galima ištrinti");
                }

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

        //-------------------------KITAS MYGTUKAS-------------------------------------

        private void btnIstrintiIplauka_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM Iplaukos WHERE Suma = @AtitinkamaSuma";
            SqlConnection connection = new SqlConnection(connString);
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AtitinkamaSuma", listVartotojoIplaukos.SelectedValue);
            try
            {
                if (listVartotojoIplaukos.Items.Count > 0)
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    PopulateIplaukos();
                    txtIplaukosPav.Clear();
                    txtIplaukosMenesis.Clear();
                    label10.Hide();
                }
                else
                {
                    MessageBox.Show("Nėra įrašų,kuriuos būtų galima ištrinti");
                }

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

        //-------------------------KITAS MYGTUKAS-------------------------------------

        private void btnUpdateIslaidos_Click(object sender, EventArgs e)
        {
            if (listBoxIslaidos.Items.Count > 0)
            {
                IslaidosUpdate islaidosup = new IslaidosUpdate();
                islaidosup.GautiReiksme = textBox1.Text;
                islaidosup.Show();
            }
            else
            {
                MessageBox.Show("Nėra įrašų kuriuos būtų galima redaguoti");
            }
        }

        //-------------------------KITAS MYGTUKAS-------------------------------------

        private void btnUpdateIplaukos_Click(object sender, EventArgs e)
        {
            if (listVartotojoIplaukos.Items.Count > 0)
            {
                IplaukosUpdate iplaukosup = new IplaukosUpdate();
                iplaukosup.GautiReiksme = txtIplaukosPav.Text;
                iplaukosup.Show();
            }
            else
            {
                MessageBox.Show("Nėra įrašų kuriuos būtų galima redaguoti");
            }
        }

        //-------------------------KITAS MYGTUKAS-------------------------------------

        private void btnMenIslaidos_Click(object sender, EventArgs e)
        {
            if (listBoxIslaidos.Items.Count > 0)
            {
                MenesioIslaidos();
            }
            else
            {
                MessageBox.Show("Nėra įrašų iš kurių būtų galima parodyti mėnesio biudžetą");
            }
        }

        //-------------------------KITAS MYGTUKAS-------------------------------------

        private void btnMenesioIplaukos_Click(object sender, EventArgs e)
        {
            if (listVartotojoIplaukos.Items.Count > 0)
            {
                MenesioIplaukos();
            }
            else
            {
                MessageBox.Show("Nėra įrašų iš kurių būtų galima parodyti mėnesio biudžetą");
            }
        }

        //-------------------------KITAS MYGTUKAS-------------------------------------

        private void btnMenBalansas_Click(object sender, EventArgs e)
        {
            SkaiciuotiBalansa();
        }

        //-------------------------KITAS MYGTUKAS-------------------------------------

        private void btnMaxMenIslaida_Click(object sender, EventArgs e)
        {
            MaxMenIslaida();
        }

        //-------------------------KITAS MYGTUKAS-------------------------------------

        private void btnMinMenIslaida_Click(object sender, EventArgs e)
        {
            MinMenIslaida();
        }

        //-------------------------KITAS MYGTUKAS-------------------------------------

        private void MaxMenIplauka_Click(object sender, EventArgs e)
        {
            MaxMenIplaukos();
        }

        //-------------------------KITAS MYGTUKAS-------------------------------------

        private void button3_Click(object sender, EventArgs e)
        {
            MinMenIplaukos();
        }

        //-------------------------KITAS MYGTUKAS-------------------------------------

        private void listVartotojaiInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateBalansas();
        }

        private void listVartotojoBalansas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string queryMen = "SELECT Menesis FROM Balansas WHERE Suma = @AtitinkamaSuma";
            string pavadinimasMen;
            SqlConnection connection = new SqlConnection(connString); 
            SqlCommand commandMen = new SqlCommand(queryMen, connection);
            commandMen.Parameters.AddWithValue("@AtitinkamaSuma", listVartotojoBalansas.SelectedValue);

            try
            {
                connection.Open();
                pavadinimasMen = (string)commandMen.ExecuteScalar();
                txtBalansas.Text = pavadinimasMen.ToString();
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

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}



