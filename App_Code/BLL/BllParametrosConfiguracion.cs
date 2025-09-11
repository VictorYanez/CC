/*
============================================================================================
tbl_ParametrosConfiguracion		
Autor:		VMT\marvin.ruiz
Fecha:		miércoles, 21 de julio de 2021 18:20:28
============================================================================================
*/
using System;
using System.Collections.Generic;
using ENT;
using DAL;

namespace BLL
{
	public class BllParametrosConfiguracion
	{
		DalParametrosConfiguracion dalParametrosConfiguracion;

		public BllParametrosConfiguracion()
		{
			dalParametrosConfiguracion = new DalParametrosConfiguracion();
		}
		public int insertar(ParametrosConfiguracion parametrosconfiguracion)
		{
			return dalParametrosConfiguracion.insertar(parametrosconfiguracion);
		}
		public int actualizar(ParametrosConfiguracion parametrosconfiguracion)
		{
			return dalParametrosConfiguracion.actualizar(parametrosconfiguracion);
		}
		public int eliminar(ParametrosConfiguracion parametrosconfiguracion)
		{
			return dalParametrosConfiguracion.eliminar(parametrosconfiguracion);
		}
		public List<ParametrosConfiguracion> buscar(ParametrosConfiguracion parametrosconfiguracion, string _ordenarPor = null, int? _mostrarN = null)
		{
			return dalParametrosConfiguracion.buscar(parametrosconfiguracion, _ordenarPor, _mostrarN);
		}
	} // end class
} // end namespace
