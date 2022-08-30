using Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Taller.Web.Paginas
{
    public partial class wfrmProveedor : System.Web.UI.Page
    {
        Controladora.ControladoraWeb controladoraWeb = new Controladora.ControladoraWeb();

        #region Load & SelectedIndex
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["IdAdmin"] == null)
            {
                Response.Redirect("~/");
            }

            if (!IsPostBack)
            {
                this.listarProveedores();
            }
        }

        protected void lstProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstProveedores.SelectedIndex > -1)
            {
                string linea = this.lstProveedores.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                string rut = partes[0];
                this.cargar(rut);
            }
            this.lstProveedores.SelectedIndex = -1;
        }
        #endregion

        #region Métodos auxiliares
        private bool faltanDatos()
        {
            if (this.txtRUT.Text == "" || this.txtNombre.Text == "" || this.txtMail.Text == "" || this.txtTelefono.Text == "")
            {
                return true;
            }
            return false;
        }

        private void cargar(string pRUT)
        {
            Proveedor unProveedor = controladoraWeb.BuscarProveedor(pRUT);

            this.txtRUT.Text = unProveedor.RUT;
            this.txtNombre.Text = unProveedor.Nombre;
            this.txtMail.Text = unProveedor.Mail;
            this.txtTelefono.Text = unProveedor.Telefono;
        }

        private void limpiar()
        {
            this.txtRUT.Text = "";
            this.txtNombre.Text = "";
            this.txtMail.Text = "";
            this.txtTelefono.Text = "";
        }

        private void listarProveedores()
        {
            this.lstProveedores.DataSource = null;
            this.lstProveedores.DataSource = controladoraWeb.ListaProveedores();
            this.lstProveedores.DataBind();
        }

        private bool buscarProveedorEnRepuestos(string pRUT)
        {
            foreach(Repuesto unRepuesto in controladoraWeb.ListaRepuestos())
            {
                foreach(Proveedor unProveedor in controladoraWeb.ListaProveedores())
                {
                    if(unProveedor.RUT == unRepuesto.RUTProveedor)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region Botones
        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatos())
            {
                string rut = this.txtRUT.Text;
                string nombre = this.txtNombre.Text;
                string mail = this.txtMail.Text;
                string telefono = this.txtTelefono.Text;

                Proveedor unProveedor = new Proveedor(rut, nombre, mail, telefono);
                if (controladoraWeb.AltaProveedor(unProveedor))
                {
                    this.lblMensajes.Text = "Proveedor ingresado con éxito.";
                    this.listarProveedores();
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

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            if (this.txtRUT.Text != "")
            {
                if (!buscarProveedorEnRepuestos(this.txtRUT.Text))
                {

                    string rut = this.txtRUT.Text;

                    if (controladoraWeb.BajaProveedor(rut))
                    {
                        this.limpiar();
                        this.lblMensajes.Text = "Proveedor eliminado con éxito";
                        this.listarProveedores();
                    }
                    else
                    {
                        this.lblMensajes.Text = "No existe un proveedor con ese id";
                    }
                }
                else
                {
                    this.lblMensajes.Text = "No se puede eliminar porque el RUT está en la tabla Repuestos";
                }
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatos())
            {
                string rut = this.txtRUT.Text;
                string nombre = this.txtNombre.Text;
                string mail = this.txtMail.Text;
                string telefono = this.txtTelefono.Text;

                Proveedor unProveedor = new Proveedor(rut, nombre, mail, telefono);
                if (controladoraWeb.ModificarProveedor(unProveedor))
                {
                    this.lblMensajes.Text = "Proveedor modificado con éxito.";
                    this.listarProveedores();
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

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }
        #endregion
    }
}