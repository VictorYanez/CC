/*
============================================================================================
tbl_AsignacionesLineas		Tabla que almacena la asignaciones de líneas, concesionario y contratos.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 13 de julio de 2021 11:27:55
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
	public class DalAsignacionesLineas
	{
		Conexion cnn;

		public DalAsignacionesLineas()
		{
			cnn = new Conexion();
		}


		#region "METODOS DE LA CLASE"
		public int insertar(AsignacionesLineas asignacioneslineas)
		{
			cnn.Com.CommandText = "pa_tbl_AsignacionesLineas";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "insertar";

			try { cnn.Com.Parameters.Add("@IdLinea", SqlDbType.Int).Value = asignacioneslineas.IdLinea.IdLinea;} catch { }
			try { cnn.Com.Parameters.Add("@IdConcesionario", SqlDbType.Int).Value = asignacioneslineas.IdConcesionario.IdConcesionario;} catch { }
			try { cnn.Com.Parameters.Add("@IdContrato", SqlDbType.Int).Value = asignacioneslineas.IdContrato.IdContrato;} catch { }
			try { cnn.Com.Parameters.Add("@UsuarioIngreso", SqlDbType.VarChar).Value = asignacioneslineas.UsuarioIngreso;} catch { }
			try { cnn.Com.Parameters.Add("@IpEquipoUsuarioIngreso", SqlDbType.VarChar).Value = asignacioneslineas.IpEquipoUsuarioIngreso;} catch { }

			return cnn.Ejecutar(false);
		}

		public int actualizar(AsignacionesLineas asignacioneslineas)
		{
			cnn.Com.CommandText = "pa_tbl_AsignacionesLineas";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "actualizar";
			try { cnn.Com.Parameters.Add("@IdAsignacionLinea", SqlDbType.Int).Value = asignacioneslineas.IdAsignacionLinea;} catch { }
			try { cnn.Com.Parameters.Add("@IdLinea", SqlDbType.Int).Value = asignacioneslineas.IdLinea.IdLinea;} catch { }
			try { cnn.Com.Parameters.Add("@IdConcesionario", SqlDbType.Int).Value = asignacioneslineas.IdConcesionario.IdConcesionario;} catch { }
			try { cnn.Com.Parameters.Add("@Activo", SqlDbType.Bit).Value = asignacioneslineas.Activo;} catch { }
            try { cnn.Com.Parameters.Add("@Anulado", SqlDbType.Bit).Value = asignacioneslineas.Anulado; }           catch { }
			try { cnn.Com.Parameters.Add("@IdContrato", SqlDbType.Int).Value = asignacioneslineas.IdContrato.IdContrato;} catch { }
			try { cnn.Com.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime).Value = asignacioneslineas.FechaActualizacion;} catch { }
			try { cnn.Com.Parameters.Add("@UsuarioActualizacion", SqlDbType.VarChar).Value = asignacioneslineas.UsuarioActualizacion;} catch { }
			try { cnn.Com.Parameters.Add("@IpEquipoActualizacion", SqlDbType.VarChar).Value = asignacioneslineas.IpEquipoActualizacion;} catch { }

			return cnn.Ejecutar(false);
		}

		public int eliminar(AsignacionesLineas asignacioneslineas)
		{
			cnn.Com.CommandText = "pa_tbl_AsignacionesLineas";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "eliminar";

			try { cnn.Com.Parameters.Add("@IdAsignacionLinea", SqlDbType.Int).Value = asignacioneslineas.IdAsignacionLinea;} catch { }
            try { cnn.Com.Parameters.Add("@UsuarioActualizacion", SqlDbType.VarChar).Value = asignacioneslineas.UsuarioActualizacion; }            catch { }
            try { cnn.Com.Parameters.Add("@IpEquipoActualizacion", SqlDbType.VarChar).Value = asignacioneslineas.IpEquipoActualizacion; }            catch { }
			return cnn.Ejecutar(false);
		}

		public List<AsignacionesLineas> buscar(AsignacionesLineas parAsignacionesLineas, string _ordenarPor = null, int? _mostrarN = null)
		{
			cnn.Com.CommandText = "pa_tbl_AsignacionesLineas";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "buscar";
			cnn.Com.Parameters.Add("@_ordenarPor", SqlDbType.VarChar).Value = _ordenarPor;
			cnn.Com.Parameters.Add("@_mostrarN", SqlDbType.Int).Value = _mostrarN;

			try { cnn.Com.Parameters.Add("@IdAsignacionLinea", SqlDbType.Int).Value = parAsignacionesLineas.IdAsignacionLinea;} catch { }
			try { cnn.Com.Parameters.Add("@IdLinea", SqlDbType.Int).Value = parAsignacionesLineas.IdLinea.IdLinea;} catch { }
			try { cnn.Com.Parameters.Add("@IdConcesionario", SqlDbType.Int).Value = parAsignacionesLineas.IdConcesionario.IdConcesionario;} catch { }
			try { cnn.Com.Parameters.Add("@Activo", SqlDbType.Bit).Value = parAsignacionesLineas.Activo;} catch { }
			try { cnn.Com.Parameters.Add("@IdContrato", SqlDbType.Int).Value = parAsignacionesLineas.IdContrato.IdContrato;} catch { }
			try { cnn.Com.Parameters.Add("@Anulado", SqlDbType.Bit).Value = parAsignacionesLineas.Anulado;} catch { }
			try { cnn.Com.Parameters.Add("@FechaIngreso", SqlDbType.DateTime).Value = parAsignacionesLineas.FechaIngreso;} catch { }
			try { cnn.Com.Parameters.Add("@UsuarioIngreso", SqlDbType.VarChar).Value = parAsignacionesLineas.UsuarioIngreso;} catch { }
			try { cnn.Com.Parameters.Add("@IpEquipoUsuarioIngreso", SqlDbType.VarChar).Value = parAsignacionesLineas.IpEquipoUsuarioIngreso;} catch { }
			try { cnn.Com.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime).Value = parAsignacionesLineas.FechaActualizacion;} catch { }
			try { cnn.Com.Parameters.Add("@UsuarioActualizacion", SqlDbType.VarChar).Value = parAsignacionesLineas.UsuarioActualizacion;} catch { }
			try { cnn.Com.Parameters.Add("@IpEquipoActualizacion", SqlDbType.VarChar).Value = parAsignacionesLineas.IpEquipoActualizacion;} catch { }

			DataTable dt = cnn.Seleccionar();

			List<AsignacionesLineas> lstAsignacionesLineas= new List<AsignacionesLineas>();

			if(dt != null)
			{
				List<Concesionarios> lstConcesionarios = (new DalConcesionarios().buscar(new Concesionarios()));
				List<Lineas> lstLineas = (new DalLineas().buscar(new Lineas()));
				List<Contratos> lstContratos = (new DalContratos().buscar(new Contratos()));

			foreach(DataRow dr in dt.Rows)
			{
				AsignacionesLineas asignacioneslineas = new AsignacionesLineas();
				asignacioneslineas.IdConcesionario = new Concesionarios();
				asignacioneslineas.IdLinea = new Lineas();
				asignacioneslineas.IdContrato = new Contratos();

				try
				{
					asignacioneslineas.IdAsignacionLinea = Convert.ToInt32(dr["IdAsignacionLinea"]);
				}
				catch
				{
					asignacioneslineas.IdAsignacionLinea = null;
				}

				try
				{
					asignacioneslineas.IdLinea.IdLinea = Convert.ToInt32(dr["IdLinea"]);

					var _entidad = from _i in lstLineas where _i.IdLinea == asignacioneslineas.IdLinea.IdLinea select _i;

					foreach (var _x in _entidad)

						asignacioneslineas.IdLinea = _x;

				}
				catch
				{
					asignacioneslineas.IdLinea = null;
				}

				try
				{
					asignacioneslineas.IdConcesionario.IdConcesionario = Convert.ToInt32(dr["IdConcesionario"]);

					var _entidad = from _i in lstConcesionarios where _i.IdConcesionario == asignacioneslineas.IdConcesionario.IdConcesionario select _i;

					foreach (var _x in _entidad)

						asignacioneslineas.IdConcesionario = _x;

				}
				catch
				{
					asignacioneslineas.IdConcesionario = null;
				}

				try
				{
					asignacioneslineas.Activo = Convert.ToBoolean(dr["Activo"]);
				}
				catch
				{
					asignacioneslineas.Activo = null;
				}

				try
				{
					asignacioneslineas.IdContrato.IdContrato = Convert.ToInt32(dr["IdContrato"]);

					var _entidad = from _i in lstContratos where _i.IdContrato == asignacioneslineas.IdContrato.IdContrato select _i;

					foreach (var _x in _entidad)

						asignacioneslineas.IdContrato = _x;

				}
				catch
				{
					asignacioneslineas.IdContrato = null;
				}

				try
				{
					asignacioneslineas.Anulado = Convert.ToBoolean(dr["Anulado"]);
				}
				catch
				{
					asignacioneslineas.Anulado = null;
				}

				try
				{
					asignacioneslineas.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]);
				}
				catch
				{
					asignacioneslineas.FechaIngreso = null;
				}

				try
				{
					asignacioneslineas.UsuarioIngreso = Convert.ToString(dr["UsuarioIngreso"]);
				}
				catch
				{
					asignacioneslineas.UsuarioIngreso = null;
				}

				try
				{
					asignacioneslineas.IpEquipoUsuarioIngreso = Convert.ToString(dr["IpEquipoUsuarioIngreso"]);
				}
				catch
				{
					asignacioneslineas.IpEquipoUsuarioIngreso = null;
				}

				try
				{
					asignacioneslineas.FechaActualizacion = Convert.ToDateTime(dr["FechaActualizacion"]);
				}
				catch
				{
					asignacioneslineas.FechaActualizacion = null;
				}

				try
				{
					asignacioneslineas.UsuarioActualizacion = Convert.ToString(dr["UsuarioActualizacion"]);
				}
				catch
				{
					asignacioneslineas.UsuarioActualizacion = null;
				}

				try
				{
					asignacioneslineas.IpEquipoActualizacion = Convert.ToString(dr["IpEquipoActualizacion"]);
				}
				catch
				{
					asignacioneslineas.IpEquipoActualizacion = null;
				}


				lstAsignacionesLineas.Add(asignacioneslineas);
				}
			}
		return lstAsignacionesLineas;
	}
		#endregion // METODOS DE LA CLASE
	} // end class
} // FIN NAMESPACE
