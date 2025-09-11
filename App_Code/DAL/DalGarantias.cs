/*
============================================================================================
tbl_Garantias		Tabla que almacena las garantías de los contratos.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 13 de julio de 2021 11:27:35
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
	public class DalGarantias
	{
		Conexion cnn;

		public DalGarantias()
		{
			cnn = new Conexion();
		}


		#region "METODOS DE LA CLASE"
		public int insertar(Garantias garantias)
		{
			cnn.Com.CommandText = "pa_tbl_Garantias";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "insertar";

			try { cnn.Com.Parameters.Add("@Numero", SqlDbType.VarChar).Value = garantias.Numero;} catch { }
			try { cnn.Com.Parameters.Add("@Monto", SqlDbType.Decimal).Value = garantias.Monto;} catch { }
			try { cnn.Com.Parameters.Add("@FechaEmision", SqlDbType.Date).Value = garantias.FechaEmision;} catch { }
			try { cnn.Com.Parameters.Add("@FechaVigenciaInicial", SqlDbType.Date).Value = garantias.FechaVigenciaInicial;} catch { }
			try { cnn.Com.Parameters.Add("@FechaVigenciaFinal", SqlDbType.Date).Value = garantias.FechaVigenciaFinal;} catch { }
			try { cnn.Com.Parameters.Add("@IdEmisor", SqlDbType.Int).Value = garantias.IdEmisor.IdEmisor;} catch { }
			try { cnn.Com.Parameters.Add("@IdForma", SqlDbType.Int).Value = garantias.IdForma.IdForma;} catch { }
			try { cnn.Com.Parameters.Add("@IdEstadoActual", SqlDbType.Int).Value = garantias.IdEstadoActual;} catch { }
			try { cnn.Com.Parameters.Add("@IdContrato", SqlDbType.Int).Value = garantias.IdContrato.IdContrato;} catch { }
            try { cnn.Com.Parameters.Add("@Comentario", SqlDbType.VarChar).Value = garantias.Comentario; }  catch { }
			try { cnn.Com.Parameters.Add("@UsuarioIngreso", SqlDbType.VarChar).Value = garantias.UsuarioIngreso;} catch { }
			try { cnn.Com.Parameters.Add("@IpEquipoUsuarioIngreso", SqlDbType.VarChar).Value = garantias.IpEquipoUsuarioIngreso;} catch { }

			return cnn.Ejecutar(false);
		}

		public int actualizar(Garantias garantias)
		{
			cnn.Com.CommandText = "pa_tbl_Garantias";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "actualizar";
			try { cnn.Com.Parameters.Add("@IdGarantia", SqlDbType.Int).Value = garantias.IdGarantia;} catch { }
			try { cnn.Com.Parameters.Add("@Numero", SqlDbType.VarChar).Value = garantias.Numero;} catch { }
			try { cnn.Com.Parameters.Add("@Monto", SqlDbType.Decimal).Value = garantias.Monto;} catch { }
			try { cnn.Com.Parameters.Add("@FechaEmision", SqlDbType.Date).Value = garantias.FechaEmision;} catch { }
			try { cnn.Com.Parameters.Add("@FechaVigenciaInicial", SqlDbType.Date).Value = garantias.FechaVigenciaInicial;} catch { }
			try { cnn.Com.Parameters.Add("@FechaVigenciaFinal", SqlDbType.Date).Value = garantias.FechaVigenciaFinal;} catch { }
			try { cnn.Com.Parameters.Add("@IdEmisor", SqlDbType.Int).Value = garantias.IdEmisor.IdEmisor;} catch { }
			try { cnn.Com.Parameters.Add("@IdForma", SqlDbType.Int).Value = garantias.IdForma.IdForma;} catch { }
			try { cnn.Com.Parameters.Add("@IdContrato", SqlDbType.Int).Value = garantias.IdContrato.IdContrato;} catch { }
            try { cnn.Com.Parameters.Add("@Comentario", SqlDbType.VarChar).Value = garantias.Comentario; }       catch { }
            try { cnn.Com.Parameters.Add("@DocumentacionPendiente", SqlDbType.Bit).Value = garantias.DocumentacionPendiente; }   catch { }
			try { cnn.Com.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime).Value = garantias.FechaActualizacion;} catch { }
			try { cnn.Com.Parameters.Add("@UsuarioActualizacion", SqlDbType.VarChar).Value = garantias.UsuarioActualizacion;} catch { }
			try { cnn.Com.Parameters.Add("@IpEquipoActualizacion", SqlDbType.VarChar).Value = garantias.IpEquipoActualizacion;} catch { }

			return cnn.Ejecutar(false);
		}

		public int eliminar(Garantias garantias)
		{
			cnn.Com.CommandText = "pa_tbl_Garantias";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "eliminar";

			try { cnn.Com.Parameters.Add("@IdGarantia", SqlDbType.Int).Value = garantias.IdGarantia;} catch { }

			return cnn.Ejecutar(false);
		}

		public List<Garantias> buscar(Garantias parGarantias, string _ordenarPor = null, int? _mostrarN = null)
		{
			cnn.Com.CommandText = "pa_tbl_Garantias";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "buscar";
			cnn.Com.Parameters.Add("@_ordenarPor", SqlDbType.VarChar).Value = _ordenarPor;
			cnn.Com.Parameters.Add("@_mostrarN", SqlDbType.Int).Value = _mostrarN;

			try { cnn.Com.Parameters.Add("@IdGarantia", SqlDbType.Int).Value = parGarantias.IdGarantia;} catch { }
			try { cnn.Com.Parameters.Add("@Numero", SqlDbType.VarChar).Value = parGarantias.Numero;} catch { }
			try { cnn.Com.Parameters.Add("@Monto", SqlDbType.Decimal).Value = parGarantias.Monto;} catch { }
			try { cnn.Com.Parameters.Add("@FechaEmision", SqlDbType.Date).Value = parGarantias.FechaEmision;} catch { }
			try { cnn.Com.Parameters.Add("@FechaVigenciaInicial", SqlDbType.Date).Value = parGarantias.FechaVigenciaInicial;} catch { }
			try { cnn.Com.Parameters.Add("@FechaVigenciaFinal", SqlDbType.Date).Value = parGarantias.FechaVigenciaFinal;} catch { }
			try { cnn.Com.Parameters.Add("@IdEmisor", SqlDbType.Int).Value = parGarantias.IdEmisor.IdEmisor;} catch { }
			try { cnn.Com.Parameters.Add("@IdForma", SqlDbType.Int).Value = parGarantias.IdForma.IdForma;} catch { }
			try { cnn.Com.Parameters.Add("@IdEstadoActual", SqlDbType.Int).Value = parGarantias.IdEstadoActual;} catch { }
			try { cnn.Com.Parameters.Add("@IdContrato", SqlDbType.Int).Value = parGarantias.IdContrato.IdContrato;} catch { }
            try { cnn.Com.Parameters.Add("@Comentario", SqlDbType.VarChar).Value = parGarantias.Comentario; }   catch { }
            try { cnn.Com.Parameters.Add("@DocumentacionPendiente", SqlDbType.Bit).Value = parGarantias.DocumentacionPendiente; }  catch { }
			try { cnn.Com.Parameters.Add("@Anulado", SqlDbType.Bit).Value = parGarantias.Anulado;} catch { }
			try { cnn.Com.Parameters.Add("@FechaIngreso", SqlDbType.DateTime).Value = parGarantias.FechaIngreso;} catch { }
			try { cnn.Com.Parameters.Add("@UsuarioIngreso", SqlDbType.VarChar).Value = parGarantias.UsuarioIngreso;} catch { }
			try { cnn.Com.Parameters.Add("@IpEquipoUsuarioIngreso", SqlDbType.VarChar).Value = parGarantias.IpEquipoUsuarioIngreso;} catch { }
			try { cnn.Com.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime).Value = parGarantias.FechaActualizacion;} catch { }
			try { cnn.Com.Parameters.Add("@UsuarioActualizacion", SqlDbType.VarChar).Value = parGarantias.UsuarioActualizacion;} catch { }
			try { cnn.Com.Parameters.Add("@IpEquipoActualizacion", SqlDbType.VarChar).Value = parGarantias.IpEquipoActualizacion;} catch { }

			DataTable dt = cnn.Seleccionar();

			List<Garantias> lstGarantias= new List<Garantias>();

			if(dt != null)
			{
				List<Emisores> lstEmisores = (new DalEmisores().buscar(new Emisores()));
				List<FormasGarantias> lstFormasGarantias = (new DalFormasGarantias().buscar(new FormasGarantias()));
				List<Contratos> lstContratos = (new DalContratos().buscar(new Contratos()));
                List<Estados> lstEstados = (new DalEstados().buscar(new Estados()));

			foreach(DataRow dr in dt.Rows)
			{
				Garantias garantias = new Garantias();
				garantias.IdEmisor = new Emisores();
				garantias.IdForma = new FormasGarantias();
				garantias.IdContrato = new Contratos();
                garantias.IdEstadoActual = new Estados();

				try
				{
					garantias.IdGarantia = Convert.ToInt32(dr["IdGarantia"]);
				}
				catch
				{
					garantias.IdGarantia = null;
				}

				try
				{
					garantias.Numero = Convert.ToString(dr["Numero"]);
				}
				catch
				{
					garantias.Numero = null;
				}

				try
				{
					garantias.Monto = Convert.ToDecimal(dr["Monto"]);
				}
				catch
				{
					garantias.Monto = null;
				}

				try
				{
					garantias.FechaEmision = Convert.ToDateTime(dr["FechaEmision"]);
				}
				catch
				{
					garantias.FechaEmision = null;
				}

				try
				{
					garantias.FechaVigenciaInicial = Convert.ToDateTime(dr["FechaVigenciaInicial"]);
				}
				catch
				{
					garantias.FechaVigenciaInicial = null;
				}

				try
				{
					garantias.FechaVigenciaFinal = Convert.ToDateTime(dr["FechaVigenciaFinal"]);
				}
				catch
				{
					garantias.FechaVigenciaFinal = null;
				}

				try
				{
					garantias.IdEmisor.IdEmisor = Convert.ToInt32(dr["IdEmisor"]);

					var _entidad = from _i in lstEmisores where _i.IdEmisor == garantias.IdEmisor.IdEmisor select _i;

					foreach (var _x in _entidad)

						garantias.IdEmisor = _x;

				}
				catch
				{
					garantias.IdEmisor = null;
				}

				try
				{
					garantias.IdForma.IdForma = Convert.ToInt32(dr["IdForma"]);

					var _entidad = from _i in lstFormasGarantias where _i.IdForma == garantias.IdForma.IdForma select _i;

					foreach (var _x in _entidad)

						garantias.IdForma = _x;

				}
				catch
				{
					garantias.IdForma = null;
				}

				try
				{
                    garantias.IdEstadoActual.IdEstado = Convert.ToInt32(dr["IdEstadoActual"]);

                    var _entidad = from _i in lstEstados where _i.IdEstado == garantias.IdEstadoActual.IdEstado select _i;

                    foreach (var _x in _entidad)

                        garantias.IdEstadoActual = _x;
				}
				catch
				{
					garantias.IdEstadoActual = null;
				}

				try
				{
					garantias.IdContrato.IdContrato = Convert.ToInt32(dr["IdContrato"]);

					var _entidad = from _i in lstContratos where _i.IdContrato == garantias.IdContrato.IdContrato select _i;

					foreach (var _x in _entidad)

						garantias.IdContrato = _x;

				}
				catch
				{
					garantias.IdContrato = null;
				}

                try
                {
                    garantias.Comentario = Convert.ToString(dr["Comentario"]);
                }
                catch
                {
                    garantias.Comentario = null;
                }

                try
                {
                    garantias.DocumentacionPendiente = Convert.ToBoolean(dr["DocumentacionPendiente"]);
                }
                catch
                {
                    garantias.DocumentacionPendiente = null;
                }

				try
				{
					garantias.Anulado = Convert.ToBoolean(dr["Anulado"]);
				}
				catch
				{
					garantias.Anulado = null;
				}

				try
				{
					garantias.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]);
				}
				catch
				{
					garantias.FechaIngreso = null;
				}

				try
				{
					garantias.UsuarioIngreso = Convert.ToString(dr["UsuarioIngreso"]);
				}
				catch
				{
					garantias.UsuarioIngreso = null;
				}

				try
				{
					garantias.IpEquipoUsuarioIngreso = Convert.ToString(dr["IpEquipoUsuarioIngreso"]);
				}
				catch
				{
					garantias.IpEquipoUsuarioIngreso = null;
				}

				try
				{
					garantias.FechaActualizacion = Convert.ToDateTime(dr["FechaActualizacion"]);
				}
				catch
				{
					garantias.FechaActualizacion = null;
				}

				try
				{
					garantias.UsuarioActualizacion = Convert.ToString(dr["UsuarioActualizacion"]);
				}
				catch
				{
					garantias.UsuarioActualizacion = null;
				}

				try
				{
					garantias.IpEquipoActualizacion = Convert.ToString(dr["IpEquipoActualizacion"]);
				}
				catch
				{
					garantias.IpEquipoActualizacion = null;
				}

                try
                {
                    garantias.DiasAlertas = Convert.ToInt32(dr["DiasAlerta"]);
                }
                catch
                {
                    garantias.DiasAlertas = null;
                }

                try
                {
                    garantias.Final = Convert.ToBoolean(dr["Final"]);
                }
                catch
                {
                    garantias.Final = null;
                }

                try
                {
                    garantias.DiasParametroVencimiento = Convert.ToInt32(dr["DiasParametroVencimiento"]);
                }
                catch
                {
                    garantias.DiasParametroVencimiento = null;
                }


				lstGarantias.Add(garantias);
				}
			}
		return lstGarantias;
	}
		#endregion // METODOS DE LA CLASE
	} // end class
} // FIN NAMESPACE
