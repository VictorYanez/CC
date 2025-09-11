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
    public class ParReportes
{
    Conexion cnn;
    public ParReportes()
	{
        cnn = new Conexion();
	}

    public DataTable ReporteContratos(ContratosParamsRep param, string accion = "Contratos")
    {
        cnn.Com.CommandText = "pa_br_Reportes";
        cnn.Com.Parameters.Clear();
        try { cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = accion; }    catch { }
        try { cnn.Com.Parameters.Add("@RegistrosPorVencer", SqlDbType.Bit).Value = param.RegistrosPorVencer; } catch { }
        try { cnn.Com.Parameters.Add("@RegistrosVencidos", SqlDbType.Bit).Value = param.RegistrosVencidos; }  catch { }
        try { cnn.Com.Parameters.Add("@ContratoFinalizado", SqlDbType.Bit).Value = param.ContratoFinalizado; } catch { }
        try { cnn.Com.Parameters.Add("@IdsContratos", SqlDbType.VarChar).Value = param.IdsContratos; }  catch { }
        try { cnn.Com.Parameters.Add("@IdsConcesionarios", SqlDbType.VarChar).Value = param.IdsConcesionarios; }      catch { }
        try { cnn.Com.Parameters.Add("@IdsFlujoGarantias", SqlDbType.VarChar).Value = param.IdsFlujoGarantias; }    catch { }

        DataTable dt = cnn.Seleccionar();

        return dt;
    }

    public DataTable ReporteGarantias(ContratosParamsRep param)
    {
        cnn.Com.CommandText = "pa_br_Reportes";
        cnn.Com.Parameters.Clear();
        try { cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "GarantiasContrato"; } catch { }
        try { cnn.Com.Parameters.Add("@RegistrosPorVencer", SqlDbType.Bit).Value = param.RegistrosPorVencer; } catch { }
        try { cnn.Com.Parameters.Add("@RegistrosVencidos", SqlDbType.Bit).Value = param.RegistrosVencidos; } catch { }
        try { cnn.Com.Parameters.Add("@IdsContratos", SqlDbType.VarChar).Value = param.IdsContratos; } catch { }
        try { cnn.Com.Parameters.Add("@IdsConcesionarios", SqlDbType.VarChar).Value = param.IdsConcesionarios; }  catch { }
        try { cnn.Com.Parameters.Add("@IdsFlujoGarantias", SqlDbType.VarChar).Value = param.IdsFlujoGarantias; } catch { }
        try { cnn.Com.Parameters.Add("@RegistrosDocPendiente", SqlDbType.Bit).Value = param.RegistrosDocPendiente; }  catch { }
        try { cnn.Com.Parameters.Add("@NumeroGarantia", SqlDbType.VarChar).Value = param.NumeroGarantia; }     catch { }
        try { cnn.Com.Parameters.Add("@FechaIngresoInicio", SqlDbType.Date).Value = param.FechaIngresoInicio; }  catch { }
        try { cnn.Com.Parameters.Add("@FechaIngresoFin", SqlDbType.Date).Value = param.FechaIngresoFin; }  catch { }
        DataTable dt = cnn.Seleccionar();

        return dt;
    }
   
}
}