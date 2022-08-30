using Dominio.Modelo;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.PControladora
{
    public class PControladoraReparacion : Conexion
    {
        #region Persistencia Repuestos
        public static List<Repuesto> ListaRepuestos()
        {
            List<Repuesto> resultado = new List<Repuesto>();
            try
            {
                Repuesto repuesto;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ObtenerRepuestos", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        repuesto = new Repuesto();
                        repuesto.Codigo = reader["RepuestoCod"].ToString();
                        repuesto.Descripcion = reader["RepuestoDsc"].ToString();
                        repuesto.Costo = double.Parse(reader["RepuestoCosto"].ToString());
                        repuesto.Tipo = reader["RepuestoTipo"].ToString();
                        repuesto.RUTProveedor = reader["ProveedorRUT"].ToString();
                        resultado.Add(repuesto);
                    }
                }

                conexionSQL.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());

            }


            return resultado;

        }

        public static bool AltaRepuesto(Repuesto pRepuesto)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("AltaRepuesto", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RepuestoCod", pRepuesto.Codigo));
                cmd.Parameters.Add(new SqlParameter("@RepuestoDsc", pRepuesto.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@RepuestoCosto", pRepuesto.Costo));
                cmd.Parameters.Add(new SqlParameter("@RepuestoTipo", pRepuesto.Tipo));
                cmd.Parameters.Add(new SqlParameter("@ProveedorRUT", pRepuesto.RUTProveedor));
                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;

        }

        public static bool BajaRepuesto(string pCodigo)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("BajaRepuesto", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RepuestoCod", pCodigo));
                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        public static bool ModificarRepuesto(Repuesto pRepuesto)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ModificarRepuesto", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RepuestoCod", pRepuesto.Codigo));
                cmd.Parameters.Add(new SqlParameter("@RepuestoDsc", pRepuesto.Descripcion));
                cmd.Parameters.Add(new SqlParameter("@RepuestoCosto", pRepuesto.Costo));
                cmd.Parameters.Add(new SqlParameter("@RepuestoTipo", pRepuesto.Tipo));
                cmd.Parameters.Add(new SqlParameter("@ProveedorRUT", pRepuesto.RUTProveedor));
                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        public static Repuesto BuscarRepuesto(string pCodigo)
        {
            Repuesto resultado = new Repuesto();
            try
            {
                Repuesto repuesto;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("BuscarRepuesto", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RepuestoCod", pCodigo));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        repuesto = new Repuesto();
                        repuesto.Codigo = reader["RepuestoCod"].ToString();
                        repuesto.Descripcion = reader["RepuestoDsc"].ToString();
                        repuesto.Costo = double.Parse(reader["RepuestoCosto"].ToString());
                        repuesto.Tipo = reader["RepuestoTipo"].ToString();
                        repuesto.RUTProveedor = reader["ProveedorRUT"].ToString();
                        resultado = repuesto;
                    }
                }

                conexionSQL.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());

            }

            return resultado;
        }
        #endregion

        #region Persistencia Vehiculos
        public static List<Vehiculo> ListaVehiculos()
        {
            List<Vehiculo> resultado = new List<Vehiculo>();
            try
            {
                Vehiculo vehiculo;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ObtenerVehiculos", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vehiculo = new Vehiculo();
                        vehiculo.Id = int.Parse(reader["VehiculoCod"].ToString());
                        vehiculo.Matricula = reader["Matricula"].ToString();
                        vehiculo.Marca = reader["Marca"].ToString();
                        vehiculo.Modelo = reader["Modelo"].ToString();
                        vehiculo.Anio = int.Parse(reader["Anio"].ToString());
                        vehiculo.Color = reader["Color"].ToString();
                        resultado.Add(vehiculo);
                    }
                }

                conexionSQL.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());

            }

            return resultado;

        }

        public static bool AltaVehiculo(Vehiculo pVehiculo)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("AltaVehiculo", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Matricula", pVehiculo.Matricula));
                cmd.Parameters.Add(new SqlParameter("@Marca", pVehiculo.Marca));
                cmd.Parameters.Add(new SqlParameter("@Modelo", pVehiculo.Modelo));
                cmd.Parameters.Add(new SqlParameter("@Anio", pVehiculo.Anio));
                cmd.Parameters.Add(new SqlParameter("@Color", pVehiculo.Color));
                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;

        }

        public static bool BajaVehiculo(int pId)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("BajaVehiculo", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@VehiculoCod", pId));
                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        public static bool ModificarVehiculo(Vehiculo pVehiculo)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ModificarVehiculo", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@VehiculoCod", pVehiculo.Id));
                cmd.Parameters.Add(new SqlParameter("@Matricula", pVehiculo.Matricula));
                cmd.Parameters.Add(new SqlParameter("@Marca", pVehiculo.Marca));
                cmd.Parameters.Add(new SqlParameter("@Modelo", pVehiculo.Modelo));
                cmd.Parameters.Add(new SqlParameter("@Anio", pVehiculo.Anio));
                cmd.Parameters.Add(new SqlParameter("@Color", pVehiculo.Color));
                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        public static Vehiculo BuscarVehiculo(int pId)
        {
            Vehiculo resultado = new Vehiculo();
            try
            {
                Vehiculo vehiculo;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("BuscarVehiculo", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@VehiculoCod", pId));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vehiculo = new Vehiculo();
                        vehiculo.Id = int.Parse(reader["VehiculoCod"].ToString());
                        vehiculo.Matricula = reader["Matricula"].ToString();
                        vehiculo.Marca = reader["Marca"].ToString();
                        vehiculo.Modelo = reader["Modelo"].ToString();
                        vehiculo.Anio = int.Parse(reader["Anio"].ToString());
                        vehiculo.Color = reader["Color"].ToString();
                        resultado = vehiculo;
                    }
                }

                conexionSQL.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());

            }

            return resultado;
        }

        public static Vehiculo BuscarVehiculoPorMatricula(string pMatricula)
        {
            Vehiculo resultado = new Vehiculo();
            try
            {
                Vehiculo vehiculo;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("BuscarVehiculoPorMatricula", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Matricula", pMatricula));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vehiculo = new Vehiculo();
                        vehiculo.Id = int.Parse(reader["VehiculoCod"].ToString());
                        vehiculo.Matricula = reader["Matricula"].ToString();
                        vehiculo.Marca = reader["Marca"].ToString();
                        vehiculo.Modelo = reader["Modelo"].ToString();
                        vehiculo.Anio = int.Parse(reader["Anio"].ToString());
                        vehiculo.Color = reader["Color"].ToString();
                        resultado = vehiculo;
                    }
                }

                conexionSQL.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());

            }

            return resultado;
        }
        #endregion

        #region Persistencia Clientes Vehiculos
        public static List<Cliente_Vehiculo> ListaClienteVehiculos()
        {
            List<Cliente_Vehiculo> resultado = new List<Cliente_Vehiculo>();
            try
            {
                Cliente_Vehiculo clientevehiculo;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ObtenerClientesVehiculos", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clientevehiculo = new Cliente_Vehiculo();
                        clientevehiculo.CliCod = int.Parse(reader["CliCod"].ToString());
                        clientevehiculo.VehiculoMatricula = reader["VehiculoMatricula"].ToString();
                        clientevehiculo.Fecha = Convert.ToDateTime(reader["Fecha"].ToString());
                        resultado.Add(clientevehiculo);
                    }
                }

                conexionSQL.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());

            }


            return resultado;

        }

        public static bool AltaClienteVehiculo(Cliente_Vehiculo pClienteVehiculo)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("AltaClienteVehiculo", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CliCod", pClienteVehiculo.CliCod));
                cmd.Parameters.Add(new SqlParameter("@VehiculoMatricula", pClienteVehiculo.VehiculoMatricula));
                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;

        }

        public static bool BajaClienteVehiculo(int pCliCod, string pVehiculoMatricula)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("BajaClienteVehiculo", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@VehiculoMatricula", pVehiculoMatricula));
                cmd.Parameters.Add(new SqlParameter("@CliCod", pCliCod));
                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        public static bool ModificarClienteVehiculo(Cliente_Vehiculo pClienteVehiculo)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ModificarClienteVehiculo", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CliCod", pClienteVehiculo.CliCod));
                cmd.Parameters.Add(new SqlParameter("@VehiculoMatricula", pClienteVehiculo.VehiculoMatricula));
                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        public static Cliente_Vehiculo BuscarClienteVehiculo(int pCliCod, string pVehiculoMatricula)
        {
            Cliente_Vehiculo resultado = new Cliente_Vehiculo();
            try
            {
                Cliente_Vehiculo clientevehiculo;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("BuscarClienteVehiculo", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@VehiculoMatricula", pVehiculoMatricula));
                cmd.Parameters.Add(new SqlParameter("@CliCod", pCliCod));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clientevehiculo = new Cliente_Vehiculo();
                        clientevehiculo.CliCod = int.Parse(reader["CliCod"].ToString());
                        clientevehiculo.VehiculoMatricula = reader["VehiculoMatricula"].ToString();
                        clientevehiculo.Fecha = Convert.ToDateTime(reader["Fecha"].ToString());
                        resultado = clientevehiculo;
                    }
                }

                conexionSQL.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());

            }

            return resultado;
        }
        #endregion

        #region Persistencia Reservas
        public static List<Reserva> ListaReservas()
        {
            List<Reserva> resultado = new List<Reserva>();
            try
            {
                Reserva reserva;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ObtenerReservas", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reserva = new Reserva();
                        reserva.Id = int.Parse(reader["IdReserva"].ToString());
                        reserva.IdCliente = int.Parse(reader["CliCod"].ToString());
                        reserva.Matricula = reader["Matricula"].ToString();
                        reserva.DescripcionProblema = reader["DescripcionProblema"].ToString();
                        reserva.Fecha = Convert.ToDateTime(reader["Fecha"].ToString());
                        reserva.Aceptado = reader["Aceptado"].ToString();
                        resultado.Add(reserva);
                    }
                }

                conexionSQL.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());

            }


            return resultado;

        }

        public static bool AltaReserva(Reserva pReserva)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("AltaReserva", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CliCod", pReserva.IdCliente));
                cmd.Parameters.Add(new SqlParameter("@Matricula", pReserva.Matricula));
                cmd.Parameters.Add(new SqlParameter("@DescripcionProblema", pReserva.DescripcionProblema));
                cmd.Parameters.Add(new SqlParameter("@Fecha", pReserva.Fecha));
                cmd.Parameters.Add(new SqlParameter("@Aceptado", pReserva.Aceptado));
                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;

        }

        public static bool BajaReserva(int pId)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("BajaReserva", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdReserva", pId));
                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        public static bool ModificarReserva(Reserva pReserva)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ModificarReserva", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdReserva", pReserva.Id));
                cmd.Parameters.Add(new SqlParameter("@CliCod", pReserva.IdCliente));
                cmd.Parameters.Add(new SqlParameter("@Matricula", pReserva.Matricula));
                cmd.Parameters.Add(new SqlParameter("@DescripcionProblema", pReserva.DescripcionProblema));
                cmd.Parameters.Add(new SqlParameter("@Fecha", pReserva.Fecha));
                cmd.Parameters.Add(new SqlParameter("@Aceptado", pReserva.Aceptado));
                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        public static Reserva BuscarReserva(int pId)
        {
            Reserva resultado = new Reserva();
            try
            {
                Reserva reserva;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("BuscarReserva", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdReserva", pId));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reserva = new Reserva();
                        reserva.Id = int.Parse(reader["IdReserva"].ToString());
                        reserva.IdCliente = int.Parse(reader["CliCod"].ToString());
                        reserva.Matricula = reader["Matricula"].ToString();
                        reserva.DescripcionProblema = reader["DescripcionProblema"].ToString();
                        reserva.Fecha = Convert.ToDateTime(reader["Fecha"].ToString());
                        reserva.Aceptado = reader["Aceptado"].ToString();
                        resultado = reserva;
                    }
                }

                conexionSQL.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());

            }

            return resultado;
        }
        #endregion

        #region Persistencia Reparaciones
        public static List<Reparacion> ListaReparaciones()
        {
            List<Reparacion> resultado = new List<Reparacion>();
            try
            {
                Reparacion reparacion;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ObtenerReparaciones", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reparacion = new Reparacion();
                        reparacion.Id = int.Parse(reader["RepCod"].ToString());
                        reparacion.Anio = int.Parse(reader["RepAnio"].ToString());
                        reparacion.Matricula = reader["Matricula"].ToString();
                        reparacion.FechaEntrada = DateTime.Parse(reader["FchEntrada"].ToString());
                        reparacion.FechaSalida = DateTime.Parse(reader["FchSalida"].ToString());
                        reparacion.IdMecanico = int.Parse(reader["MecCod"].ToString());
                        reparacion.DescripcionEntrada = reader["RepDscEntrada"].ToString();
                        reparacion.DescripcionSalida = reader["RepDscSalida"].ToString();
                        reparacion.KmEntrada = int.Parse(reader["KmsEntrada"].ToString());
                        resultado.Add(reparacion);
                    }
                }

                conexionSQL.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());

            }


            return resultado;

        }

        public static bool AltaReparacion(Reparacion pReparacion)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("AltaReparacion", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RepCod", pReparacion.Id));
                cmd.Parameters.Add(new SqlParameter("@Matricula", pReparacion.Matricula));
                cmd.Parameters.Add(new SqlParameter("@FchEntrada", pReparacion.FechaEntrada));
                cmd.Parameters.Add(new SqlParameter("@FchSalida", pReparacion.FechaSalida));
                cmd.Parameters.Add(new SqlParameter("@MecCod", pReparacion.IdMecanico));
                cmd.Parameters.Add(new SqlParameter("@RepDscEntrada", pReparacion.DescripcionEntrada));
                cmd.Parameters.Add(new SqlParameter("@RepDscSalida", pReparacion.DescripcionSalida));
                cmd.Parameters.Add(new SqlParameter("@KmsEntrada", pReparacion.KmEntrada));
                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;

        }

        public static bool BajaReparacion(int pId, int pAnio)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("BajaReparacion", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RepCod", pId));
                cmd.Parameters.Add(new SqlParameter("@RepAnio", pAnio));
                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        public static bool ModificarReparacion(Reparacion pReparacion)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ModificarReparacion", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RepCod", pReparacion.Id));
                cmd.Parameters.Add(new SqlParameter("@RepAnio", pReparacion.Anio));
                cmd.Parameters.Add(new SqlParameter("@Matricula", pReparacion.Matricula));
                cmd.Parameters.Add(new SqlParameter("@FchEntrada", pReparacion.FechaEntrada));
                cmd.Parameters.Add(new SqlParameter("@FchSalida", pReparacion.FechaSalida));
                cmd.Parameters.Add(new SqlParameter("@MecCod", pReparacion.IdMecanico));
                cmd.Parameters.Add(new SqlParameter("@RepDscEntrada", pReparacion.DescripcionEntrada));
                cmd.Parameters.Add(new SqlParameter("@RepDscSalida", pReparacion.DescripcionSalida));
                cmd.Parameters.Add(new SqlParameter("@KmsEntrada", pReparacion.KmEntrada));
                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        public static Reparacion BuscarReparacion(int pId, int pAnio)
        {
            Reparacion resultado = new Reparacion();
            try
            {
                Reparacion reparacion;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("BuscarReparacion", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RepCod", pId));
                cmd.Parameters.Add(new SqlParameter("@RepAnio", pAnio));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reparacion = new Reparacion();
                        reparacion.Id = int.Parse(reader["RepCod"].ToString());
                        reparacion.Anio = int.Parse(reader["RepAnio"].ToString());
                        reparacion.Matricula = reader["Matricula"].ToString();
                        reparacion.FechaEntrada = DateTime.Parse(reader["FchEntrada"].ToString());
                        reparacion.FechaSalida = DateTime.Parse(reader["FchSalida"].ToString());
                        reparacion.IdMecanico = int.Parse(reader["MecCod"].ToString());
                        reparacion.DescripcionEntrada = reader["RepDscEntrada"].ToString();
                        reparacion.DescripcionSalida = reader["RepDscSalida"].ToString();
                        reparacion.KmEntrada = int.Parse(reader["KmsEntrada"].ToString());
                        resultado = reparacion;
                    }
                }

                conexionSQL.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());

            }

            return resultado;
        }
        #endregion

        #region Persistencia Reparación Repuestos
        public static List<Reparacion_Repuestos> ListaReparacion_Repuestos()
        {
            List<Reparacion_Repuestos> resultado = new List<Reparacion_Repuestos>();
            try
            {
                Reparacion_Repuestos reparacion_repuesto;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ObtenerReparacionRepuestos", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reparacion_repuesto = new Reparacion_Repuestos();
                        reparacion_repuesto.IdReparacion = int.Parse(reader["RepCod"].ToString());
                        reparacion_repuesto.Anio = int.Parse(reader["RepAnio"].ToString());
                        reparacion_repuesto.RepuestoCod = reader["RepuestoCod"].ToString();
                        reparacion_repuesto.Cantidad = int.Parse(reader["Cantidad"].ToString());
                        reparacion_repuesto.CostoUnitario = double.Parse(reader["CostoUnitario"].ToString());
                        resultado.Add(reparacion_repuesto);
                    }
                }

                conexionSQL.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());

            }


            return resultado;

        }

        public static bool AltaReparacionRepuesto(Reparacion_Repuestos pReparacionRepuesto)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("AltaReparacionRepuesto", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RepCod", pReparacionRepuesto.IdReparacion));
                cmd.Parameters.Add(new SqlParameter("@RepAnio", pReparacionRepuesto.Anio));
                cmd.Parameters.Add(new SqlParameter("@RepuestoCod", pReparacionRepuesto.RepuestoCod));
                cmd.Parameters.Add(new SqlParameter("@Cantidad", pReparacionRepuesto.Cantidad));
                cmd.Parameters.Add(new SqlParameter("@CostoUnitario", pReparacionRepuesto.CostoUnitario));
                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;

        }

        public static bool BajaReparacionRepuesto(int pRepCod, int pRepAnio, string pRepuestoCod)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("BajaReparacionRepuesto", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RepCod", pRepCod));
                cmd.Parameters.Add(new SqlParameter("@RepAnio", pRepAnio));
                cmd.Parameters.Add(new SqlParameter("@RepuestoCod", pRepuestoCod));
                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        public static bool ModificarReparacionRepuesto(Reparacion_Repuestos pReparacionRepuesto)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ModificarReparacionRepuesto", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RepCod", pReparacionRepuesto.IdReparacion));
                cmd.Parameters.Add(new SqlParameter("@RepAnio", pReparacionRepuesto.Anio));
                cmd.Parameters.Add(new SqlParameter("@RepuestoCod", pReparacionRepuesto.RepuestoCod));
                cmd.Parameters.Add(new SqlParameter("@Cantidad", pReparacionRepuesto.Cantidad));
                cmd.Parameters.Add(new SqlParameter("@CostoUnitario", pReparacionRepuesto.CostoUnitario));
                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        public static Reparacion_Repuestos BuscarReparacionRepuesto(int pRepCod, int pRepAnio, string pRepuestoCod)
        {
            Reparacion_Repuestos resultado = new Reparacion_Repuestos();
            try
            {
                Reparacion_Repuestos reparacion_repuesto;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("BuscarReparacionRepuesto", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RepCod", pRepCod));
                cmd.Parameters.Add(new SqlParameter("@RepAnio", pRepAnio));
                cmd.Parameters.Add(new SqlParameter("@RepuestoCod", pRepuestoCod));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reparacion_repuesto = new Reparacion_Repuestos();
                        reparacion_repuesto.IdReparacion = int.Parse(reader["RepCod"].ToString());
                        reparacion_repuesto.Anio = int.Parse(reader["RepAnio"].ToString());
                        reparacion_repuesto.RepuestoCod = reader["RepuestoCod"].ToString();
                        reparacion_repuesto.Cantidad = int.Parse(reader["Cantidad"].ToString());
                        reparacion_repuesto.CostoUnitario = double.Parse(reader["CostoUnitario"].ToString());
                        resultado = reparacion_repuesto;
                    }
                }

                conexionSQL.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());

            }

            return resultado;
        }
        #endregion

        #region Persistencia Reparación Horas
        public static List<Reparacion_Horas> ListaReparacion_Horas()
        {
            List<Reparacion_Horas> resultado = new List<Reparacion_Horas>();
            try
            {
                Reparacion_Horas reparacion_horas;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ObtenerReparacionHoras", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reparacion_horas = new Reparacion_Horas();
                        reparacion_horas.IdReparacion = int.Parse(reader["RepCod"].ToString());
                        reparacion_horas.Anio = int.Parse(reader["RepAnio"].ToString());
                        reparacion_horas.IdMecanico = int.Parse(reader["MecCod"].ToString());
                        reparacion_horas.Horas = int.Parse(reader["Horas"].ToString());
                        reparacion_horas.CostoHora = int.Parse(reader["CostoHora"].ToString());
                        resultado.Add(reparacion_horas);
                    }
                }

                conexionSQL.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());

            }


            return resultado;

        }

        public static bool AltaReparacionHoras(Reparacion_Horas pReparacionHoras)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("AltaReparacionHoras", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RepCod", pReparacionHoras.IdReparacion));
                cmd.Parameters.Add(new SqlParameter("@RepAnio", pReparacionHoras.Anio));
                cmd.Parameters.Add(new SqlParameter("@MecCod", pReparacionHoras.IdMecanico));
                cmd.Parameters.Add(new SqlParameter("@Horas", pReparacionHoras.Horas));
                cmd.Parameters.Add(new SqlParameter("@CostoHora", pReparacionHoras.CostoHora));
                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;

        }

        public static bool BajaReparacionHoras(int pRepCod, int pRepAnio)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("BajaReparacionHoras", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RepCod", pRepCod));
                cmd.Parameters.Add(new SqlParameter("@RepAnio", pRepAnio));
                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        public static bool ModificarReparacionHoras(Reparacion_Horas pReparacionHoras)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ModificarReparacionHoras", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RepCod", pReparacionHoras.IdReparacion));
                cmd.Parameters.Add(new SqlParameter("@RepAnio", pReparacionHoras.Anio));
                cmd.Parameters.Add(new SqlParameter("@MecCod", pReparacionHoras.IdMecanico));
                cmd.Parameters.Add(new SqlParameter("@Horas", pReparacionHoras.Horas));
                cmd.Parameters.Add(new SqlParameter("@CostoHora", pReparacionHoras.CostoHora));
                int resBD = cmd.ExecuteNonQuery();

                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexionSQL.State == ConnectionState.Open)
                {
                    conexionSQL.Close();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        public static Reparacion_Horas BuscarReparacionHoras(int pRepCod, int pRepAnio)
        {
            Reparacion_Horas resultado = new Reparacion_Horas();
            try
            {
                Reparacion_Horas reparacion_horas;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("BuscarReparacionHoras", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RepCod", pRepCod));
                cmd.Parameters.Add(new SqlParameter("@RepAnio", pRepAnio));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reparacion_horas = new Reparacion_Horas();
                        reparacion_horas.IdReparacion = int.Parse(reader["RepCod"].ToString());
                        reparacion_horas.Anio = int.Parse(reader["RepAnio"].ToString());
                        reparacion_horas.IdMecanico = int.Parse(reader["MecCod"].ToString());
                        reparacion_horas.Horas = int.Parse(reader["Horas"].ToString());
                        reparacion_horas.CostoHora = int.Parse(reader["CostoHora"].ToString());
                        resultado = reparacion_horas;
                    }
                }

                conexionSQL.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());

            }

            return resultado;
        }
        #endregion

    }
}
