/*
============================================================================================
tbl_FormasGarantias		Tabla que almacena la forma en la que se emite la garantía.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 29 de junio de 2021 15:30:22
============================================================================================
*/
using System;
using System.Collections.Generic;
using ENT;
using DAL;

namespace BLL
{
	public class BllFormasGarantias
	{
		DalFormasGarantias dalFormasGarantias;

		public BllFormasGarantias()
		{
			dalFormasGarantias = new DalFormasGarantias();
		}
		public int insertar(FormasGarantias formasgarantias)
		{
			return dalFormasGarantias.insertar(formasgarantias);
		}
		public int actualizar(FormasGarantias formasgarantias)
		{
			return dalFormasGarantias.actualizar(formasgarantias);
		}
		public int eliminar(FormasGarantias formasgarantias)
		{
			return dalFormasGarantias.eliminar(formasgarantias);
		}
		public List<FormasGarantias> buscar(FormasGarantias formasgarantias, string _ordenarPor = null, int? _mostrarN = null)
		{
			return dalFormasGarantias.buscar(formasgarantias, _ordenarPor, _mostrarN);
		}
	} // end class
} // end namespace
