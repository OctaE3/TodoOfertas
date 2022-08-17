using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TODOOFERTAS.Dominio;

namespace TODOOFERTAS.Persistencia
{
    public class pUsuario : Conexion
    {
        public static List<Usuario> ListaUsuario()
        {
            List<Usuario> resultado = new List<Usuario>();
            try
            {
                Usuario usuario;

                var conexion = new SqlConnection(CadenaDeConexion);
                conexion.Open();

                SqlCommand cmd = new SqlCommand(null, conexion);

                cmd.CommandText = "SELECT cedula, nombre, password FROM Usuario";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuario = new Usuario();
                        usuario.Ci = int.Parse(reader["cedula"].ToString());
                        usuario.Nombre = reader["nombre"].ToString();
                        usuario.Password = reader["password"].ToString();
                    }
                }

                conexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

            return resultado;
        }

        public static bool AltaUsuario(Usuario pUsuario)
        {
            bool resultado = false;

            try
            {
                var conexion = new SqlConnection(CadenaDeConexion);
                conexion.Open();
                SqlCommand cmd = new SqlCommand(null, conexion);

                cmd.CommandText = $"INSERT INTO Usuario(cedula, nombre, password, intentos) VALUES(@cedula, @nombre, @password, @intentos)";

                SqlParameter cedula = new SqlParameter("@cedula", SqlDbType.Int, 0);
                SqlParameter nombre = new SqlParameter("@nombre", SqlDbType.Text, 30);
                SqlParameter password = new SqlParameter("@password", SqlDbType.VarChar, 16);
                SqlParameter intentos = new SqlParameter("@intentos", SqlDbType.Int, 0);

                cedula.Value = pUsuario.Ci;
                nombre.Value = pUsuario.Nombre;
                password.Value = pUsuario.Password;
                intentos.Value = pUsuario.Intentos;

                cmd.Parameters.Add(cedula);
                cmd.Parameters.Add(nombre);
                cmd.Parameters.Add(password);
                cmd.Parameters.Add(intentos);

                cmd.Prepare();
                int resBD = cmd.ExecuteNonQuery();
                if (resBD > 0)
                {
                    resultado = true;
                }
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        public static Usuario BuscarUsuario(int pCedula, string pPassword)
        {
            Usuario resultado = new Usuario();
            try
            {
                Usuario usuario;

                var conexion = new SqlConnection(CadenaDeConexion);
                conexion.Open();
                SqlCommand cmd = new SqlCommand(null, conexion);

                cmd.CommandText = $"SELECT cedula, nombre, password, intentos FROM Usuario WHERE cedula = @cedula AND password = @password";

                SqlParameter cedula = new SqlParameter("@cedula", SqlDbType.Int, 0);
                SqlParameter password = new SqlParameter("@password", SqlDbType.VarChar, 16);

                cedula.Value = pCedula;
                password.Value = pPassword;

                cmd.Parameters.Add(cedula);
                cmd.Parameters.Add(password);

                cmd.Prepare();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuario = new Usuario();
                        usuario.Ci = int.Parse(reader["cedula"].ToString());
                        usuario.Nombre = reader["nombre"].ToString();
                        usuario.Password = reader["password"].ToString();
                        usuario.Intentos = int.Parse(reader["intentos"].ToString());
                        resultado = usuario;
                        return resultado;
                    }
                }

                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

        public static bool SumarIntentos(int pCedula)
        {
            try
            {
                var conexion = new SqlConnection(CadenaDeConexion);
                conexion.Open();
                SqlCommand cmd = new SqlCommand(null, conexion);

                cmd.CommandText = $"UPDATE Usuario SET intentos = intentos + 1 WHERE cedula = @cedula";

                SqlParameter cedula = new SqlParameter("@cedula", SqlDbType.Int, 0);

                cedula.Value = pCedula;
                cmd.Parameters.Add(cedula);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }
        public static bool Reset(int pCedula)
        {
            try
            {
                var conexion = new SqlConnection(CadenaDeConexion);
                conexion.Open();
                SqlCommand cmd = new SqlCommand(null, conexion);

                cmd.CommandText = $"UPDATE Usuario SET intentos = 0 WHERE cedula = @cedula";

                SqlParameter cedula = new SqlParameter("@cedula", SqlDbType.Int, 0);

                cedula.Value = pCedula;
                cmd.Parameters.Add(cedula);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }


        public static Usuario BuscarUsuarioCi(int pCedula)
        {
            Usuario resultado = new Usuario();
            try
            {
                Usuario usuario;

                var conexion = new SqlConnection(CadenaDeConexion);
                conexion.Open();
                SqlCommand cmd = new SqlCommand(null, conexion);

                cmd.CommandText = $"SELECT cedula, nombre, password, intentos FROM Usuario WHERE cedula = @cedula";

                SqlParameter cedula = new SqlParameter("@cedula", SqlDbType.Int, 0);
               

                cedula.Value = pCedula;
                

                cmd.Parameters.Add(cedula);
                

                cmd.Prepare();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuario = new Usuario();
                        usuario.Ci = int.Parse(reader["cedula"].ToString());
                        usuario.Nombre = reader["nombre"].ToString();
                        usuario.Password = reader["password"].ToString();
                        usuario.Intentos = int.Parse(reader["intentos"].ToString());
                        resultado = usuario;
                        return resultado;
                    }
                }

                conexion.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

    }

}