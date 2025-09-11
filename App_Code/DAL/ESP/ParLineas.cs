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
public class ParLineas
{
    Conexion cnn;
    public ParLineas()
	{
        cnn = new Conexion();
	}

    /// <summary>
    /// Método que verifica si una línea ya existe con el mismo nombre.
    /// </summary>
    /// <param name="IdLinea">Nombre de línea</param>
    /// <returns>Verdadero o Falso</returns>
    public bool ExisteLinea(string IdLinea)
    {
        bool respuesta = false;
        int resultado = 0;
        cnn.Com.CommandText = "pa_br_Lineas";
        cnn.Com.Parameters.Clear();
        try { cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "ExisteLinea"; }   catch { }
        try { cnn.Com.Parameters.Add("@NombreLinea", SqlDbType.VarChar).Value = IdLinea; }        catch { }
        DataTable dt = cnn.Seleccionar();
        if (dt != null) {
            resultado = (int)dt.Rows[0][0];
            if (resultado >= 1) {
                respuesta = true;
            }
        }
        return respuesta;
    }

    public List<Lineas> LineasSinAsignar()
    {
        cnn.Com.CommandText = "pa_br_Lineas";
        cnn.Com.Parameters.Clear();

        cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "LineasSinAsignar";
      
     
        DataTable dt = cnn.Seleccionar();

        List<Lineas> lstLineas = new List<Lineas>();

        if (dt != null)
        {

            foreach (DataRow dr in dt.Rows)
            {
                Lineas lineas = new Lineas();

                try
                {
                    lineas.IdLinea = Convert.ToInt32(dr["IdLinea"]);
                }
                catch
                {
                    lineas.IdLinea = null;
                }

                try
                {
                    lineas.Nombre = Convert.ToString(dr["Nombre"]);
                }
                catch
                {
                    lineas.Nombre = null;
                }


                lstLineas.Add(lineas);
            }
        }
        return lstLineas;
    }

    /// <summary>
    /// Método que devuelve la lista de líneas con información relacionada.
    /// </summary>
    /// <param name="nombreLinea">Parámetro para filtrar por nombre de la línea.</param>
    /// <param name="numeroContrato">Parámetro para filtrar por el número de contrato.</param>
    /// <param name="nombreConcesionario">Parámetro para filtrar por el nombre del concesionario.</param>
    /// <returns>DataTable</returns>
    public DataTable ListaLineas(string nombreLinea, string numeroContrato, string nombreConcesionario)
    {
        cnn.Com.CommandText = "pa_br_Lineas";
        cnn.Com.Parameters.Clear();
        try { cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "ListaLineas"; }        catch { }
        try { cnn.Com.Parameters.Add("@NombreLinea", SqlDbType.VarChar).Value = nombreLinea; }        catch { }
        try { cnn.Com.Parameters.Add("@NumeroContrato", SqlDbType.VarChar).Value = numeroContrato; }        catch { }
        try { cnn.Com.Parameters.Add("@NombreConcesionario", SqlDbType.VarChar).Value = nombreConcesionario; }        catch { }
     
        DataTable dt = cnn.Seleccionar();

        return dt;
    }

   
}
}