using Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Taller.Web.Paginas
{
    public partial class wfrmMecanico : System.Web.UI.Page
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
                this.listarMecanicos();
            }
        }

        protected void lstMecanicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstMecanicos.SelectedIndex > -1)
            {
                string linea = this.lstMecanicos.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int id = int.Parse(partes[0]);
                this.cargar(id);
            }
            this.lstMecanicos.SelectedIndex = -1;
        }
        #endregion

        #region Métodos auxiliares
        private bool faltanDatos()
        {
            if (this.txtCedula.Text == "" || this.txtNombre.Text == "" || this.txtTelefono.Text == "" || this.txtValorHora.Text == "" || this.ddlActivo.Text == "")
            {
                return true;
            }
            return false;
        }

        private void cargar(int pId)
        {
            Mecanico unMecanico = controladoraWeb.BuscarMecanico(pId);

            this.txtId.Text = Convert.ToString(unMecanico.Id);
            this.txtNombre.Text = unMecanico.Nombre;
            this.txtCedula.Text = unMecanico.Cedula;
            this.txtTelefono.Text = unMecanico.Telefono;

            DateTime fechae = Convert.ToDateTime(unMecanico.FechaIngreso);
            this.dtpFechaIngreso.Text = fechae.ToString("yyyy-MM-dd");

            this.txtValorHora.Text = Convert.ToString(unMecanico.ValorHora);
            this.ddlActivo.Text = unMecanico.Activo;
        }

        private void limpiar()
        {
            this.txtId.Text = "";
            this.txtNombre.Text = "";
            this.txtCedula.Text = "";
            this.txtTelefono.Text = "";
            this.dtpFechaIngreso.Text = "";
            this.txtValorHora.Text = "";
        }

        private void listarMecanicos()
        {
            this.lstMecanicos.DataSource = null;
            this.lstMecanicos.DataSource = controladoraWeb.ListaMecanicos();
            this.lstMecanicos.DataBind();
        }

        private bool mecanicosAsignados()
        {
            int id = int.Parse(this.txtId.Text);
            Mecanico unMecanico = controladoraWeb.BuscarMecanico(id);
            foreach (Reparacion unaReparacion in controladoraWeb.ListaReparaciones())
            {
                if (unMecanico.Id == unaReparacion.IdMecanico)
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
                int id = 1;
                string nombre = this.txtNombre.Text;
                string cedula = this.txtCedula.Text;
                string telefono = this.txtTelefono.Text;

                DateTime fechai = Convert.ToDateTime(this.dtpFechaIngreso.Text);
                DateTime fechaingreso = fechai.Date;

                int valorhora = int.Parse(this.txtValorHora.Text);
                string activo = this.ddlActivo.Text;

                Mecanico unMecanico = new Mecanico(id, nombre, cedula, telefono, fechaingreso, valorhora, activo);
                if (controladoraWeb.AltaMecanico(unMecanico))
                {
                    this.lblMensajes.Text = "Mecánico ingresado con éxito.";
                    this.listarMecanicos();
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
            if (!this.mecanicosAsignados())
            {
                if (this.txtId.Text != "")
                {
                    int id = int.Parse(this.txtId.Text);

                    if (controladoraWeb.BajaMecanico(id))
                    {
                        this.limpiar();
                        this.lblMensajes.Text = "Mecánico eliminado con éxito";
                        this.listarMecanicos();
                    }
                    else
                    {
                        this.lblMensajes.Text = "No existe un mecánico con ese id";
                    }
                }
            }
            else
            {
                this.lblMensajes.Text = "No se puede eliminar porque el mecánico está asignado en una reparación";
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatos())
            {
                int id = 1;
                string nombre = this.txtNombre.Text;
                string cedula = this.txtCedula.Text;
                string telefono = this.txtTelefono.Text;

                DateTime fechai = Convert.ToDateTime(this.dtpFechaIngreso.Text);
                DateTime fechaingreso = fechai.Date;

                int valorhora = int.Parse(this.txtValorHora.Text);
                string activo = this.ddlActivo.Text;

                Mecanico unMecanico = new Mecanico(id, nombre, cedula, telefono, fechaingreso, valorhora, activo);
                if (controladoraWeb.ModificarMecanico(unMecanico))
                {
                    this.lblMensajes.Text = "Mecánico modificado con éxito.";
                    this.limpiar();
                }
                else
                {
                    this.lblMensajes.Text = "No se pudo modificar. Intentelo de nuevo más tarde.";
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