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
        /// Método que verifica si una línea ya existe con el mismo nombre.
        /// </summary>
        /// <param name="IdLinea">Nombre de línea</param>
        /// <returns>Verdadero o Falso</returns>
        public bool ExisteLinea(string IdLinea)
        {
            return parLineas.ExisteLinea(IdLinea);
        }

        /// <summary>
        /// Obtine la lista de líneas sin asignar a un contrato.
        /// </summary>
        /// <returns></returns>
        public List<Lineas> LineasSinAsignar()
        {
            return parLineas.LineasSinAsignar();
        }

        /// <summary>
        /// Método que devuelve la lista de líneas con información relacionada.
        /// </summary>
        /// <param name="nombreLinea">Parámetro para filtrar por nombre de la línea.</param>
        /// <param name="numeroContrato">Parámetro para filtrar por el número de contrato.</param>
        /// <param name="nombreConcesionario">Parámetro para filtrar por el nombre del concesionario.</param>
        /// <returns>DataTable</returns>
        public DataTable ListaLineas(string nombreLinea, string numeroContrato, string nombreConcesionario)
        {
            return parLineas.ListaLineas(nombreLinea, numeroContrato, nombreConcesionario);
        }
	} // end class
} // end namespace
