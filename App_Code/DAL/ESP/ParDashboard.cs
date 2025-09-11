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
    public class ParDashboard
{
    Conexion cnn;
    public ParDashboard()
	{
        cnn = new Conexion();
	}

    public int GarantiasDocumentosPendientes()
    {
        int resultado = 0;
        cnn.Com.CommandText = "pa_br_Dashboard";
        cnn.Com.Parameters.Clear();
        try { cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "GarantiasDocumentosPendientes"; }  catch { }
      
        DataTable dt = cnn.Seleccionar();
        if (dt != null)
        {
            resultado = (int)dt.Rows[0][0];
        }
        return resultado;
    }

    public int GarantiasProximasVencer()
    {
        int resultado = 0;
        cnn.Com.CommandText = "pa_br_Dashboard";
        cnn.Com.Parameters.Clear();
        try { cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "GarantiasProximasVencer"; }        catch { }

        DataTable dt = cnn.Seleccionar();
        if (dt != null)
        {
            resultado = (int)dt.Rows[0][0];
        }
        return resultado;
    }

    public int GarantiasVencidas()
    {
        int resultado = 0;
        cnn.Com.CommandText = "pa_br_Dashboard";
        cnn.Com.Parameters.Clear();
        try { cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "GarantiasVencidas"; }        catch { }

        DataTable dt = cnn.Seleccionar();
        if (dt != null)
        {
            resultado = (int)dt.Rows[0][0];
        }
        return resultado;
    }

    public int ContratosProximosVencer()
    {
        int resultado = 0;
        cnn.Com.CommandText = "pa_br_Dashboard";
        cnn.Com.Parameters.Clear();
        try { cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "ContratosProximosVencer"; }
        catch { }

        DataTable dt = cnn.Seleccionar();
        if (dt != null)
        {
            resultado = (int)dt.Rows[0][0];
        }
        return resultado;
    }

    public int ContratosVencidos()
    {
        int resultado = 0;
        cnn.Com.CommandText = "pa_br_Dashboard";
        cnn.Com.Parameters.Clear();
        try { cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "ContratosVencidos"; }
        catch { }

        DataTable dt = cnn.Seleccionar();
        if (dt != null)
        {
            resultado = (int)dt.Rows[0][0];
        }
        return resultado;
    }

    public int GarantiasEnviadasResguardo()
    {
        int resultado = 0;
        cnn.Com.CommandText = "pa_br_Dashboard";
        cnn.Com.Parameters.Clear();
        try { cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "GarantiasEnviadasResguardo"; }
        catch { }

        DataTable dt = cnn.Seleccionar();
        if (dt != null)
        {
            resultado = (int)dt.Rows[0][0];
        }
        return resultado;
    }
   
   
}
}