/*
============================================================================================
tbl_Concesionarios		Tabla que almacena la información relevante de los concesionarios.
Autor:		VMT\marvin.ruiz
Fecha:		miércoles, 30 de junio de 2021 10:20:07
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
    public class DalConcesionarios
    {
        Conexion cnn;

        public DalConcesionarios()
        {
            cnn = new Conexion();
        }


        #region "METODOS DE LA CLASE"
        public int insertar(Concesionarios concesionarios)
        {
            cnn.Com.CommandText = "pa_tbl_Concesionarios";
            cnn.Com.Parameters.Clear();

            cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "insertar";

            try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = concesionarios.Nombre; }
            catch { }
            try { cnn.Com.Parameters.Add("@Abreviatura", SqlDbType.VarChar).Value = concesionarios.Abreviatura; }
            catch { }
            try { cnn.Com.Parameters.Add("@Nit", SqlDbType.VarChar).Value = concesionarios.Nit; }
            catch { }
            try { cnn.Com.Parameters.Add("@IdTipoConcesionario", SqlDbType.Int).Value = concesionarios.IdTipoConcesionario.IdTipoConcesionario; }
            catch { }
            try { cnn.Com.Parameters.Add("@UsuarioIngreso", SqlDbType.VarChar).Value = concesionarios.UsuarioIngreso; }
            catch { }
            try { cnn.Com.Parameters.Add("@IpEquipoUsuarioIngreso", SqlDbType.VarChar).Value = concesionarios.IpEquipoUsuarioIngreso; }
            catch { }
           

            return cnn.Ejecutar(false);
        }

        public int actualizar(Concesionarios concesionarios)
        {
            cnn.Com.CommandText = "pa_tbl_Concesionarios";
            cnn.Com.Parameters.Clear();

            cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "actualizar";

            try { cnn.Com.Parameters.Add("@IdConcesionario", SqlDbType.Int).Value = concesionarios.IdConcesionario; }            catch { }
            try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = concesionarios.Nombre; }            catch { }
            try { cnn.Com.Parameters.Add("@Abreviatura", SqlDbType.VarChar).Value = concesionarios.Abreviatura; }            catch { }
            try { cnn.Com.Parameters.Add("@Nit", SqlDbType.VarChar).Value = concesionarios.Nit; }            catch { }
            try { cnn.Com.Parameters.Add("@IdTipoConcesionario", SqlDbType.Int).Value = concesionarios.IdTipoConcesionario.IdTipoConcesionario; }            catch { }
            try { cnn.Com.Parameters.Add("@UsuarioActualizacion", SqlDbType.VarChar).Value = concesionarios.UsuarioActualizacion; }            catch { }
            try { cnn.Com.Parameters.Add("@IpEquipoActualizacion", SqlDbType.VarChar).Value = concesionarios.IpEquipoActualizacion; }            catch { }

            return cnn.Ejecutar(false);
        }

        public int eliminar(Concesionarios concesionarios)
        {
            cnn.Com.CommandText = "pa_tbl_Concesionarios";
            cnn.Com.Parameters.Clear();

            cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "eliminar";

            try { cnn.Com.Parameters.Add("@IdConcesionario", SqlDbType.Int).Value = concesionarios.IdConcesionario; }  catch { }

            return cnn.Ejecutar(false);
        }

        public List<Concesionarios> buscar(Concesionarios parConcesionarios, string _ordenarPor = null, int? _mostrarN = null)
        {
            cnn.Com.CommandText = "pa_tbl_Concesionarios";
            cnn.Com.Parameters.Clear();

            cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "buscar";
            cnn.Com.Parameters.Add("@_ordenarPor", SqlDbType.VarChar).Value = _ordenarPor;
            cnn.Com.Parameters.Add("@_mostrarN", SqlDbType.Int).Value = _mostrarN;

            try { cnn.Com.Parameters.Add("@IdConcesionario", SqlDbType.Int).Value = parConcesionarios.IdConcesionario; }            catch { }
            try { cnn.Com.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = parConcesionarios.Nombre; }            catch { }
            try { cnn.Com.Parameters.Add("@Abreviatura", SqlDbType.VarChar).Value = parConcesionarios.Abreviatura; }            catch { }
            try { cnn.Com.Parameters.Add("@Nit", SqlDbType.VarChar).Value = parConcesionarios.Nit; }            catch { }
            try { cnn.Com.Parameters.Add("@IdTipoConcesionario", SqlDbType.Int).Value = parConcesionarios.IdTipoConcesionario.IdTipoConcesionario; }            catch { }
            try { cnn.Com.Parameters.Add("@Anulado", SqlDbType.Bit).Value = parConcesionarios.Anulado; }            catch { }
            try { cnn.Com.Parameters.Add("@FechaIngreso", SqlDbType.DateTime).Value = parConcesionarios.FechaIngreso; }            catch { }
            try { cnn.Com.Parameters.Add("@UsuarioIngreso", SqlDbType.VarChar).Value = parConcesionarios.UsuarioIngreso; }            catch { }
            try { cnn.Com.Parameters.Add("@IpEquipoUsuarioIngreso", SqlDbType.VarChar).Value = parConcesionarios.IpEquipoUsuarioIngreso; }            catch { }
            try { cnn.Com.Parameters.Add("@FechaActualizacion", SqlDbType.DateTime).Value = parConcesionarios.FechaActualizacion; }            catch { }
            try { cnn.Com.Parameters.Add("@UsuarioActualizacion", SqlDbType.VarChar).Value = parConcesionarios.UsuarioActualizacion; }            catch { }
            try { cnn.Com.Parameters.Add("@IpEquipoActualizacion", SqlDbType.VarChar).Value = parConcesionarios.IpEquipoActualizacion; }            catch { }

            DataTable dt = cnn.Seleccionar();

            List<Concesionarios> lstConcesionarios = new List<Concesionarios>();

            if (dt != null)
            {

                List<TiposConcesionarios> lstTiposConcesionarios = (new DalTiposConcesionarios().buscar(new TiposConcesionarios()));

                foreach (DataRow dr in dt.Rows)
                {
                    Concesionarios concesionarios = new Concesionarios();
                    concesionarios.IdTipoConcesionario = new TiposConcesionarios();

                    try
                    {
                        concesionarios.IdConcesionario = Convert.ToInt32(dr["IdConcesionario"]);
                    }
                    catch
                    {
                        concesionarios.IdConcesionario = null;
                    }

                    try
                    {
                        concesionarios.Nombre = Convert.ToString(dr["Nombre"]);
                    }
                    catch
                    {
                        concesionarios.Nombre = null;
                    }

                    try
                    {
                        concesionarios.Abreviatura = Convert.ToString(dr["Abreviatura"]);
                    }
                    catch
                    {
                        concesionarios.Abreviatura = null;
                    }

                    try
                    {
                        concesionarios.Nit = Convert.ToString(dr["Nit"]);
                    }
                    catch
                    {
                        concesionarios.Nit = null;
                    }

                    try
                    {
                        concesionarios.IdTipoConcesionario.IdTipoConcesionario = Convert.ToInt32(dr["IdTipoConcesionario"]);

                        var _entidad = from _i in lstTiposConcesionarios where _i.IdTipoConcesionario == concesionarios.IdTipoConcesionario.IdTipoConcesionario select _i;

                        foreach (var _x in _entidad)

                            concesionarios.IdTipoConcesionario = _x;

                    }
                    catch
                    {
                        concesionarios.IdTipoConcesionario = null;
                    }

                    try
                    {
                        concesionarios.Anulado = Convert.ToBoolean(dr["Anulado"]);
                    }
                    catch
                    {
                        concesionarios.Anulado = null;
                    }

                    try
                    {
                        concesionarios.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]);
                    }
                    catch
                    {
                        concesionarios.FechaIngreso = null;
                    }

                    try
                    {
                        concesionarios.UsuarioIngreso = Convert.ToString(dr["UsuarioIngreso"]);
                    }
                    catch
                    {
                        concesionarios.UsuarioIngreso = null;
                    }

                    try
                    {
                        concesionarios.IpEquipoUsuarioIngreso = Convert.ToString(dr["IpEquipoUsuarioIngreso"]);
                    }
                    catch
                    {
                        concesionarios.IpEquipoUsuarioIngreso = null;
                    }

                    try
                    {
                        concesionarios.FechaActualizacion = Convert.ToDateTime(dr["FechaActualizacion"]);
                    }
                    catch
                    {
                        concesionarios.FechaActualizacion = null;
                    }

                    try
                    {
                        concesionarios.UsuarioActualizacion = Convert.ToString(dr["UsuarioActualizacion"]);
                    }
                    catch
                    {
                        concesionarios.UsuarioActualizacion = null;
                    }

                    try
                    {
                        concesionarios.IpEquipoActualizacion = Convert.ToString(dr["IpEquipoActualizacion"]);
                    }
                    catch
                    {
                        concesionarios.IpEquipoActualizacion = null;
                    }


                    lstConcesionarios.Add(concesionarios);
                }
            }
            return lstConcesionarios;
        }
        #endregion // METODOS DE LA CLASE
    } // end class
} // FIN NAMESPACE
