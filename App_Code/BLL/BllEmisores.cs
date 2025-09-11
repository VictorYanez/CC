/*
============================================================================================
tbl_Emisores		Tabla que almacena las diferentes entidades que emiten fianzas o cheques.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 29 de junio de 2021 15:29:11
============================================================================================
*/
using System;
using System.Collections.Generic;
using ENT;
using DAL;

namespace BLL
{
	public class BllEmisores
	{
		DalEmisores dalEmisores;

		public BllEmisores()
		{
			dalEmisores = new DalEmisores();
		}
		public int insertar(Emisores emisores)
		{
			return dalEmisores.insertar(emisores);
		}
		public int actualizar(Emisores emisores)
		{
			return dalEmisores.actualizar(emisores);
		}
		public int eliminar(Emisores emisores)
		{
			return dalEmisores.eliminar(emisores);
		}
		public List<Emisores> buscar(Emisores emisores, string _ordenarPor = null, int? _mostrarN = null)
		{
			return dalEmisores.buscar(emisores, _ordenarPor, _mostrarN);
		}
	} // end class
} // end namespace
