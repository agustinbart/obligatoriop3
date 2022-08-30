using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelo;
using Modelo;
using Modelo.Consultas;
using Persistencia.PControladora;

namespace Dominio.Controladora
{
    public class Controladora
    {
        //Personas
        #region Administradores
        public List<Administrador> ListaAdministradores()
        {
            return PControladora.ListaAdministradores();
        }

        public Administrador BuscarAdmin(int pId)
        {
            return PControladora.BuscarAdmin(pId);
        }

        public bool AltaAdmin(Administrador pAdmin)
        {
            return PControladora.AltaAdmin(pAdmin);
        }

        public bool BajaAdmin(int pId)
        {
            return PControladora.BajaAdmin(pId);
        }

        public bool ModificarAdmin(Administrador pAdmin)
        {
            return PControladora.ModificarAdmin(pAdmin);
        }
        #endregion

        #region Clientes
        public List<Cliente> ListaClientes()
        {
            return PControladora.ListaClientes();
        }

        public Cliente BuscarCliente(int pId)
        {
            return PControladora.BuscarCliente(pId);
        }

        public bool AltaCliente(Cliente pCliente)
        {
            return PControladora.AltaCliente(pCliente);
        }

        public bool BajaCliente(int pId)
        {
            return PControladora.BajaCliente(pId);
        }

        public bool ModificarCliente(Cliente pCliente)
        {
            return PControladora.ModificarCliente(pCliente);
        }
        #endregion

        #region Mecánicos
        public List<Mecanico> ListaMecanicos()
        {
            return PControladora.ListaMecanicos();
        }

        public Mecanico BuscarMecanico(int pId)
        {
            return PControladora.BuscarMecanico(pId);
        }

        public bool AltaMecanico(Mecanico pMecanico)
        {
            return PControladora.AltaMecanico(pMecanico);
        }

        public bool BajaMecanico(int pId)
        {
            return PControladora.BajaMecanico(pId);
        }

        public bool ModificarMecanico(Mecanico pMecanico)
        {
            return PControladora.ModificarMecanico(pMecanico);
        }
        #endregion

        #region Proveedores
        public List<Proveedor> ListaProveedores()
        {
            return PControladora.ListaProveedores();
        }

        public Proveedor BuscarProveedor(string pRUT)
        {
            return PControladora.BuscarProveedor(pRUT);
        }

        public bool AltaProveedor(Proveedor pProveedor)
        {
            return PControladora.AltaProveedor(pProveedor);
        }

        public bool BajaProveedor(string pRUT)
        {
            return PControladora.BajaProveedor(pRUT);
        }

        public bool ModificarProveedor(Proveedor pProveedor)
        {
            return PControladora.ModificarProveedor(pProveedor);
        }
        #endregion

        #region Login Clientes
        public Cliente BuscarClienteLogin(string pCedula, string pContrasena)
        {
            return PControladora.BuscarClienteLogin(pCedula, pContrasena);
        }
        #endregion

        #region Login Administradores
        public Administrador BuscarAdminLogin(string pCedula, string pContrasena)
        {
            return PControladora.BuscarAdminLogin(pCedula, pContrasena);
        }
        #endregion

        //Reparaciones
        #region Repuestos
        public List<Repuesto> ListaRepuestos()
        {
            return PControladora.ListaRepuestos();
        }

        public Repuesto BuscarRepuesto(string pCodigo)
        {
            return PControladora.BuscarRepuesto(pCodigo);
        }

        public bool AltaRepuesto(Repuesto pRepuesto)
        {
            return PControladora.AltaRepuesto(pRepuesto);
        }

        public bool BajaRepuesto(string pCodigo)
        {
            return PControladora.BajaRepuesto(pCodigo);
        }

        public bool ModificarRepuesto(Repuesto pRepuesto)
        {
            return PControladora.ModificarRepuesto(pRepuesto);
        }
        #endregion

        #region Vehiculos
        public List<Vehiculo> ListaVehiculos()
        {
            return PControladora.ListaVehiculos();
        }

        public Vehiculo BuscarVehiculo(int pId)
        {
            return PControladora.BuscarVehiculo(pId);
        }

        public Vehiculo BuscarVehiculoPorMatricula(string pMatricula)
        {
            return PControladora.BuscarVehiculoPorMatricula(pMatricula);
        }

        public bool AltaVehiculo(Vehiculo pVehiculo)
        {
            return PControladora.AltaVehiculo(pVehiculo);
        }

        public bool BajaVehiculo(int pId)
        {
            return PControladora.BajaVehiculo(pId);
        }

        public bool ModificarVehiculo(Vehiculo pVehiculo)
        {
            return PControladora.ModificarVehiculo(pVehiculo);
        }
        #endregion

        #region Clientes Vehiculos
        public List<Cliente_Vehiculo> ListaClienteVehiculos()
        {
            return PControladora.ListaClienteVehiculos();
        }

        public Cliente_Vehiculo BuscarClienteVehiculo(int pCliCod, string pVehiculoMatricula)
        {
            return PControladora.BuscarClienteVehiculo(pCliCod, pVehiculoMatricula);
        }

        public bool AltaClienteVehiculo(Cliente_Vehiculo pClienteVehiculo)
        {
            return PControladora.AltaClienteVehiculo(pClienteVehiculo);
        }

        public bool BajaClienteVehiculo(int pCliCod, string pVehiculoMatricula)
        {
            return PControladora.BajaClienteVehiculo(pCliCod, pVehiculoMatricula);
        }

        public bool ModificarClienteVehiculo(Cliente_Vehiculo pClienteVehiculo)
        {
            return PControladora.ModificarClienteVehiculo(pClienteVehiculo);
        }
        #endregion

        #region Reservas
        public List<Reserva> ListaReservas()
        {
            return PControladora.ListaReservas();
        }

        public Reserva BuscarReserva(int pId)
        {
            return PControladora.BuscarReserva(pId);
        }

        public bool AltaReserva(Reserva pReserva)
        {
            return PControladora.AltaReserva(pReserva);
        }

        public bool BajaReserva(int pId)
        {
            return PControladora.BajaReserva(pId);
        }

        public bool ModificarReserva(Reserva pReserva)
        {
            return PControladora.ModificarReserva(pReserva);
        }
        #endregion

        #region Reparaciones
        public List<Reparacion> ListaReparaciones()
        {
            return PControladora.ListaReparaciones();
        }

        public Reparacion BuscarReparacion(int pId, int pAnio)
        {
            return PControladora.BuscarReparacion(pId, pAnio);
        }

        public bool AltaReparacion(Reparacion pReparacion)
        {
            return PControladora.AltaReparacion(pReparacion);
        }

        public bool BajaReparacion(int pId, int pAnio)
        {
            return PControladora.BajaReparacion(pId, pAnio);
        }

        public bool ModificarReparacion(Reparacion pReparacion)
        {
            return PControladora.ModificarReparacion(pReparacion);
        }
        #endregion

        #region Reparación Repuestos
        public List<Reparacion_Repuestos> ListaReparacion_Repuestos()
        {
            return PControladora.ListaReparacion_Repuestos();
        }

        public Reparacion_Repuestos BuscarReparacionRepuesto(int pRepCod, int pRepAnio, string pRepuestoCod)
        {
            return PControladora.BuscarReparacionRepuesto(pRepCod, pRepAnio, pRepuestoCod);
        }

        public bool AltaReparacionRepuesto(Reparacion_Repuestos pReparacionRepuesto)
        {
            return PControladora.AltaReparacionRepuesto(pReparacionRepuesto);
        }

        public bool BajaReparacionRepuesto(int pRepCod, int pRepAnio, string pRepuestoCod)
        {
            return PControladora.BajaReparacionRepuesto(pRepCod, pRepAnio, pRepuestoCod);
        }

        public bool ModificarReparacionRepuesto(Reparacion_Repuestos pReparacionRepuesto)
        {
            return PControladora.ModificarReparacionRepuesto(pReparacionRepuesto);
        }
        #endregion

        #region Reparación Horas
        public List<Reparacion_Horas> ListaReparacion_Horas()
        {
            return PControladora.ListaReparacion_Horas();
        }

        public Reparacion_Horas BuscarReparacionHoras(int pRepCod, int pRepAnio)
        {
            return PControladora.BuscarReparacionHoras(pRepCod, pRepAnio);
        }

        public bool AltaReparacionHoras(Reparacion_Horas pReparacionHoras)
        {
            return PControladora.AltaReparacionHoras(pReparacionHoras);
        }

        public bool BajaReparacionHoras(int pRepCod, int pRepAnio)
        {
            return PControladora.BajaReparacionHoras(pRepCod, pRepAnio);
        }

        public bool ModificarReparacionHoras(Reparacion_Horas pReparacionHoras)
        {
            return PControladora.ModificarReparacionHoras(pReparacionHoras);
        }
        #endregion

        //Estadisticas
        #region Filtro de fechas
        #region Reparaciones completas
        public List<FiltroFechaListaReparacion> ObtenerReparacionesEntreFechas(DateTime pFecha1, DateTime pFecha2)
        {
            return Estadistica.ObtenerReparacionesEntreFechas(pFecha1, pFecha2);
        }
        #endregion

        #region Reparaciones pendientes
        public List<FiltroFechaListaPendiente> ObtenerReparacionesPendientesEntreFechas(DateTime pFecha1, DateTime pFecha2)
        {
            return Estadistica.ObtenerReparacionesPendientesEntreFechas(pFecha1, pFecha2);
        }
        #endregion
        #endregion

        #region Repuestos ordenados por más vendidos
        public List<RepuestosMasVendidos> ObtenerRepuestosMasVendidos()
        {
            return Estadistica.ObtenerRepuestosMasVendidos();
        }
        #endregion
    }
}
