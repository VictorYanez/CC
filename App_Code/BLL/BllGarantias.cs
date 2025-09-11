/*
============================================================================================
tbl_Garantias		Tabla que almacena las garantías de los contratos.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 13 de julio de 2021 11:27:35
============================================================================================
*/
using System;
using System.Collections.Generic;
using ENT;
using DAL;
using System.Data;
using Especiales.DAL;
namespace BLL
{
	public class BllGarantias
	{
		DalGarantias dalGarantias;
        ParGarantias parGarantias;
		public BllGarantias()
		{
			dalGarantias = new DalGarantias();
            parGarantias = new ParGarantias();
		}
		public int insertar(Garantias garantias)
		{
			return dalGarantias.insertar(garantias);
		}
		public int actualizar(Garantias garantias)
		{
			return dalGarantias.actualizar(garantias);
		}
		public int eliminar(Garantias garantias)
		{
			return dalGarantias.eliminar(garantias);
		}
		public List<Garantias> buscar(Garantias garantias, string _ordenarPor = null, int? _mostrarN = null)
		{
			return dalGarantias.buscar(garantias, _ordenarPor, _mostrarN);
		}

        /// <summary>
        /// Método que devuelve las garantías en sus diferentes esetados de alertas.
        /// </summary>
        /// <param name="porVencer">Indica si se desea obtener garantías por vencer.</param>
        /// <param name="vencidas">Indica si se desea obtener garnatías vencidas.</param>
        /// <param name="documentacionPendiente">Indica si se desean obtener las garantías pendientes de documentación.</param>
        /// <returns>DataTable</returns>
        public DataTable ConsultaGarantias(string numero, int idEstado, bool? porVencer = null, bool? vencidas = null, bool? documentacionPendiente = null)
        {
            return parGarantias.ConsultaGarantias(numero, idEstado, porVencer, vencidas, documentacionPendiente);
        }

        /// <summary>
        /// Método que obtiene los estados de alerta de los contratos.
        /// </summary>
        /// <returns></returns>
        public DataTable EstadosAlertas()
        {
            return parGarantias.EstadosAlertas();
        }
        public int ObtenerIdProximoEstado(int idGarantia)
        {
            return parGarantias.ObtenerIdProximoEstado(idGarantia);
        }

	} // end class
} // end namespace
