/*
============================================================================================
tbl_FormasGarantias		Tabla que almacena la forma en la que se emite la garantía.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 29 de junio de 2021 15:30:22
============================================================================================
*/
using System;
using System.Web;
using System.Runtime.Serialization;

namespace ENT
{
	public class FormasGarantias
	{
		#region properties

		/// <summary>
		/// Código identificador único de la forma de la garantía.
		/// </summary>
		public Int32? IdForma { get; set; }

		/// <summary>
		/// Nombre de la forma de entrega de la garantía.
		/// </summary>
		public String Nombre { get; set; }

		 #endregion // properties
	} // end class
} // end namespace
