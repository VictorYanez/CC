/*
============================================================================================
tbl_FlujosGarantias		Tabla que almacena el historial de estados de la garantía.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 29 de junio de 2021 15:35:34
============================================================================================
*/
using System;
using System.Collections.Generic;
using ENT;
using DAL;
using Especiales.DAL;

namespace BLL
{
	public class BllFlujosGarantias
	{
		DalFlujosGarantias dalFlujosGarantias;
        ParFlujosGarantias parFlujoGarantias;
		public BllFlujosGarantias()
		{
			dalFlujosGarantias = new DalFlujosGarantias();
            parFlujoGarantias = new ParFlujosGarantias();
		}
		public int insertar(FlujosGarantias flujosgarantias)
		{
			return dalFlujosGarantias.insertar(flujosgarantias);
		}
		public int actualizar(FlujosGarantias flujosgarantias)
		{
			return dalFlujosGarantias.actualizar(flujosgarantias);
		}
		public int eliminar(FlujosGarantias flujosgarantias)
		{
			return dalFlujosGarantias.eliminar(flujosgarantias);
		}
		public List<FlujosGarantias> buscar(FlujosGarantias flujosgarantias, string _ordenarPor = null, int? _mostrarN = null)
		{
			return dalFlujosGarantias.buscar(flujosgarantias, _ordenarPor, _mostrarN);
		}
        /// <summary>
        /// Método que obtiene la lista de estados pendientes de procesar en la garantía
        /// </summary>
        /// <param name="idGarantia">Código de la garantía</param>
        /// <returns>List</returns>
        public List<Estados> EstadosPendienteGarantia(int idGarantia)
        {
            return parFlujoGarantias.EstadosPendienteGarantia(idGarantia);
        }
	} // end class
} // end namespace
