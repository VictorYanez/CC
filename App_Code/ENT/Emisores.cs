/*
============================================================================================
tbl_Emisores		Tabla que almacena las diferentes entidades que emiten fianzas o cheques.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 29 de junio de 2021 15:29:11
============================================================================================
*/
using System;
using System.Web;
using System.Runtime.Serialization;

namespace ENT
{
	public class Emisores
	{
		#region properties

		/// <summary>
		/// Identificador único del emisor de garantías.
		/// </summary>
		public Int32? IdEmisor { get; set; }

		/// <summary>
		/// Nombre del emisor.
		/// </summary>
		public String Nombre { get; set; }

		 #endregion // properties
	} // end class
} // end namespace
