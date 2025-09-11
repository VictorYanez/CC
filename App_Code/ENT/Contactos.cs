/*
============================================================================================
tbl_Contactos		Tabla que almacena los contactos de los concesionarios.
Autor:		VMT\marvin.ruiz
Fecha:		jueves, 08 de julio de 2021 15:30:38
============================================================================================
*/
using System;
using System.Web;
using System.Runtime.Serialization;

namespace ENT
{
    public class Contactos
    {
        #region properties

        /// <summary>
        /// Código identificador único del contacto.
        /// </summary>
        public Int32? IdContacto { get; set; }

        /// <summary>
        /// Nombres del contacto.
        /// </summary>
        public String Nombres { get; set; }

        /// <summary>
        /// Apellidos del contacto.
        /// </summary>
        public String Apellidos { get; set; }

        /// <summary>
        /// NIT del contacto.
        /// </summary>
        public String Nit { get; set; }

        /// <summary>
        /// Teléfono de oficina.
        /// </summary>
        public String TelefonoOficina { get; set; }

        /// <summary>
        /// Número de celular.
        /// </summary>
        public String NumeroCelular { get; set; }

        /// <summary>
        /// Correo electrónico del contacto.
        /// </summary>
        public String CorreoElectronico { get; set; }

        /// <summary>
        /// Código del tipo de contacto.
        /// </summary>
        public TiposContactos IdTipoContacto { get; set; }

        /// <summary>
        /// Código del concesionario asociado al contacto.
        /// </summary>
        public Concesionarios IdConcesionario { get; set; }

        /// <summary>
        /// Comentarios adiconales acerca del contacto.
        /// </summary>
        public String Comentarios { get; set; }

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
