/*
============================================================================================
tbl_Concesionarios		Tabla que almacena la información relevante de los concesionarios.
Autor:		VMT\marvin.ruiz
Fecha:		martes, 29 de junio de 2021 15:34:33
============================================================================================
*/
using System;
using System.Collections.Generic;
using ENT;
using DAL;
using Especiales.DAL;
namespace BLL
{
	public class BllConcesionarios
	{
		DalConcesionarios dalConcesionarios;
        ParConcesionarios parConcesionarios;

		public BllConcesionarios()
		{
			dalConcesionarios = new DalConcesionarios();
            parConcesionarios = new ParConcesionarios();
		}
		public int insertar(Concesionarios concesionarios)
		{
			return dalConcesionarios.insertar(concesionarios);
		}
		public int actualizar(Concesionarios concesionarios)
		{
			return dalConcesionarios.actualizar(concesionarios);
		}
		public int eliminar(Concesionarios concesionarios)
		{
			return dalConcesionarios.eliminar(concesionarios);
		}
		public List<Concesionarios> buscar(Concesionarios concesionarios, string _ordenarPor = null, int? _mostrarN = null)
		{
			return dalConcesionarios.buscar(concesionarios, _ordenarPor, _mostrarN);
		}

        /// <summary>
        /// Método que obtiene la cantidad de contactos que posee un concesionario.
        /// </summary>
        /// <param name="IdConcesionario">Código de concesionario</param>
        /// <returns>Cantidad de contactos</returns>
        public int CantidadContactosConcesionario(int IdConcesionario)
        {
            return parConcesionarios.CantidadContactosConcesionario(IdConcesionario);
        }
	} // end class
} // end namespace
