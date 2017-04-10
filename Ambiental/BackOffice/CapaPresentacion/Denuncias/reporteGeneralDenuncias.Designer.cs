namespace CapaPresentacion
{
    partial class reporteGeneralDenuncias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reporteGeneralDenuncias));
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.button5 = new System.Windows.Forms.Button();
            this.grid3 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.combo1 = new System.Windows.Forms.ComboBox();
            this.fFecha = new System.Windows.Forms.Button();
            this.fecha2 = new System.Windows.Forms.DateTimePicker();
            this.distritos = new System.Windows.Forms.ComboBox();
            this.canton = new System.Windows.Forms.ComboBox();
            this.Provincia = new System.Windows.Forms.ComboBox();
            this.hash = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid3)).BeginInit();
            this.SuspendLayout();
            // 
            // fecha
            // 
            this.fecha.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha.Location = new System.Drawing.Point(318, 10);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(141, 27);
            this.fecha.TabIndex = 65;
            // 
            // button5
            // 
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(1090, 15);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(64, 32);
            this.button5.TabIndex = 64;
            this.button5.Text = "Atras";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // grid3
            // 
            this.grid3.AllowUserToAddRows = false;
            this.grid3.AllowUserToDeleteRows = false;
            this.grid3.AllowUserToOrderColumns = true;
            this.grid3.BackgroundColor = System.Drawing.Color.Green;
            this.grid3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.grid3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.grid3.GridColor = System.Drawing.Color.Black;
            this.grid3.Location = new System.Drawing.Point(12, 53);
            this.grid3.Name = "grid3";
            this.grid3.ReadOnly = true;
            this.grid3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid3.Size = new System.Drawing.Size(1126, 539);
            this.grid3.TabIndex = 63;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Titulo";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Descripción";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Fecha";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "UserName";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Provincia";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Canton";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Distrito";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Estado";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "HashTag";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 180;
            // 
            // combo1
            // 
            this.combo1.AutoCompleteCustomSource.AddRange(new string[] {
            "Filtro por Fechas",
            "Filtro por Provincia",
            "Filtro por Canton",
            "Filtro por Distrito",
            "Filtro por Hashtag"});
            this.combo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo1.FormattingEnabled = true;
            this.combo1.Items.AddRange(new object[] {
            "Filtro por Fechas",
            "Filtro por Provincia",
            "Filtro por Canton",
            "Filtro por Distrito",
            "Filtro por HashTag"});
            this.combo1.Location = new System.Drawing.Point(858, 14);
            this.combo1.Name = "combo1";
            this.combo1.Size = new System.Drawing.Size(226, 33);
            this.combo1.TabIndex = 67;
            this.combo1.Text = "Filtros";
            this.combo1.SelectedIndexChanged += new System.EventHandler(this.combo1_SelectedIndexChanged);
            // 
            // fFecha
            // 
            this.fFecha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fFecha.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fFecha.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fFecha.Image = ((System.Drawing.Image)(resources.GetObject("fFecha.Image")));
            this.fFecha.Location = new System.Drawing.Point(634, 10);
            this.fFecha.Name = "fFecha";
            this.fFecha.Size = new System.Drawing.Size(182, 26);
            this.fFecha.TabIndex = 66;
            this.fFecha.Text = "Filtrar por Fecha";
            this.fFecha.UseVisualStyleBackColor = true;
            this.fFecha.Click += new System.EventHandler(this.button1_Click);
            // 
            // fecha2
            // 
            this.fecha2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha2.Location = new System.Drawing.Point(475, 10);
            this.fecha2.Name = "fecha2";
            this.fecha2.Size = new System.Drawing.Size(141, 27);
            this.fecha2.TabIndex = 68;
            // 
            // distritos
            // 
            this.distritos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.distritos.FormattingEnabled = true;
            this.distritos.Location = new System.Drawing.Point(678, 12);
            this.distritos.Name = "distritos";
            this.distritos.Size = new System.Drawing.Size(174, 33);
            this.distritos.TabIndex = 71;
            this.distritos.Text = "Distrito";
            this.distritos.SelectedIndexChanged += new System.EventHandler(this.distritos_SelectedIndexChanged);
            // 
            // canton
            // 
            this.canton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.canton.FormattingEnabled = true;
            this.canton.Location = new System.Drawing.Point(498, 10);
            this.canton.Name = "canton";
            this.canton.Size = new System.Drawing.Size(174, 33);
            this.canton.TabIndex = 70;
            this.canton.Text = "Cantón";
            this.canton.SelectedIndexChanged += new System.EventHandler(this.canton_SelectedIndexChanged);
            // 
            // Provincia
            // 
            this.Provincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Provincia.FormattingEnabled = true;
            this.Provincia.Location = new System.Drawing.Point(318, 9);
            this.Provincia.Name = "Provincia";
            this.Provincia.Size = new System.Drawing.Size(174, 33);
            this.Provincia.TabIndex = 69;
            this.Provincia.Text = "Provincia";
            this.Provincia.SelectedIndexChanged += new System.EventHandler(this.Provincia_SelectedIndexChanged);
            // 
            // hash
            // 
            this.hash.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hash.Location = new System.Drawing.Point(522, 10);
            this.hash.Name = "hash";
            this.hash.Size = new System.Drawing.Size(193, 31);
            this.hash.TabIndex = 72;
            this.hash.TextChanged += new System.EventHandler(this.hash_TextChanged);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label.Location = new System.Drawing.Point(314, 14);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(202, 23);
            this.label.TabIndex = 73;
            this.label.Text = "Digite el HashTag";
            // 
            // reporteGeneralDenuncias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1158, 605);
            this.Controls.Add(this.label);
            this.Controls.Add(this.hash);
            this.Controls.Add(this.distritos);
            this.Controls.Add(this.canton);
            this.Controls.Add(this.Provincia);
            this.Controls.Add(this.fecha2);
            this.Controls.Add(this.combo1);
            this.Controls.Add(this.fFecha);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.grid3);
            this.Name = "reporteGeneralDenuncias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes de Denuncias";
            ((System.ComponentModel.ISupportInitialize)(this.grid3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.Button button5;
        public System.Windows.Forms.DataGridView grid3;
        private System.Windows.Forms.ComboBox combo1;
        private System.Windows.Forms.Button fFecha;
        private System.Windows.Forms.DateTimePicker fecha2;
        private System.Windows.Forms.ComboBox distritos;
        private System.Windows.Forms.ComboBox canton;
        private System.Windows.Forms.ComboBox Provincia;
        private System.Windows.Forms.TextBox hash;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}