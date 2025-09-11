/*
============================================================================================
tbl_Contactos		Tabla que almacena los contactos de los concesionarios.
Autor:		VMT\marvin.ruiz
Fecha:		viernes, 09 de julio de 2021 11:43:50
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
	public class DalContactos
	{
		Conexion cnn;

		public DalContactos()
		{
			cnn = new Conexion();
		}


		#region "METODOS DE LA CLASE"
		public int insertar(Contactos contactos)
		{
			cnn.Com.CommandText = "pa_tbl_Contactos";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "insertar";

			try { cnn.Com.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = contactos.Nombres;} catch { }
			try { cnn.Com.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = contactos.Apellidos;} catch { }
			try { cnn.Com.Parameters.Add("@Nit", SqlDbType.VarChar).Value = contactos.Nit;} catch { }
			try { cnn.Com.Parameters.Add("@TelefonoOficina", SqlDbType.VarChar).Value = contactos.TelefonoOficina;} catch { }
			try { cnn.Com.Parameters.Add("@NumeroCelular", SqlDbType.VarChar).Value = contactos.NumeroCelular;} catch { }
			try { cnn.Com.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar).Value = contactos.CorreoElectronico;} catch { }
			try { cnn.Com.Parameters.Add("@IdTipoContacto", SqlDbType.Int).Value = contactos.IdTipoContacto.IdTipoContacto;} catch { }
			try { cnn.Com.Parameters.Add("@IdConcesionario", SqlDbType.Int).Value = contactos.IdConcesionario.IdConcesionario;} catch { }
			try { cnn.Com.Parameters.Add("@Comentarios", SqlDbType.VarChar).Value = contactos.Comentarios;} catch { }
			try { cnn.Com.Parameters.Add("@UsuarioIngreso", SqlDbType.VarChar).Value = contactos.UsuarioIngreso;} catch { }
			try { cnn.Com.Parameters.Add("@IpEquipoUsuarioIngreso", SqlDbType.VarChar).Value = contactos.IpEquipoUsuarioIngreso;} catch { }

			return cnn.Ejecutar(false);
		}

		public int actualizar(Contactos contactos)
		{
			cnn.Com.CommandText = "pa_tbl_Contactos";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "actualizar";
			try { cnn.Com.Parameters.Add("@IdContacto", SqlDbType.Int).Value = contactos.IdContacto;} catch { }
			try { cnn.Com.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = contactos.Nombres;} catch { }
			try { cnn.Com.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = contactos.Apellidos;} catch { }
			try { cnn.Com.Parameters.Add("@Nit", SqlDbType.VarChar).Value = contactos.Nit;} catch { }
			try { cnn.Com.Parameters.Add("@TelefonoOficina", SqlDbType.VarChar).Value = contactos.TelefonoOficina;} catch { }
			try { cnn.Com.Parameters.Add("@NumeroCelular", SqlDbType.VarChar).Value = contactos.NumeroCelular;} catch { }
			try { cnn.Com.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar).Value = contactos.CorreoElectronico;} catch { }
			try { cnn.Com.Parameters.Add("@IdTipoContacto", SqlDbType.Int).Value = contactos.IdTipoContacto.IdTipoContacto;} catch { }
			try { cnn.Com.Parameters.Add("@IdConcesionario", SqlDbType.Int).Value = contactos.IdConcesionario.IdConcesionario;} catch { }
			try { cnn.Com.Parameters.Add("@Comentarios", SqlDbType.VarChar).Value = contactos.Comentarios;} catch { }
			try { cnn.Com.Parameters.Add("@UsuarioActualizacion", SqlDbType.VarChar).Value = contactos.UsuarioActualizacion;} catch { }
			try { cnn.Com.Parameters.Add("@IpEquipoActualizacion", SqlDbType.VarChar).Value = contactos.IpEquipoActualizacion;} catch { }

			return cnn.Ejecutar(false);
		}

		public int eliminar(Contactos contactos)
		{
			cnn.Com.CommandText = "pa_tbl_Contactos";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "eliminar";

			try { cnn.Com.Parameters.Add("@IdContacto", SqlDbType.Int).Value = contactos.IdContacto;} catch { }

			return cnn.Ejecutar(false);
		}

		public List<Contactos> buscar(Contactos parContactos, string _ordenarPor = null, int? _mostrarN = null)
		{
			cnn.Com.CommandText = "pa_tbl_Contactos";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "buscar";
			cnn.Com.Parameters.Add("@_ordenarPor", SqlDbType.VarChar).Value = _ordenarPor;
			cnn.Com.Parameters.Add("@_mostrarN", SqlDbType.Int).Value = _mostrarN;

			try { cnn.Com.Parameters.Add("@IdContacto", SqlDbType.Int).Value = parContactos.IdContacto;} catch { }
			try { cnn.Com.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = parContactos.Nombres;} catch { }
			try { cnn.Com.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = parContactos.Apellidos;} catch { }
			try { cnn.Com.Parameters.Add("@Nit", SqlDbType.VarChar).Value = parContactos.Nit;} catch { }
			try { cnn.Com.Parameters.Add("@TelefonoOficina", SqlDbType.VarChar).Value = parContactos.TelefonoOficina;} catch { }
			try { cnn.Com.Parameters.Add("@NumeroCelular", SqlDbType.VarChar).Value = parContactos.NumeroCelular;} catch { }
			try { cnn.Com.Parameters.Add("@CorreoElectronico", SqlDbType.VarChar).Value = parContactos.CorreoElectronico;} catch { }
			try { cnn.Com.Parameters.Add("@IdTipoContacto", SqlDbType.Int).Value = parContactos.IdTipoContacto.IdTipoContacto;} catch { }
			try { cnn.Com.Parameters.Add("@IdConcesionario", SqlDbType.Int).Value = parContactos.IdConcesionario.IdConcesionario;} catch { }
			try { cnn.Com.Parameters.Add("@Comentarios", SqlDbType.VarChar).Value = parContactos.Comentarios;} catch { }
			try { cnn.Com.Parameters.Add("@Anulado", SqlDbType.Bit).Value = parContactos.Anulado;} catch { }
			try { cnn.Com.Parameters.Add("@FechaIngreso", SqlDbType.DateTime).Value = parContactos.FechaIngreso;} catch { }
			try { cnn.Com.Parameters.Add("@UsuarioIngreso", SqlDbType.VarChar).Value = parContactos.UsuarioIngreso;} catch { }
			try { cnn.Com.Parameters.Add("@IpEquipoUsuarioIngreso", SqlDbType.VarChar).Value = parContactos.IpEquipoUsuarioIngreso;} catch { }
			try { cnn.Com.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime).Value = parContactos.FechaActualizacion;} catch { }
			try { cnn.Com.Parameters.Add("@UsuarioActualizacion", SqlDbType.VarChar).Value = parContactos.UsuarioActualizacion;} catch { }
			try { cnn.Com.Parameters.Add("@IpEquipoActualizacion", SqlDbType.VarChar).Value = parContactos.IpEquipoActualizacion;} catch { }

			DataTable dt = cnn.Seleccionar();

			List<Contactos> lstContactos= new List<Contactos>();

			if(dt != null)
			{
				List<Concesionarios> lstConcesionarios = (new DalConcesionarios().buscar(new Concesionarios()));
				List<TiposContactos> lstTiposContactos = (new DalTiposContactos().buscar(new TiposContactos()));

			foreach(DataRow dr in dt.Rows)
			{
				Contactos contactos = new Contactos();
				contactos.IdConcesionario = new Concesionarios();
				contactos.IdTipoContacto = new TiposContactos();

				try
				{
					contactos.IdContacto = Convert.ToInt32(dr["IdContacto"]);
				}
				catch
				{
					contactos.IdContacto = null;
				}

				try
				{
					contactos.Nombres = Convert.ToString(dr["Nombres"]);
				}
				catch
				{
					contactos.Nombres = null;
				}

				try
				{
					contactos.Apellidos = Convert.ToString(dr["Apellidos"]);
				}
				catch
				{
					contactos.Apellidos = null;
				}

				try
				{
					contactos.Nit = Convert.ToString(dr["Nit"]);
				}
				catch
				{
					contactos.Nit = null;
				}

				try
				{
					contactos.TelefonoOficina = Convert.ToString(dr["TelefonoOficina"]);
				}
				catch
				{
					contactos.TelefonoOficina = null;
				}

				try
				{
					contactos.NumeroCelular = Convert.ToString(dr["NumeroCelular"]);
				}
				catch
				{
					contactos.NumeroCelular = null;
				}

				try
				{
					contactos.CorreoElectronico = Convert.ToString(dr["CorreoElectronico"]);
				}
				catch
				{
					contactos.CorreoElectronico = null;
				}

				try
				{
					contactos.IdTipoContacto.IdTipoContacto = Convert.ToInt32(dr["IdTipoContacto"]);

					var _entidad = from _i in lstTiposContactos where _i.IdTipoContacto == contactos.IdTipoContacto.IdTipoContacto select _i;

					foreach (var _x in _entidad)

						contactos.IdTipoContacto = _x;

				}
				catch
				{
					contactos.IdTipoContacto = null;
				}

				try
				{
					contactos.IdConcesionario.IdConcesionario = Convert.ToInt32(dr["IdConcesionario"]);

					var _entidad = from _i in lstConcesionarios where _i.IdConcesionario == contactos.IdConcesionario.IdConcesionario select _i;

					foreach (var _x in _entidad)

						contactos.IdConcesionario = _x;

				}
				catch
				{
					contactos.IdConcesionario = null;
				}

				try
				{
					contactos.Comentarios = Convert.ToString(dr["Comentarios"]);
				}
				catch
				{
					contactos.Comentarios = null;
				}

				try
				{
					contactos.Anulado = Convert.ToBoolean(dr["Anulado"]);
				}
				catch
				{
					contactos.Anulado = null;
				}

				try
				{
					contactos.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]);
				}
				catch
				{
					contactos.FechaIngreso = null;
				}

				try
				{
					contactos.UsuarioIngreso = Convert.ToString(dr["UsuarioIngreso"]);
				}
				catch
				{
					contactos.UsuarioIngreso = null;
				}

				try
				{
					contactos.IpEquipoUsuarioIngreso = Convert.ToString(dr["IpEquipoUsuarioIngreso"]);
				}
				catch
				{
					contactos.IpEquipoUsuarioIngreso = null;
				}

				try
				{
					contactos.FechaActualizacion = Convert.ToDateTime(dr["FechaActualizacion"]);
				}
				catch
				{
					contactos.FechaActualizacion = null;
				}

				try
				{
					contactos.UsuarioActualizacion = Convert.ToString(dr["UsuarioActualizacion"]);
				}
				catch
				{
					contactos.UsuarioActualizacion = null;
				}

				try
				{
					contactos.IpEquipoActualizacion = Convert.ToString(dr["IpEquipoActualizacion"]);
				}
				catch
				{
					contactos.IpEquipoActualizacion = null;
				}


				lstContactos.Add(contactos);
				}
			}
		return lstContactos;
	}
		#endregion // METODOS DE LA CLASE
	} // end class
} // FIN NAMESPACE
