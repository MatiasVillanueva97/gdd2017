﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.IniciarSesion
{
    public partial class SeleccionarRol : Form
    {
        public SeleccionarRol(string username)
        {
            InitializeComponent();
            comboRoles.DataSource = BD.roles(username);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string rol = comboRoles.SelectedValue.ToString();


            this.Hide();
            if(rol == "cobrador")
            {
                 new SeleccionarSucursal().Show();
            }
            else
            {
                 new AccionesAdmin(rol).Show();
            }
        }
    }
}
