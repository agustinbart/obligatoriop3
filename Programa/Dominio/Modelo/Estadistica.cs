using Modelo.Consultas;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Estadistica : Conexion
    {
        #region Filtro de fechas

        #region Reparaciones realizadas
        public static List<FiltroFechaListaReparacion> ObtenerReparacionesEntreFechas(DateTime pFecha1, DateTime pFecha2)
        {
            List<FiltroFechaListaReparacion> resultado = new List<FiltroFechaListaReparacion>();
            try
            {
                FiltroFechaListaReparacion reparacion;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ObtenerReparacionesEntreFechas", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Fecha1", pFecha1));
                cmd.Parameters.Add(new SqlParameter("@Fecha2", pFecha2));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reparacion = new FiltroFechaListaReparacion();
                        reparacion.CliNom = reader["CliNom"].ToString();
                        reparacion.Matricula = reader["Matricula"].ToString();
                        reparacion.Fecha = Convert.ToDateTime(reader["FchEntrada"].ToString());
                        reparacion.CostoTotal = double.Parse(reader["CostoTotal"].ToString());
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
        #endregion

        #region Reparaciones pendientes
        public static List<FiltroFechaListaPendiente> ObtenerReparacionesPendientesEntreFechas(DateTime pFecha1, DateTime pFecha2)
        {
            List<FiltroFechaListaPendiente> resultado = new List<FiltroFechaListaPendiente>();
            try
            {
                FiltroFechaListaPendiente reparacion;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ObtenerReparacionesPendientesEntreFechas", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Fecha1", pFecha1));
                cmd.Parameters.Add(new SqlParameter("@Fecha2", pFecha2));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reparacion = new FiltroFechaListaPendiente();
                        reparacion.CliNom = reader["CliNom"].ToString();
                        reparacion.Matricula = reader["Matricula"].ToString();
                        reparacion.Fecha = Convert.ToDateTime(reader["Fecha"].ToString());
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
        #endregion

        #endregion

        #region Repuestos ordenados por más vendidos
        public static List<RepuestosMasVendidos> ObtenerRepuestosMasVendidos()
        {
            List<RepuestosMasVendidos> resultado = new List<RepuestosMasVendidos>();
            try
            {
                RepuestosMasVendidos repuesto;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ObtenerRepuestosMasVendidos", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        repuesto = new RepuestosMasVendidos();
                        repuesto.Codigo = reader["RepuestoCod"].ToString();
                        repuesto.Descripcion = reader["RepuestoDsc"].ToString();
                        repuesto.Costo = double.Parse(reader["RepuestoCosto"].ToString());
                        repuesto.Tipo = reader["RepuestoTipo"].ToString();
                        repuesto.RUTProveedor = reader["ProveedorRUT"].ToString();
                        repuesto.Cantidad = int.Parse(reader["Cantidad"].ToString());
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
        #endregion
    }
}
