/*
============================================================================================
tbl_TiposContactos		Tabla que almacena los diferentes tipos de contactos del concesionario.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 29 de junio de 2021 15:32:04
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
	public class DalTiposContactos
	{
		Conexion cnn;

		public DalTiposContactos()
		{
			cnn = new Conexion();
		}


		#region "METODOS DE LA CLASE"
		public int insertar(TiposContactos tiposcontactos)
		{
			cnn.Com.CommandText = "pa_tbl_TiposContactos";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "insertar";

			try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tiposcontactos.Nombre;} catch { }

			return cnn.Ejecutar(false);
		}

		public int actualizar(TiposContactos tiposcontactos)
		{
			cnn.Com.CommandText = "pa_tbl_TiposContactos";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "actualizar";

			try { cnn.Com.Parameters.Add("@IdTipoContacto", SqlDbType.Int).Value = tiposcontactos.IdTipoContacto;} catch { }
			try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tiposcontactos.Nombre;} catch { }

			return cnn.Ejecutar(false);
		}

		public int eliminar(TiposContactos tiposcontactos)
		{
			cnn.Com.CommandText = "pa_tbl_TiposContactos";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "eliminar";

			try { cnn.Com.Parameters.Add("@IdTipoContacto", SqlDbType.Int).Value = tiposcontactos.IdTipoContacto;} catch { }

			return cnn.Ejecutar(false);
		}

		public List<TiposContactos> buscar(TiposContactos parTiposContactos, string _ordenarPor = null, int? _mostrarN = null)
		{
			cnn.Com.CommandText = "pa_tbl_TiposContactos";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "buscar";
			cnn.Com.Parameters.Add("@_ordenarPor", SqlDbType.VarChar).Value = _ordenarPor;
			cnn.Com.Parameters.Add("@_mostrarN", SqlDbType.Int).Value = _mostrarN;

			try { cnn.Com.Parameters.Add("@IdTipoContacto", SqlDbType.Int).Value = parTiposContactos.IdTipoContacto;} catch { }
			try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = parTiposContactos.Nombre;} catch { }

			DataTable dt = cnn.Seleccionar();

			List<TiposContactos> lstTiposContactos= new List<TiposContactos>();

			if(dt != null)
			{


			foreach(DataRow dr in dt.Rows)
			{
				TiposContactos tiposcontactos = new TiposContactos();

				try
				{
					tiposcontactos.IdTipoContacto = Convert.ToInt32(dr["IdTipoContacto"]);
				}
				catch
				{
					tiposcontactos.IdTipoContacto = null;
				}

				try
				{
					tiposcontactos.Nombre = Convert.ToString(dr["Nombre"]);
				}
				catch
				{
					tiposcontactos.Nombre = null;
				}


				lstTiposContactos.Add(tiposcontactos);
				}
			}
		return lstTiposContactos;
	}
		#endregion // METODOS DE LA CLASE
	} // end class
} // FIN NAMESPACE
