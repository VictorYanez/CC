/*
============================================================================================
tbl_TiposContactos		Tabla que almacena los diferentes tipos de contactos del concesionario.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 29 de junio de 2021 15:32:04
============================================================================================
*/
using System;
using System.Web;
using System.Runtime.Serialization;

namespace ENT
{
	public class TiposContactos
	{
		#region properties

		/// <summary>
		/// Identificador único del tipo de contacto.
		/// </summary>
		public Int32? IdTipoContacto { get; set; }

		/// <summary>
		/// Nombre del tipo de contacto.
		/// </summary>
		public String Nombre { get; set; }

		 #endregion // properties
	} // end class
} // end namespace
