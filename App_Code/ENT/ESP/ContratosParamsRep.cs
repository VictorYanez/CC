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
    public class ContratosParamsRep
	{
		#region properties

	
		public Int32? IdContrato { get; set; }
        
		public String Numero { get; set; }

        public Boolean? RegistrosPorVencer { get; set; }

        public Boolean? RegistrosVencidos { get; set; }

        public Int32? IdConcesionario { get; set; }

        public Boolean? ContratoFinalizado { get; set; }

        public String UsuarioConsulta { get; set; }

        public String IdsContratos { get; set; }

        public String IdsConcesionarios { get; set; }

        public String IdsFlujoGarantias { get; set; }

        public Boolean? RegistrosDocPendiente{ get; set; }

        public String NumeroGarantia { get; set; }

        public DateTime? FechaIngresoInicio { get; set; }

        public DateTime? FechaIngresoFin { get; set; }
		 #endregion // properties
	} // end class
} // end namespace
