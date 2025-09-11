/*
============================================================================================
tbl_Lineas		Tabla que almacena las lineas emitidas para concesiones.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 29 de junio de 2021 15:31:05
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
	public class DalLineas
	{
		Conexion cnn;

		public DalLineas()
		{
			cnn = new Conexion();
		}


		#region "METODOS DE LA CLASE"
		public int insertar(Lineas lineas)
		{
			cnn.Com.CommandText = "pa_tbl_Lineas";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "insertar";

			try { cnn.Com.Parameters.Add("@IdLinea", SqlDbType.Int).Value = lineas.IdLinea;} catch { }
			try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = lineas.Nombre;} catch { }

			return cnn.Ejecutar(false);
		}

		public int actualizar(Lineas lineas)
		{
			cnn.Com.CommandText = "pa_tbl_Lineas";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "actualizar";

			try { cnn.Com.Parameters.Add("@IdLinea", SqlDbType.Int).Value = lineas.IdLinea;} catch { }
			try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = lineas.Nombre;} catch { }

			return cnn.Ejecutar(false);
		}

		public int eliminar(Lineas lineas)
		{
			cnn.Com.CommandText = "pa_tbl_Lineas";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "eliminar";

			try { cnn.Com.Parameters.Add("@IdLinea", SqlDbType.Int).Value = lineas.IdLinea;} catch { }

			return cnn.Ejecutar(false);
		}

		public List<Lineas> buscar(Lineas parLineas, string _ordenarPor = null, int? _mostrarN = null)
		{
			cnn.Com.CommandText = "pa_tbl_Lineas";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "buscar";
			cnn.Com.Parameters.Add("@_ordenarPor", SqlDbType.VarChar).Value = _ordenarPor;
			cnn.Com.Parameters.Add("@_mostrarN", SqlDbType.Int).Value = _mostrarN;

			try { cnn.Com.Parameters.Add("@IdLinea", SqlDbType.Int).Value = parLineas.IdLinea;} catch { }
			try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = parLineas.Nombre;} catch { }

			DataTable dt = cnn.Seleccionar();

			List<Lineas> lstLineas= new List<Lineas>();

			if(dt != null)
			{


			foreach(DataRow dr in dt.Rows)
			{
				Lineas lineas = new Lineas();

				try
				{
					lineas.IdLinea = Convert.ToInt32(dr["IdLinea"]);
				}
				catch
				{
					lineas.IdLinea = null;
				}

				try
				{
					lineas.Nombre = Convert.ToString(dr["Nombre"]);
				}
				catch
				{
					lineas.Nombre = null;
				}

                try
                {
                    lineas.Final = Convert.ToBoolean(dr["Final"]);
                }
                catch
                {
                    lineas.Final = null;
                }


				lstLineas.Add(lineas);
				}
			}
		return lstLineas;
	}
		#endregion // METODOS DE LA CLASE
	} // end class
} // FIN NAMESPACE
