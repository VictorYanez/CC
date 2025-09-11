/*
============================================================================================
tbl_TiposContactos		Tabla que almacena los diferentes tipos de contactos del concesionario.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 29 de junio de 2021 15:32:04
============================================================================================
*/
using System;
using System.Collections.Generic;
using ENT;
using DAL;

namespace BLL
{
	public class BllTiposContactos
	{
		DalTiposContactos dalTiposContactos;

		public BllTiposContactos()
		{
			dalTiposContactos = new DalTiposContactos();
		}
		public int insertar(TiposContactos tiposcontactos)
		{
			return dalTiposContactos.insertar(tiposcontactos);
		}
		public int actualizar(TiposContactos tiposcontactos)
		{
			return dalTiposContactos.actualizar(tiposcontactos);
		}
		public int eliminar(TiposContactos tiposcontactos)
		{
			return dalTiposContactos.eliminar(tiposcontactos);
		}
		public List<TiposContactos> buscar(TiposContactos tiposcontactos, string _ordenarPor = null, int? _mostrarN = null)
		{
			return dalTiposContactos.buscar(tiposcontactos, _ordenarPor, _mostrarN);
		}
	} // end class
} // end namespace
