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
        /// Método que obtiene la cantidad de garantías que posee un contrato.
        /// </summary>
        /// <param name="IdContrato">Código de contrato</param>
        /// <returns>Cantidad de garantias</returns>
        public int CantidadGarantiasContrato(int IdContrato)
        {
            return parContratos.CantidadGarantiasContrato(IdContrato);
        }

        /// <summary>
        /// Método que obtiene la cantidad de líneas asignadas al contrato.
        /// </summary>
        /// <param name="IdContrato">Código de contrato</param>
        /// <returns>Cantidad de lineas</returns>
        public int CantidadLineasContrato(int IdContrato, bool activo)
        {
            return parContratos.CantidadLineasContrato(IdContrato, activo);
        }

        /// <summary>
        /// Método que obtien la listas de contrato por vencer o vencidos
        /// </summary>
        ///  <param name="numero">Número de contrato.</param>
        ///   <param name="idConcesionario">Código único de concesionario.</param>
        /// <param name="porVencer">Verdadero indica que obtiene contratos por vencer.</param>
        /// <param name="vencidos">Verdaro indica que obtiene contratos vencidos.</param>
        /// <returns>Lista de contratos en DataTable</returns>
        public DataTable ConsultaContratos(string numero, int idConcesionario, bool? porVencer = null, bool? vencidos = null)
        {
            return parContratos.ConsultaContratos(numero, idConcesionario,porVencer, vencidos);
        }

        /// <summary>
        /// Método que obtiene la próxima modificación de un contrato
        /// </summary>
        /// <param name="Numero">Número de contrato</param>
        /// <returns>Próximo número de modificación</returns>
        public int ObtenerNumeroProximaModificacion(string Numero)
        {
            return parContratos.ObtenerNumeroProximaModificacion(Numero);
        }

        /// <summary>
        /// Método que obtiene los estados de alerta de los contratos.
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
