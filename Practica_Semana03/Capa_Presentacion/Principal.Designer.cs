namespace Capa_Presentacion
{
    partial class Principal
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
            this.btnIngresarUsuario = new System.Windows.Forms.Button();
            this.btnIngresarProducto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCargar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIngresarUsuario
            // 
            this.btnIngresarUsuario.Location = new System.Drawing.Point(70, 215);
            this.btnIngresarUsuario.Name = "btnIngresarUsuario";
            this.btnIngresarUsuario.Size = new System.Drawing.Size(120, 23);
            this.btnIngresarUsuario.TabIndex = 0;
            this.btnIngresarUsuario.Text = "Ingresar Usuario";
            this.btnIngresarUsuario.UseVisualStyleBackColor = true;
            // 
            // btnIngresarProducto
            // 
            this.btnIngresarProducto.Location = new System.Drawing.Point(212, 215);
            this.btnIngresarProducto.Name = "btnIngresarProducto";
            this.btnIngresarProducto.Size = new System.Drawing.Size(120, 23);
            this.btnIngresarProducto.TabIndex = 1;
            this.btnIngresarProducto.Text = "Ingresar Producto";
            this.btnIngresarProducto.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bienvenido";
            // 
            // lblCargar
            // 
            this.lblCargar.AutoSize = true;
            this.lblCargar.Location = new System.Drawing.Point(153, 98);
            this.lblCargar.Name = "lblCargar";
            this.lblCargar.Size = new System.Drawing.Size(37, 13);
            this.lblCargar.TabIndex = 3;
            this.lblCargar.Text = "_____";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 423);
            this.Controls.Add(this.lblCargar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIngresarProducto);
            this.Controls.Add(this.btnIngresarUsuario);
            this.Name = "Principal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIngresarUsuario;
        private System.Windows.Forms.Button btnIngresarProducto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCargar;
    }
}