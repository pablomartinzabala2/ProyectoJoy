﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaFact.Clases;
namespace SistemaFact
{
    public partial class FrmAnmTipoJoya : FormBase 
    {
        cFunciones fun;
        public FrmAnmTipoJoya()
        {
            InitializeComponent();
        }

        private void Botonera(int Jugada)
        {
            switch (Jugada)
            {
                //estado inicial
                case 1:
                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;
                    break;
                case 2:
                    btnNuevo.Enabled = false;
                    btnEditar.Enabled = false;
                    btnEliminar.Enabled = true;
                    btnAceptar.Enabled = true;
                    btnCancelar.Enabled = true;
                    break;
                case 3:
                    //viene del buscador
                    btnNuevo.Enabled = true;
                    btnEditar.Enabled = true;
                    btnEliminar.Enabled = true;
                    btnAceptar.Enabled = false;
                    btnCancelar.Enabled = false;
                    break;
            }


        }

        private void FrmAnmTipoJoya_Load(object sender, EventArgs e)
        {
            Botonera(1);
            Grupo.Enabled = false;
            fun = new cFunciones();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Botonera(2);
            Grupo.Enabled = true;
            fun.LimpiarGenerico(this);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txt_Nombre.Text == "")
            {
                Mensaje("Debe ingresar una descripción para continuar");
                return;
            }
            if (txtCodigo.Text == "")
                fun.GuardarNuevoGenerico(this, "Tipo");
            else
            {
                // if (txt_Ruta.Text != "")
                //   txt_Ruta.Text = txt_Ruta.Text.Replace("\\", "\\\\");
                fun.ModificarGenerico(this, "Tipo", "CodTipo", txtCodigo.Text);

            }
            MessageBox.Show("Datos grabados correctamente");
            fun.LimpiarGenerico(this);
            Botonera(1);
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            Principal.OpcionesdeBusqueda = "Nombre";
            Principal.TablaPrincipal = "Tipo";
            Principal.OpcionesColumnasGrilla = "CodTipo;Nombre";
            Principal.ColumnasVisibles = "0;1";
            Principal.ColumnasAncho = "0;580";
            FrmBuscadorGenerico form = new FrmBuscadorGenerico();
            form.FormClosing += new FormClosingEventHandler(form_FormClosing);
            form.ShowDialog();
        }

        private void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Principal.CodigoPrincipalAbm != null)
            {
                Botonera(3);
                txtCodigo.Text = Principal.CodigoPrincipalAbm.ToString();

                fun.CargarControles(this, "Tipo", "CodTipo", txtCodigo.Text);

            }
            Grupo.Enabled = false;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            txtCodigo.Text = "";
            txt_Nombre.Text = "";
            Botonera(1);
            Grupo.Enabled = false;
            fun.LimpiarGenerico(this);
            Botonera(1);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Botonera(2);
            Grupo.Enabled = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
