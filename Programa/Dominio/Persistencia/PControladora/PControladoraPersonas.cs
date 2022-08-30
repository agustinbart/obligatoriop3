using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Modelo;


namespace Persistencia.PControladora
{
    public class PControladoraPersonas : Conexion
    {
        #region Persistencia Administradores
        public static List<Administrador> ListaAdministradores()
        {
            List<Administrador> resultado = new List<Administrador>();
            try
            {
                Administrador administrador;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ObtenerAdmin", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        administrador = new Administrador();
                        administrador.Id = int.Parse(reader["AdminCod"].ToString());
                        administrador.Nombre = reader["AdminNom"].ToString();
                        administrador.Cedula = reader["AdminCI"].ToString();
                        administrador.Telefono = reader["AdminTel"].ToString();
                        administrador.Direccion = reader["AdminDir"].ToString();
                        administrador.Mail = reader["AdminMail"].ToString();
                        administrador.FechaRegistro = Convert.ToDateTime(reader["FchRegistro"].ToString());
                        administrador.Contrasena = reader["Contrasena"].ToString();
                        resultado.Add(administrador);
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

        public static bool AltaAdmin(Administrador pAdmin)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("AltaAdmin", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@AdminNom", pAdmin.Nombre));
                cmd.Parameters.Add(new SqlParameter("@AdminCI", pAdmin.Cedula));
                cmd.Parameters.Add(new SqlParameter("@AdminTel", pAdmin.Telefono));
                cmd.Parameters.Add(new SqlParameter("@AdminDir", pAdmin.Direccion));
                cmd.Parameters.Add(new SqlParameter("@AdminMail", pAdmin.Mail));
                cmd.Parameters.Add(new SqlParameter("@Contrasena", pAdmin.Contrasena));
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

        public static bool BajaAdmin(int pId)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("BajaAdmin", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@AdminCod", pId));
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

        public static bool ModificarAdmin(Administrador pAdmin)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ModificarAdmin", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@AdminCod", pAdmin.Id));
                cmd.Parameters.Add(new SqlParameter("@AdminNom", pAdmin.Nombre));
                cmd.Parameters.Add(new SqlParameter("@AdminCI", pAdmin.Cedula));
                cmd.Parameters.Add(new SqlParameter("@AdminTel", pAdmin.Telefono));
                cmd.Parameters.Add(new SqlParameter("@AdminDir", pAdmin.Direccion));
                cmd.Parameters.Add(new SqlParameter("@AdminMail", pAdmin.Mail));
                cmd.Parameters.Add(new SqlParameter("@Contrasena", pAdmin.Contrasena));
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

        public static Administrador BuscarAdmin(int pId)
        {
            Administrador resultado = new Administrador();
            try
            {
                Administrador administrador;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("BuscarAdmin", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@AdminCod", pId));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        administrador = new Administrador();
                        administrador.Id = int.Parse(reader["AdminCod"].ToString());
                        administrador.Nombre = reader["AdminNom"].ToString();
                        administrador.Cedula = reader["AdminCI"].ToString();
                        administrador.Telefono = reader["AdminTel"].ToString();
                        administrador.Direccion = reader["AdminDir"].ToString();
                        administrador.Mail = reader["AdminMail"].ToString();
                        administrador.FechaRegistro = Convert.ToDateTime(reader["FchRegistro"].ToString());
                        administrador.Contrasena = reader["Contrasena"].ToString();
                        resultado = administrador;
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

        #region Persistencia Clientes
        public static List<Cliente> ListaClientes()
        {
            List<Cliente> resultado = new List<Cliente>();
            try
            {
                Cliente cliente;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ObtenerClientes", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cliente = new Cliente();
                        cliente.Id = int.Parse(reader["CliCod"].ToString());
                        cliente.Nombre = reader["CliNom"].ToString();
                        cliente.Cedula = reader["CliCI"].ToString();
                        cliente.Telefono = reader["CliTel"].ToString();
                        cliente.Direccion = reader["CliDir"].ToString();
                        cliente.Mail = reader["CliMail"].ToString();
                        cliente.FechaRegistro = Convert.ToDateTime(reader["FchRegistro"].ToString());
                        cliente.Contrasena = reader["Contrasena"].ToString();
                        resultado.Add(cliente);
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

        public static bool AltaCliente(Cliente pCliente)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("AltaCliente", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CliNom", pCliente.Nombre));
                cmd.Parameters.Add(new SqlParameter("@CliCI", pCliente.Cedula));
                cmd.Parameters.Add(new SqlParameter("@CliTel", pCliente.Telefono));
                cmd.Parameters.Add(new SqlParameter("@CliDir", pCliente.Direccion));
                cmd.Parameters.Add(new SqlParameter("@CliMail", pCliente.Mail));
                cmd.Parameters.Add(new SqlParameter("@Contrasena", pCliente.Contrasena));
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

        public static bool BajaCliente(int pId)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("BajaCliente", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CliCod", pId));
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

        public static bool ModificarCliente(Cliente pCliente)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ModificarCliente", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CliCod", pCliente.Id));
                cmd.Parameters.Add(new SqlParameter("@CliNom", pCliente.Nombre));
                cmd.Parameters.Add(new SqlParameter("@CliCI", pCliente.Cedula));
                cmd.Parameters.Add(new SqlParameter("@CliTel", pCliente.Telefono));
                cmd.Parameters.Add(new SqlParameter("@CliDir", pCliente.Direccion));
                cmd.Parameters.Add(new SqlParameter("@CliMail", pCliente.Mail));
                cmd.Parameters.Add(new SqlParameter("@Contrasena", pCliente.Contrasena));
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

        public static Cliente BuscarCliente(int pId)
        {
            Cliente resultado = new Cliente();
            try
            {
                Cliente cliente;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("BuscarCliente", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CliCod", pId));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cliente = new Cliente();
                        cliente.Id = int.Parse(reader["CliCod"].ToString());
                        cliente.Nombre = reader["CliNom"].ToString();
                        cliente.Cedula = reader["CliCI"].ToString();
                        cliente.Telefono = reader["CliTel"].ToString();
                        cliente.Direccion = reader["CliDir"].ToString();
                        cliente.Mail = reader["CliMail"].ToString();
                        cliente.FechaRegistro = Convert.ToDateTime(reader["FchRegistro"].ToString());
                        cliente.Contrasena = reader["Contrasena"].ToString();
                        resultado = cliente;
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

        #region Persistencia Mecánicos
        public static List<Mecanico> ListaMecanicos()
        {
            List<Mecanico> resultado = new List<Mecanico>();
            try
            {
                Mecanico mecanico;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ObtenerMecanicos", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mecanico = new Mecanico();
                        mecanico.Id = int.Parse(reader["MecCod"].ToString());
                        mecanico.Nombre = reader["MecNom"].ToString();
                        mecanico.Cedula = reader["MecCI"].ToString();
                        mecanico.Telefono = reader["MecTel"].ToString();
                        mecanico.FechaIngreso = Convert.ToDateTime(reader["MecFchIng"].ToString());
                        mecanico.ValorHora = int.Parse(reader["MecValorHora"].ToString());
                        mecanico.Activo = reader["MecActivo"].ToString();
                        resultado.Add(mecanico);
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

        public static bool AltaMecanico(Mecanico pMecanico)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("AltaMecanico", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MecNom", pMecanico.Nombre));
                cmd.Parameters.Add(new SqlParameter("@MecCI", pMecanico.Cedula));
                cmd.Parameters.Add(new SqlParameter("@MecTel", pMecanico.Telefono));
                cmd.Parameters.Add(new SqlParameter("@MecFchIng", pMecanico.FechaIngreso));
                cmd.Parameters.Add(new SqlParameter("@MecValorHora", pMecanico.ValorHora));
                cmd.Parameters.Add(new SqlParameter("@MecActivo", pMecanico.Activo));
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

        public static bool BajaMecanico(int pId)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("BajaMecanico", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MecCod", pId));
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

        public static bool ModificarMecanico(Mecanico pMecanico)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ModificarMecanico", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MecCod", pMecanico.Id));
                cmd.Parameters.Add(new SqlParameter("@MecNom", pMecanico.Nombre));
                cmd.Parameters.Add(new SqlParameter("@MecCI", pMecanico.Cedula));
                cmd.Parameters.Add(new SqlParameter("@MecTel", pMecanico.Telefono));
                cmd.Parameters.Add(new SqlParameter("@MecFchIng", pMecanico.FechaIngreso));
                cmd.Parameters.Add(new SqlParameter("@MecValorHora", pMecanico.ValorHora));
                cmd.Parameters.Add(new SqlParameter("@MecActivo", pMecanico.Activo));
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

        public static Mecanico BuscarMecanico(int pId)
        {
            Mecanico resultado = new Mecanico();
            try
            {
                Mecanico mecanico;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("BuscarMecanico", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@MecCod", pId));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        mecanico = new Mecanico();
                        mecanico.Id = int.Parse(reader["MecCod"].ToString());
                        mecanico.Nombre = reader["MecNom"].ToString();
                        mecanico.Cedula = reader["MecCI"].ToString();
                        mecanico.Telefono = reader["MecTel"].ToString();
                        mecanico.FechaIngreso = Convert.ToDateTime(reader["MecFchIng"].ToString());
                        mecanico.ValorHora = int.Parse(reader["MecValorHora"].ToString());
                        mecanico.Activo = reader["MecActivo"].ToString();
                        resultado = mecanico;
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

        #region Persistencia Proveedores
        public static List<Proveedor> ListaProveedores()
        {
            List<Proveedor> resultado = new List<Proveedor>();
            try
            {
                Proveedor proveedor;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ObtenerProveedor", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        proveedor = new Proveedor();
                        proveedor.RUT = reader["RUT"].ToString();
                        proveedor.Nombre = reader["Nombre"].ToString();
                        proveedor.Mail = reader["Mail"].ToString();
                        proveedor.Telefono = reader["Telefono"].ToString();
                        resultado.Add(proveedor);
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

        public static bool AltaProveedor(Proveedor pProveedor)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("AltaProveedor", conexionSQL);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RUT", pProveedor.RUT));
                cmd.Parameters.Add(new SqlParameter("@Nombre", pProveedor.Nombre));
                cmd.Parameters.Add(new SqlParameter("@Mail", pProveedor.Mail));
                cmd.Parameters.Add(new SqlParameter("@Telefono", pProveedor.Telefono));
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

        public static bool BajaProveedor(string pRUT)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("BajaProveedor", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RUT", pRUT));
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

        public static bool ModificarProveedor(Proveedor pProveedor)
        {
            bool resultado = false;

            try
            {
                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("ModificarProveedor", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RUT", pProveedor.RUT));
                cmd.Parameters.Add(new SqlParameter("@Nombre", pProveedor.Nombre));
                cmd.Parameters.Add(new SqlParameter("@Mail", pProveedor.Mail));
                cmd.Parameters.Add(new SqlParameter("@Telefono", pProveedor.Telefono));
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

        public static Proveedor BuscarProveedor(string pRUT)
        {
            Proveedor resultado = new Proveedor();
            try
            {
                Proveedor proveedor;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();
                SqlCommand cmd = new SqlCommand("BuscarProveedor", conexionSQL);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RUT", pRUT));
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        proveedor = new Proveedor();
                        proveedor.RUT = reader["RUT"].ToString();
                        proveedor.Nombre = reader["Nombre"].ToString();
                        proveedor.Mail = reader["Mail"].ToString();
                        proveedor.Telefono = reader["Telefono"].ToString();
                        resultado = proveedor;
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

        #region Login Clientes
        public static Cliente BuscarClienteLogin(string pCedula, string pContrasena)
        {
            Cliente resultado = new Cliente();
            try
            {
                Cliente cliente;

                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("BuscarClienteLogin", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Cedula", pCedula));
                cmd.Parameters.Add(new SqlParameter("@Contrasena", pContrasena));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cliente = new Cliente();
                        cliente.Id = int.Parse(reader["CliCod"].ToString());
                        cliente.Cedula = reader["CliCI"].ToString();
                        cliente.Contrasena = reader["Contrasena"].ToString();
                        resultado = cliente;
                        return resultado;
                    }
                }
                conexionSql.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        #endregion

        #region Login Administradores
        public static Administrador BuscarAdminLogin(string pCedula, string pContrasena)
        {
            Administrador resultado = new Administrador();
            try
            {
                Administrador admin;

                var conexionSql = new SqlConnection(CadenaDeConexion);
                conexionSql.Open();

                SqlCommand cmd = new SqlCommand("BuscarAdminLogin", conexionSql);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Cedula", pCedula));
                cmd.Parameters.Add(new SqlParameter("@Contrasena", pContrasena));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        admin = new Administrador();
                        admin.Id = int.Parse(reader["AdminCod"].ToString());
                        admin.Cedula = reader["AdminCI"].ToString();
                        admin.Contrasena = reader["Contrasena"].ToString();
                        resultado = admin;
                        return resultado;
                    }
                }
                conexionSql.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        #endregion
    }
}
