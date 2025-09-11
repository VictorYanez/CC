/*
============================================================================================
tbl_TiposConcesionarios		Tabla que almacena los diferentes tipos de concesionarios.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 29 de junio de 2021 15:31:24
============================================================================================
*/
using System;
using System.Web;
using System.Runtime.Serialization;

namespace ENT
{
	public class TiposConcesionarios
	{
		#region properties

		/// <summary>
		/// Identificador único del tipo de concesionario.
		/// </summary>
		public Int32? IdTipoConcesionario { get; set; }

		/// <summary>
		/// Nombre del tipo de concesionario.
		/// </summary>
		public String Nombre { get; set; }

		 #endregion // properties
	} // end class
} // end namespace
