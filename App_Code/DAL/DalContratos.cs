/*
============================================================================================
tbl_Contratos		Tabla que almacena los contratos de los concesionarios.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 13 de julio de 2021 11:26:23
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
	public class DalContratos
	{
		Conexion cnn;

		public DalContratos()
		{
			cnn = new Conexion();
		}


		#region "METODOS DE LA CLASE"
		public int insertar(Contratos contratos)
		{
			cnn.Com.CommandText = "pa_tbl_Contratos";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "insertar";

			try { cnn.Com.Parameters.Add("@Numero", SqlDbType.VarChar).Value = contratos.Numero;} catch { }
			try { cnn.Com.Parameters.Add("@FechaVigenciaInicial", SqlDbType.Date).Value = contratos.FechaVigenciaInicial;} catch { }
			try { cnn.Com.Parameters.Add("@FechaVigenciaFinal", SqlDbType.Date).Value = contratos.FechaVigenciaFinal;} catch { }
			try { cnn.Com.Parameters.Add("@IdContratoDepende", SqlDbType.Int).Value = contratos.IdContratoDepende.IdContrato;} catch { }
            try { cnn.Com.Parameters.Add("@IdConcesionario", SqlDbType.Int).Value = contratos.IdConcesionario.IdConcesionario; }  catch { }
            try { cnn.Com.Parameters.Add("@Comentario", SqlDbType.VarChar).Value = contratos.Comentario; }     catch { }
            try { cnn.Com.Parameters.Add("@Resolucion", SqlDbType.VarChar).Value = contratos.Resolucion; }   catch { }
            try { cnn.Com.Parameters.Add("@Modificativa", SqlDbType.Int).Value = contratos.Modificativa; }    catch { }
			try { cnn.Com.Parameters.Add("@UsuarioIngreso", SqlDbType.VarChar).Value = contratos.UsuarioIngreso;} catch { }
			try { cnn.Com.Parameters.Add("@IpEquipoUsuarioIngreso", SqlDbType.VarChar).Value = contratos.IpEquipoUsuarioIngreso;} catch { }
			
			return cnn.Ejecutar(false);
		}

		public int actualizar(Contratos contratos)
		{
			cnn.Com.CommandText = "pa_tbl_Contratos";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "actualizar";
			try { cnn.Com.Parameters.Add("@IdContrato", SqlDbType.Int).Value = contratos.IdContrato;} catch { }
			try { cnn.Com.Parameters.Add("@Numero", SqlDbType.VarChar).Value = contratos.Numero;} catch { }
			try { cnn.Com.Parameters.Add("@FechaVigenciaInicial", SqlDbType.Date).Value = contratos.FechaVigenciaInicial;} catch { }
			try { cnn.Com.Parameters.Add("@FechaVigenciaFinal", SqlDbType.Date).Value = contratos.FechaVigenciaFinal;} catch { }
            try { cnn.Com.Parameters.Add("@Finalizado", SqlDbType.Bit).Value = contratos.Finalizado; }  catch { }			
			try { cnn.Com.Parameters.Add("@IdContratoDepende", SqlDbType.Int).Value = contratos.IdContratoDepende.IdContrato;} catch { }
            try { cnn.Com.Parameters.Add("@IdConcesionario", SqlDbType.Int).Value = contratos.IdConcesionario.IdConcesionario; } catch { }
            try { cnn.Com.Parameters.Add("@Comentario", SqlDbType.VarChar).Value = contratos.Comentario; }   catch { }
            try { cnn.Com.Parameters.Add("@Resolucion", SqlDbType.VarChar).Value = contratos.Resolucion; }            catch { }
            try { cnn.Com.Parameters.Add("@Modificativa", SqlDbType.Int).Value = contratos.Modificativa; }   catch { }
			try { cnn.Com.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime).Value = contratos.FechaActualizacion;} catch { }
			try { cnn.Com.Parameters.Add("@UsuarioActualizacion", SqlDbType.VarChar).Value = contratos.UsuarioActualizacion;} catch { }
			try { cnn.Com.Parameters.Add("@IpEquipoActualizacion", SqlDbType.VarChar).Value = contratos.IpEquipoActualizacion;} catch { }

			return cnn.Ejecutar(false);
		}

		public int eliminar(Contratos contratos)
		{
			cnn.Com.CommandText = "pa_tbl_Contratos";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "eliminar";

			try { cnn.Com.Parameters.Add("@IdContrato", SqlDbType.Int).Value = contratos.IdContrato;} catch { }

			return cnn.Ejecutar(false);
		}

		public List<Contratos> buscar(Contratos parContratos, string _ordenarPor = null, int? _mostrarN = null)
		{
			cnn.Com.CommandText = "pa_tbl_Contratos";
			cnn.Com.Parameters.Clear();

			cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "buscar";
			cnn.Com.Parameters.Add("@_ordenarPor", SqlDbType.VarChar).Value = _ordenarPor;
			cnn.Com.Parameters.Add("@_mostrarN", SqlDbType.Int).Value = _mostrarN;

			try { cnn.Com.Parameters.Add("@IdContrato", SqlDbType.Int).Value = parContratos.IdContrato;} catch { }
			try { cnn.Com.Parameters.Add("@Numero", SqlDbType.VarChar).Value = parContratos.Numero;} catch { }
			try { cnn.Com.Parameters.Add("@FechaVigenciaInicial", SqlDbType.Date).Value = parContratos.FechaVigenciaInicial;} catch { }
			try { cnn.Com.Parameters.Add("@FechaVigenciaFinal", SqlDbType.Date).Value = parContratos.FechaVigenciaFinal;} catch { }
			try { cnn.Com.Parameters.Add("@IdContratoDepende", SqlDbType.Int).Value = parContratos.IdContratoDepende.IdContrato;} catch { }
            try { cnn.Com.Parameters.Add("@IdConcesionario", SqlDbType.Int).Value = parContratos.IdConcesionario.IdConcesionario; } catch { }
            try { cnn.Com.Parameters.Add("@Comentario", SqlDbType.VarChar).Value = parContratos.Comentario; }   catch { }
            try { cnn.Com.Parameters.Add("@Resolucion", SqlDbType.VarChar).Value = parContratos.Resolucion; }           catch { }
            try { cnn.Com.Parameters.Add("@Modificativa", SqlDbType.Int).Value = parContratos.Modificativa; }        catch { }
			try { cnn.Com.Parameters.Add("@Anulado", SqlDbType.Bit).Value = parContratos.Anulado;} catch { }
            try { cnn.Com.Parameters.Add("@Finalizado", SqlDbType.Bit).Value = parContratos.Finalizado; }  catch { }	
			try { cnn.Com.Parameters.Add("@FechaIngreso", SqlDbType.DateTime).Value = parContratos.FechaIngreso;} catch { }
			try { cnn.Com.Parameters.Add("@UsuarioIngreso", SqlDbType.VarChar).Value = parContratos.UsuarioIngreso;} catch { }
			try { cnn.Com.Parameters.Add("@IpEquipoUsuarioIngreso", SqlDbType.VarChar).Value = parContratos.IpEquipoUsuarioIngreso;} catch { }
			try { cnn.Com.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime).Value = parContratos.FechaActualizacion;} catch { }
			try { cnn.Com.Parameters.Add("@UsuarioActualizacion", SqlDbType.VarChar).Value = parContratos.UsuarioActualizacion;} catch { }
			try { cnn.Com.Parameters.Add("@IpEquipoActualizacion", SqlDbType.VarChar).Value = parContratos.IpEquipoActualizacion;} catch { }
            try { cnn.Com.Parameters.Add("@PalabraClave", SqlDbType.VarChar).Value = parContratos.PalabraClave; }  catch { }

			DataTable dt = cnn.Seleccionar();

			List<Contratos> lstContratos= new List<Contratos>();

			if(dt != null)
			{
                List<Concesionarios> lstConcesionarios = (new DalConcesionarios().buscar(new Concesionarios()));

			foreach(DataRow dr in dt.Rows)
			{
				Contratos contratos = new Contratos();
				contratos.IdContratoDepende = new Contratos();
                contratos.IdConcesionario = new Concesionarios();

				try
				{
					contratos.IdContrato = Convert.ToInt32(dr["IdContrato"]);
				}
				catch
				{
					contratos.IdContrato = null;
				}

				try
				{
					contratos.Numero = Convert.ToString(dr["Numero"]);
				}
				catch
				{
					contratos.Numero = null;
				}

				try
				{
					contratos.FechaVigenciaInicial = Convert.ToDateTime(dr["FechaVigenciaInicial"]);
				}
				catch
				{
					contratos.FechaVigenciaInicial = null;
				}

				try
				{
					contratos.FechaVigenciaFinal = Convert.ToDateTime(dr["FechaVigenciaFinal"]);
				}
				catch
				{
					contratos.FechaVigenciaFinal = null;
				}

                try
                {
                    contratos.IdContratoDepende.IdContrato = Convert.ToInt32(dr["IdContratoDepende"]);
                }
                catch
                {
                    contratos.IdContratoDepende = null;
                }

                try
                {
                    contratos.IdConcesionario.IdConcesionario = Convert.ToInt32(dr["IdConcesionario"]);

                    var _entidad = from _i in lstConcesionarios where _i.IdConcesionario == contratos.IdConcesionario.IdConcesionario select _i;

                    foreach (var _x in _entidad)

                        contratos.IdConcesionario = _x;

                }
                catch
                {
                    contratos.IdConcesionario = null;
                }

                try
                {
                    contratos.CodigoConcesionario= Convert.ToInt32(dr["IdConcesionario"]);
                }
                catch
                {
                    contratos.CodigoConcesionario = null;
                }

                try
                {
                    contratos.NumeroContratoDependiente = Convert.ToString(dr["NumeroContratoDependiente"]);
                }
                catch
                {
                    contratos.NumeroContratoDependiente = null;
                }

                try
                {
                    contratos.Comentario = Convert.ToString(dr["Comentario"]);
                }
                catch
                {
                    contratos.Comentario = null;
                }

                try
                {
                    contratos.Resolucion = Convert.ToString(dr["Resolucion"]);
                }
                catch
                {
                    contratos.Resolucion = null;
                }

                try
                {
                    contratos.Modificativa = Convert.ToInt32(dr["Modificativa"]);
                }
                catch
                {
                    contratos.Modificativa = null;
                }

				try
				{
					contratos.Anulado = Convert.ToBoolean(dr["Anulado"]);
				}
				catch
				{
					contratos.Anulado = null;
				}

                try
                {
                    contratos.Finalizado = Convert.ToBoolean(dr["Finalizado"]);
                }
                catch
                {
                    contratos.Finalizado = null;
                }

				try
				{
					contratos.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]);
				}
				catch
				{
					contratos.FechaIngreso = null;
				}

				try
				{
					contratos.UsuarioIngreso = Convert.ToString(dr["UsuarioIngreso"]);
				}
				catch
				{
					contratos.UsuarioIngreso = null;
				}

				try
				{
					contratos.IpEquipoUsuarioIngreso = Convert.ToString(dr["IpEquipoUsuarioIngreso"]);
				}
				catch
				{
					contratos.IpEquipoUsuarioIngreso = null;
				}

				try
				{
					contratos.FechaActualizacion = Convert.ToDateTime(dr["FechaActualizacion"]);
				}
				catch
				{
					contratos.FechaActualizacion = null;
				}

				try
				{
					contratos.UsuarioActualizacion = Convert.ToString(dr["UsuarioActualizacion"]);
				}
				catch
				{
					contratos.UsuarioActualizacion = null;
				}

				try
				{
					contratos.IpEquipoActualizacion = Convert.ToString(dr["IpEquipoActualizacion"]);
				}
				catch
				{
					contratos.IpEquipoActualizacion = null;
				}

                try
                {
                    contratos.DiasAlertas = Convert.ToInt32(dr["DiasAlertas"]);
                }
                catch
                {
                    contratos.DiasAlertas = null;
                }

                try
                {
                    contratos.DiasParametroVencimiento = Convert.ToInt32(dr["DiasParametroVencimiento"]);
                }
                catch
                {
                    contratos.DiasParametroVencimiento = null;
                }


				lstContratos.Add(contratos);
				}
			}
		return lstContratos;
	}
		#endregion // METODOS DE LA CLASE
	} // end class
} // FIN NAMESPACE
