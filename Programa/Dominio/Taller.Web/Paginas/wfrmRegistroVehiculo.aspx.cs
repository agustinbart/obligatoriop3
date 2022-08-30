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
    public partial class wfrmRegistroVehiculo : System.Web.UI.Page
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

        protected void lstVehiculos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstVehiculos.SelectedIndex > -1)
            {
                string linea = this.lstVehiculos.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int id = Convert.ToInt16(partes[0]);
                this.cargar(id);
            }
            this.lstVehiculos.SelectedIndex = -1;
        }
        #endregion

        #region Métodos auxiliares
        private void limpiar()
        {
            this.txtId.Text = "";
            this.txtMatricula.Text = "";
            this.txtMarca.Text = "";
            this.txtModelo.Text = "";
            this.txtAnio.Text = "";
            this.txtColor.Text = "";
        }
        private bool faltanDatos()
        {
            if (this.txtMatricula.Text == "" || this.txtMarca.Text == "" || this.txtModelo.Text == "" || this.txtAnio.Text == "" || this.txtColor.Text == "")
            {
                return true;
            }
            return false;
        }

        private void cargar(int pId)
        {
            Vehiculo unVehiculo = controladoraWeb.BuscarVehiculo(pId);

            this.txtId.Text = Convert.ToString(unVehiculo.Id);
            this.txtMatricula.Text = unVehiculo.Matricula;
            this.txtMarca.Text = unVehiculo.Marca;
            this.txtModelo.Text = unVehiculo.Modelo;
            this.txtAnio.Text = Convert.ToString(unVehiculo.Anio);
            this.txtColor.Text = unVehiculo.Color;
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
            this.lstVehiculos.DataSource = null;
            this.lstVehiculos.DataSource = this.clienteVehiculos();
            this.lstVehiculos.DataBind();
        }

        private bool vehiculosAsignados()
        {
            string matricula = this.txtMatricula.Text;
            Vehiculo unVehiculo = controladoraWeb.BuscarVehiculoPorMatricula(matricula);
            foreach (Reparacion unaReparacion in controladoraWeb.ListaReparaciones())
            {
                if (unVehiculo.Matricula == unaReparacion.Matricula)
                {
                    return true;
                }
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
                string matricula = this.txtMatricula.Text;
                string marca = this.txtMarca.Text;
                string modelo = this.txtModelo.Text;
                int anio = int.Parse(this.txtAnio.Text);
                string color = this.txtColor.Text;

                HttpCookie idCookie = Request.Cookies["IdUsuario"];
                string cookiesvalue = Server.HtmlEncode(idCookie.Value);
                int idcliente = int.Parse(Server.HtmlEncode(idCookie.Value));

                DateTime fecha = DateTime.Today;

                Vehiculo unVehiculo = new Vehiculo(id, matricula, marca, modelo, anio, color);
                if (controladoraWeb.AltaVehiculo(unVehiculo))
                {
                    Cliente_Vehiculo unClienteVehiculo = new Cliente_Vehiculo(idcliente, matricula, fecha);
                    if (controladoraWeb.AltaClienteVehiculo(unClienteVehiculo))
                    {
                        this.lblMensajes.Text = "Vehículo registrado con éxito.";
                        this.limpiar();
                        this.listarVehiculos();
                    }
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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.txtId.Text != "")
            {
                int id = int.Parse(this.txtId.Text);
                string matricula = this.txtMatricula.Text;
                Cliente_Vehiculo unClienteVehiculo = controladoraWeb.BuscarClienteVehiculo(id, matricula);
                int idcliente = int.Parse(this.txtIdCliente.Text);

                if (!this.vehiculosAsignados())
                {
                    if (controladoraWeb.BajaClienteVehiculo(idcliente, matricula))
                    {
                        if (controladoraWeb.BajaVehiculo(id))
                        {
                            this.limpiar();
                            this.listarVehiculos();
                            this.lblMensajes.Text = "Vehiculo eliminado con éxito";
                        }
                        else
                        {
                            this.lblMensajes.Text = "No existe un vehiculo con ese id";
                        }
                    }
                }
                else
                {
                    this.lblMensajes.Text = "No se puede eliminar ya que tiene una reparación asignada";
                }
            }
        }
        #endregion
    }
}