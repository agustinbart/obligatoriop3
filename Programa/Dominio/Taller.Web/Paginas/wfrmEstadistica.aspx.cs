using Modelo;
using Modelo.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Taller.Web.Paginas
{
    public partial class wfrmEstadistica : System.Web.UI.Page
    {
        Controladora.ControladoraWeb controladoraWeb = new Controladora.ControladoraWeb();

        #region Load & SelectedIndex
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["IdAdmin"] == null)
            {
                Response.Redirect("~/");
            }

            this.lstRepuestosMasVendidos.DataSource = null;
            this.lstRepuestosMasVendidos.DataSource = controladoraWeb.ObtenerRepuestosMasVendidos();
            this.lstRepuestosMasVendidos.DataBind();
        }

        protected void lstReparacionesCompletas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lstReparacionesCompletas.SelectedIndex = -1;
        }

        protected void lstReparacionesPendientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lstReparacionesPendientes.SelectedIndex = -1;
        }

        protected void lstRepuestosMasVendidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lstRepuestosMasVendidos.SelectedIndex = -1;
        }
        #endregion

        #region Botones
        protected void btnConsulta1_Click(object sender, EventArgs e)
        {
            if (this.dtpFecha1C1.Text != "" && this.dtpFecha2C1.Text != "")
            {
                DateTime fecha1a = Convert.ToDateTime(this.dtpFecha1C1.Text);
                DateTime fecha1 = fecha1a.Date;

                DateTime fecha2a = Convert.ToDateTime(this.dtpFecha2C1.Text);
                DateTime fecha2 = fecha2a.Date;

                this.lstReparacionesCompletas.DataSource = null;
                this.lstReparacionesCompletas.DataSource = controladoraWeb.ObtenerReparacionesEntreFechas(fecha1, fecha2);
                this.lstReparacionesCompletas.DataBind();
            }
            else
            {
                this.lblMensajesCompletas.Text = "Ingrese un rango de fechas.";
            }
        }

        protected void btnConsulta2_Click(object sender, EventArgs e)
        {
            if (this.dtpFecha1C2.Text != "" && this.dtpFecha2C2.Text != "")
            {
                DateTime fecha1b = Convert.ToDateTime(this.dtpFecha1C2.Text);
                DateTime fecha1 = fecha1b.Date;

                DateTime fecha2b = Convert.ToDateTime(this.dtpFecha2C2.Text);
                DateTime fecha2 = fecha2b.Date;

                this.lstReparacionesPendientes.DataSource = null;
                this.lstReparacionesPendientes.DataSource = controladoraWeb.ObtenerReparacionesPendientesEntreFechas(fecha1, fecha2);
                this.lstReparacionesPendientes.DataBind();
            }
            else
            {
                this.lblMensajesPendientes.Text = "Ingrese un rango de fechas.";
            }
        }
        #endregion
    }
}