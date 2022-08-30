using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio.Modelo;

namespace Taller.Web.Paginas
{
    public partial class wfrmAdministrador : System.Web.UI.Page
    {
        Controladora.ControladoraWeb controladoraWeb = new Controladora.ControladoraWeb();
        string ciAdmin = "3.492.751-1";

        #region Load & SelectedIndex
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["IdAdmin"] == null)
            {
                Response.Redirect("~/");
            }

            if (!IsPostBack)
            {
                this.listarAdmin();
            }
        }
        protected void lstAdministradores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstAdministradores.SelectedIndex > -1)
            {
                string linea = this.lstAdministradores.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int id = Convert.ToInt16(partes[0]);
                this.cargar(id);
            }
            this.lstAdministradores.SelectedIndex = -1;
        }
        #endregion

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

        private void listarAdmin()
        {
            this.lstAdministradores.DataSource = null;
            this.lstAdministradores.DataSource = controladoraWeb.ListaAdministradores();
            this.lstAdministradores.DataBind();
        }

        private void cargar(int pId)
        {
            Administrador unAdmin = controladoraWeb.BuscarAdmin(pId);

            this.txtId.Text = Convert.ToString(unAdmin.Id);
            this.txtCedula.Text = unAdmin.Cedula;
            this.txtContrasena.Attributes.Add("value", unAdmin.Contrasena);
            this.txtDireccion.Text = unAdmin.Direccion;
            this.txtMail.Text = unAdmin.Mail;
            this.txtNombre.Text = unAdmin.Nombre;
            this.txtTelefono.Text = unAdmin.Telefono;

            DateTime fechar = Convert.ToDateTime(unAdmin.FechaRegistro);
            this.dtpFechaRegistro.Text = fechar.ToString("yyyy-MM-dd");
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
        protected void btnAlta_Click(object sender, EventArgs e)
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

                Administrador unAdmin = new Administrador(id, nombre, cedula, telefono, direccion, mail, fecharegistro, contrasena);
                if (controladoraWeb.AltaAdmin(unAdmin))
                {
                    this.lblMensajes.Text = "Administrador ingresado con éxito";
                    this.limpiar();
                    this.listarAdmin();
                }
                else
                {
                    this.lblMensajes.Text = "Ya existe un administrador con esa id";
                }
            }
            else
            {
                this.lblMensajes.Text = "Faltan datos";
            }
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            HttpCookie idCookie = Request.Cookies["IdAdmin"];
            int cookiesvalue = int.Parse(Server.HtmlEncode(idCookie.Value));

            Administrador unAdmin = controladoraWeb.BuscarAdmin(cookiesvalue);

            if (unAdmin.Cedula == ciAdmin)
            {
                if (this.txtId.Text != "")
                {
                    int id = int.Parse(this.txtId.Text);

                    if (controladoraWeb.BajaAdmin(id))
                    {
                        this.limpiar();
                        this.lblMensajes.Text = "Administrador eliminado con éxito";
                        this.listarAdmin();
                    }
                    else
                    {
                        this.txtId.Focus();
                        this.lblMensajes.Text = "No existe un administrador con ese id";
                    }
                }
            }
            else
            {
                this.lblMensajes.Text = "Permiso denegado";
            }
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtId.Text);
            string nombre = this.txtNombre.Text;
            string cedula = this.txtCedula.Text;
            string telefono = this.txtTelefono.Text;
            string direccion = this.txtDireccion.Text;
            string mail = this.txtMail.Text;
            DateTime fechar = Convert.ToDateTime(this.dtpFechaRegistro.Text);
            DateTime fecharegistro = fechar.Date;
            string contrasena = this.txtContrasena.Text;

            Administrador unAdmin = new Administrador(id, nombre, cedula, telefono, direccion, mail, fecharegistro, contrasena);
            if (controladoraWeb.ModificarAdmin(unAdmin))
            {
                this.lblMensajes.Text = "Administrador modificado con éxito";
                this.limpiar();
                this.listarAdmin();
            }
            else
            {
                this.lblMensajes.Text = "Administrador no encontrado";
                this.limpiar();
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }
        #endregion
    }
}