/*
============================================================================================
tbl_Estados		Tabla que almacena los diferentes estados del proceso de las garantías.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 29 de junio de 2021 15:35:24
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
	public class DalEstados
	{
		Conexion cnn;

		public DalEstados()
		{
			cnn = new Conexion();
		}


		#region "METODOS DE LA CLASE"
		public int insertar(Estados estados)
		{
			cnn.Com.CommandText = "pa_tbl_Estados";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "insertar";

			try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = estados.Nombre;} catch { }

			return cnn.Ejecutar(false);
		}

		public int actualizar(Estados estados)
		{
			cnn.Com.CommandText = "pa_tbl_Estados";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "actualizar";

			try { cnn.Com.Parameters.Add("@IdEstado", SqlDbType.Int).Value = estados.IdEstado;} catch { }
			try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = estados.Nombre;} catch { }

			return cnn.Ejecutar(false);
		}

		public int eliminar(Estados estados)
		{
			cnn.Com.CommandText = "pa_tbl_Estados";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "eliminar";

			try { cnn.Com.Parameters.Add("@IdEstado", SqlDbType.Int).Value = estados.IdEstado;} catch { }

			return cnn.Ejecutar(false);
		}

		public List<Estados> buscar(Estados parEstados, string _ordenarPor = null, int? _mostrarN = null)
		{
			cnn.Com.CommandText = "pa_tbl_Estados";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "buscar";
			cnn.Com.Parameters.Add("@_ordenarPor", SqlDbType.VarChar).Value = _ordenarPor;
			cnn.Com.Parameters.Add("@_mostrarN", SqlDbType.Int).Value = _mostrarN;

			try { cnn.Com.Parameters.Add("@IdEstado", SqlDbType.Int).Value = parEstados.IdEstado;} catch { }
			try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = parEstados.Nombre;} catch { }
          
			DataTable dt = cnn.Seleccionar();

			List<Estados> lstEstados= new List<Estados>();

			if(dt != null)
			{


			foreach(DataRow dr in dt.Rows)
			{
				Estados estados = new Estados();

				try
				{
					estados.IdEstado = Convert.ToInt32(dr["IdEstado"]);
				}
				catch
				{
					estados.IdEstado = null;
				}

				try
				{
					estados.Nombre = Convert.ToString(dr["Nombre"]);
				}
				catch
				{
					estados.Nombre = null;
				}

                try
                {
                    estados.Orden = Convert.ToInt32(dr["Orden"]);
                }
                catch
                {
                    estados.Orden = null;
                }

                try
                {
                    estados.Final = Convert.ToBoolean(dr["Final"]);
                }
                catch
                {
                    estados.Final = null;
                }


				lstEstados.Add(estados);
				}
			}
		return lstEstados;
	}
		#endregion // METODOS DE LA CLASE
	} // end class
} // FIN NAMESPACE
