using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOOFERTAS.Dominio;

namespace TODOOFERTAS.Persistencia
{
    public class pAudith : Conexion
    {
        public static bool AltaAudith(Audith pAudith)
        {
            bool resultado = false;

            try
            {
                var conexion = new SqlConnection(CadenaDeConexion);
                conexion.Open();
                SqlCommand cmd = new SqlCommand(null, conexion);

                cmd.CommandText = $"INSERT INTO audithPromocion(cedula, descripcion, fecha) VALUES(@cedula, @descripcion, @fecha)";

                SqlParameter cedula = new SqlParameter("@cedula", SqlDbType.Int, 0);
                SqlParameter descripcion = new SqlParameter("@descripcion", SqlDbType.Text, 30);
                SqlParameter fecha = new SqlParameter("@fecha", SqlDbType.Date);

              
                cedula.Value = pAudith.Cedula;
                descripcion.Value = pAudith.Desc;
                fecha.Value = pAudith.Fecha;

                cmd.Parameters.Add(cedula);
                cmd.Parameters.Add(descripcion);
                cmd.Parameters.Add(fecha);

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
    }
}
