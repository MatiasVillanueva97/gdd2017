﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Data;
using System.Data.SqlClient;

namespace PagoAgilFrba.AbmCliente
{
    public partial class ABMCliente : Form
    {
        public ABMCliente()
        {
            InitializeComponent();
            string query = "select cli_nombre,cli_apellido,cli_DNI from EL_JAPONES_SANGRANDO.Clientes";
            DataTable ds = BD.busqueda(query);
            dataViewModificar.DataSource = ds;
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            {
                buttons.HeaderText = "Modificar";
                buttons.Text = "Modificar";
                buttons.UseColumnTextForButtonValue = true;
                buttons.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                buttons.FlatStyle = FlatStyle.Standard;
                buttons.CellTemplate.Style.BackColor = Color.Honeydew;
                buttons.DisplayIndex = 3;
            }
            dataViewModificar.Columns.Add(buttons);

            query = "select cli_nombre,cli_apellido,cli_DNI from EL_JAPONES_SANGRANDO.Clientes where cli_estado = 1";
            datagridEliminar.DataSource = BD.busqueda(query);
            DataGridViewButtonColumn buttons2 = new DataGridViewButtonColumn();
            {
                buttons2.HeaderText = "Eliminar";
                buttons2.Text = "Eliminar";
                buttons2.UseColumnTextForButtonValue = true;
                buttons2.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;
                buttons2.FlatStyle = FlatStyle.Standard;
                buttons2.CellTemplate.Style.BackColor = Color.Honeydew;
                buttons2.DisplayIndex = 3;
            }
            datagridEliminar.Columns.Add(buttons2);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                string x = datagridEliminar.Rows[e.RowIndex].Cells["cli_DNI"].Value.ToString();
                if(BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Clientes SET cli_estado = 0 WHERE cli_DNI = '"+x+"'")>0){
                    MessageBox.Show("cliente eliminado", "Al pique quique", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    String query = "select cli_nombre,cli_apellido,cli_DNI from EL_JAPONES_SANGRANDO.Clientes where cli_estado = 1";
                    datagridEliminar.DataSource = BD.busqueda(query);
                    query = "select cli_nombre,cli_apellido,cli_DNI from EL_JAPONES_SANGRANDO.Clientes";
                    DataTable ds = BD.busqueda(query);
                    dataViewModificar.DataSource = ds;
                }

                //string rol = dataGridViewModificarC.Rows[e.ColumnIndex].Cells[2].Value.ToString();
                //BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Roles SET rol_estado = 0 WHERE rol_nombre ='" +rol+ "'");
            }
        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            IniciarSesion.AccionesAdmin accion_ADMIN = new IniciarSesion.AccionesAdmin();
            IniciarSesion.Acciones accion = new IniciarSesion.Acciones();
            accion_ADMIN.Show();
            accion.Show();
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            IniciarSesion.AccionesAdmin accion_ADMIN = new IniciarSesion.AccionesAdmin();
            IniciarSesion.Acciones accion = new IniciarSesion.Acciones();
            accion_ADMIN.Show();
            accion.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            IniciarSesion.AccionesAdmin accion_ADMIN = new IniciarSesion.AccionesAdmin();
            IniciarSesion.Acciones accion = new IniciarSesion.Acciones();
            accion_ADMIN.Show();
            accion.Show();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textDni.Text, @"^\d+$"))
            {
                MessageBox.Show("Sólo se permiten numeros en el DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (textNombre.Text.Trim() == "" | textApellido.Text.Trim() == "" | textDni.Text.Trim() == "" | textDireccion.Text.Trim() == "" | textDireccion.Text.Trim() == "" | dateTimePickerFechaNac.Text.Trim() == "")
            {
                MessageBox.Show("Faltan completar campos obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                String nombre = textNombre.Text;
                String apellido = textApellido.Text;
                String dni = textDni.Text;
                String mail = textMail.Text;
                String direccion = textDireccion.Text;
                String fechanacimiento = dateTimePickerFechaNac.Text;
                if(BD.ABM("INSERT INTO EL_JAPONES_SANGRANDO.Clientes(cli_DNI,cli_nombre,cli_apellido,cli_fechanac,cli_mail,cli_direccion,cli_CP)values('"+dni+"','"+nombre+"','"+apellido+"','"+fechanacimiento+"','"+mail+"','"+direccion+"','"+textCodigoPostal.Text+"')")>0){
                    MessageBox.Show("Se ingreso correctamente el cliente", "Insertado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textNombre.Text = "";
                    textApellido.Text = "";
                    textDni.Text = "";
                    textMail.Text = "";
                    textCodigoPostal.Text = "";
                    textDireccion.Text = "";
                    dateTimePickerFechaNac.Text = "";
                    string query = "select cli_nombre,cli_apellido,cli_DNI from EL_JAPONES_SANGRANDO.Clientes";
                    DataTable ds = BD.busqueda(query);
                    dataViewModificar.DataSource = ds;
                    query = "select cli_nombre,cli_apellido,cli_DNI from EL_JAPONES_SANGRANDO.Clientes where cli_estado = 1";
                    datagridEliminar.DataSource = BD.busqueda(query);
                }
                else{
                    MessageBox.Show("Datos erroneos el cliente", "Error en seleccion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    

                }
               

            }
            
           
        }

        private void dataViewModificar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                new Eliminar_Modificar_Cliente_Seleccionado(dataViewModificar.Rows[e.RowIndex].Cells["cli_DNI"].Value.ToString()).Show();
                string query = "select cli_nombre,cli_apellido,cli_DNI from EL_JAPONES_SANGRANDO.Clientes";
                DataTable ds = BD.busqueda(query);
                dataViewModificar.DataSource = ds;
                 query = "select cli_nombre,cli_apellido,cli_DNI from EL_JAPONES_SANGRANDO.Clientes where cli_estado = 1";
                datagridEliminar.DataSource = BD.busqueda(query);
                //string rol = dataGridViewModificarC.Rows[e.ColumnIndex].Cells[2].Value.ToString();
                //BD.ABM("UPDATE EL_JAPONES_SANGRANDO.Roles SET rol_estado = 0 WHERE rol_nombre ='" +rol+ "'");
            }
        }
    
        }

      
    }

