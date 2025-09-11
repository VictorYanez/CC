/*
============================================================================================
tbl_ParametrosConfiguracion		
Autor:		VMT\marvin.ruiz
Fecha:		miércoles, 21 de julio de 2021 18:20:28
============================================================================================
*/
using System;
using System.Web;
using System.Runtime.Serialization;

namespace ENT
{
	public class ParametrosConfiguracion
	{
		#region properties

		/// <summary>
		/// 
		/// </summary>
		public String IdParametro { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public String Nombre { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public Int32? ValorNumerico { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public String ValorCadena { get; set; }

		 #endregion // properties
	} // end class
} // end namespace
