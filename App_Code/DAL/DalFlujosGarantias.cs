/*
============================================================================================
tbl_FlujosGarantias		Tabla que almacena el historial de estados de la garantía.
Autor:		VMT\marvin.ruiz
Fecha:		miércoles, 30 de junio de 2021 9:52:21
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
    public class DalFlujosGarantias
    {
        Conexion cnn;

        public DalFlujosGarantias()
        {
            cnn = new Conexion();
        }


        #region "METODOS DE LA CLASE"
        public int insertar(FlujosGarantias flujosgarantias)
        {
            cnn.Com.CommandText = "pa_tbl_FlujosGarantias";
            cnn.Com.Parameters.Clear();

            cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "insertar";

            try { cnn.Com.Parameters.Add("@IdGarantia", SqlDbType.Int).Value = flujosgarantias.IdGarantia.IdGarantia; }
            catch { }
            try { cnn.Com.Parameters.Add("@IdEstado", SqlDbType.Int).Value = flujosgarantias.IdEstado.IdEstado; }
            catch { }
            try { cnn.Com.Parameters.Add("@UsuarioIngreso", SqlDbType.VarChar).Value = flujosgarantias.UsuarioIngreso; }
            catch { }
            try { cnn.Com.Parameters.Add("@IpEquipoUsuarioIngreso", SqlDbType.VarChar).Value = flujosgarantias.IpEquipoUsuarioIngreso; }
            catch { }

            return cnn.Ejecutar(false);
        }

        public int actualizar(FlujosGarantias flujosgarantias)
        {
            cnn.Com.CommandText = "pa_tbl_FlujosGarantias";
            cnn.Com.Parameters.Clear();

            cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "actualizar";

            try { cnn.Com.Parameters.Add("@IdFlujoGarantia", SqlDbType.Int).Value = flujosgarantias.IdFlujoGarantia; }
            catch { }
            try { cnn.Com.Parameters.Add("@IdGarantia", SqlDbType.Int).Value = flujosgarantias.IdGarantia.IdGarantia; }
            catch { }
            try { cnn.Com.Parameters.Add("@IdEstado", SqlDbType.Int).Value = flujosgarantias.IdEstado.IdEstado; }
            catch { }
           

            return cnn.Ejecutar(false);
        }

        public int eliminar(FlujosGarantias flujosgarantias)
        {
            cnn.Com.CommandText = "pa_tbl_FlujosGarantias";
            cnn.Com.Parameters.Clear();

            cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "eliminar";

            try { cnn.Com.Parameters.Add("@IdFlujoGarantia", SqlDbType.Int).Value = flujosgarantias.IdFlujoGarantia; }
            catch { }

            return cnn.Ejecutar(false);
        }

        public List<FlujosGarantias> buscar(FlujosGarantias parFlujosGarantias, string _ordenarPor = null, int? _mostrarN = null)
        {
            cnn.Com.CommandText = "pa_tbl_FlujosGarantias";
            cnn.Com.Parameters.Clear();

            cnn.Com.Parameters.Add("@_accion", SqlDbType.VarChar).Value = "buscar";
            cnn.Com.Parameters.Add("@_ordenarPor", SqlDbType.VarChar).Value = _ordenarPor;
            cnn.Com.Parameters.Add("@_mostrarN", SqlDbType.Int).Value = _mostrarN;

            try { cnn.Com.Parameters.Add("@IdFlujoGarantia", SqlDbType.Int).Value = parFlujosGarantias.IdFlujoGarantia; }
            catch { }
            try { cnn.Com.Parameters.Add("@IdGarantia", SqlDbType.Int).Value = parFlujosGarantias.IdGarantia.IdGarantia; }
            catch { }
            try { cnn.Com.Parameters.Add("@IdEstado", SqlDbType.Int).Value = parFlujosGarantias.IdEstado.IdEstado; }
            catch { }
            try { cnn.Com.Parameters.Add("@FechaIngreso", SqlDbType.DateTime).Value = parFlujosGarantias.FechaIngreso; }
            catch { }
            try { cnn.Com.Parameters.Add("@UsuarioIngreso", SqlDbType.VarChar).Value = parFlujosGarantias.UsuarioIngreso; }
            catch { }
            try { cnn.Com.Parameters.Add("@IpEquipoUsuarioIngreso", SqlDbType.VarChar).Value = parFlujosGarantias.IpEquipoUsuarioIngreso; }
            catch { }
          

            DataTable dt = cnn.Seleccionar();

            List<FlujosGarantias> lstFlujosGarantias = new List<FlujosGarantias>();

            if (dt != null)
            {

                List<Estados> lstEstados = (new DalEstados().buscar(new Estados()));
                List<Garantias> lstGarantias = (new DalGarantias().buscar(new Garantias()));

                foreach (DataRow dr in dt.Rows)
                {
                    FlujosGarantias flujosgarantias = new FlujosGarantias();
                    flujosgarantias.IdEstado = new Estados();
                    flujosgarantias.IdGarantia = new Garantias();

                    try
                    {
                        flujosgarantias.IdFlujoGarantia = Convert.ToInt32(dr["IdFlujoGarantia"]);
                    }
                    catch
                    {
                        flujosgarantias.IdFlujoGarantia = null;
                    }

                    try
                    {
                        flujosgarantias.IdGarantia.IdGarantia = Convert.ToInt32(dr["IdGarantia"]);

                        var _entidad = from _i in lstGarantias where _i.IdGarantia == flujosgarantias.IdGarantia.IdGarantia select _i;

                        foreach (var _x in _entidad)

                            flujosgarantias.IdGarantia = _x;

                    }
                    catch
                    {
                        flujosgarantias.IdGarantia = null;
                    }

                    try
                    {
                        flujosgarantias.IdEstado.IdEstado = Convert.ToInt32(dr["IdEstado"]);

                        var _entidad = from _i in lstEstados where _i.IdEstado == flujosgarantias.IdEstado.IdEstado select _i;

                        foreach (var _x in _entidad)

                            flujosgarantias.IdEstado = _x;

                    }
                    catch
                    {
                        flujosgarantias.IdEstado = null;
                    }

                    try
                    {
                        flujosgarantias.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]);
                    }
                    catch
                    {
                        flujosgarantias.FechaIngreso = null;
                    }

                    try
                    {
                        flujosgarantias.UsuarioIngreso = Convert.ToString(dr["UsuarioIngreso"]);
                    }
                    catch
                    {
                        flujosgarantias.UsuarioIngreso = null;
                    }

                    try
                    {
                        flujosgarantias.IpEquipoUsuarioIngreso = Convert.ToString(dr["IpEquipoUsuarioIngreso"]);
                    }
                    catch
                    {
                        flujosgarantias.IpEquipoUsuarioIngreso = null;
                    }

                    lstFlujosGarantias.Add(flujosgarantias);
                }
            }
            return lstFlujosGarantias;
        }
        #endregion // METODOS DE LA CLASE
    } // end class
} // FIN NAMESPACE
