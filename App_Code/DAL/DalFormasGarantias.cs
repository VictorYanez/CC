/*
============================================================================================
tbl_FormasGarantias		Tabla que almacena la forma en la que se emite la garantía.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 29 de junio de 2021 15:30:22
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
	public class DalFormasGarantias
	{
		Conexion cnn;

		public DalFormasGarantias()
		{
			cnn = new Conexion();
		}


		#region "METODOS DE LA CLASE"
		public int insertar(FormasGarantias formasgarantias)
		{
			cnn.Com.CommandText = "pa_tbl_FormasGarantias";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "insertar";

			try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = formasgarantias.Nombre;} catch { }

			return cnn.Ejecutar(false);
		}

		public int actualizar(FormasGarantias formasgarantias)
		{
			cnn.Com.CommandText = "pa_tbl_FormasGarantias";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "actualizar";

			try { cnn.Com.Parameters.Add("@IdForma", SqlDbType.Int).Value = formasgarantias.IdForma;} catch { }
			try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = formasgarantias.Nombre;} catch { }

			return cnn.Ejecutar(false);
		}

		public int eliminar(FormasGarantias formasgarantias)
		{
			cnn.Com.CommandText = "pa_tbl_FormasGarantias";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "eliminar";

			try { cnn.Com.Parameters.Add("@IdForma", SqlDbType.Int).Value = formasgarantias.IdForma;} catch { }

			return cnn.Ejecutar(false);
		}

		public List<FormasGarantias> buscar(FormasGarantias parFormasGarantias, string _ordenarPor = null, int? _mostrarN = null)
		{
			cnn.Com.CommandText = "pa_tbl_FormasGarantias";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "buscar";
			cnn.Com.Parameters.Add("@_ordenarPor", SqlDbType.VarChar).Value = _ordenarPor;
			cnn.Com.Parameters.Add("@_mostrarN", SqlDbType.Int).Value = _mostrarN;

			try { cnn.Com.Parameters.Add("@IdForma", SqlDbType.Int).Value = parFormasGarantias.IdForma;} catch { }
			try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = parFormasGarantias.Nombre;} catch { }

			DataTable dt = cnn.Seleccionar();

			List<FormasGarantias> lstFormasGarantias= new List<FormasGarantias>();

			if(dt != null)
			{


			foreach(DataRow dr in dt.Rows)
			{
				FormasGarantias formasgarantias = new FormasGarantias();

				try
				{
					formasgarantias.IdForma = Convert.ToInt32(dr["IdForma"]);
				}
				catch
				{
					formasgarantias.IdForma = null;
				}

				try
				{
					formasgarantias.Nombre = Convert.ToString(dr["Nombre"]);
				}
				catch
				{
					formasgarantias.Nombre = null;
				}


				lstFormasGarantias.Add(formasgarantias);
				}
			}
		return lstFormasGarantias;
	}
		#endregion // METODOS DE LA CLASE
	} // end class
} // FIN NAMESPACE
