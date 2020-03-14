namespace cSharpIntroWinForms
{
    partial class GodineStudijaForm
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
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.cbAktivna = new System.Windows.Forms.CheckBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.dgvGodinaStudja = new System.Windows.Forms.DataGridView();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aktivna1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Ukloni = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGodinaStudja)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(32, 33);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(309, 22);
            this.txtNaziv.TabIndex = 1;
            // 
            // cbAktivna
            // 
            this.cbAktivna.AutoSize = true;
            this.cbAktivna.Location = new System.Drawing.Point(363, 35);
            this.cbAktivna.Name = "cbAktivna";
            this.cbAktivna.Size = new System.Drawing.Size(76, 21);
            this.cbAktivna.TabIndex = 2;
            this.cbAktivna.Text = "Aktivna";
            this.cbAktivna.UseVisualStyleBackColor = true;
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(466, 28);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(107, 33);
            this.btnSacuvaj.TabIndex = 3;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnSacuvaj_Click);
            // 
            // dgvGodinaStudja
            // 
            this.dgvGodinaStudja.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGodinaStudja.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGodinaStudja.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Naziv,
            this.Aktivna1,
            this.Ukloni});
            this.dgvGodinaStudja.Location = new System.Drawing.Point(32, 67);
            this.dgvGodinaStudja.Name = "dgvGodinaStudja";
            this.dgvGodinaStudja.ReadOnly = true;
            this.dgvGodinaStudja.RowHeadersWidth = 51;
            this.dgvGodinaStudja.RowTemplate.Height = 24;
            this.dgvGodinaStudja.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGodinaStudja.Size = new System.Drawing.Size(541, 250);
            this.dgvGodinaStudja.TabIndex = 4;
            this.dgvGodinaStudja.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvGodinaStudja_CellContentClick);
            this.dgvGodinaStudja.DoubleClick += new System.EventHandler(this.DgvGodinaStudja_DoubleClick);
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.MinimumWidth = 6;
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // Aktivna1
            // 
            this.Aktivna1.DataPropertyName = "Aktivna";
            this.Aktivna1.HeaderText = "Aktivna";
            this.Aktivna1.MinimumWidth = 6;
            this.Aktivna1.Name = "Aktivna1";
            this.Aktivna1.ReadOnly = true;
            this.Aktivna1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Aktivna1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Ukloni
            // 
            this.Ukloni.HeaderText = "Ukloni";
            this.Ukloni.MinimumWidth = 6;
            this.Ukloni.Name = "Ukloni";
            this.Ukloni.ReadOnly = true;
            this.Ukloni.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ukloni.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Ukloni.Text = "Ukloni";
            this.Ukloni.UseColumnTextForButtonValue = true;
            // 
            // GodineStudijaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 329);
            this.Controls.Add(this.dgvGodinaStudja);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.cbAktivna);
            this.Controls.Add(this.txtNaziv);
            this.Name = "GodineStudijaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GodineStudijaForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGodinaStudja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.CheckBox cbAktivna;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.DataGridView dgvGodinaStudja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Aktivna1;
        private System.Windows.Forms.DataGridViewButtonColumn Ukloni;
    }
}