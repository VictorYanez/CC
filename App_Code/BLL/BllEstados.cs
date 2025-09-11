/*
============================================================================================
tbl_Estados		Tabla que almacena los diferentes estados del proceso de las garantías.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 29 de junio de 2021 15:35:24
============================================================================================
*/
using System;
using System.Collections.Generic;
using ENT;
using DAL;

namespace BLL
{
	public class BllEstados
	{
		DalEstados dalEstados;

		public BllEstados()
		{
			dalEstados = new DalEstados();
		}
		public int insertar(Estados estados)
		{
			return dalEstados.insertar(estados);
		}
		public int actualizar(Estados estados)
		{
			return dalEstados.actualizar(estados);
		}
		public int eliminar(Estados estados)
		{
			return dalEstados.eliminar(estados);
		}
		public List<Estados> buscar(Estados estados, string _ordenarPor = null, int? _mostrarN = null)
		{
			return dalEstados.buscar(estados, _ordenarPor, _mostrarN);
		}
	} // end class
} // end namespace
