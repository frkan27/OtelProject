namespace Otel.WFA
{
    partial class FrmRezervasyon
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
            this.lstOdalar = new System.Windows.Forms.ListBox();
            this.btnRezervasyon = new System.Windows.Forms.Button();
            this.nukisi = new System.Windows.Forms.NumericUpDown();
            this.dtpGiris = new System.Windows.Forms.DateTimePicker();
            this.dtpCikis = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.nukisi)).BeginInit();
            this.SuspendLayout();
            // 
            // lstOdalar
            // 
            this.lstOdalar.FormattingEnabled = true;
            this.lstOdalar.Location = new System.Drawing.Point(12, 31);
            this.lstOdalar.Name = "lstOdalar";
            this.lstOdalar.Size = new System.Drawing.Size(126, 303);
            this.lstOdalar.TabIndex = 0;
            // 
            // btnRezervasyon
            // 
            this.btnRezervasyon.Location = new System.Drawing.Point(168, 109);
            this.btnRezervasyon.Name = "btnRezervasyon";
            this.btnRezervasyon.Size = new System.Drawing.Size(120, 37);
            this.btnRezervasyon.TabIndex = 1;
            this.btnRezervasyon.Text = "Rezervasyon Kaydet";
            this.btnRezervasyon.UseVisualStyleBackColor = true;
            this.btnRezervasyon.Click += new System.EventHandler(this.btnRezervasyon_Click);
            // 
            // nukisi
            // 
            this.nukisi.Location = new System.Drawing.Point(168, 31);
            this.nukisi.Name = "nukisi";
            this.nukisi.Size = new System.Drawing.Size(120, 20);
            this.nukisi.TabIndex = 2;
            // 
            // dtpGiris
            // 
            this.dtpGiris.Location = new System.Drawing.Point(168, 57);
            this.dtpGiris.Name = "dtpGiris";
            this.dtpGiris.Size = new System.Drawing.Size(178, 20);
            this.dtpGiris.TabIndex = 3;
            // 
            // dtpCikis
            // 
            this.dtpCikis.Location = new System.Drawing.Point(168, 83);
            this.dtpCikis.Name = "dtpCikis";
            this.dtpCikis.Size = new System.Drawing.Size(178, 20);
            this.dtpCikis.TabIndex = 4;
            // 
            // FrmRezervasyon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtpCikis);
            this.Controls.Add(this.dtpGiris);
            this.Controls.Add(this.nukisi);
            this.Controls.Add(this.btnRezervasyon);
            this.Controls.Add(this.lstOdalar);
            this.Name = "FrmRezervasyon";
            this.Text = "FrmRezervasyon";
            this.Load += new System.EventHandler(this.FrmRezervasyon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nukisi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstOdalar;
        private System.Windows.Forms.Button btnRezervasyon;
        private System.Windows.Forms.NumericUpDown nukisi;
        private System.Windows.Forms.DateTimePicker dtpGiris;
        private System.Windows.Forms.DateTimePicker dtpCikis;
    }
}