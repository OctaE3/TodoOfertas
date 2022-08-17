using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TODOOFERTAS.Dominio;

namespace TODOOFERTAS.Persistencia
{
    public class pVenta : Conexion
    {
        public static List<Venta> ListaVenta()
        {
            List<Venta> resultado = new List<Venta>();
            try
            {
                Venta venta;

                var conexion = new SqlConnection(CadenaDeConexion);
                conexion.Open();

                SqlCommand cmd = new SqlCommand(null, conexion);

                cmd.CommandText = "SELECT id_venta, id_promocion, ci_usuario FROM Usuario";

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        venta = new Venta();
                        venta.Id = int.Parse(reader["id_venta"].ToString());
                        venta.IdPromocion = reader["id_promocion"].ToString();
                        venta.CiUsuario = int.Parse(reader["ci_usuario"].ToString());
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

        public static bool AltaVenta(Venta venta)
        {
            bool resultado = false;

            try
            {
                var conexion = new SqlConnection(CadenaDeConexion);
                conexion.Open();
                SqlCommand cmd = new SqlCommand(null, conexion);

                cmd.CommandText = $"INSERT INTO Venta(id_promocion, ci_usuario) VALUES(@id_promocion, @ci_usuario)";

                SqlParameter idpromocion = new SqlParameter("@id_promocion", SqlDbType.VarChar, 6);
                SqlParameter ciusuario = new SqlParameter("@ci_usuario", SqlDbType.Int, 0);

                idpromocion.Value = venta.IdPromocion;
                ciusuario.Value = venta.CiUsuario;

                cmd.Parameters.Add(idpromocion);
                cmd.Parameters.Add(ciusuario);

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

        public static Venta BuscarVenta(int pId)
        {
            Venta resultado = new Venta();
            try
            {
                Venta venta;

                var conexion = new SqlConnection(CadenaDeConexion);
                conexion.Open();
                SqlCommand cmd = new SqlCommand(null, conexion);

                cmd.CommandText = $"SELECT id_venta, id_promocion, ci_usuario FROM Usuario WHERE id_venta = @id_venta";

                SqlParameter idventa = new SqlParameter("@id_venta", SqlDbType.Int, 0);

                idventa.Value = pId;

                cmd.Parameters.Add(idventa);

                cmd.Prepare();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        venta = new Venta();
                        venta.Id = int.Parse(reader["id_venta"].ToString());
                        venta.IdPromocion = reader["id_promocion"].ToString();
                        venta.CiUsuario = int.Parse(reader["ci_usuario"].ToString());
                        resultado = venta;
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