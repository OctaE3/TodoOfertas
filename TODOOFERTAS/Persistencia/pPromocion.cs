using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using TODOOFERTAS.Dominio;

namespace TODOOFERTAS.Persistencia
{
    public class pPromocion : Conexion
    {
        public static List<Promocion> ListaPromocion()
        {
            List<Promocion> resultado = new List<Promocion>();
            try
            {
                Promocion promocion;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand command = new SqlCommand(null, conexionSQL);

                command.CommandText =
                    "Select id_promocion,titulo,producto,descripcion,precio_original,precio_promocion,porcentaje_descuento,imagen,detalles,condiciones,fecha from Promocion";

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        promocion = new Promocion();
                        promocion.Id = reader["id_promocion"].ToString();
                        promocion.Titulo = reader["titulo"].ToString();
                        promocion.Producto = reader["producto"].ToString();
                        promocion.Descripcion = reader["descripcion"].ToString();
                        promocion.PrecioOriginal = int.Parse(reader["precio_original"].ToString());
                        promocion.PrecioPromocion = int.Parse(reader["precio_promocion"].ToString());
                        promocion.PorcentajeDesc = int.Parse(reader["porcentaje_descuento"].ToString());
                        promocion.Imagen = reader["imagen"].ToString();
                        promocion.Detalles = reader["detalles"].ToString();
                        promocion.Condiciones = reader["condiciones"].ToString();
                        promocion.Fecha = DateTime.Parse(reader["fecha"].ToString());
                        resultado.Add(promocion);
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

        public static Promocion BuscarPromocion(string pIdPromocion)
        {
            Promocion resultado = new Promocion();
            try
            {
                Promocion promocion;

                var conexionSQL = new SqlConnection(CadenaDeConexion);
                conexionSQL.Open();

                SqlCommand command = new SqlCommand(null, conexionSQL);

                command.CommandText =
                    "Select id_promocion, titulo,producto,descripcion,precio_original,precio_promocion,porcentaje_descuento,imagen,detalles,condiciones,fecha from Promocion where id_promocion = @id_promocion";

                SqlParameter id_promocion = new SqlParameter("@id_promocion", SqlDbType.VarChar, 6);

                id_promocion.Value = pIdPromocion;

                command.Parameters.Add(id_promocion);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        promocion = new Promocion();
                        promocion.Id = reader["id_promocion"].ToString();
                        promocion.Titulo = reader["titulo"].ToString();
                        promocion.Producto = reader["producto"].ToString();
                        promocion.Descripcion = reader["descripcion"].ToString();
                        promocion.PrecioOriginal = int.Parse(reader["precio_original"].ToString());
                        promocion.PrecioPromocion = int.Parse(reader["precio_promocion"].ToString());
                        promocion.PorcentajeDesc = int.Parse(reader["porcentaje_descuento"].ToString());
                        promocion.Imagen = reader["imagen"].ToString();
                        promocion.Detalles = reader["detalles"].ToString();
                        promocion.Condiciones = reader["condiciones"].ToString();
                        promocion.Fecha = DateTime.Parse(reader["fecha"].ToString());
                        resultado = promocion;
                        return resultado;
                    }
                }
                conexionSQL.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return null;
        }

        public static bool InsertTablaPromocion(Promocion pPromocion)
        {
            bool resultado = false;
            try
            {
                var conexion = new SqlConnection(CadenaDeConexion);
                conexion.Open();

                SqlCommand command = new SqlCommand(null, conexion);

                command.CommandText =
                    "Insert into Promocion(id_promocion, titulo,producto,descripcion,precio_original,precio_promocion,porcentaje_descuento,imagen,detalles,condiciones,fecha)" +
                    "Values(@id_promocion, @titulo,@producto,@descripcion,@precio_original,@precio_promocion,@porcentaje_descuento,@imagen,@detalles,@condiciones,@fecha)";

                SqlParameter id_promocion = new SqlParameter("@id_promocion", SqlDbType.VarChar, 6);
                SqlParameter titulo = new SqlParameter("@titulo", SqlDbType.Text, 30);
                SqlParameter descripcion = new SqlParameter("@descripcion", SqlDbType.Text, 50);
                SqlParameter producto = new SqlParameter("@producto", SqlDbType.Text, 30);
                SqlParameter precio_original = new SqlParameter("@precio_original", SqlDbType.Int, 0);
                SqlParameter precio_promocion = new SqlParameter("@precio_promocion", SqlDbType.Int, 0);
                SqlParameter porcentaje_descuento = new SqlParameter("@porcentaje_descuento", SqlDbType.Int, 0);
                SqlParameter imagen = new SqlParameter("@imagen", SqlDbType.Text, 150);
                SqlParameter detalles = new SqlParameter("@detalles", SqlDbType.Text, 100);
                SqlParameter condiciones = new SqlParameter("@condiciones", SqlDbType.Text, 100);
                SqlParameter fecha = new SqlParameter("@fecha", SqlDbType.Date);

                id_promocion.Value = pPromocion.Id;
                titulo.Value = pPromocion.Titulo;
                producto.Value = pPromocion.Producto;
                descripcion.Value = pPromocion.Descripcion;
                precio_original.Value = pPromocion.PrecioOriginal;
                precio_promocion.Value = pPromocion.PrecioPromocion;
                porcentaje_descuento.Value = pPromocion.PorcentajeDesc;
                imagen.Value = pPromocion.Imagen;
                detalles.Value = pPromocion.Detalles;
                condiciones.Value = pPromocion.Condiciones;
                fecha.Value = pPromocion.Fecha;

                command.Parameters.Add(id_promocion);
                command.Parameters.Add(titulo);
                command.Parameters.Add(producto);
                command.Parameters.Add(descripcion);
                command.Parameters.Add(precio_original);
                command.Parameters.Add(precio_promocion);
                command.Parameters.Add(porcentaje_descuento);
                command.Parameters.Add(imagen);
                command.Parameters.Add(detalles);
                command.Parameters.Add(condiciones);
                command.Parameters.Add(fecha);

                command.Prepare();
                command.ExecuteNonQuery();

                conexion.Close();
                resultado = true;
            }
            catch(Exception e)
            {
                throw new Exception(e.ToString());
            }
            return resultado;
        }

        public static bool EliminarPromocion(string pIdPromocion)
        {
            bool resultado = false;
            try
            {
                var conexion = new SqlConnection(CadenaDeConexion);
                conexion.Open();

                SqlCommand command = new SqlCommand(null, conexion);

                command.CommandText =
                    "Delete from Promocion where id_promocion = @id_promocion";

                SqlParameter id_promocion = new SqlParameter("@id_promocion", SqlDbType.VarChar, 6);

                id_promocion.Value = pIdPromocion;

                command.Parameters.Add(id_promocion);

                command.Prepare();
                command.ExecuteNonQuery();

                conexion.Close();
                resultado = true;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            return resultado;
        }

        public static bool ModificarPromocion(Promocion pPromocion)
        {
            bool resultado = false;
            try
            {
                var conexion = new SqlConnection(CadenaDeConexion);
                conexion.Open();

                SqlCommand command = new SqlCommand(null, conexion);

                command.CommandText =
                    "Update Promocion set titulo = @titulo, descripcion = @descripcion, producto = @producto, precio_original = @precio_original, porcentaje_descuento = @porcentaje_descuento, imagen = @imagen, detalles = @detalles, condiciones = @condiciones, fecha = @fecha where id_promocion = @id_promocion";

                SqlParameter id_promocion = new SqlParameter("@id_promocion", SqlDbType.VarChar, 6);
                SqlParameter titulo = new SqlParameter("@titulo", SqlDbType.Text, 30);
                SqlParameter descripcion = new SqlParameter("@descripcion", SqlDbType.Text, 50);
                SqlParameter producto = new SqlParameter("@producto", SqlDbType.Text, 30);
                SqlParameter precio_original = new SqlParameter("@precio_original", SqlDbType.Int, 0);
                SqlParameter precio_promocion = new SqlParameter("@precio_promocion", SqlDbType.Int, 0);
                SqlParameter porcentaje_descuento = new SqlParameter("@porcentaje_descuento", SqlDbType.Int, 0);
                SqlParameter imagen = new SqlParameter("@imagen", SqlDbType.Text, 150);
                SqlParameter detalles = new SqlParameter("@detalles", SqlDbType.Text, 100);
                SqlParameter condiciones = new SqlParameter("@condiciones", SqlDbType.Text, 100);
                SqlParameter fecha = new SqlParameter("@fecha", SqlDbType.Date);

                id_promocion.Value = pPromocion.Id;
                titulo.Value = pPromocion.Titulo;
                producto.Value = pPromocion.Producto;
                descripcion.Value = pPromocion.Descripcion;
                precio_original.Value = pPromocion.PrecioOriginal;
                precio_promocion.Value = pPromocion.PrecioPromocion;
                porcentaje_descuento.Value = pPromocion.PorcentajeDesc;
                imagen.Value = pPromocion.Imagen;
                detalles.Value = pPromocion.Detalles;
                condiciones.Value = pPromocion.Condiciones;
                fecha.Value = pPromocion.Fecha;

                command.Parameters.Add(id_promocion);
                command.Parameters.Add(titulo);
                command.Parameters.Add(producto);
                command.Parameters.Add(descripcion);
                command.Parameters.Add(precio_original);
                command.Parameters.Add(precio_promocion);
                command.Parameters.Add(porcentaje_descuento);
                command.Parameters.Add(imagen);
                command.Parameters.Add(detalles);
                command.Parameters.Add(condiciones);
                command.Parameters.Add(fecha);

                command.Prepare();
                command.ExecuteNonQuery();

                conexion.Close();
                resultado = true;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            return resultado;
        }
    }
}