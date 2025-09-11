/*
============================================================================================
tbl_FlujosGarantias		Tabla que almacena el historial de estados de la garantía.
Autor:		VMT\marvin.ruiz
Fecha:		miércoles, 30 de junio de 2021 9:52:21
============================================================================================
*/
using System;
using System.Web;
using System.Runtime.Serialization;

namespace ENT
{
    public class FlujosGarantias
    {
        #region properties

        /// <summary>
        /// Código único identificador del historial de estados de la garantía.
        /// </summary>
        public Int32? IdFlujoGarantia { get; set; }

        /// <summary>
        /// Código de la garantia.
        /// </summary>
        public Garantias IdGarantia { get; set; }

        /// <summary>
        /// Código de estado de la garantia.
        /// </summary>
        public Estados IdEstado { get; set; }

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
