﻿using STPR_UI.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STPR_Demo
{
    public partial class frmSeguridad : Form
    {
        public frmSeguridad()
        {
            InitializeComponent();
        }
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            var error = false;
            var mensaje = string.Empty;
            var mensajeRetorno=string.Empty;

            if (string.IsNullOrEmpty(txtUsuario.Text)) {
                error = true;
                mensaje += "* Ingrese usuario."+ Environment.NewLine;
            }

            if (string.IsNullOrEmpty(txtClave.Text)) {
                error = true;
                mensaje +=  "* Ingrese clave."+ Environment.NewLine;
            }

            if (error) {
                MessageBox.Show(mensaje,"Se encontrarón las siguientes incidencias");
                return;
            }

            var textoEncriptado = new utilitarioBL().HashPassword(txtClave.Text);
            var objUsuario = new tm_usuarioBL().get_usuario(txtUsuario.Text, out mensajeRetorno);
            if (new utilitarioBL().VerificarClave(txtClave.Text, objUsuario.clave))
            {
                MessageBox.Show("Inicio de sesión exitoso.");
            }
            else {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
