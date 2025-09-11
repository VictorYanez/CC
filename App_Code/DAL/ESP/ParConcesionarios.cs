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
    public class ParConcesionarios
{
    Conexion cnn;
    public ParConcesionarios()
	{
        cnn = new Conexion();
	}

    /// <summary>
    /// Método que obtiene la cantidad de contactos que posee un concesionario.
    /// </summary>
    /// <param name="IdConcesionario">Código de concesionario</param>
    /// <returns>Cantidad de contactos</returns>
    public int CantidadContactosConcesionario(int IdConcesionario)
    {
        int resultado = 0;
        cnn.Com.CommandText = "pa_br_Concesionarios";
        cnn.Com.Parameters.Clear();
        try { cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "CantidadContactosConcesionario"; }        catch { }
        try { cnn.Com.Parameters.Add("@IdConcesionario", SqlDbType.Int).Value = IdConcesionario; }        catch { }
        DataTable dt = cnn.Seleccionar();
        if (dt != null) {
            resultado = (int)dt.Rows[0][0];
        }
        return resultado;
    }
}
}