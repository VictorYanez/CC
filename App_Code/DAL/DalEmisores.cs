/*
============================================================================================
tbl_Emisores		Tabla que almacena las diferentes entidades que emiten fianzas o cheques.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 29 de junio de 2021 15:29:11
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
	public class DalEmisores
	{
		Conexion cnn;

		public DalEmisores()
		{
			cnn = new Conexion();
		}


		#region "METODOS DE LA CLASE"
		public int insertar(Emisores emisores)
		{
			cnn.Com.CommandText = "pa_tbl_Emisores";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "insertar";

			try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = emisores.Nombre;} catch { }

			return cnn.Ejecutar(false);
		}

		public int actualizar(Emisores emisores)
		{
			cnn.Com.CommandText = "pa_tbl_Emisores";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "actualizar";

			try { cnn.Com.Parameters.Add("@IdEmisor", SqlDbType.Int).Value = emisores.IdEmisor;} catch { }
			try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = emisores.Nombre;} catch { }

			return cnn.Ejecutar(false);
		}

		public int eliminar(Emisores emisores)
		{
			cnn.Com.CommandText = "pa_tbl_Emisores";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "eliminar";

			try { cnn.Com.Parameters.Add("@IdEmisor", SqlDbType.Int).Value = emisores.IdEmisor;} catch { }

			return cnn.Ejecutar(false);
		}

		public List<Emisores> buscar(Emisores parEmisores, string _ordenarPor = null, int? _mostrarN = null)
		{
			cnn.Com.CommandText = "pa_tbl_Emisores";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "buscar";
			cnn.Com.Parameters.Add("@_ordenarPor", SqlDbType.VarChar).Value = _ordenarPor;
			cnn.Com.Parameters.Add("@_mostrarN", SqlDbType.Int).Value = _mostrarN;

			try { cnn.Com.Parameters.Add("@IdEmisor", SqlDbType.Int).Value = parEmisores.IdEmisor;} catch { }
			try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = parEmisores.Nombre;} catch { }

			DataTable dt = cnn.Seleccionar();

			List<Emisores> lstEmisores= new List<Emisores>();

			if(dt != null)
			{


			foreach(DataRow dr in dt.Rows)
			{
				Emisores emisores = new Emisores();

				try
				{
					emisores.IdEmisor = Convert.ToInt32(dr["IdEmisor"]);
				}
				catch
				{
					emisores.IdEmisor = null;
				}

				try
				{
					emisores.Nombre = Convert.ToString(dr["Nombre"]);
				}
				catch
				{
					emisores.Nombre = null;
				}


				lstEmisores.Add(emisores);
				}
			}
		return lstEmisores;
	}
		#endregion // METODOS DE LA CLASE
	} // end class
} // FIN NAMESPACE
