/*
============================================================================================
tbl_ParametrosConfiguracion		
Autor:		VMT\marvin.ruiz
Fecha:		miércoles, 21 de julio de 2021 18:20:28
============================================================================================
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ENT;

namespace DAL
{
	public class DalParametrosConfiguracion
	{
		Conexion cnn;

		public DalParametrosConfiguracion()
		{
			cnn = new Conexion();
		}


		#region "METODOS DE LA CLASE"
		public int insertar(ParametrosConfiguracion parametrosconfiguracion)
		{
			cnn.Com.CommandText = "pa_tbl_ParametrosConfiguracion";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "insertar";

			try { cnn.Com.Parameters.Add("@IdParametro", SqlDbType.Char).Value = parametrosconfiguracion.IdParametro;} catch { }
			try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = parametrosconfiguracion.Nombre;} catch { }
			try { cnn.Com.Parameters.Add("@ValorNumerico", SqlDbType.Int).Value = parametrosconfiguracion.ValorNumerico;} catch { }
			try { cnn.Com.Parameters.Add("@ValorCadena", SqlDbType.VarChar).Value = parametrosconfiguracion.ValorCadena;} catch { }

			return cnn.Ejecutar(false);
		}

		public int actualizar(ParametrosConfiguracion parametrosconfiguracion)
		{
			cnn.Com.CommandText = "pa_tbl_ParametrosConfiguracion";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "actualizar";
			try { cnn.Com.Parameters.Add("@IdParametro", SqlDbType.Char).Value = parametrosconfiguracion.IdParametro;} catch { }
			try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = parametrosconfiguracion.Nombre;} catch { }
			try { cnn.Com.Parameters.Add("@ValorNumerico", SqlDbType.Int).Value = parametrosconfiguracion.ValorNumerico;} catch { }
			try { cnn.Com.Parameters.Add("@ValorCadena", SqlDbType.VarChar).Value = parametrosconfiguracion.ValorCadena;} catch { }

			return cnn.Ejecutar(false);
		}

		public int eliminar(ParametrosConfiguracion parametrosconfiguracion)
		{
			cnn.Com.CommandText = "pa_tbl_ParametrosConfiguracion";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "eliminar";

			try { cnn.Com.Parameters.Add("@IdParametro", SqlDbType.Char).Value = parametrosconfiguracion.IdParametro;} catch { }

			return cnn.Ejecutar(false);
		}

		public List<ParametrosConfiguracion> buscar(ParametrosConfiguracion parParametrosConfiguracion, string _ordenarPor = null, int? _mostrarN = null)
		{
			cnn.Com.CommandText = "pa_tbl_ParametrosConfiguracion";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "buscar";
			cnn.Com.Parameters.Add("@_ordenarPor", SqlDbType.VarChar).Value = _ordenarPor;
			cnn.Com.Parameters.Add("@_mostrarN", SqlDbType.Int).Value = _mostrarN;

			try { cnn.Com.Parameters.Add("@IdParametro", SqlDbType.Char).Value = parParametrosConfiguracion.IdParametro;} catch { }
			try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = parParametrosConfiguracion.Nombre;} catch { }
			try { cnn.Com.Parameters.Add("@ValorNumerico", SqlDbType.Int).Value = parParametrosConfiguracion.ValorNumerico;} catch { }
			try { cnn.Com.Parameters.Add("@ValorCadena", SqlDbType.VarChar).Value = parParametrosConfiguracion.ValorCadena;} catch { }

			DataTable dt = cnn.Seleccionar();

			List<ParametrosConfiguracion> lstParametrosConfiguracion= new List<ParametrosConfiguracion>();

			if(dt != null)
			{

			foreach(DataRow dr in dt.Rows)
			{
				ParametrosConfiguracion parametrosconfiguracion = new ParametrosConfiguracion();

				try
				{
					parametrosconfiguracion.IdParametro = Convert.ToString(dr["IdParametro"]);
				}
				catch
				{
					parametrosconfiguracion.IdParametro = null;
				}

				try
				{
					parametrosconfiguracion.Nombre = Convert.ToString(dr["Nombre"]);
				}
				catch
				{
					parametrosconfiguracion.Nombre = null;
				}

				try
				{
					parametrosconfiguracion.ValorNumerico = Convert.ToInt32(dr["ValorNumerico"]);
				}
				catch
				{
					parametrosconfiguracion.ValorNumerico = null;
				}

				try
				{
					parametrosconfiguracion.ValorCadena = Convert.ToString(dr["ValorCadena"]);
				}
				catch
				{
					parametrosconfiguracion.ValorCadena = null;
				}


				lstParametrosConfiguracion.Add(parametrosconfiguracion);
				}
			}
		return lstParametrosConfiguracion;
	}
		#endregion // METODOS DE LA CLASE
	} // end class
} // FIN NAMESPACE
