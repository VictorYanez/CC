/*
============================================================================================
tbl_Lineas		Tabla que almacena las lineas emitidas para concesiones.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 29 de junio de 2021 15:31:05
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
	public class BllLineas
	{
		DalLineas dalLineas;
        ParLineas parLineas;
		public BllLineas()
		{
			dalLineas = new DalLineas();
            parLineas = new ParLineas();
            
		}
		public int insertar(Lineas lineas)
		{
			return dalLineas.insertar(lineas);
		}
		public int actualizar(Lineas lineas)
		{
			return dalLineas.actualizar(lineas);
		}
		public int eliminar(Lineas lineas)
		{
			return dalLineas.eliminar(lineas);
		}
		public List<Lineas> buscar(Lineas lineas, string _ordenarPor = null, int? _mostrarN = null)
		{
			return dalLineas.buscar(lineas, _ordenarPor, _mostrarN);
		}
        /// <summary>
        /// M�todo que verifica si una l�nea ya existe con el mismo nombre.
        /// </summary>
        /// <param name="IdLinea">Nombre de l�nea</param>
        /// <returns>Verdadero o Falso</returns>
        public bool ExisteLinea(string IdLinea)
        {
            return parLineas.ExisteLinea(IdLinea);
        }

        /// <summary>
        /// Obtine la lista de l�neas sin asignar a un contrato.
        /// </summary>
        /// <returns></returns>
        public List<Lineas> LineasSinAsignar()
        {
            return parLineas.LineasSinAsignar();
        }

        /// <summary>
        /// M�todo que devuelve la lista de l�neas con informaci�n relacionada.
        /// </summary>
        /// <param name="nombreLinea">Par�metro para filtrar por nombre de la l�nea.</param>
        /// <param name="numeroContrato">Par�metro para filtrar por el n�mero de contrato.</param>
        /// <param name="nombreConcesionario">Par�metro para filtrar por el nombre del concesionario.</param>
        /// <returns>DataTable</returns>
        public DataTable ListaLineas(string nombreLinea, string numeroContrato, string nombreConcesionario)
        {
            return parLineas.ListaLineas(nombreLinea, numeroContrato, nombreConcesionario);
        }
	} // end class
} // end namespace
