/*
============================================================================================
tbl_AsignacionesLineas		Tabla que almacena la asignaciones de líneas, concesionario y contratos.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 13 de julio de 2021 11:27:55
============================================================================================
*/
using System;
using System.Collections.Generic;
using ENT;
using DAL;

namespace BLL
{
	public class BllAsignacionesLineas
	{
		DalAsignacionesLineas dalAsignacionesLineas;
      
		public BllAsignacionesLineas()
		{
			dalAsignacionesLineas = new DalAsignacionesLineas();
		}
		public int insertar(AsignacionesLineas asignacioneslineas)
		{
			return dalAsignacionesLineas.insertar(asignacioneslineas);
		}
		public int actualizar(AsignacionesLineas asignacioneslineas)
		{
			return dalAsignacionesLineas.actualizar(asignacioneslineas);
		}
		public int eliminar(AsignacionesLineas asignacioneslineas)
		{
			return dalAsignacionesLineas.eliminar(asignacioneslineas);
		}
		public List<AsignacionesLineas> buscar(AsignacionesLineas asignacioneslineas, string _ordenarPor = null, int? _mostrarN = null)
		{
			return dalAsignacionesLineas.buscar(asignacioneslineas, _ordenarPor, _mostrarN);
		}
      
	} // end class
} // end namespace
