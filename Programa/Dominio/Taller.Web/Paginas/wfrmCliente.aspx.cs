using Dominio.Modelo;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Taller.Web.Paginas
{
    public partial class wfrmCliente : System.Web.UI.Page
    {
        Controladora.ControladoraWeb controladoraWeb = new Controladora.ControladoraWeb();

        #region Load & SelectedIndex
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["IdAdmin"] == null)
            {
                Response.Redirect("~/");
            }

            if (!this.IsPostBack)
            {
                this.listarClientes();
            }
        }

        protected void lstClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstClientes.SelectedIndex > -1)
            {
                string linea = this.lstClientes.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int id = Convert.ToInt16(partes[0]);
                this.cargar(id);
            }
            this.lstClientes.SelectedIndex = -1;
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

        private void listarClientes()
        {
            this.lstClientes.DataSource = null;
            this.lstClientes.DataSource = controladoraWeb.ListaClientes();
            this.lstClientes.DataBind();
        }

        private void cargar(int pId)
        {
            Cliente unCliente = controladoraWeb.BuscarCliente(pId);

            this.txtId.Text = Convert.ToString(unCliente.Id);
            this.txtCedula.Text = unCliente.Cedula;
            this.txtContrasena.Attributes.Add("value", unCliente.Contrasena);
            this.txtDireccion.Text = unCliente.Direccion;
            this.txtMail.Text = unCliente.Mail;
            this.txtNombre.Text = unCliente.Nombre;
            this.txtTelefono.Text = unCliente.Telefono;
        }

        private bool faltanDatos()
        {
            if (this.txtCedula.Text == "" || this.txtDireccion.Text == "" || this.txtMail.Text == "" || this.txtNombre.Text == "" || this.txtTelefono.Text == "")
            {
                return true;
            }
            return false;
        }

        private bool clientesAsignados()
        {
            int id = int.Parse(this.txtId.Text);
            Cliente unCliente = controladoraWeb.BuscarCliente(id);
            foreach (Cliente_Vehiculo unCliVeh in controladoraWeb.ListaClienteVehiculos())
            {
                if (unCliente.Id == unCliVeh.CliCod)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Botones
        protected void BajaCliente()
        {
            int id = int.Parse(this.txtId.Text);
            if (this.txtId.Text != "" && !this.clientesAsignados())
            {
                if (controladoraWeb.BajaCliente(id))
                {
                    this.limpiar();
                    this.lblMensajes.Text = "Cliente eliminado con éxito";
                    this.listarClientes();
                }
                else
                {
                    this.lblMensajes.Text = "No se puede eliminar";
                }
            }
            else
            {
                this.lblMensajes.Text = "No se puede eliminar ya que tiene un registro en cliente_vehiculo";
            }
        }
        protected void btnBaja_Click(object sender, EventArgs e)
        {
            this.BajaCliente();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatos())
            {
                int id = int.Parse(this.txtId.Text);
                string nombre = this.txtNombre.Text;
                string cedula = this.txtCedula.Text;
                string telefono = this.txtTelefono.Text;
                string direccion = this.txtDireccion.Text;
                string mail = this.txtMail.Text;
                DateTime fecharegistro = DateTime.Today;
                string contrasena = this.txtContrasena.Text;

                Cliente unCliente = new Cliente(id, nombre, cedula, telefono, direccion, mail, fecharegistro, contrasena);
                if (controladoraWeb.ModificarCliente(unCliente))
                {
                    this.lblMensajes.Text = "Cliente modificado con éxito.";
                    this.limpiar();
                    this.listarClientes();
                }
                else
                {
                    this.lblMensajes.Text = "No se pudo modificar. Intentelo de nuevo más tarde.";
                    this.limpiar();
                }
            }
            else
            {
                this.lblMensajes.Text = "Faltan datos";
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatos())
            {
                int id = 0;
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
                    this.BajaCliente();
                    this.limpiar();
                    this.listarClientes();
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
        #endregion

    }
}