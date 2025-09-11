/*
============================================================================================
tbl_Contratos		Tabla que almacena los contratos de los concesionarios.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 13 de julio de 2021 11:26:23
============================================================================================
*/
using System;
using System.Web;
using System.Runtime.Serialization;

namespace ENT
{
	public class Contratos
	{
		#region properties

		/// <summary>
		/// Código identificador único del contrato.
		/// </summary>
		public Int32? IdContrato { get; set; }

		/// <summary>
		/// Número de contrato con el cual realizan los procesos jurídicos.
		/// </summary>
		public String Numero { get; set; }

		/// <summary>
		/// Fecha de inicio del contrato.
		/// </summary>
		public DateTime? FechaVigenciaInicial { get; set; }

		/// <summary>
		/// Fecha fin del contrato.
		/// </summary>
		public DateTime? FechaVigenciaFinal { get; set; }

		/// <summary>
		/// Código identificador de contrato padre del que depende un contrato.
		/// </summary>
		public Contratos IdContratoDepende { get; set; }

        /// <summary>
        /// Código de concesionario asociado al contrato.
        /// </summary>
        public Concesionarios IdConcesionario { get; set; }

        /// <summary>
        /// Comentarios adicionales a al contrato.
        /// </summary>
        public String Comentario { get; set; }


        /// <summary>
        /// Número de resolución asociado a la modificativa.
        /// </summary>
        public String Resolucion { get; set; }

        /// <summary>
        /// Número de modificación de un contrato.
        /// </summary>
        public Int32? Modificativa { get; set; }
		/// <summary>
		/// Verdadero indica que ha sido eliminado el registro visualmente al usuario.
		/// </summary>
		public Boolean? Anulado { get; set; }

        /// <summary>
        /// Valor que indica si el contrato ha sido finalizado. True es finalizado, False está activo.
        /// </summary>
        public Boolean? Finalizado { get; set; }

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
        /// Propiedad definida a nivel de consulta desde la fuente de datos. Obtiene número del contrato dependiente.
        /// </summary>
        public String NumeroContratoDependiente { get; set; }
        
        /// <summary>
        /// Propiedad definida a nivel de consulta desde la fuente de datos. Obtiene el número de días entre la
        /// fecha actual y la fecha de finalización del contrato.
        /// </summary>
        public Int32? DiasAlertas { get; set; }

        /// <summary>
        /// Propiedad definida a nivel de consulta desde la fuente de datos. Obtiene solo el id de concesionario y no el objeto Concesionario
        /// </summary>
        public Int32? CodigoConcesionario { get; set; }

        /// <summary>
        /// Obtiene los dias configurados en los parámetros generales de vencimiento  de contrato.
        /// </summary>
        public Int32? DiasParametroVencimiento { get; set; }
        
        /// <summary>
        /// Propiedad usada para buscar por campos compuestos a nivel de base de datos. Busca por resolución y comentario.
        /// </summary>
        public String PalabraClave { get; set; }

        
		 #endregion // properties
	} // end class
} // end namespace
