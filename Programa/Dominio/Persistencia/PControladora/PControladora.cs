using Dominio.Modelo;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.PControladora
{
    public class PControladora
    {
        // Personas
        #region Administradores
        public static List<Administrador> ListaAdministradores()
        {
            return PControladoraPersonas.ListaAdministradores();
        }

        public static Administrador BuscarAdmin(int pId)
        {
            return PControladoraPersonas.BuscarAdmin(pId);
        }

        public static bool AltaAdmin(Administrador pAdmin)
        {
            return PControladoraPersonas.AltaAdmin(pAdmin);
        }

        public static bool BajaAdmin(int pId)
        {
            return PControladoraPersonas.BajaAdmin(pId);
        }

        public static bool ModificarAdmin(Administrador pAdmin)
        {
            return PControladoraPersonas.ModificarAdmin(pAdmin);
        }
        #endregion

        #region Clientes
        public static List<Cliente> ListaClientes()
        {
            return PControladoraPersonas.ListaClientes();
        }

        public static Cliente BuscarCliente(int pId)
        {
            return PControladoraPersonas.BuscarCliente(pId);
        }

        public static bool AltaCliente(Cliente pCliente)
        {
            return PControladoraPersonas.AltaCliente(pCliente);
        }

        public static bool BajaCliente(int pId)
        {
            return PControladoraPersonas.BajaCliente(pId);
        }

        public static bool ModificarCliente(Cliente pCliente)
        {
            return PControladoraPersonas.ModificarCliente(pCliente);
        }
        #endregion

        #region Mecánicos
        public static List<Mecanico> ListaMecanicos()
        {
            return PControladoraPersonas.ListaMecanicos();
        }

        public static Mecanico BuscarMecanico(int pId)
        {
            return PControladoraPersonas.BuscarMecanico(pId);
        }

        public static bool AltaMecanico(Mecanico pMecanico)
        {
            return PControladoraPersonas.AltaMecanico(pMecanico);
        }

        public static bool BajaMecanico(int pId)
        {
            return PControladoraPersonas.BajaMecanico(pId);
        }

        public static bool ModificarMecanico(Mecanico pMecanico)
        {
            return PControladoraPersonas.ModificarMecanico(pMecanico);
        }
        #endregion

        #region Proveedores
        public static List<Proveedor> ListaProveedores()
        {
            return PControladoraPersonas.ListaProveedores();
        }

        public static Proveedor BuscarProveedor(string pRUT)
        {
            return PControladoraPersonas.BuscarProveedor(pRUT);
        }

        public static bool AltaProveedor(Proveedor pProveedor)
        {
            return PControladoraPersonas.AltaProveedor(pProveedor);
        }

        public static bool BajaProveedor(string pRUT)
        {
            return PControladoraPersonas.BajaProveedor(pRUT);
        }

        public static bool ModificarProveedor(Proveedor pProveedor)
        {
            return PControladoraPersonas.ModificarProveedor(pProveedor);
        }
        #endregion

        #region Login Clientes
        public static Cliente BuscarClienteLogin(string pCedula, string pContrasena)
        {
            return PControladoraPersonas.BuscarClienteLogin(pCedula, pContrasena);
        }
        #endregion

        #region Login Administradores
        public static Administrador BuscarAdminLogin(string pCedula, string pContrasena)
        {
            return PControladoraPersonas.BuscarAdminLogin(pCedula, pContrasena);
        }
        #endregion

        // Reparaciones
        #region Repuestos
        public static List<Repuesto> ListaRepuestos()
        {
            return PControladoraReparacion.ListaRepuestos();
        }

        public static Repuesto BuscarRepuesto(string pCodigo)
        {
            return PControladoraReparacion.BuscarRepuesto(pCodigo);
        }

        public static bool AltaRepuesto(Repuesto pRepuesto)
        {
            return PControladoraReparacion.AltaRepuesto(pRepuesto);
        }

        public static bool BajaRepuesto(string pCodigo)
        {
            return PControladoraReparacion.BajaRepuesto(pCodigo);
        }

        public static bool ModificarRepuesto(Repuesto pRepuesto)
        {
            return PControladoraReparacion.ModificarRepuesto(pRepuesto);
        }
        #endregion

        #region Vehiculos
        public static List<Vehiculo> ListaVehiculos()
        {
            return PControladoraReparacion.ListaVehiculos();
        }

        public static Vehiculo BuscarVehiculo(int pId)
        {
            return PControladoraReparacion.BuscarVehiculo(pId);
        }

        public static Vehiculo BuscarVehiculoPorMatricula(string pMatricula)
        {
            return PControladoraReparacion.BuscarVehiculoPorMatricula(pMatricula);
        }

        public static bool AltaVehiculo(Vehiculo pVehiculo)
        {
            return PControladoraReparacion.AltaVehiculo(pVehiculo);
        }

        public static bool BajaVehiculo(int pId)
        {
            return PControladoraReparacion.BajaVehiculo(pId);
        }

        public static bool ModificarVehiculo(Vehiculo pVehiculo)
        {
            return PControladoraReparacion.ModificarVehiculo(pVehiculo);
        }
        #endregion

        #region Clientes Vehiculos
        public static List<Cliente_Vehiculo> ListaClienteVehiculos()
        {
            return PControladoraReparacion.ListaClienteVehiculos();
        }

        public static Cliente_Vehiculo BuscarClienteVehiculo(int pCliCod, string pVehiculoMatricula)
        {
            return PControladoraReparacion.BuscarClienteVehiculo(pCliCod, pVehiculoMatricula);
        }

        public static bool AltaClienteVehiculo(Cliente_Vehiculo pClienteVehiculo)
        {
            return PControladoraReparacion.AltaClienteVehiculo(pClienteVehiculo);
        }

        public static bool BajaClienteVehiculo(int pCliCod, string pVehiculoMatricula)
        {
            return PControladoraReparacion.BajaClienteVehiculo(pCliCod, pVehiculoMatricula);
        }

        public static bool ModificarClienteVehiculo(Cliente_Vehiculo pClienteVehiculo)
        {
            return PControladoraReparacion.ModificarClienteVehiculo(pClienteVehiculo);
        }
        #endregion

        #region Reservas
        public static List<Reserva> ListaReservas()
        {
            return PControladoraReparacion.ListaReservas();
        }

        public static Reserva BuscarReserva(int pId)
        {
            return PControladoraReparacion.BuscarReserva(pId);
        }

        public static bool AltaReserva(Reserva pReserva)
        {
            return PControladoraReparacion.AltaReserva(pReserva);
        }

        public static bool BajaReserva(int pId)
        {
            return PControladoraReparacion.BajaReserva(pId);
        }

        public static bool ModificarReserva(Reserva pReserva)
        {
            return PControladoraReparacion.ModificarReserva(pReserva);
        }
        #endregion

        #region Reparaciones
        public static List<Reparacion> ListaReparaciones()
        {
            return PControladoraReparacion.ListaReparaciones();
        }

        public static Reparacion BuscarReparacion(int pId, int pAnio)
        {
            return PControladoraReparacion.BuscarReparacion(pId, pAnio);
        }

        public static bool AltaReparacion(Reparacion pReparacion)
        {
            return PControladoraReparacion.AltaReparacion(pReparacion);
        }

        public static bool BajaReparacion(int pId, int pAnio)
        {
            return PControladoraReparacion.BajaReparacion(pId, pAnio);
        }

        public static bool ModificarReparacion(Reparacion pReparacion)
        {
            return PControladoraReparacion.ModificarReparacion(pReparacion);
        }
        #endregion

        #region Reparación Repuestos
        public static List<Reparacion_Repuestos> ListaReparacion_Repuestos()
        {
            return PControladoraReparacion.ListaReparacion_Repuestos();
        }

        public static Reparacion_Repuestos BuscarReparacionRepuesto(int pRepCod, int pRepAnio, string pRepuestoCod)
        {
            return PControladoraReparacion.BuscarReparacionRepuesto(pRepCod, pRepAnio, pRepuestoCod);
        }

        public static bool AltaReparacionRepuesto(Reparacion_Repuestos pReparacionRepuesto)
        {
            return PControladoraReparacion.AltaReparacionRepuesto(pReparacionRepuesto);
        }

        public static bool BajaReparacionRepuesto(int pRepCod, int pRepAnio, string pRepuestoCod)
        {
            return PControladoraReparacion.BajaReparacionRepuesto(pRepCod, pRepAnio, pRepuestoCod);
        }

        public static bool ModificarReparacionRepuesto(Reparacion_Repuestos pReparacionRepuesto)
        {
            return PControladoraReparacion.ModificarReparacionRepuesto(pReparacionRepuesto);
        }
        #endregion

        #region Reparación Horas
        public static List<Reparacion_Horas> ListaReparacion_Horas()
        {
            return PControladoraReparacion.ListaReparacion_Horas();
        }

        public static Reparacion_Horas BuscarReparacionHoras(int pRepCod, int pRepAnio)
        {
            return PControladoraReparacion.BuscarReparacionHoras(pRepCod, pRepAnio);
        }

        public static bool AltaReparacionHoras(Reparacion_Horas pReparacionHoras)
        {
            return PControladoraReparacion.AltaReparacionHoras(pReparacionHoras);
        }

        public static bool BajaReparacionHoras(int pRepCod, int pRepAnio)
        {
            return PControladoraReparacion.BajaReparacionHoras(pRepCod, pRepAnio);
        }

        public static bool ModificarReparacionHoras(Reparacion_Horas pReparacionHoras)
        {
            return PControladoraReparacion.ModificarReparacionHoras(pReparacionHoras);
        }
        #endregion
    }
}
