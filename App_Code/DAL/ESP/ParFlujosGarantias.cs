using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ENT;
using DAL;



namespace Especiales.DAL
{
public class ParFlujosGarantias
{
    Conexion cnn;
    public ParFlujosGarantias()
	{
        cnn = new Conexion();
	}

    /// <summary>
    /// Método que obtiene la lista de estados pendientes de procesar en la garantía
    /// </summary>
    /// <param name="idGarantia">Código de la garantía</param>
    /// <returns>List</returns>
    public List<Estados> EstadosPendienteGarantia(int idGarantia)
    {
        cnn.Com.CommandText = "pa_br_FlujosGarantias";
        cnn.Com.Parameters.Clear();

        cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "EstadosPendienteGarantia";

        try { cnn.Com.Parameters.Add("@IdGarantia", SqlDbType.Int).Value = idGarantia; } catch { }
   
        DataTable dt = cnn.Seleccionar();

        List<Estados> lstEstados = new List<Estados>();

        if (dt != null)
        {
            foreach (DataRow dr in dt.Rows)
            {
                Estados estados = new Estados();

                try
                {
                    estados.IdEstado = Convert.ToInt32(dr["IdEstado"]);
                }
                catch
                {
                    estados.IdEstado = null;
                }

                try
                {
                    estados.Nombre = Convert.ToString(dr["Nombre"]);
                }
                catch
                {
                    estados.Nombre = null;
                }


                lstEstados.Add(estados);
            }
        }
        return lstEstados;
    }
}
}