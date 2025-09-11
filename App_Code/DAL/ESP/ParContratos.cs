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
    public class ParContratos
{
    Conexion cnn;
    public ParContratos()
	{
        cnn = new Conexion();
	}

    /// <summary>
    /// Método que obtiene la cantidad de garantías que posee un contrato.
    /// </summary>
    /// <param name="IdContrato">Código de contrato</param>
    /// <returns>Cantidad de garantias</returns>
    public int CantidadGarantiasContrato(int IdContrato)
    {
        int resultado = 0;
        cnn.Com.CommandText = "pa_br_Contratos";
        cnn.Com.Parameters.Clear();
        try { cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "CantidadGarantiasContrato"; }        catch { }
        try { cnn.Com.Parameters.Add("@IdContrato", SqlDbType.Int).Value = IdContrato; }    catch { }
        DataTable dt = cnn.Seleccionar();
        if (dt != null) {
            resultado = (int)dt.Rows[0][0];
        }
        return resultado;
    }

    /// <summary>
    /// Método que obtiene la cantidad de líneas asignadas al contrato.
    /// </summary>
    /// <param name="IdContrato">Código de contrato</param>
    /// <returns>Cantidad de lineas</returns>
    public int CantidadLineasContrato(int IdContrato, bool activo)
    {
        int resultado = 0;
        cnn.Com.CommandText = "pa_br_Contratos";
        cnn.Com.Parameters.Clear();
        try { cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "CantidadLineasContrato"; }        catch { }
        try { cnn.Com.Parameters.Add("@IdContrato", SqlDbType.Int).Value = IdContrato; }        catch { }
        try { cnn.Com.Parameters.Add("@Activo", SqlDbType.Bit).Value = activo; }
        catch { }
        
        DataTable dt = cnn.Seleccionar();
        if (dt != null)
        {
            resultado = (int)dt.Rows[0][0];
        }
        return resultado;
    }

    /// <summary>
    /// Método que obtien la listas de contrato por vencer o vencidos
    /// </summary>
    ///  <param name="numero">Número de contrato.</param>
    ///   <param name="idConcesionario">Código único de concesionario.</param>
    /// <param name="porVencer">Verdadero indica que obtiene contratos por vencer.</param>
    /// <param name="vencidos">Verdaro indica que obtiene contratos vencidos.</param>
    /// <returns>Lista de contratos en DataTable</returns>
    public DataTable ConsultaContratos(string numero, int idConcesionario, bool? porVencer = null, bool? vencidos = null)
    {
        cnn.Com.CommandText = "pa_br_Contratos";
        cnn.Com.Parameters.Clear();
        try { cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "ConsultaContratos"; }        catch { }
        try { cnn.Com.Parameters.Add("@PorVencer", SqlDbType.Bit).Value = porVencer; }        catch { }
        try { cnn.Com.Parameters.Add("@Vencidos", SqlDbType.Bit).Value = vencidos; }  catch { }
        try { cnn.Com.Parameters.Add("@Numero", SqlDbType.VarChar).Value = numero; }        catch { }
        try { cnn.Com.Parameters.Add("@IdConcesionario", SqlDbType.Int).Value = idConcesionario; }        catch { }
        DataTable dt = cnn.Seleccionar();

        return dt;
    }

    /// <summary>
    /// Método que obtiene la próxima modificación de un contrato
    /// </summary>
    /// <param name="Numero">Número de contrato</param>
    /// <returns>Próximo número de modificación</returns>
    public int ObtenerNumeroProximaModificacion(string Numero)
    {
        int resultado = 0;
        cnn.Com.CommandText = "pa_br_Contratos";
        cnn.Com.Parameters.Clear();
        try { cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "ObtenerNumeroProximaModificacion"; }   catch { }
        try { cnn.Com.Parameters.Add("@Numero", SqlDbType.VarChar).Value = Numero; }   catch { }
        DataTable dt = cnn.Seleccionar();
        if (dt != null)
        {
            resultado = (int)dt.Rows[0][0];
        }
        return resultado;
    }

    /// <summary>
    /// Método que obtiene los estados de alerta de los contratos.
    /// </summary>
    /// <returns></returns>
    public DataTable EstadosAlertas()
    {
        cnn.Com.CommandText = "pa_br_Contratos";
        cnn.Com.Parameters.Clear();
        try { cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "EstadosAlertas"; }   catch { }
       
        DataTable dt = cnn.Seleccionar();

        return dt;
    }

    /// <summary>
    /// Acción que obtiene le Id y Número de contrato formateado con la modifiacion y resolucion si la tienen. Sirve para el filtro de informe de contrato.
    /// </summary>
    /// <returns></returns>
    public DataTable ContratosCodigoNombre()
    {
        cnn.Com.CommandText = "pa_br_Contratos";
        cnn.Com.Parameters.Clear();
        try { cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "ContratosCodigoNombre"; } catch { }

        DataTable dt = cnn.Seleccionar();

        return dt;
    }
  
}
}