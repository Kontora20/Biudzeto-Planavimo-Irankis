namespace Biudzeto_Planavimo_Irankis
{
    partial class IplaukuForma
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbMenesis2 = new System.Windows.Forms.ComboBox();
            this.txtPav2 = new System.Windows.Forms.TextBox();
            this.txtSuma2 = new System.Windows.Forms.TextBox();
            this.cmbVartotojai2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonIplauka = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbMenesis2
            // 
            this.cmbMenesis2.FormattingEnabled = true;
            this.cmbMenesis2.Items.AddRange(new object[] {
            "Sausis",
            "Vasaris",
            "Kovas",
            "Balandis",
            "Geguze",
            "Birzelis",
            "Liepa",
            "Rugpjutis",
            "Rugsejis",
            "Spalis",
            "Lapkritis",
            "Gruodis"});
            this.cmbMenesis2.Location = new System.Drawing.Point(183, 144);
            this.cmbMenesis2.Name = "cmbMenesis2";
            this.cmbMenesis2.Size = new System.Drawing.Size(121, 21);
            this.cmbMenesis2.TabIndex = 18;
            // 
            // txtPav2
            // 
            this.txtPav2.Location = new System.Drawing.Point(183, 109);
            this.txtPav2.Name = "txtPav2";
            this.txtPav2.Size = new System.Drawing.Size(121, 20);
            this.txtPav2.TabIndex = 16;
            // 
            // txtSuma2
            // 
            this.txtSuma2.Location = new System.Drawing.Point(183, 75);
            this.txtSuma2.Name = "txtSuma2";
            this.txtSuma2.Size = new System.Drawing.Size(121, 20);
            this.txtSuma2.TabIndex = 15;
            // 
            // cmbVartotojai2
            // 
            this.cmbVartotojai2.FormattingEnabled = true;
            this.cmbVartotojai2.Location = new System.Drawing.Point(183, 40);
            this.cmbVartotojai2.Name = "cmbVartotojai2";
            this.cmbVartotojai2.Size = new System.Drawing.Size(121, 21);
            this.cmbVartotojai2.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Mėnesis";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Išlaidos pavadinimas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Suma";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Vartotojas";
            // 
            // buttonIplauka
            // 
            this.buttonIplauka.Location = new System.Drawing.Point(78, 190);
            this.buttonIplauka.Name = "buttonIplauka";
            this.buttonIplauka.Size = new System.Drawing.Size(185, 23);
            this.buttonIplauka.TabIndex = 19;
            this.buttonIplauka.Text = "Pridėti";
            this.buttonIplauka.UseVisualStyleBackColor = true;
            this.buttonIplauka.Click += new System.EventHandler(this.buttonIplauka_Click);
            // 
            // IplaukuForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 245);
            this.Controls.Add(this.buttonIplauka);
            this.Controls.Add(this.cmbMenesis2);
            this.Controls.Add(this.txtPav2);
            this.Controls.Add(this.txtSuma2);
            this.Controls.Add(this.cmbVartotojai2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "IplaukuForma";
            this.Text = "Naujas įplaukos įrašas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMenesis2;
        private System.Windows.Forms.TextBox txtPav2;
        private System.Windows.Forms.TextBox txtSuma2;
        private System.Windows.Forms.ComboBox cmbVartotojai2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonIplauka;
    }
}