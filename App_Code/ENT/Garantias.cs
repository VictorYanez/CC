/*
============================================================================================
tbl_Garantias		Tabla que almacena las garantías de los contratos.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 13 de julio de 2021 11:27:35
============================================================================================
*/
using System;
using System.Web;
using System.Runtime.Serialization;

namespace ENT
{
	public class Garantias
	{
		#region properties

		/// <summary>
		/// Identificador único de la garantia. 
		/// </summary>
		public Int32? IdGarantia { get; set; }

		/// <summary>
		/// Número de garantía o número de serie de cheque de la garantía.
		/// </summary>
		public String Numero { get; set; }

		/// <summary>
		/// Monto o valor de la garantía.
		/// </summary>
		public Decimal? Monto { get; set; }

		/// <summary>
		/// Fecha de emisión de la garantía.
		/// </summary>
		public DateTime? FechaEmision { get; set; }

		/// <summary>
		/// Fecha de inicio de vigencia de la garantia.
		/// </summary>
		public DateTime? FechaVigenciaInicial { get; set; }

		/// <summary>
		/// Fecha de finalizción de vigencia de la garantia.
		/// </summary>
		public DateTime? FechaVigenciaFinal { get; set; }

		/// <summary>
		/// Código identificador del emisor de la garantía.
		/// </summary>
		public Emisores IdEmisor { get; set; }

		/// <summary>
		/// Código identicador de la forma de la garantía.
		/// </summary>
		public FormasGarantias IdForma { get; set; }

		/// <summary>
		/// Código identicador del estado actual de la garantía. Se actualiza a través de un disparador.
		/// </summary>
		public Estados IdEstadoActual { get; set; }

		/// <summary>
		/// Código identificador de contrato al que pertence la garantía.
		/// </summary>
		public Contratos IdContrato { get; set; }

        /// <summary>
        /// Comentarios adicionales a la garantía.
        /// </summary>
        public String Comentario { get; set; }

        /// <summary>
        /// Indica si la garantía posee documentación pendiente de presentar.
        /// </summary>
        public Boolean? DocumentacionPendiente { get; set; }

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

        /// <summary>
        /// Cantidad de dias que restan entre la fecha actual y la fecha de vencimiento de la garantia
        /// Esta propiedad no existe en la base de datos, es un campo calculado en el SELECT
        /// </summary>
        public Int32? DiasAlertas { get; set; }

        /// <summary>
        /// Indica si el estado es el final del flujo. Utilizada directamente en garantías
        /// </summary>
        public Boolean? Final { get; set; }

        /// <summary>
        /// Obtiene los dias configurados en los parámetros generales de vencimiento  de garantia.
        /// </summary>
        public Int32? DiasParametroVencimiento { get; set; }

		 #endregion // properties
	} // end class
} // end namespace
