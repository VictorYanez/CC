/*
============================================================================================
tbl_Contratos		Tabla que almacena los contratos de los concesionarios.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 13 de julio de 2021 11:26:23
============================================================================================
*/
using System;
using System.Collections.Generic;
using ENT;
using DAL;
using Especiales.DAL;
using System.Data;
namespace BLL
{
	public class BllContratos
	{
		DalContratos dalContratos;
        ParContratos parContratos;
        ParReportes parReportes;
		public BllContratos()
		{
			dalContratos = new DalContratos();
            parContratos = new ParContratos();
            parReportes = new ParReportes();
		}
		public int insertar(Contratos contratos)
		{
			return dalContratos.insertar(contratos);
		}
		public int actualizar(Contratos contratos)
		{
			return dalContratos.actualizar(contratos);
		}
		public int eliminar(Contratos contratos)
		{
			return dalContratos.eliminar(contratos);
		}
		public List<Contratos> buscar(Contratos contratos, string _ordenarPor = null, int? _mostrarN = null)
		{
			return dalContratos.buscar(contratos, _ordenarPor, _mostrarN);
		}

        /// <summary>
        /// M�todo que obtiene la cantidad de garant�as que posee un contrato.
        /// </summary>
        /// <param name="IdContrato">C�digo de contrato</param>
        /// <returns>Cantidad de garantias</returns>
        public int CantidadGarantiasContrato(int IdContrato)
        {
            return parContratos.CantidadGarantiasContrato(IdContrato);
        }

        /// <summary>
        /// M�todo que obtiene la cantidad de l�neas asignadas al contrato.
        /// </summary>
        /// <param name="IdContrato">C�digo de contrato</param>
        /// <returns>Cantidad de lineas</returns>
        public int CantidadLineasContrato(int IdContrato, bool activo)
        {
            return parContratos.CantidadLineasContrato(IdContrato, activo);
        }

        /// <summary>
        /// M�todo que obtien la listas de contrato por vencer o vencidos
        /// </summary>
        ///  <param name="numero">N�mero de contrato.</param>
        ///   <param name="idConcesionario">C�digo �nico de concesionario.</param>
        /// <param name="porVencer">Verdadero indica que obtiene contratos por vencer.</param>
        /// <param name="vencidos">Verdaro indica que obtiene contratos vencidos.</param>
        /// <returns>Lista de contratos en DataTable</returns>
        public DataTable ConsultaContratos(string numero, int idConcesionario, bool? porVencer = null, bool? vencidos = null)
        {
            return parContratos.ConsultaContratos(numero, idConcesionario,porVencer, vencidos);
        }

        /// <summary>
        /// M�todo que obtiene la pr�xima modificaci�n de un contrato
        /// </summary>
        /// <param name="Numero">N�mero de contrato</param>
        /// <returns>Pr�ximo n�mero de modificaci�n</returns>
        public int ObtenerNumeroProximaModificacion(string Numero)
        {
            return parContratos.ObtenerNumeroProximaModificacion(Numero);
        }

        /// <summary>
        /// M�todo que obtiene los estados de alerta de los contratos.
        /// </summary>
        /// <returns></returns>
        public DataTable EstadosAlertas()
        {
            return parContratos.EstadosAlertas();
        }

        public DataTable ReporteContratos(ContratosParamsRep param, string accion = "Contratos")
        {
            return parReportes.ReporteContratos(param, accion);
        }

        public DataTable ContratosCodigoNombre()
        {
            return parContratos.ContratosCodigoNombre();
        }

        public DataTable ReporteGarantias(ContratosParamsRep param)
        {
            return parReportes.ReporteGarantias(param);
        }


	} // end class
} // end namespace
