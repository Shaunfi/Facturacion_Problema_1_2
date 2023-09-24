﻿using Facturacion_Problema_1_2.Datos.Implementacion;
using Facturacion_Problema_1_2.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Facturacion_Problema_1_2.Presentaciones
{
    public partial class FrmNuevoCliente : Form
    {
        private ClientesDAO daoClientes;

        public FrmNuevoCliente()
        {
            InitializeComponent();
        }

        private void FrmNuevoCliente_Load(object sender, EventArgs e)
        {
            daoClientes = new ClientesDAO();
            CargarLista();
            Limpiar();
        }

        private void CargarLista()
        {
            lstClientes.Items.Clear();

            daoClientes.ListarClientes().ForEach((cliente) => lstClientes.Items.Add(cliente));
        }

        private void Limpiar()
        {
            txtBoxApellido.Text = String.Empty;
            txtBoxNombre.Text = String.Empty;
        }

        private bool Validar()
        {
            if (txtBoxApellido.Text == String.Empty)
            {
                MessageBox.Show("Apellido Vacio");
                return false;
            }
            if (txtBoxNombre.Text == String.Empty)
            {
                MessageBox.Show("Nombre Vacio");
                return false;
            }

            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                Clientes cliente = new Clientes();

                cliente.Apellido = txtBoxApellido.Text;
                cliente.Nombre = txtBoxNombre.Text;

                if (daoClientes.AgregarCliente(cliente))
                {
                    MessageBox.Show("El cliente ha si agregado con exito.", "CONFIRMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El cliente no se ha agregado.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                CargarLista();
                Limpiar();
            }
        }
    }
}
