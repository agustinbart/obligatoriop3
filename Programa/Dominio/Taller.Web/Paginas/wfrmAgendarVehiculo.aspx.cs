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
    public partial class wfrmAgendarVehiculo : System.Web.UI.Page
    {
        Controladora.ControladoraWeb controladoraWeb = new Controladora.ControladoraWeb();

        #region Load & SelectedIndex
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["IdUsuario"] == null)
            {
                Response.Redirect("~/Paginas/wfrmLogin");
            }

            if (!this.IsPostBack)
            {
                HttpCookie idCookie = Request.Cookies["IdUsuario"];
                string cookiesvalue = Server.HtmlEncode(idCookie.Value);
                this.txtIdCliente.Text = Server.HtmlEncode(idCookie.Value);
                this.listarVehiculos();
            }
        }

        protected void ddlVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Vehiculo unVehiculo = controladoraWeb.BuscarVehiculo(int.Parse(ddlVehiculos.SelectedValue[0].ToString()));
        }
        #endregion

        #region Métodos auxiliares
        private bool faltanDatos()
        {
            if (this.txtDescripcionProblema.Text == "" || this.dtpFecha.Text == "")
            {
                return true;
            }
            return false;
        }

        private void limpiar()
        {
            this.txtId.Text = "";
            this.dtpFecha.Text = "";
            this.txtDescripcionProblema.Text = "";
        }

        private List<Vehiculo> clienteVehiculos()
        {
            List<Vehiculo> vehiculosDeCliente = new List<Vehiculo>();
            foreach (Cliente_Vehiculo unClienteVehiculo in controladoraWeb.ListaClienteVehiculos())
            {
                foreach (Vehiculo unVehiculo in controladoraWeb.ListaVehiculos())
                {
                    if (unClienteVehiculo.CliCod == int.Parse(this.txtIdCliente.Text) && unClienteVehiculo.VehiculoMatricula == unVehiculo.Matricula)
                    {
                        vehiculosDeCliente.Add(unVehiculo);
                    }
                }
            }
            return vehiculosDeCliente;
        }

        private void listarVehiculos()
        {
            this.ddlVehiculos.DataSource = null;
            this.ddlVehiculos.DataSource = this.clienteVehiculos();
            this.ddlVehiculos.DataBind();
        }
        #endregion

        #region Botones
        protected void btnAgendar_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatos())
            {
                string linea = this.ddlVehiculos.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                string matricula = partes[1];

                int id = 1;

                DateTime fec = Convert.ToDateTime(this.dtpFecha.Text);
                DateTime fecha = fec.Date;
                string descripcion = this.txtDescripcionProblema.Text;
                int idcliente = int.Parse(this.txtIdCliente.Text);
                string aceptado = "N";

                Reserva unaReserva = new Reserva(id, fecha, descripcion, idcliente, matricula, aceptado);
                if (controladoraWeb.AltaReserva(unaReserva))
                {
                    this.lblMensajes.Text = "Solicitud de reserva enviada con éxito.";
                    this.limpiar();
                }
                else
                {
                    this.lblMensajes.Text = "No se pudo enviar la reserva. Intentelo de nuevo más tarde.";
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