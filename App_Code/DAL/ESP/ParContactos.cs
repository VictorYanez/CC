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
public class ParContactos
{
    Conexion cnn;
    public ParContactos()
	{
        cnn = new Conexion();
	}


   /// <summary>
   /// Método que obtiene los contactos con información relacionada.
   /// </summary>
   /// <param name="idGarantia">Parámetro de IdGarantia</param>
   /// <param name="idContrato">Parámetro de IdContrato</param>
   /// <returns>DataTable</returns>
    public DataTable ListaContactosConsulta(int idGarantia, int idContrato)
    {
        cnn.Com.CommandText = "pa_br_Contactos";
        cnn.Com.Parameters.Clear();
        try { cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "ListaContactosConsulta"; }        catch { }
        try { cnn.Com.Parameters.Add("@IdGarantia", SqlDbType.Int).Value = idGarantia; }        catch { }
        try { cnn.Com.Parameters.Add("@IdContrato", SqlDbType.Int).Value = idContrato; }         catch { }
     
        DataTable dt = cnn.Seleccionar();

        return dt;
    }

   
}
}