using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dominio.Modelo;
using Modelo;
using Modelo.Consultas;

namespace Taller.Web.Controladora
{
    public class ControladoraWeb
    {
        Dominio.Controladora.Controladora Taller;
        public ControladoraWeb()
        {
            Taller = new Dominio.Controladora.Controladora();
        }

        // Personas
        #region Administradores
        public List<Administrador> ListaAdministradores()
        {
            return Taller.ListaAdministradores();
        }

        public Administrador BuscarAdmin(int pId)
        {
            return Taller.BuscarAdmin(pId);
        }

        public bool AltaAdmin(Administrador pAdmin)
        {
            return Taller.AltaAdmin(pAdmin);
        }

        public bool BajaAdmin(int pId)
        {
            return Taller.BajaAdmin(pId);
        }

        public bool ModificarAdmin(Administrador pAdmin)
        {
            return Taller.ModificarAdmin(pAdmin);
        }
        #endregion

        #region Clientes
        public List<Cliente> ListaClientes()
        {
            return Taller.ListaClientes();
        }

        public Cliente BuscarCliente(int pId)
        {
            return Taller.BuscarCliente(pId);
        }

        public bool AltaCliente(Cliente pCliente)
        {
            return Taller.AltaCliente(pCliente);
        }

        public bool BajaCliente(int pId)
        {
            return Taller.BajaCliente(pId);
        }

        public bool ModificarCliente(Cliente pCliente)
        {
            return Taller.ModificarCliente(pCliente);
        }
        #endregion

        #region Mecánicos
        public List<Mecanico> ListaMecanicos()
        {
            return Taller.ListaMecanicos();
        }

        public Mecanico BuscarMecanico(int pId)
        {
            return Taller.BuscarMecanico(pId);
        }

        public bool AltaMecanico(Mecanico pMecanico)
        {
            return Taller.AltaMecanico(pMecanico);
        }

        public bool BajaMecanico(int pId)
        {
            return Taller.BajaMecanico(pId);
        }

        public bool ModificarMecanico(Mecanico pMecanico)
        {
            return Taller.ModificarMecanico(pMecanico);
        }
        #endregion

        #region Proveedores
        public List<Proveedor> ListaProveedores()
        {
            return Taller.ListaProveedores();
        }

        public Proveedor BuscarProveedor(string pRUT)
        {
            return Taller.BuscarProveedor(pRUT);
        }

        public bool AltaProveedor(Proveedor pProveedor)
        {
            return Taller.AltaProveedor(pProveedor);
        }

        public bool BajaProveedor(string pRUT)
        {
            return Taller.BajaProveedor(pRUT);
        }

        public bool ModificarProveedor(Proveedor pProveedor)
        {
            return Taller.ModificarProveedor(pProveedor);
        }
        #endregion

        #region Login Clientes
        public Cliente BuscarClienteLogin(string pCedula, string pContrasena)
        {
            return Taller.BuscarClienteLogin(pCedula, pContrasena);
        }
        #endregion

        #region Login Administradores
        public Administrador BuscarAdminLogin(string pCedula, string pContrasena)
        {
            return Taller.BuscarAdminLogin(pCedula, pContrasena);
        }
        #endregion

        // Reparaciones
        #region Repuestos
        public List<Repuesto> ListaRepuestos()
        {
            return Taller.ListaRepuestos();
        }

        public Repuesto BuscarRepuesto(string pCodigo)
        {
            return Taller.BuscarRepuesto(pCodigo);
        }

        public bool AltaRepuesto(Repuesto pRepuesto)
        {
            return Taller.AltaRepuesto(pRepuesto);
        }

        public bool BajaRepuesto(string pCodigo)
        {
            return Taller.BajaRepuesto(pCodigo);
        }

        public bool ModificarRepuesto(Repuesto pRepuesto)
        {
            return Taller.ModificarRepuesto(pRepuesto);
        }
        #endregion

        #region Vehiculos
        public List<Vehiculo> ListaVehiculos()
        {
            return Taller.ListaVehiculos();
        }

        public Vehiculo BuscarVehiculo(int pId)
        {
            return Taller.BuscarVehiculo(pId);
        }

        public Vehiculo BuscarVehiculoPorMatricula(string pMatricula)
        {
            return Taller.BuscarVehiculoPorMatricula(pMatricula);
        }

        public bool AltaVehiculo(Vehiculo pVehiculo)
        {
            return Taller.AltaVehiculo(pVehiculo);
        }

        public bool BajaVehiculo(int pId)
        {
            return Taller.BajaVehiculo(pId);
        }

        public bool ModificarVehiculo(Vehiculo pVehiculo)
        {
            return Taller.ModificarVehiculo(pVehiculo);
        }
        #endregion

        #region Clientes Vehiculos
        public List<Cliente_Vehiculo> ListaClienteVehiculos()
        {
            return Taller.ListaClienteVehiculos();
        }

        public Cliente_Vehiculo BuscarClienteVehiculo(int pCliCod, string pVehiculoMatricula)
        {
            return Taller.BuscarClienteVehiculo(pCliCod, pVehiculoMatricula);
        }

        public bool AltaClienteVehiculo(Cliente_Vehiculo pClienteVehiculo)
        {
            return Taller.AltaClienteVehiculo(pClienteVehiculo);
        }

        public bool BajaClienteVehiculo(int pCliCod, string pVehiculoMatricula)
        {
            return Taller.BajaClienteVehiculo(pCliCod, pVehiculoMatricula);
        }

        public bool ModificarVehiculo(Cliente_Vehiculo pClienteVehiculo)
        {
            return Taller.ModificarClienteVehiculo(pClienteVehiculo);
        }
        #endregion

        #region Reservas
        public List<Reserva> ListaReservas()
        {
            return Taller.ListaReservas();
        }

        public Reserva BuscarReserva(int pId)
        {
            return Taller.BuscarReserva(pId);
        }

        public bool AltaReserva(Reserva pReserva)
        {
            return Taller.AltaReserva(pReserva);
        }

        public bool BajaReserva(int pId)
        {
            return Taller.BajaReserva(pId);
        }

        public bool ModificarReserva(Reserva pReserva)
        {
            return Taller.ModificarReserva(pReserva);
        }
        #endregion

        #region Reparaciones
        public List<Reparacion> ListaReparaciones()
        {
            return Taller.ListaReparaciones();
        }

        public Reparacion BuscarReparacion(int pId, int pAnio)
        {
            return Taller.BuscarReparacion(pId, pAnio);
        }

        public bool AltaReparacion(Reparacion pReparacion)
        {
            return Taller.AltaReparacion(pReparacion);
        }

        public bool BajaReparacion(int pId, int pAnio)
        {
            return Taller.BajaReparacion(pId, pAnio);
        }

        public bool ModificarReparacion(Reparacion pReparacion)
        {
            return Taller.ModificarReparacion(pReparacion);
        }
        #endregion

        #region Reparación Repuestos
        public List<Reparacion_Repuestos> ListaReparacion_Repuestos()
        {
            return Taller.ListaReparacion_Repuestos();
        }

        public Reparacion_Repuestos BuscarReparacionRepuesto(int pRepCod, int pRepAnio, string pRepuestoCod)
        {
            return Taller.BuscarReparacionRepuesto(pRepCod, pRepAnio, pRepuestoCod);
        }

        public bool AltaReparacionRepuesto(Reparacion_Repuestos pReparacionRepuesto)
        {
            return Taller.AltaReparacionRepuesto(pReparacionRepuesto);
        }

        public bool BajaReparacionRepuesto(int pRepCod, int pRepAnio, string pRepuestoCod)
        {
            return Taller.BajaReparacionRepuesto(pRepCod, pRepAnio, pRepuestoCod);
        }

        public bool ModificarReparacionRepuesto(Reparacion_Repuestos pReparacionRepuesto)
        {
            return Taller.ModificarReparacionRepuesto(pReparacionRepuesto);
        }
        #endregion

        #region Reparación Horas
        public List<Reparacion_Horas> ListaReparacion_Horas()
        {
            return Taller.ListaReparacion_Horas();
        }

        public Reparacion_Horas BuscarReparacionHoras(int pRepCod, int pRepAnio)
        {
            return Taller.BuscarReparacionHoras(pRepCod, pRepAnio);
        }

        public bool AltaReparacionHoras(Reparacion_Horas pReparacionHoras)
        {
            return Taller.AltaReparacionHoras(pReparacionHoras);
        }

        public bool BajaReparacionHoras(int pRepCod, int pRepAnio)
        {
            return Taller.BajaReparacionHoras(pRepCod, pRepAnio);
        }

        public bool ModificarReparacionHoras(Reparacion_Horas pReparacionHoras)
        {
            return Taller.ModificarReparacionHoras(pReparacionHoras);
        }
        #endregion

        //Estadisticas
        #region Filtro de fechas
        #region Reparaciones completas
        public List<FiltroFechaListaReparacion> ObtenerReparacionesEntreFechas(DateTime pFecha1, DateTime pFecha2)
        {
            return Taller.ObtenerReparacionesEntreFechas(pFecha1, pFecha2);
        }
        #endregion

        #region Reparaciones pendientes
        public List<FiltroFechaListaPendiente> ObtenerReparacionesPendientesEntreFechas(DateTime pFecha1, DateTime pFecha2)
        {
            return Taller.ObtenerReparacionesPendientesEntreFechas(pFecha1, pFecha2);
        }
        #endregion
        #endregion

        #region Repuestos ordenados por más vendidos
        public List<RepuestosMasVendidos> ObtenerRepuestosMasVendidos()
        {
            return Taller.ObtenerRepuestosMasVendidos();
        }
        #endregion
    }
}