/*
============================================================================================
tbl_Lineas		Tabla que almacena las lineas emitidas para concesiones.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 29 de junio de 2021 15:31:05
============================================================================================
*/
using System;
using System.Web;
using System.Runtime.Serialization;

namespace ENT
{
	public class Lineas
	{
		#region properties

		/// <summary>
		/// Código identificador único de la línea.
		/// </summary>
		public Int32? IdLinea { get; set; }

		/// <summary>
		/// Nombre o número de línea.
		/// </summary>
		public String Nombre { get; set; }
        
        /// <summary>
        /// Indica si el estado es el final del flujo.
        /// </summary>
        public Boolean? Final { get; set; }
		 #endregion // properties
	} // end class
} // end namespace
