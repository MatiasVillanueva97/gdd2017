﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PagoAgilFrba.RegistroPago
{
    public partial class Pagos : Form
    {
        public Pagos()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }


        private void Pagos_Load(object sender, EventArgs e)
        {
            List<string> lista = BD.listaDeUnCampo("select empresa_nombre from EL_JAPONES_SANGRANDO.Empresas");
            lista.Insert(0,"");
            comboEmpresas.DataSource = lista;
            comboMedioDePago.DataSource = BD.listaDeUnCampo("select formaDePago_desc from EL_JAPONES_SANGRANDO.Formas_De_Pago");
            comboSucursal.DataSource = BD.listaDeUnCampo("select sucursal_nombre from EL_JAPONES_SANGRANDO.Sucursales");
        }
        /// <summary>
        /// 
        /// 
        /// 
        /// HAY QUE AGREGAR EL FILTRO DE LAS FACTURAS SOLO PAGADAS
        /// 
        /// 
        /// 
        /// </summary>
        string queryf = "Select factura_numero, (select empresa_nombre from EL_JAPONES_SANGRANDO.Empresas where empresa_cuit = factura_empresa) as Empresa, factura_cliente,factura_fecha,factura_fecha_vencimiento,factura_total from EL_JAPONES_SANGRANDO.Facturas where factura_estado  = 1 ";
        string queryBusqueda;

        private bool los4estanvacios()
        {
            return txtDni.Text == "" && dateVenc.Text == "1/1/2017" && txtFactura.Text == "" && comboEmpresas.Text == "";
        }

        string conAnd(string cadena)
        {
            return " AND " + cadena + " ";
        }

        private string queryFactura()
        {
            return txtFactura.Text == "" ? "" : ("factura_numero like '" + txtFactura.Text+"%'");
        }
        private string queryVencimiento()
        {
            return dateVenc.Text == "" ? "" : ("YEAR(factura_fecha_vencimiento) = "+ dateVenc.Value.Year +"and MONTH(factura_fecha_vencimiento) = "+dateVenc.Value.Month+" and DAY(factura_fecha_vencimiento) = " + dateVenc.Value.Day +" ");
        }
        private string queryDni()
        {
            return txtDni.Text == "" ? "" : ("factura_cliente like '" + txtDni.Text+"%'");
        }

        private string queryEmpresa()
        {
            if (comboEmpresas.Text != "")
            {
                string empresaCuit = BD.consultaDeUnSoloResultado("select empresa_cuit from EL_JAPONES_SANGRANDO.Empresas where empresa_nombre='" + comboEmpresas.Text + "'");
                return "factura_empresa = '" + empresaCuit + "'";
            }
            return "";
        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            string query2 = "";
            if (txtDni.Text != "")
            {
                query2 = queryf + " AND " + this.queryDni();
            }
            else
                query2 = queryf + " AND 1 = 1";
               if (dateVenc.Text != "1/1/2017")
               {
                   query2 += conAnd(queryVencimiento());
               }
               if (txtFactura.Text != "")
               {
                   query2 += conAnd(queryFactura());
               }
               if (comboEmpresas.Text != "")
               {
                   query2 += conAnd(queryEmpresa());
               }

               dataGridFacturas.DataSource = BD.busqueda(query2);
            


        }


        private void txtFactura_TextChanged(object sender, EventArgs e)
        {
            string query2 = "";
            if (txtFactura.Text != "")
            {
                query2 = queryf + " AND " + this.queryFactura();
            }
            else{
                query2 +=queryf +"AND 1 = 1";
            }
                if (dateVenc.Text != "1/1/2017")
                {
                    query2 += conAnd(queryVencimiento());
                }
                if (txtDni.Text != "")
                {
                    query2 += conAnd(queryDni());
                }
                if (comboEmpresas.Text != "")
                {
                    query2 += conAnd(queryEmpresa());
                }

                dataGridFacturas.DataSource = BD.busqueda(query2);
            



        }


        private void comboEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query2 = "";
            if (comboEmpresas.Text != "")
            {
                query2 = queryf + " AND " + this.queryEmpresa();
            }
            else{ 
                    query2 = queryf + " AND 1 = 1"; 
                }
                if (dateVenc.Text != "1/1/2017")
                {
                    query2 += conAnd(queryVencimiento());
                }
                if (txtFactura.Text != "")
                {
                    query2 += conAnd(queryFactura());
                }
                if (txtDni.Text != "")
                {
                    query2 += conAnd(queryDni());
                }

                dataGridFacturas.DataSource = BD.busqueda(query2);

            
        }

        private void dateVenc_ValueChanged(object sender, EventArgs e)
        {
            string query2 = "";
            if (dateVenc.Text != "1/1/2017")
            {
                query2 = queryf + " AND " + this.queryVencimiento();
                if (txtDni.Text != "")
                {
                    query2 += conAnd(queryDni());
                }
                if (txtFactura.Text != "")
                {
                    query2 += conAnd(queryFactura());
                }
                if (comboEmpresas.Text != "")
                {
                    query2 += conAnd(queryEmpresa());
                }

                dataGridFacturas.DataSource = BD.busqueda(query2);

            }
        }

        private void dataGridFacturas_SelectionChanged(object sender, EventArgs e)
        {
            double valor = 0;
            foreach (DataGridViewRow row in dataGridFacturas.SelectedRows)
            {
                valor += double.Parse(row.Cells["factura_total"].Value.ToString());
            }
            lblImporte.Text = valor.ToString();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (lblImporte.Text != "0")
            {
                insertarPago();

                MessageBox.Show("Se cargo correctamente");
                txtDni.Text = "";
            }
            else
            {

                MessageBox.Show("Hay campos sin rellenar");
            }
        }
        private void insertarPago()
        {

            if(textPagador.Text == ""){
                MessageBox.Show("No selecciono pagador");
                return;
            }
            string idPago = BD.consultaDeUnSoloResultado("select top 1 pago_nro+1 from EL_JAPONES_SANGRANDO.Pagos ORDER BY pago_nro desc");
            string sucursal = BD.consultaDeUnSoloResultado("SELECT sucursal_codigo_postal from EL_JAPONES_SANGRANDO.Sucursales where sucursal_nombre='" + comboSucursal.Text +"'");
            string medio = BD.consultaDeUnSoloResultado("SELECT formaDePago_id from EL_JAPONES_SANGRANDO.Formas_De_Pago where formaDePago_desc='" + comboMedioDePago.Text + "'");
            string fecha = dateVenc.Value.Date.ToString("MM/dd/yyyy");
            
           
            string insert2 = "INSERT INTO EL_JAPONES_SANGRANDO.Pagos (pago_nro, pago_sucursal,pago_importe,pago_formaDePago,pago_fecha,pago_cliente) VALUES(" + idPago + "," + sucursal + "," + lblImporte.Text.Replace(",",".") + "," + medio + ",'" + fecha + "',38270412)";
            MessageBox.Show(idPago.ToString());
            List<String> lista = new List<string>();
            lista.Add(insert2);
            foreach (DataGridViewRow row in dataGridFacturas.SelectedRows)
            {
                string factura = row.Cells["factura_numero"].Value.ToString();
                String insert = "INSERT INTO EL_JAPONES_SANGRANDO.Pago_Factura(pago_Factura_factura,pago_Factura_pago) values ('" + factura + "'," + idPago + ")";
                String update = "UPDATE EL_JAPONES_SANGRANDO.Facturas SET factura_estado = 2 where factura_numero = '" + factura+"'";
                
                lista.Add(insert);
                lista.Add(update);
            }
            if(BD.correrStoreProcedure(lista)>0){
                MessageBox.Show("Se concreto el pago");
            }
            else{
                MessageBox.Show("Datos erroneos");
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}