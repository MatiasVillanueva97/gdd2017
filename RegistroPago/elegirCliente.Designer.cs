﻿namespace PagoAgilFrba.RegistroPago
{
    partial class elegirCliente
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
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.listadoClientes = new System.Windows.Forms.DataGridView();
            this.Elegir = new System.Windows.Forms.DataGridViewButtonColumn();
            this.filtroNombre = new System.Windows.Forms.TextBox();
            this.filtroApellido = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.filtroDNI = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.listadoClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(39, 369);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(141, 28);
            this.btnLimpiar.TabIndex = 46;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click_1);
            // 
            // listadoClientes
            // 
            this.listadoClientes.AllowUserToAddRows = false;
            this.listadoClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listadoClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Elegir});
            this.listadoClientes.Location = new System.Drawing.Point(220, 58);
            this.listadoClientes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listadoClientes.Name = "listadoClientes";
            this.listadoClientes.Size = new System.Drawing.Size(868, 383);
            this.listadoClientes.TabIndex = 44;
            this.listadoClientes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listadoClientes_CellContentClick);
            // 
            // Elegir
            // 
            this.Elegir.HeaderText = "Elegir";
            this.Elegir.Name = "Elegir";
            this.Elegir.ReadOnly = true;
            this.Elegir.Text = "Elegir";
            this.Elegir.UseColumnTextForButtonValue = true;
            // 
            // filtroNombre
            // 
            this.filtroNombre.Location = new System.Drawing.Point(16, 298);
            this.filtroNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.filtroNombre.Name = "filtroNombre";
            this.filtroNombre.Size = new System.Drawing.Size(195, 22);
            this.filtroNombre.TabIndex = 42;
            this.filtroNombre.TextChanged += new System.EventHandler(this.filtrar);
            // 
            // filtroApellido
            // 
            this.filtroApellido.Location = new System.Drawing.Point(16, 214);
            this.filtroApellido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.filtroApellido.Name = "filtroApellido";
            this.filtroApellido.Size = new System.Drawing.Size(195, 22);
            this.filtroApellido.TabIndex = 40;
            this.filtroApellido.TextChanged += new System.EventHandler(this.filtrar);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 263);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(129, 17);
            this.label12.TabIndex = 39;
            this.label12.Text = "Buscar por nombre";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 84);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 17);
            this.label13.TabIndex = 38;
            this.label13.Text = "Buscar por DNI";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 172);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(130, 17);
            this.label14.TabIndex = 37;
            this.label14.Text = "Buscar por apellido";
            // 
            // filtroDNI
            // 
            this.filtroDNI.Location = new System.Drawing.Point(16, 122);
            this.filtroDNI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.filtroDNI.Name = "filtroDNI";
            this.filtroDNI.Size = new System.Drawing.Size(195, 22);
            this.filtroDNI.TabIndex = 47;
            this.filtroDNI.TextChanged += new System.EventHandler(this.filtrar);
            // 
            // elegirCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 490);
            this.Controls.Add(this.filtroDNI);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.listadoClientes);
            this.Controls.Add(this.filtroNombre);
            this.Controls.Add(this.filtroApellido);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "elegirCliente";
            this.Text = "Elegir Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.listadoClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView listadoClientes;
        private System.Windows.Forms.TextBox filtroNombre;
        private System.Windows.Forms.TextBox filtroApellido;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox filtroDNI;
        private System.Windows.Forms.DataGridViewButtonColumn Elegir;
    }
}