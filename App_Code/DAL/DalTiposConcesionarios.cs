/*
============================================================================================
tbl_TiposConcesionarios		Tabla que almacena los diferentes tipos de concesionarios.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 29 de junio de 2021 15:31:24
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
	public class DalTiposConcesionarios
	{
		Conexion cnn;

		public DalTiposConcesionarios()
		{
			cnn = new Conexion();
		}


		#region "METODOS DE LA CLASE"
		public int insertar(TiposConcesionarios tiposconcesionarios)
		{
			cnn.Com.CommandText = "pa_tbl_TiposConcesionarios";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "insertar";

			try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tiposconcesionarios.Nombre;} catch { }

			return cnn.Ejecutar(false);
		}

		public int actualizar(TiposConcesionarios tiposconcesionarios)
		{
			cnn.Com.CommandText = "pa_tbl_TiposConcesionarios";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "actualizar";

			try { cnn.Com.Parameters.Add("@IdTipoConcesionario", SqlDbType.Int).Value = tiposconcesionarios.IdTipoConcesionario;} catch { }
			try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = tiposconcesionarios.Nombre;} catch { }

			return cnn.Ejecutar(false);
		}

		public int eliminar(TiposConcesionarios tiposconcesionarios)
		{
			cnn.Com.CommandText = "pa_tbl_TiposConcesionarios";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "eliminar";

			try { cnn.Com.Parameters.Add("@IdTipoConcesionario", SqlDbType.Int).Value = tiposconcesionarios.IdTipoConcesionario;} catch { }

			return cnn.Ejecutar(false);
		}

		public List<TiposConcesionarios> buscar(TiposConcesionarios parTiposConcesionarios, string _ordenarPor = null, int? _mostrarN = null)
		{
			cnn.Com.CommandText = "pa_tbl_TiposConcesionarios";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "buscar";
			cnn.Com.Parameters.Add("@_ordenarPor", SqlDbType.VarChar).Value = _ordenarPor;
			cnn.Com.Parameters.Add("@_mostrarN", SqlDbType.Int).Value = _mostrarN;

			try { cnn.Com.Parameters.Add("@IdTipoConcesionario", SqlDbType.Int).Value = parTiposConcesionarios.IdTipoConcesionario;} catch { }
			try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = parTiposConcesionarios.Nombre;} catch { }

			DataTable dt = cnn.Seleccionar();

			List<TiposConcesionarios> lstTiposConcesionarios= new List<TiposConcesionarios>();

			if(dt != null)
			{


			foreach(DataRow dr in dt.Rows)
			{
				TiposConcesionarios tiposconcesionarios = new TiposConcesionarios();

				try
				{
					tiposconcesionarios.IdTipoConcesionario = Convert.ToInt32(dr["IdTipoConcesionario"]);
				}
				catch
				{
					tiposconcesionarios.IdTipoConcesionario = null;
				}

				try
				{
					tiposconcesionarios.Nombre = Convert.ToString(dr["Nombre"]);
				}
				catch
				{
					tiposconcesionarios.Nombre = null;
				}


				lstTiposConcesionarios.Add(tiposconcesionarios);
				}
			}
		return lstTiposConcesionarios;
	}
		#endregion // METODOS DE LA CLASE
	} // end class
} // FIN NAMESPACE
