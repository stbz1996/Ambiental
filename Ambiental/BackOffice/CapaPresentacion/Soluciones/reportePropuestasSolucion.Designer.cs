namespace CapaPresentacion.Soluciones
{
    partial class reportePropuestasSolucion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reportePropuestasSolucion));
            this.button1 = new System.Windows.Forms.Button();
            this.grid3 = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.combo = new System.Windows.Forms.ComboBox();
            this.fecha = new System.Windows.Forms.DateTimePicker();
            this.distritos = new System.Windows.Forms.ComboBox();
            this.canton = new System.Windows.Forms.ComboBox();
            this.Provincia = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.box = new System.Windows.Forms.TextBox();
            this.hash = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid3)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(1087, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 34);
            this.button1.TabIndex = 74;
            this.button1.Text = "Atras";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.Column4,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.grid3.GridColor = System.Drawing.Color.Red;
            this.grid3.Location = new System.Drawing.Point(12, 60);
            this.grid3.Name = "grid3";
            this.grid3.ReadOnly = true;
            this.grid3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grid3.Size = new System.Drawing.Size(1161, 616);
            this.grid3.TabIndex = 73;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Título de la denuncia";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 220;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Descripción de la Denuncia";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "La realizó";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Fecha";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 78;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "La Aceptó";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 120;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Descripción de Solución";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 200;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Fecha de Solución";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 78;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Validación de la Solucion";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // combo
            // 
            this.combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo.FormattingEnabled = true;
            this.combo.Items.AddRange(new object[] {
            "Cargar todas las denuncias",
            "Filtro por Fecha",
            "Filtro por Provincia",
            "Filtro por Cantón",
            "Filtro por Distrito",
            "Filtro por HashTag"});
            this.combo.Location = new System.Drawing.Point(798, 16);
            this.combo.Name = "combo";
            this.combo.Size = new System.Drawing.Size(283, 33);
            this.combo.TabIndex = 75;
            this.combo.Text = "Filtros";
            this.combo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // fecha
            // 
            this.fecha.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha.Location = new System.Drawing.Point(537, 18);
            this.fecha.Name = "fecha";
            this.fecha.Size = new System.Drawing.Size(141, 27);
            this.fecha.TabIndex = 76;
            this.fecha.ValueChanged += new System.EventHandler(this.fecha_ValueChanged);
            // 
            // distritos
            // 
            this.distritos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.distritos.FormattingEnabled = true;
            this.distritos.Location = new System.Drawing.Point(572, 12);
            this.distritos.Name = "distritos";
            this.distritos.Size = new System.Drawing.Size(174, 33);
            this.distritos.TabIndex = 79;
            this.distritos.Text = "Distrito";
            this.distritos.SelectedIndexChanged += new System.EventHandler(this.distritos_SelectedIndexChanged);
            // 
            // canton
            // 
            this.canton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.canton.FormattingEnabled = true;
            this.canton.Location = new System.Drawing.Point(382, 12);
            this.canton.Name = "canton";
            this.canton.Size = new System.Drawing.Size(174, 33);
            this.canton.TabIndex = 78;
            this.canton.Text = "Cantón";
            this.canton.SelectedIndexChanged += new System.EventHandler(this.canton_SelectedIndexChanged);
            // 
            // Provincia
            // 
            this.Provincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Provincia.FormattingEnabled = true;
            this.Provincia.Location = new System.Drawing.Point(193, 12);
            this.Provincia.Name = "Provincia";
            this.Provincia.Size = new System.Drawing.Size(174, 33);
            this.Provincia.TabIndex = 77;
            this.Provincia.Text = "Provincia";
            this.Provincia.SelectedIndexChanged += new System.EventHandler(this.Provincia_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(312, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 25);
            this.label1.TabIndex = 80;
            this.label1.Text = "Seleccione la fecha";
            // 
            // box
            // 
            this.box.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.box.Location = new System.Drawing.Point(537, 20);
            this.box.Name = "box";
            this.box.Size = new System.Drawing.Size(171, 31);
            this.box.TabIndex = 81;
            this.box.TextChanged += new System.EventHandler(this.box_TextChanged);
            // 
            // hash
            // 
            this.hash.AutoSize = true;
            this.hash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hash.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hash.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.hash.Location = new System.Drawing.Point(334, 20);
            this.hash.Name = "hash";
            this.hash.Size = new System.Drawing.Size(197, 25);
            this.hash.TabIndex = 82;
            this.hash.Text = "Digite el hashTag";
            // 
            // reportePropuestasSolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1190, 688);
            this.Controls.Add(this.hash);
            this.Controls.Add(this.box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.distritos);
            this.Controls.Add(this.canton);
            this.Controls.Add(this.Provincia);
            this.Controls.Add(this.fecha);
            this.Controls.Add(this.combo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grid3);
            this.Name = "reportePropuestasSolucion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.grid3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView grid3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.ComboBox combo;
        private System.Windows.Forms.DateTimePicker fecha;
        private System.Windows.Forms.ComboBox distritos;
        private System.Windows.Forms.ComboBox canton;
        private System.Windows.Forms.ComboBox Provincia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox box;
        private System.Windows.Forms.Label hash;
    }
}