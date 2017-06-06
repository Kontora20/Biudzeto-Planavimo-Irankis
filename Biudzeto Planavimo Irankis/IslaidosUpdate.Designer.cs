namespace Biudzeto_Planavimo_Irankis
{
    partial class IslaidosUpdate
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSuma = new System.Windows.Forms.TextBox();
            this.txtPavadinimas = new System.Windows.Forms.TextBox();
            this.cmbMenesiai = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnIssaugoti = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Suma";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pavadinimas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mėnesis";
            // 
            // txtSuma
            // 
            this.txtSuma.Location = new System.Drawing.Point(105, 53);
            this.txtSuma.Name = "txtSuma";
            this.txtSuma.Size = new System.Drawing.Size(130, 20);
            this.txtSuma.TabIndex = 3;
            // 
            // txtPavadinimas
            // 
            this.txtPavadinimas.Location = new System.Drawing.Point(105, 83);
            this.txtPavadinimas.Name = "txtPavadinimas";
            this.txtPavadinimas.Size = new System.Drawing.Size(130, 20);
            this.txtPavadinimas.TabIndex = 4;
            // 
            // cmbMenesiai
            // 
            this.cmbMenesiai.FormattingEnabled = true;
            this.cmbMenesiai.Items.AddRange(new object[] {
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
            this.cmbMenesiai.Location = new System.Drawing.Point(105, 113);
            this.cmbMenesiai.Name = "cmbMenesiai";
            this.cmbMenesiai.Size = new System.Drawing.Size(130, 21);
            this.cmbMenesiai.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label4.Location = new System.Drawing.Point(48, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Įveskite naujus duomenis";
            // 
            // btnIssaugoti
            // 
            this.btnIssaugoti.Location = new System.Drawing.Point(76, 166);
            this.btnIssaugoti.Name = "btnIssaugoti";
            this.btnIssaugoti.Size = new System.Drawing.Size(128, 23);
            this.btnIssaugoti.TabIndex = 7;
            this.btnIssaugoti.Text = "Išsaugoti pakeitimus";
            this.btnIssaugoti.UseVisualStyleBackColor = true;
            this.btnIssaugoti.Click += new System.EventHandler(this.btnIssaugoti_Click);
            // 
            // IslaidosUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 272);
            this.Controls.Add(this.btnIssaugoti);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbMenesiai);
            this.Controls.Add(this.txtPavadinimas);
            this.Controls.Add(this.txtSuma);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "IslaidosUpdate";
            this.Text = "IslaidosUpdate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSuma;
        private System.Windows.Forms.TextBox txtPavadinimas;
        private System.Windows.Forms.ComboBox cmbMenesiai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnIssaugoti;
    }
}