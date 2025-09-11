/*
============================================================================================
tbl_AsignacionesLineas		Tabla que almacena la asignaciones de líneas, concesionario y contratos.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 13 de julio de 2021 11:27:55
============================================================================================
*/
using System;
using System.Web;
using System.Runtime.Serialization;

namespace ENT
{
	public class AsignacionesLineas
	{
		#region properties

		/// <summary>
		/// Código identificador único de la asignación de línea.
		/// </summary>
		public Int32? IdAsignacionLinea { get; set; }

		/// <summary>
		/// Código de línea.
		/// </summary>
		public Lineas IdLinea { get; set; }

		/// <summary>
		/// Código de concesionario.
		/// </summary>
		public Concesionarios IdConcesionario { get; set; }

		/// <summary>
		/// Indica la asignación activa de la línea. 
		/// </summary>
		public Boolean? Activo { get; set; }

		/// <summary>
		/// Código identificador de contrato al que pertence la garantía.
		/// </summary>
		public Contratos IdContrato { get; set; }

		/// <summary>
		/// Verdadero indica que ha sido eliminado el registro visualmente al usuario.
		/// </summary>
        public Boolean? Anulado { get; set; }

		/// <summary>
		/// Fecha de ingreso del registro.
		/// </summary>
		public DateTime? FechaIngreso { get; set; }

		/// <summary>
		/// Usuario que ingresó el registro.
		/// </summary>
		public String UsuarioIngreso { get; set; }

		/// <summary>
		/// Dirección IP del equipo del usuario que ingreso del registro.
		/// </summary>
		public String IpEquipoUsuarioIngreso { get; set; }

		/// <summary>
		/// Ultima fecha de actualización del registro.
		/// </summary>
		public DateTime? FechaActualizacion { get; set; }

		/// <summary>
		/// Usuario que realiza la última actualización.
		/// </summary>
		public String UsuarioActualizacion { get; set; }

		/// <summary>
		/// Dirección IP del equipo del último usuario que actualizó el registro.
		/// </summary>
		public String IpEquipoActualizacion { get; set; }

		 #endregion // properties
	} // end class
} // end namespace
