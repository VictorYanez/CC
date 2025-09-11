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
    public class ParGarantias
{
    Conexion cnn;
    public ParGarantias()
	{
        cnn = new Conexion();
	}

    /// <summary>
    /// Método que devuelve las garantías en sus diferentes esetados de alertas.
    /// </summary>
    /// <param name="porVencer">Indica si se desea obtener garantías por vencer.</param>
    /// <param name="vencidas">Indica si se desea obtener garnatías vencidas.</param>
    /// <param name="documentacionPendiente">Indica si se desean obtener las garantías pendientes de documentación.</param>
    ///  <param name="numero">Número de garantía</param>
    ///  <param name="idEstado">Código de estado de la garantía</param>
    /// <returns>DataTable</returns>
    public DataTable ConsultaGarantias(string numero, int idEstado, bool? porVencer, bool? vencidas, bool? documentacionPendiente)
    {
        cnn.Com.CommandText = "pa_br_Garantias";
        cnn.Com.Parameters.Clear();
        try { cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "ConsultaGarantias"; }   catch { }
        try { cnn.Com.Parameters.Add("@PorVencer", SqlDbType.Bit).Value = porVencer; }        catch { }
        try { cnn.Com.Parameters.Add("@Vencidas", SqlDbType.Bit).Value = vencidas; }  catch { }
        try { cnn.Com.Parameters.Add("@DocumentacionPendiente", SqlDbType.Bit).Value = documentacionPendiente; }      catch { }
        try { cnn.Com.Parameters.Add("@Numero", SqlDbType.VarChar).Value = numero; }        catch { }
        try { cnn.Com.Parameters.Add("@IdEstado", SqlDbType.Int).Value = idEstado; }        catch { }
        DataTable dt = cnn.Seleccionar();

        return dt;
    }

    /// <summary>
    /// Método que obtiene los estados de alerta de los contratos.
    /// </summary>
    /// <returns></returns>
    public DataTable EstadosAlertas()
    {
        cnn.Com.CommandText = "pa_br_Garantias";
        cnn.Com.Parameters.Clear();
        try { cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "EstadosAlertas"; }  catch { }
      
        DataTable dt = cnn.Seleccionar();

        return dt;
    }

    public int ObtenerIdProximoEstado(int idGarantia)
    {
        int resultado = 0;
        cnn.Com.CommandText = "pa_br_Garantias";
        cnn.Com.Parameters.Clear();
        try { cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "ObtenerIdProximoEstado"; }        catch { }
        try { cnn.Com.Parameters.Add("@IdGarantia", SqlDbType.Int).Value = idGarantia; }        catch { }
        DataTable dt = cnn.Seleccionar();
        
        if (dt != null)
        {
            resultado = (int)dt.Rows[0][0];
        }
        return resultado;
    }

  
}
}