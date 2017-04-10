namespace CapaPresentacion
{
    partial class gravedadDenuncias
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gravedadDenuncias));
            this.grid3 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fFecha = new System.Windows.Forms.Button();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.fecha2 = new System.Windows.Forms.DateTimePicker();
            this.canton = new System.Windows.Forms.ComboBox();
            this.Provincia = new System.Windows.Forms.ComboBox();
            this.combo1 = new System.Windows.Forms.ComboBox();
            this.distritos = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid3)).BeginInit();
            this.SuspendLayout();
            // 
            // grid3
            // 
            this.grid3.AllowUserToAddRows = false;
            this.grid3.AllowUserToDeleteRows = false;
            this.grid3.AllowUserToOrderColumns = true;
            this.grid3.BackgroundColor = System.Drawing.Color.Green;
            this.grid3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid3.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.grid3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.Column1,
            this.Column2,
            this.Column3});
            this.grid3.GridColor = System.Drawing.Color.Red;
            this.grid3.Location = new System.Drawing.Point(12, 12);
            this.grid3.Name = "grid3";
            this.grid3.ReadOnly = true;
            this.grid3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid3.Size = new System.Drawing.Size(546, 275);
            this.grid3.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn3.FillWeight = 25F;
            this.dataGridViewTextBoxColumn3.Frozen = true;
            this.dataGridViewTextBoxColumn3.HeaderText = "Estado";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Total";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Leve";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Regular";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Grave";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // fFecha
            // 
            this.fFecha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fFecha.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fFecha.Image = ((System.Drawing.Image)(resources.GetObject("fFecha.Image")));
            this.fFecha.Location = new System.Drawing.Point(611, 66);
            this.fFecha.Name = "fFecha";
            this.fFecha.Size = new System.Drawing.Size(203, 42);
            this.fFecha.TabIndex = 13;
            this.fFecha.Text = "Filtro por Fechas";
            this.fFecha.UseVisualStyleBackColor = true;
            this.fFecha.Click += new System.EventHandler(this.button2_Click);
            // 
            // fecha
            // 
            this.fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha.Location = new System.Drawing.Point(564, 114);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(141, 35);
            this.fecha.TabIndex = 47;
            // 
            // fecha2
            // 
            this.fecha2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha2.Location = new System.Drawing.Point(710, 114);
            this.fecha2.Name = "fecha2";
            this.fecha2.Size = new System.Drawing.Size(141, 35);
            this.fecha2.TabIndex = 48;
            // 
            // canton
            // 
            this.canton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.canton.FormattingEnabled = true;
            this.canton.Location = new System.Drawing.Point(630, 90);
            this.canton.Name = "canton";
            this.canton.Size = new System.Drawing.Size(174, 33);
            this.canton.TabIndex = 54;
            this.canton.Text = "Cantón";
            this.canton.SelectedIndexChanged += new System.EventHandler(this.canton_SelectedIndexChanged);
            // 
            // Provincia
            // 
            this.Provincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Provincia.FormattingEnabled = true;
            this.Provincia.Location = new System.Drawing.Point(630, 51);
            this.Provincia.Name = "Provincia";
            this.Provincia.Size = new System.Drawing.Size(174, 33);
            this.Provincia.TabIndex = 52;
            this.Provincia.Text = "Provincia";
            this.Provincia.SelectedIndexChanged += new System.EventHandler(this.Provincia_SelectedIndexChanged);
            // 
            // combo1
            // 
            this.combo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo1.FormattingEnabled = true;
            this.combo1.Items.AddRange(new object[] {
            "Total de Denuncias",
            "Filtro por Fechas",
            "Filtro por Provincia",
            "Filtro por Canton",
            "Filtro por Distrito"});
            this.combo1.Location = new System.Drawing.Point(564, 12);
            this.combo1.Name = "combo1";
            this.combo1.Size = new System.Drawing.Size(287, 33);
            this.combo1.TabIndex = 55;
            this.combo1.Text = "Filtro por Fechas";
            this.combo1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // distritos
            // 
            this.distritos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.distritos.FormattingEnabled = true;
            this.distritos.Location = new System.Drawing.Point(630, 129);
            this.distritos.Name = "distritos";
            this.distritos.Size = new System.Drawing.Size(174, 33);
            this.distritos.TabIndex = 58;
            this.distritos.Text = "Distrito";
            this.distritos.SelectedIndexChanged += new System.EventHandler(this.distritos_SelectedIndexChanged_1);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(760, 249);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 39);
            this.button1.TabIndex = 59;
            this.button1.Text = "Atras";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // gravedadDenuncias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(862, 300);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.distritos);
            this.Controls.Add(this.combo1);
            this.Controls.Add(this.canton);
            this.Controls.Add(this.Provincia);
            this.Controls.Add(this.fecha2);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.fFecha);
            this.Controls.Add(this.grid3);
            this.Name = "gravedadDenuncias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Denuncias";
            ((System.ComponentModel.ISupportInitialize)(this.grid3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView grid3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button fFecha;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.DateTimePicker fecha2;
        private System.Windows.Forms.ComboBox canton;
        private System.Windows.Forms.ComboBox distritos;
        private System.Windows.Forms.ComboBox Provincia;
        private System.Windows.Forms.ComboBox combo1;
        private System.Windows.Forms.Button button1;
    }
}