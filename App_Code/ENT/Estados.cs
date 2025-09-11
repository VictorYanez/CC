/*
============================================================================================
tbl_Estados		Tabla que almacena los diferentes estados del proceso de las garantías.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 29 de junio de 2021 15:35:24
============================================================================================
*/
using System;
using System.Web;
using System.Runtime.Serialization;

namespace ENT
{
	public class Estados
	{
		#region properties

		/// <summary>
		/// Código único identificador del estado de la garantía.
		/// </summary>
		public Int32? IdEstado { get; set; }

		/// <summary>
		/// Nombre del estado.
		/// </summary>
		public String Nombre { get; set; }

        /// <summary>
        /// Indica el orden de secuencia de los estados.
        /// </summary>
        public Int32? Orden { get; set; }

        /// <summary>
        /// Indica si el estado es el final del flujo.
        /// </summary>
        public Boolean? Final { get; set; }

		 #endregion // properties
	} // end class
} // end namespace
