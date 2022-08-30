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
    public partial class wfrmReparacion : System.Web.UI.Page
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
                this.listarReparaciones();
                this.listarVehiculos();
                this.listarMecanicos();
                this.listarReservas();
                this.listarRepuestos();
                this.listarReparacionRepuestos();
                this.listarReparacionesPendientes();
            }

            this.txtAnio.Text = DateTime.Now.ToString("yyyy");
        }

        protected void ddlVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string linea = this.ddlVehiculo.SelectedItem.ToString();
            string[] partes = linea.Split(' ');
            int id = int.Parse(partes[0]);

            Vehiculo unVehiculo = controladoraWeb.BuscarVehiculo(id);
        }

        protected void ddlMecanico_SelectedIndexChanged(object sender, EventArgs e)
        {
            string linea = this.ddlMecanico.SelectedItem.ToString();
            string[] partes = linea.Split(' ');
            int id = int.Parse(partes[0]);

            Mecanico unMecanico = controladoraWeb.BuscarMecanico(id);
        }

        protected void ddlRepuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string linea = this.ddlRepuestos.SelectedItem.ToString();
            string[] partes = linea.Split(' ');
            string cod = partes[0];

            Repuesto unRepuesto = controladoraWeb.BuscarRepuesto(cod);

            this.txtCostoUnitario.Text = Convert.ToString(unRepuesto.Costo);
        }

        protected void lstReparaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.limpiar();
            if (this.lstReparaciones.SelectedIndex > -1)
            {
                string linea = this.lstReparaciones.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int id = int.Parse(partes[0]);
                int anio = int.Parse(partes[1]);
                this.cargar(id, anio);
                this.cargarRepHoras(id, anio);
                this.cargarRepRepuestos(id, anio);
                this.listarReparacionRepuestos();
            }
            this.lstReparaciones.SelectedIndex = -1;
        }

        protected void lstReservas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.limpiar();
            if (this.lstReservas.SelectedIndex > -1)
            {
                string linea = this.lstReservas.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int id = int.Parse(partes[0]);
                this.cargarReserva(id);
            }
            this.lstReservas.SelectedIndex = -1;
        }

        protected void lstPendientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.limpiar();
            if (this.lstPendientes.SelectedIndex > -1)
            {
                string linea = this.lstPendientes.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int id = int.Parse(partes[0]);
                this.cargarReparacionPendiente(id);
            }
            this.lstPendientes.SelectedIndex = -1;
        }

        protected void lstReparacionRepuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.limpiar();
            if (this.lstReparacionRepuestos.SelectedIndex > -1)
            {
                string linea = this.lstReparacionRepuestos.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                int id = int.Parse(partes[0]);
                int anio = int.Parse(partes[1]);
                string repuestocod = partes[2];
                this.cargarReparacionRepuesto(id, anio, repuestocod);
            }
            this.lstReparacionRepuestos.SelectedIndex = -1;
        }
        #endregion

        #region Métodos auxiliares
        private void listarVehiculos()
        {
            this.ddlVehiculo.DataSource = null;
            this.ddlVehiculo.DataSource = controladoraWeb.ListaVehiculos();
            this.ddlVehiculo.DataBind();
        }

        private List<Mecanico> mecanicosActivos() // Filtrar mecánicos activos.
        {
            List<Mecanico> mecanicosActivos = new List<Mecanico>();
            foreach (Mecanico unMecanico in controladoraWeb.ListaMecanicos())
            {
                if (unMecanico.Activo == "S")
                {
                    mecanicosActivos.Add(unMecanico);
                }
            }

            return mecanicosActivos;
        }
        private void listarMecanicos()
        {

            this.ddlMecanico.DataSource = null;
            this.ddlMecanico.DataSource = mecanicosActivos();
            this.ddlMecanico.DataBind();
        }

        private void listarReparaciones()
        {
            this.lstReparaciones.DataSource = null;
            this.lstReparaciones.DataSource = controladoraWeb.ListaReparaciones();
            this.lstReparaciones.DataBind();
        }

        private List<Reserva> reservasAceptadas() // Filtrar reservas aceptadas.
        {
            List<Reserva> aceptadas = new List<Reserva>();

            foreach(Reserva unaReserva in controladoraWeb.ListaReservas())
            {
                if(unaReserva.Aceptado == "S")
                {
                    aceptadas.Add(unaReserva);
                }
            }

            return aceptadas;
        }

        private List<Reserva> reservasPendientes() // Filtrar reservas pendientes.
        {
            List<Reserva> pendientes = new List<Reserva>();

            foreach(Reserva unaReserva in controladoraWeb.ListaReservas())
            {
                if(unaReserva.Aceptado == "N")
                {
                    pendientes.Add(unaReserva);
                }
            }

            return pendientes;
        }
        private void listarReservas()
        {
            this.lstReservas.DataSource = null;
            this.lstReservas.DataSource = this.reservasPendientes();
            this.lstReservas.DataBind();
        }

        private void listarRepuestos()
        {
            this.ddlRepuestos.DataSource = null;
            this.ddlRepuestos.DataSource = controladoraWeb.ListaRepuestos();
            this.ddlRepuestos.DataBind();
        }

        private List<Reparacion_Repuestos> listaRepuestos()
        {
            List<Reparacion_Repuestos> repuestos = new List<Reparacion_Repuestos>();
            if (this.lstReparaciones.SelectedIndex > -1)
            {
                foreach (Reparacion_Repuestos unReparacionRepuesto in controladoraWeb.ListaReparacion_Repuestos())
                {
                    if (unReparacionRepuesto.IdReparacion == int.Parse(this.txtIdRepuestos.Text) && unReparacionRepuesto.Anio == int.Parse(this.txtAnioRepuestos.Text))
                    {
                        repuestos.Add(unReparacionRepuesto);
                    }
                }
            }
            return repuestos;
        }

        private void listarReparacionRepuestos()
        {
            this.lstReparacionRepuestos.DataSource = null;
            this.lstReparacionRepuestos.DataSource = this.listaRepuestos();
            this.lstReparacionRepuestos.DataBind();
        }

        private void listarReparacionesPendientes()
        {
            this.lstPendientes.DataSource = null;
            this.lstPendientes.DataSource = this.reservasAceptadas();
            this.lstPendientes.DataBind();
        }
        private void cargarReserva(int pId)
        {
            Reserva unaReserva = controladoraWeb.BuscarReserva(pId);

            this.txtDescripcionEntrada.Text = unaReserva.DescripcionProblema;
            this.txtIdReserva.Text = Convert.ToString(unaReserva.Id);
            this.txtIdCliente.Text = Convert.ToString(unaReserva.IdCliente);

            DateTime fechae = Convert.ToDateTime(unaReserva.Fecha);
            this.dtpFechaEntrada.Text = fechae.ToString("yyyy-MM-dd");

            string lineaR = this.lstReservas.SelectedItem.ToString();
            string[] partesR = lineaR.Split(' ');
            string idR = partesR[3];
            this.ddlVehiculo.SelectedValue = Convert.ToString(controladoraWeb.BuscarVehiculoPorMatricula(idR));
        }

        private void cargarReparacionPendiente(int pId)
        {
            Reserva unaReserva = controladoraWeb.BuscarReserva(pId);

            this.txtDescripcionEntrada.Text = unaReserva.DescripcionProblema;
            this.txtIdReserva.Text = Convert.ToString(unaReserva.Id);
            this.txtIdCliente.Text = Convert.ToString(unaReserva.IdCliente);

            DateTime fechae = Convert.ToDateTime(unaReserva.Fecha);
            this.dtpFechaEntrada.Text = fechae.ToString("yyyy-MM-dd");

            string lineaR = this.lstPendientes.SelectedItem.ToString();
            string[] partesR = lineaR.Split(' ');
            string idR = partesR[3];
            this.ddlVehiculo.SelectedValue = Convert.ToString(controladoraWeb.BuscarVehiculoPorMatricula(idR));
        }
        private void cargar(int pId, int pAnio)
        {
            Reparacion unaReparacion = controladoraWeb.BuscarReparacion(pId, pAnio);

            this.txtId.Text = Convert.ToString(unaReparacion.Id);
            this.txtAnio.Text = Convert.ToString(unaReparacion.Anio);

            DateTime fechae = Convert.ToDateTime(unaReparacion.FechaEntrada);
            this.dtpFechaEntrada.Text = fechae.ToString("yyyy-MM-dd");

            DateTime fechas = Convert.ToDateTime(unaReparacion.FechaSalida);
            this.dtpFechaSalida.Text = fechas.ToString("yyyy-MM-dd");

            this.txtDescripcionEntrada.Text = unaReparacion.DescripcionEntrada;
            this.txtDescripcionSalida.Text = unaReparacion.DescripcionSalida;
            this.txtKmEntrada.Text = Convert.ToString(unaReparacion.KmEntrada);

            string lineaR = this.lstReparaciones.SelectedItem.ToString();
            string[] partesR = lineaR.Split(' ');
            int idR = int.Parse(partesR[3]);
            this.ddlMecanico.SelectedValue = Convert.ToString(controladoraWeb.BuscarMecanico(idR));

            string idV = partesR[2];
            this.ddlVehiculo.SelectedValue = Convert.ToString(controladoraWeb.BuscarVehiculoPorMatricula(idV));
        }

        public void cargarRepHoras(int pId, int pAnio)
        {
            Reparacion unaReparacion = controladoraWeb.BuscarReparacion(pId, pAnio);
            Reparacion_Horas unaReparacionHoras = controladoraWeb.BuscarReparacionHoras(pId, pAnio);

            this.txtIdHoras.Text = Convert.ToString(unaReparacion.Id);
            this.txtAnioHoras.Text = Convert.ToString(unaReparacion.Anio);

            string lineaR = this.lstReparaciones.SelectedItem.ToString();
            string[] partesR = lineaR.Split(' ');
            int idM = int.Parse(partesR[3]);
            Mecanico mecanico = controladoraWeb.BuscarMecanico(idM);
            this.txtIdMecanicoHoras.Text = Convert.ToString(mecanico);

            if (unaReparacionHoras.Horas != 0)
            {
                this.txtHoras.Text = Convert.ToString(unaReparacionHoras.Horas);
            }

            this.txtCostoHora.Text = Convert.ToString(mecanico.ValorHora);
        }

        public void cargarRepRepuestos(int pId, int pAnio)
        {
            Reparacion unaReparacion = controladoraWeb.BuscarReparacion(pId, pAnio);

            this.txtIdRepuestos.Text = Convert.ToString(unaReparacion.Id);
            this.txtAnioRepuestos.Text = Convert.ToString(unaReparacion.Anio);

        }

        public void cargarReparacionRepuesto(int pId, int pAnio, string pRepuestoCod)
        {
            Reparacion unaReparacion = controladoraWeb.BuscarReparacion(pId, pAnio);
            Reparacion_Repuestos unReparacionRepuesto = controladoraWeb.BuscarReparacionRepuesto(pId, pAnio, pRepuestoCod);

            this.txtIdRepuestos.Text = Convert.ToString(unReparacionRepuesto.IdReparacion);
            this.txtAnioRepuestos.Text = Convert.ToString(unReparacionRepuesto.Anio);

            string lineaR = this.lstReparacionRepuestos.SelectedItem.ToString();
            string[] partesR = lineaR.Split(' ');
            string idR = partesR[2];
            this.ddlRepuestos.SelectedValue = Convert.ToString(controladoraWeb.BuscarRepuesto(idR));

            this.txtCantidadRepuesto.Text = Convert.ToString(unReparacionRepuesto.Cantidad);
            this.txtCostoUnitario.Text = Convert.ToString(unReparacionRepuesto.CostoUnitario);
        }
        private bool faltanDatos()
        {
            if (this.txtId.Text == "" || this.txtDescripcionEntrada.Text == "" || this.txtKmEntrada.Text == "")
            {
                return true;
            }
            return false;
        }

        private bool faltanDatosReparacionRepuestos()
        {
            if (this.txtCantidadRepuesto.Text == "")
            {
                return true;
            }
            return false;
        }

        private bool faltanDatosReparacionHoras()
        {
            if (this.txtHoras.Text == "")
            {
                return true;
            }
            return false;
        }
        private void limpiar()
        {
            this.txtId.Text = "";
            this.txtAnio.Text = "";
            this.txtDescripcionEntrada.Text = "";
            this.txtDescripcionSalida.Text = "";
            this.txtKmEntrada.Text = "";
            this.ddlMecanico.SelectedIndex = 0;
            this.ddlVehiculo.SelectedIndex = 0;
            this.dtpFechaEntrada.Text = "";
            this.dtpFechaSalida.Text = "";

            this.txtIdHoras.Text = "";
            this.txtIdMecanicoHoras.Text = "";
            this.txtHoras.Text = "";
            this.txtCostoHora.Text = "";
            this.txtAnioHoras.Text = "";

            this.txtIdRepuestos.Text = "";
            this.txtAnioRepuestos.Text = "";
            this.ddlRepuestos.SelectedIndex = 0;
            this.txtCantidadRepuesto.Text = "";
            this.txtCostoUnitario.Text = "";
        }
        #endregion

        #region Botones Reparación
        protected void btnAlta_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatos())
            {
                int id = int.Parse(this.txtId.Text);
                int anio = int.Parse(this.txtAnio.Text);

                string lineaVehiculo = this.ddlVehiculo.SelectedItem.ToString();
                string[] partesVehiculo = lineaVehiculo.Split(' ');
                string matricula = partesVehiculo[1];

                DateTime fechae = Convert.ToDateTime(this.dtpFechaEntrada.Text);
                DateTime fechaentrada = fechae.Date;

                DateTime fechas = Convert.ToDateTime(this.dtpFechaSalida.Text);
                DateTime fechasalida = fechas.Date;

                string lineaMecanico = this.ddlMecanico.SelectedItem.ToString();
                string[] partesMecanico = lineaMecanico.Split(' ');
                int idMecanico = Convert.ToInt16(partesMecanico[0]);

                string descripcionentrada = this.txtDescripcionEntrada.Text;
                string descripcionsalida = this.txtDescripcionSalida.Text;

                int kmentrada = int.Parse(this.txtKmEntrada.Text);

                Reparacion unaReparacion = new Reparacion(id, anio, matricula, fechaentrada, fechasalida, idMecanico, descripcionentrada, descripcionsalida, kmentrada);
                if (controladoraWeb.AltaReparacion(unaReparacion))
                {
                    this.lblMensajes.Text = "Registrado con éxito.";
                    this.limpiar();
                    this.listarReparaciones();
                    this.eliminarReserva();
                    this.listarReparacionesPendientes();
                }
                else
                {
                    this.lblMensajes.Text = "Ya existe un reparación con esa id.";
                }
            }
            else
            {
                this.lblMensajes.Text = "Faltan datos";
            }
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {

            Reparacion_Horas unaReparacionHoras = controladoraWeb.BuscarReparacionHoras(int.Parse(this.txtIdHoras.Text), int.Parse(this.txtAnioHoras.Text));
            Reparacion_Repuestos unReparacionRepuesto = controladoraWeb.BuscarReparacionRepuesto(int.Parse(this.txtIdRepuestos.Text), int.Parse(this.txtAnioRepuestos.Text), this.ddlRepuestos.SelectedValue[0].ToString()); ;

            if (this.txtId.Text != "" && this.txtAnio.Text != "")
            {
                if (int.Parse(this.txtId.Text) == unaReparacionHoras.IdReparacion && int.Parse(this.txtAnio.Text) == unaReparacionHoras.Anio || int.Parse(this.txtId.Text) == unReparacionRepuesto.IdReparacion && int.Parse(this.txtAnio.Text) == unReparacionRepuesto.Anio)
                {
                    this.lblMensajes.Text = "No se puede eliminar la reparación porque tiene repuestos u horas asignadas";
                }
                else
                {
                    int id = int.Parse(this.txtId.Text);
                    int anio = int.Parse(this.txtAnio.Text);
                    if (controladoraWeb.BajaReparacion(id, anio))
                    {
                        this.lblMensajes.Text = "Reparación eliminada con éxito";
                        this.limpiar();
                        this.listarReparaciones();
                    }
                    else
                    {
                        this.lblMensajes.Text = "La reparación no existe";
                    }
                }
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatos())
            {
                int id = int.Parse(this.txtId.Text);
                int anio = int.Parse(this.txtAnio.Text);

                string lineaVehiculo = this.ddlVehiculo.SelectedItem.ToString();
                string[] partesVehiculo = lineaVehiculo.Split(' ');
                string matricula = partesVehiculo[1];

                DateTime fechae = Convert.ToDateTime(this.dtpFechaEntrada.Text);
                DateTime fechaentrada = fechae.Date;

                DateTime fechas = Convert.ToDateTime(this.dtpFechaSalida.Text);
                DateTime fechasalida = fechas.Date;

                string lineaMecanico = this.ddlMecanico.SelectedItem.ToString();
                string[] partesMecanico = lineaMecanico.Split(' ');
                int idMecanico = Convert.ToInt16(partesMecanico[0]);

                string descripcionentrada = this.txtDescripcionEntrada.Text;
                string descripcionsalida = this.txtDescripcionSalida.Text;

                int kmentrada = int.Parse(this.txtKmEntrada.Text);

                Reparacion unaReparacion = new Reparacion(id, anio, matricula, fechaentrada, fechasalida, idMecanico, descripcionentrada, descripcionsalida, kmentrada);
                if (controladoraWeb.ModificarReparacion(unaReparacion))
                {
                    this.lblMensajes.Text = "Modificado con éxito.";
                    this.limpiar();
                    this.listarReparaciones();
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

        #region Botones Reserva
        protected void eliminarReserva()
        {
            if (this.txtIdReserva.Text != "")
            {
                int id = int.Parse(this.txtIdReserva.Text);

                if (controladoraWeb.BajaReserva(id))
                {
                    this.limpiar();
                    this.lblMensajesReserva.Text = "Reserva eliminada con éxito";
                    this.listarReservas();
                }
                else
                {
                    this.lblMensajesReserva.Text = "La reserva no existe";
                }
            }
            else
            {
                this.lblMensajesReserva.Text = "Debe seleccionar una reserva de la lista";
            }
        }
        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            this.eliminarReserva();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtIdReserva.Text);

            string linea = this.ddlVehiculo.SelectedItem.ToString();
            string[] partes = linea.Split(' ');
            string matricula = partes[1];

            DateTime fec = Convert.ToDateTime(this.dtpFechaEntrada.Text);
            DateTime fecha = fec.Date;

            string descripcion = this.txtDescripcionEntrada.Text;

            int idcliente = int.Parse(this.txtIdCliente.Text);

            string aceptado = "S";

            Reserva unaReserva = new Reserva(id, fecha, descripcion, idcliente, matricula, aceptado);
            if (controladoraWeb.ModificarReserva(unaReserva))
            {
                this.lblMensajes.Text = "Reserva aceptada con éxito.";
                this.limpiar();
                this.listarReservas();
                this.listarReparacionesPendientes();
            }
            else
            {
                this.lblMensajes.Text = "No se pudo aceptar la reserva. Intentelo de nuevo más tarde.";
            }
        }
        #endregion

        #region Botones Reparación Horas
        protected void btnAgregarHoras_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatosReparacionHoras())
            {
                int idreparacion = int.Parse(this.txtIdHoras.Text);
                int anio = int.Parse(this.txtAnioHoras.Text);

                string[] partesRep = this.txtIdMecanicoHoras.Text.Split(' ');
                int idmecanico = int.Parse(partesRep[0]);

                int horas = int.Parse(this.txtHoras.Text);
                int costohora = int.Parse(this.txtCostoHora.Text);

                Reparacion_Horas unaReparacionHoras = new Reparacion_Horas(idreparacion, anio, idmecanico, horas, costohora);
                if (controladoraWeb.AltaReparacionHoras(unaReparacionHoras))
                {
                        this.lblMensajesHoras.Text = "Horas ingresadas con éxito";
                        this.limpiar();
                }
                else
                {
                    this.lblMensajesHoras.Text = "Ya existe un registro con ese código";
                }
            }
            else
            {
                this.lblMensajesHoras.Text = "Faltan datos";
            }
        }

        protected void btnModificarHoras_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatosReparacionHoras())
            {
                int idreparacion = int.Parse(this.txtIdHoras.Text);
                int anio = int.Parse(this.txtAnioHoras.Text);

                string[] partesRep = this.txtIdMecanicoHoras.Text.Split(' ');
                int idmecanico = int.Parse(partesRep[0]);

                int horas = int.Parse(this.txtHoras.Text);
                int costohora = int.Parse(this.txtCostoHora.Text);

                Reparacion_Horas unaReparacionHoras = new Reparacion_Horas(idreparacion, anio, idmecanico, horas, costohora);
                if (controladoraWeb.ModificarReparacionHoras(unaReparacionHoras))
                {
                    this.lblMensajesHoras.Text = "Horas modificadas con éxito";
                    this.limpiar();
                }
                else
                {
                    this.lblMensajesHoras.Text = "La reparación debe tener horas asignadas para poder modificar";
                }
            }
            else
            {
                this.lblMensajesHoras.Text = "Faltan datos";
            }
        }
        #endregion

        #region Botones Reparación Repuestos
        protected void btnAgregarRepuesto_Click(object sender, EventArgs e)
        {
            if (!this.faltanDatosReparacionRepuestos())
            {
                int idreparacion = int.Parse(this.txtIdRepuestos.Text);
                int anio = int.Parse(this.txtAnioRepuestos.Text);

                string lineaRep = this.ddlRepuestos.SelectedItem.ToString();
                string[] partesRep = lineaRep.Split(' ');
                string repuestocod = partesRep[0];

                int cantidad = int.Parse(this.txtCantidadRepuesto.Text);
                double costounitario = double.Parse(this.txtCostoUnitario.Text);

                Reparacion_Repuestos unaReparacionRepuesto = new Reparacion_Repuestos(idreparacion, anio, repuestocod, cantidad, costounitario);
                if (controladoraWeb.AltaReparacionRepuesto(unaReparacionRepuesto))
                {
                    this.lblMensajesRepuesto.Text = "Repuesto ingresado con éxito";
                    this.limpiar();
                    this.listarReparacionRepuestos();
                }
                else
                {
                    this.lblMensajesRepuesto.Text = "Ya existe un repuesto con ese código";
                }
            }
            else
            {
                this.lblMensajesRepuesto.Text = "Faltan datos";
            }
        }

        protected void btnEliminarRepuesto_Click(object sender, EventArgs e)
        {
            if (this.txtIdRepuestos.Text != "" && this.txtAnioRepuestos.Text != "")
            {
                int id = int.Parse(this.txtIdRepuestos.Text);
                int anio = int.Parse(this.txtAnioRepuestos.Text);

                string lineaRep = this.ddlRepuestos.SelectedItem.ToString();
                string[] partesRep = lineaRep.Split(' ');
                string repuestocod = partesRep[0];

                if (controladoraWeb.BajaReparacionRepuesto(id, anio, repuestocod))
                {
                    this.lblMensajesRepuesto.Text = "Repuesto eliminado con éxito";
                    this.limpiar();
                    this.listarReparacionRepuestos();
                }
                else
                {
                    this.lblMensajesRepuesto.Text = "La reparación no existe";
                }
            }
        }
        #endregion
    }
}