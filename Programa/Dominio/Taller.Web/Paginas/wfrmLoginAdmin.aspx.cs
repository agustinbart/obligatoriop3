﻿using Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Taller.Web.Paginas
{
    public partial class wfrmLoginAdmin : System.Web.UI.Page
    {
        Controladora.ControladoraWeb controladoraWeb = new Controladora.ControladoraWeb();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Métodos auxiliares
        private bool faltanDatos()
        {
            if (this.txtCedula.Text == "" || this.txtContrasena.Text == "")
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Botones
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatos())
            {
                string cedula = this.txtCedula.Text;
                string contrasena = this.txtContrasena.Text;

                Administrador admin = controladoraWeb.BuscarAdminLogin(cedula, contrasena);

                if (admin != null)
                {
                    Session.Abandon();
                    int id = admin.Id;
                    HttpCookie cookie = new HttpCookie("IdAdmin", id.ToString());
                    this.Response.Cookies.Add(cookie);
                    Response.Redirect("~/");
                }
                else
                {
                    this.lblMensajes.Text = "Datos incorrectos";
                }

            }
            else
            {
                this.lblMensajes.Text = "Faltan datos";
            }
        }
        #endregion
    }
}