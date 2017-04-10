namespace CapaPresentacion
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>z
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.ingresar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pusuario = new System.Windows.Forms.TextBox();
            this.pcontrasena = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ingresar
            // 
            resources.ApplyResources(this.ingresar, "ingresar");
            this.ingresar.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.ingresar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ingresar.Name = "ingresar";
            this.ingresar.UseVisualStyleBackColor = true;
            this.ingresar.UseWaitCursor = true;
            this.ingresar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Name = "label1";
            this.label1.UseWaitCursor = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Name = "label2";
            this.label2.UseWaitCursor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Name = "label3";
            this.label3.UseWaitCursor = true;
            // 
            // pusuario
            // 
            this.pusuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.pusuario.BackColor = System.Drawing.Color.White;
            this.pusuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pusuario.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            resources.ApplyResources(this.pusuario, "pusuario");
            this.pusuario.Name = "pusuario";
            this.pusuario.UseWaitCursor = true;
            // 
            // pcontrasena
            // 
            resources.ApplyResources(this.pcontrasena, "pcontrasena");
            this.pcontrasena.Name = "pcontrasena";
            this.pcontrasena.UseWaitCursor = true;
            // 
            // Login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.pcontrasena);
            this.Controls.Add(this.pusuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ingresar);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Name = "Login";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Red;
            this.UseWaitCursor = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ingresar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pusuario;
        private System.Windows.Forms.TextBox pcontrasena;
    }
}