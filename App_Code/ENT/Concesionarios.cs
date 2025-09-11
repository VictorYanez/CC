/*
============================================================================================
tbl_Concesionarios		Tabla que almacena la información relevante de los concesionarios.
Autor:		VMT\marvin.ruiz
Fecha:		miércoles, 30 de junio de 2021 10:20:07
============================================================================================
*/
using System;
using System.Web;
using System.Runtime.Serialization;

namespace ENT
{
    public class Concesionarios
    {
        #region properties

        /// <summary>
        /// Código identicador único del concesionario.
        /// </summary>
        public Int32? IdConcesionario { get; set; }

        /// <summary>
        /// Nombre del concesionario.
        /// </summary>
        public String Nombre { get; set; }

        /// <summary>
        /// Abreviatura o nombre comercial de concesionario.
        /// </summary>
        public String Abreviatura { get; set; }

        /// <summary>
        /// NIT vinculado al concesionario.
        /// </summary>
        public String Nit { get; set; }

        /// <summary>
        /// Código de tipo de concesionario.
        /// </summary>
        public TiposConcesionarios IdTipoConcesionario { get; set; }

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
