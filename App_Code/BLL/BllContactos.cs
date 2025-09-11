/*
============================================================================================
tbl_Contactos		Tabla que almacena los contactos de los concesionarios.
Autor:		VMT\marvin.ruiz
Fecha:		jueves, 08 de julio de 2021 15:30:38
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
    public class BllContactos
    {
        DalContactos dalContactos;
        ParContactos parContactos;

        public BllContactos()
        {
            dalContactos = new DalContactos();
            parContactos = new ParContactos();
        }
        public int insertar(Contactos contactos)
        {
            return dalContactos.insertar(contactos);
        }
        public int actualizar(Contactos contactos)
        {
            return dalContactos.actualizar(contactos);
        }
        public int eliminar(Contactos contactos)
        {
            return dalContactos.eliminar(contactos);
        }
        public List<Contactos> buscar(Contactos contactos, string _ordenarPor = null, int? _mostrarN = null)
        {
            return dalContactos.buscar(contactos, _ordenarPor, _mostrarN);
        }

        /// <summary>
        /// Método que obtiene los contactos con información relacionada.
        /// </summary>
        /// <param name="idGarantia">Parámetro de IdGarantia</param>
        /// <param name="idContrato">Parámetro de IdContrato</param>
        /// <returns>DataTable</returns>
        public DataTable ListaContactosConsulta(int idGarantia, int idContrato)
        {
            return parContactos.ListaContactosConsulta(idGarantia,idContrato);
        }
    } // end class
} // end namespace
