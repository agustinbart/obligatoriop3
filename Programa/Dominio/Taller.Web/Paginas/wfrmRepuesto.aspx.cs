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
    public partial class wfrmRepuesto : System.Web.UI.Page
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
                this.listarRepuestos();
                this.listarProveedores();
            }
        }
        protected void lstRepuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstRepuestos.SelectedIndex > -1)
            {
                string linea = this.lstRepuestos.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                string codigo = partes[0];
                this.cargar(codigo);
            }
            this.lstRepuestos.SelectedIndex = -1;
        }

        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string linea = this.ddlProveedor.SelectedItem.ToString();
            string[] partes = linea.Split(' ');
            string id = partes[0];

            Proveedor unProveedor = controladoraWeb.BuscarProveedor(id);
        }
        #endregion

        #region Métodos auxiliares
        private void limpiar()
        {
            this.txtCodigo.Text = "";
            this.txtCosto.Text = "";
            this.txtDescripcion.Text = "";
            this.ddlProveedor.SelectedIndex = -1;
        }

        private void listarRepuestos()
        {
            this.lstRepuestos.DataSource = null;
            this.lstRepuestos.DataSource = controladoraWeb.ListaRepuestos();
            this.lstRepuestos.DataBind();
        }

        private void cargar(string pCodigo)
        {
            Repuesto unRepuesto = controladoraWeb.BuscarRepuesto(pCodigo);
            Proveedor unProveedor = controladoraWeb.BuscarProveedor(unRepuesto.RUTProveedor);

            this.txtCodigo.Text = unRepuesto.Codigo;
            this.txtCosto.Text = Convert.ToString(unRepuesto.Costo);
            this.txtDescripcion.Text = unRepuesto.Descripcion;
            this.ddlTipo.Text = unRepuesto.Tipo;
            this.ddlProveedor.Text = Convert.ToString(unProveedor);
        }

        private void listarProveedores()
        {
            this.ddlProveedor.DataSource = null;
            this.ddlProveedor.DataSource = controladoraWeb.ListaProveedores();
            this.ddlProveedor.DataBind();
        }

        private bool faltanDatos()
        {
            if(this.txtCodigo.Text == "" || this.txtCosto.Text == "" || this.txtDescripcion.Text == "")
            {
                return true;
            }
            return false;
        }

        private bool repuestosAsignados()
        {
            string codigo = this.txtCodigo.Text;
            Repuesto unRepuesto = controladoraWeb.BuscarRepuesto(codigo);
            foreach (Reparacion_Repuestos unaRepRepuestos in controladoraWeb.ListaReparacion_Repuestos())
            {
                if (unRepuesto.Codigo == unaRepRepuestos.RepuestoCod)
                {
                    return true;
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
                string codigo = this.txtCodigo.Text;
                double costo = Double.Parse(this.txtCosto.Text);
                string descripcion = this.txtDescripcion.Text;
                string tipo = this.ddlTipo.Text;

                string lineaR = this.ddlProveedor.SelectedItem.ToString();
                string[] partesR = lineaR.Split(' ');
                string proveedor = partesR[0];

                Repuesto unRepuesto = new Repuesto(codigo, descripcion, costo, tipo, proveedor);
                if (controladoraWeb.AltaRepuesto(unRepuesto))
                {
                    this.lblMensajes.Text = "Repuesto ingresado con éxito";
                    this.limpiar();
                    this.listarRepuestos();
                }
                else
                {
                    this.lblMensajes.Text = "Ya existe un repuesto con ese código";
                }
            }
            else
            {
                this.lblMensajes.Text = "Faltan datos";
            }
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            if (!this.repuestosAsignados())
            {
                if (this.txtCodigo.Text != "")
                {
                    string codigo = this.txtCodigo.Text;
                    if (controladoraWeb.BajaRepuesto(codigo))
                    {
                        this.limpiar();
                        this.lblMensajes.Text = "Repuesto eliminado con éxito";
                        this.listarRepuestos();
                    }
                    else
                    {
                        this.txtCodigo.Focus();
                        this.lblMensajes.Text = "No existe un repuesto con ese código";
                    }
                }
            }
            else
            {
                this.lblMensajes.Text = "No se puede eliminar el repuesto porque está asignado a una reparación";
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatos())
            {
                string codigo = this.txtCodigo.Text;
                double costo = Double.Parse(this.txtCosto.Text);
                string descripcion = this.txtDescripcion.Text;
                string tipo = this.ddlTipo.Text;

                string lineaR = this.ddlProveedor.SelectedItem.ToString();
                string[] partesR = lineaR.Split(' ');
                string proveedor = partesR[0];

                Repuesto unRepuesto = new Repuesto(codigo, descripcion, costo, tipo, proveedor);
                if (controladoraWeb.ModificarRepuesto(unRepuesto))
                {
                    this.lblMensajes.Text = "Repuesto modificado con éxito";
                    this.limpiar();
                    this.listarRepuestos();
                }
                else
                {
                    this.lblMensajes.Text = "Repuesto no encontrado";
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