using Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Taller.Web.Paginas
{
    public partial class wfrmRegistro : System.Web.UI.Page
    {
        Controladora.ControladoraWeb controladoraWeb = new Controladora.ControladoraWeb();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        #region Métodos auxiliares
        private void limpiar()
        {
            this.txtId.Text = "";
            this.txtCedula.Text = "";
            this.txtContrasena.Text = "";
            this.txtDireccion.Text = "";
            this.txtMail.Text = "";
            this.txtNombre.Text = "";
            this.txtTelefono.Text = "";
        }
        private bool faltanDatos()
        {
            if (this.txtCedula.Text == "" || this.txtContrasena.Text == "" || this.txtDireccion.Text == "" || this.txtMail.Text == "" || this.txtNombre.Text == "" || this.txtTelefono.Text == "")
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Botones
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatos())
            {
                int id = 1;
                string nombre = this.txtNombre.Text;
                string cedula = this.txtCedula.Text;
                string telefono = this.txtTelefono.Text;
                string direccion = this.txtDireccion.Text;
                string mail = this.txtMail.Text;
                DateTime fecharegistro = DateTime.Today;
                string contrasena = this.txtContrasena.Text;

                Cliente unCliente = new Cliente(id, nombre, cedula, telefono, direccion, mail, fecharegistro, contrasena);
                if (controladoraWeb.AltaCliente(unCliente))
                {
                    this.lblMensajes.Text = "Registrado con éxito.";
                    this.limpiar();
                }
                else
                {
                    this.lblMensajes.Text = "No se pudo registrar. Intentelo de nuevo más tarde.";
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