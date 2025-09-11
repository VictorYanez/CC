/*
============================================================================================
tbl_TiposConcesionarios		Tabla que almacena los diferentes tipos de concesionarios.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 29 de junio de 2021 15:31:24
============================================================================================
*/
using System;
using System.Collections.Generic;
using ENT;
using DAL;

namespace BLL
{
	public class BllTiposConcesionarios
	{
		DalTiposConcesionarios dalTiposConcesionarios;

		public BllTiposConcesionarios()
		{
			dalTiposConcesionarios = new DalTiposConcesionarios();
		}
		public int insertar(TiposConcesionarios tiposconcesionarios)
		{
			return dalTiposConcesionarios.insertar(tiposconcesionarios);
		}
		public int actualizar(TiposConcesionarios tiposconcesionarios)
		{
			return dalTiposConcesionarios.actualizar(tiposconcesionarios);
		}
		public int eliminar(TiposConcesionarios tiposconcesionarios)
		{
			return dalTiposConcesionarios.eliminar(tiposconcesionarios);
		}
		public List<TiposConcesionarios> buscar(TiposConcesionarios tiposconcesionarios, string _ordenarPor = null, int? _mostrarN = null)
		{
			return dalTiposConcesionarios.buscar(tiposconcesionarios, _ordenarPor, _mostrarN);
		}
	} // end class
} // end namespace
