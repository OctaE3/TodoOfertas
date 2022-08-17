using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TODOOFERTAS.Dominio;

namespace TODOOFERTAS.Persistencia
{
    public class pAdministrador : Conexion
    {
        public static List<Administrador> ListaAdmin()
        {
            List<Administrador> resultado = new List<Administrador>();
            try
            {
                Administrador administrador;

                var conexion = new SqlConnection(CadenaDeConexion);
                conexion.Open();

                SqlCommand cmd = new SqlCommand(null, conexion);

                cmd.CommandText = "SELECT cedula, nombre, password FROM Administrador";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        administrador = new Administrador();
                        administrador.Ci = int.Parse(reader["cedula"].ToString());
                        administrador.Nombre = reader["nombre"].ToString();
                        administrador.Password = reader["password"].ToString();
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

        public static bool AltaAdmin(Administrador pAdmin)
        {
            bool resultado = false;

            try
            {
                var conexion = new SqlConnection(CadenaDeConexion);
                conexion.Open();
                SqlCommand cmd = new SqlCommand(null, conexion);

                cmd.CommandText = $"INSERT INTO Administrador(cedula, nombre, password, intentos) VALUES(@cedula, @nombre, @password, @intentos)";

                SqlParameter cedula = new SqlParameter("@cedula", SqlDbType.Int, 0);
                SqlParameter nombre = new SqlParameter("@nombre", SqlDbType.Text, 30);
                SqlParameter password = new SqlParameter("@password", SqlDbType.VarChar, 16);
                SqlParameter intentos = new SqlParameter("@intentos", SqlDbType.Int, 0);

                cedula.Value = pAdmin.Ci;
                nombre.Value = pAdmin.Nombre;
                password.Value = pAdmin.Password;
                intentos.Value = pAdmin.Intentos;
            
                cmd.Parameters.Add(cedula);
                cmd.Parameters.Add(nombre);
                cmd.Parameters.Add(password);
                cmd.Parameters.Add(intentos);

                cmd.Prepare();
                int resBD = cmd.ExecuteNonQuery();
                if(resBD > 0)
                {
                    resultado = true;
                }
                if(conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        public static Administrador BuscarAdmin(int pCedula, string pPassword)
        {
            Administrador resultado = new Administrador();
            try
            {
                Administrador administrador;

                var conexion = new SqlConnection(CadenaDeConexion);
                conexion.Open();
                SqlCommand cmd = new SqlCommand(null, conexion);

                cmd.CommandText = $"SELECT cedula, nombre, password, intentos FROM Administrador WHERE cedula = @cedula AND password = @password";

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
                        administrador = new Administrador();
                        administrador.Ci = int.Parse(reader["cedula"].ToString());
                        administrador.Nombre = reader["nombre"].ToString();
                        administrador.Password = reader["password"].ToString();
                        administrador.Intentos = int.Parse(reader["intentos"].ToString());
                        resultado = administrador;
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
        public static Administrador BuscarAdminCi(int pCedula)
        {
            Administrador resultado = new Administrador();
            try
            {
                Administrador administrador;

                var conexion = new SqlConnection(CadenaDeConexion);
                conexion.Open();
                SqlCommand cmd = new SqlCommand(null, conexion);

                cmd.CommandText = $"SELECT cedula, nombre, password, intentos FROM Administrador WHERE cedula = @cedula";

                SqlParameter cedula = new SqlParameter("@cedula", SqlDbType.Int, 0);
                
                cedula.Value = pCedula;
                

                cmd.Parameters.Add(cedula);
                

                cmd.Prepare();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        administrador = new Administrador();
                        administrador.Ci = int.Parse(reader["cedula"].ToString());
                        administrador.Nombre = reader["nombre"].ToString();
                        administrador.Password = reader["password"].ToString();
                        administrador.Intentos = int.Parse(reader["intentos"].ToString());
                        resultado = administrador;
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

                cmd.CommandText = $"UPDATE Administrador SET intentos = intentos + 1 WHERE cedula = @cedula";

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

                cmd.CommandText = $"UPDATE Administrador SET intentos = 0 WHERE cedula = @cedula";

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
    }
}