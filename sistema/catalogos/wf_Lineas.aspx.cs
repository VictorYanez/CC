/*
============================================================================================
tbl_Lineas:	Tabla que almacena las lineas emitidas para concesiones.
Creada por:	VMT\marvin.ruiz
Fecha generación:	jueves, 01 de julio de 2021 10:26:33
============================================================================================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENT;
using BLL;
using System.Data;

public partial class wf_Lineas : System.Web.UI.Page
{

	BllLineas bllLineas = new BllLineas();
	int registros_por_pagina = 0;

	#region "CARGA DEL FORMULARIO"
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
            this.wuc_mantto.Filtro_Criterio.Items.Add("LINEA");
            this.wuc_mantto.Filtro_Criterio.Items.Add("CONTRATO");
            this.wuc_mantto.Filtro_Criterio.Items.Add("CONCESIONARIO");
			this.Habilitar_Edicion(false);
			this.Limpiar_Campos();
			this.Cargar_Datos();
		}
	}
	#endregion //"CARGA DEL FORMULARIO"

	#region "EVENTOS DE LOS BOTONES"

		protected void Nuevo(object sender, EventArgs e){
			this.Habilitar_Edicion(true);
			this.Limpiar_Campos();
			this.lbl_Accion.Text = "Insertar registro:";
			this.nb_IdLinea.Enabled = false;
		}
		protected void Editar(object sender, EventArgs e){
			this.Cargar_Registro();
			this.Habilitar_Edicion(true);
			this.lbl_Accion.Text = "Actualizar registro:";
			this.nb_IdLinea.Enabled = false;
		}
		protected void Eliminar(object sender, EventArgs e){
			this.Eliminar_Registro();
			this.Habilitar_Edicion(false);
			this.Limpiar_Campos();
			this.Cargar_Datos();
		}
		protected void Guardar(object sender, EventArgs e){
			var r = this.Guardar_Registro();
            if (r > 0)
            {
                this.Habilitar_Edicion(false);
                this.Limpiar_Campos();
                this.Cargar_Datos();
                this.wuc_mantto.MostrarBuscar = true;
            }
            else {
                this.Habilitar_Edicion(true);
            }
			
		}
		protected void Cancelar(object sender, EventArgs e){
			this.Habilitar_Edicion(false);
			this.Limpiar_Campos();
			this.Cargar_Datos();
		}
		protected void Imprimir(object sender, EventArgs e){
		/*
			this.Master.Reporte.Titulo = "Modulo";
			this.Master.Reporte.ID_Reporte = "rpt_modulo";
			this.Master.Reporte.SQL_Principal = "pa_br_Modulo @_accion='buscar'";
			//this.Master.Reporte.SQL_SubReportes = new string[] { "sql uno", "sql dos", "sql n" };
			this.Master.Reporte.TamanoPapel = CrystalDecisions.Shared.PaperSize.PaperLetter;
			this.Master.Reporte.Orientacion = CrystalDecisions.Shared.PaperOrientation.Portrait;
			this.Master.Reporte.Mostar(true);
		*/
		}
		protected void AplicarFiltro(object sender, EventArgs e){
			this.wuc_mantto.MostrarImprimir = false;
			this.Cargar_Datos();
		}
	#endregion //"EVENTOS DE LOS BOTONES"

	#region "GESTION DEL COMPORTAMIENTO DE EDICION"

	protected void Limpiar_Campos(){
		this.nb_IdLinea.Text = String.Empty;
		this.txt_Nombre.Text = String.Empty;
		}
	protected void Habilitar_Edicion(bool opcion){

		this.pnl_campos.Enabled = opcion;
		this.gv_Datos.Enabled = !opcion;

		this.wuc_mantto.Limpiar_Filtro();

		this.wuc_mantto.MostrarNuevo = !opcion;
		this.wuc_mantto.MostrarGuardar = opcion;
		this.wuc_mantto.MostrarCancelar = opcion;

		this.wuc_mantto.MostrarEditar = false;
		this.wuc_mantto.MostrarEliminar = false;
        this.wuc_mantto.MostrarBuscarPersonalizado = false;

		this.wuc_mantto.MostrarBuscar = !opcion;
        
		//this.wuc_mantto.MostrarImprimir = !opcion;
		this.wuc_mantto.MostrarImprimir = false;

		if (opcion){
			this.pnl_campos.Style["display"] = "block";
			this.div_grilla.Style["display"] = "none";
		}
		else{
			this.pnl_campos.Style["display"] = "none";
			this.div_grilla.Style["display"] = "block";
		}
	}
	#endregion //"GESTION DEL COMPORTAMIENTO DE EDICION"

	#region "GESTION DEL COMPORTAMIENTO DE LA GRID"

	protected void gv_Datos_RowDataBound(object sender, GridViewRowEventArgs e)
{
		if (e.Row.RowType == DataControlRowType.DataRow){
			e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.gv_Datos, "Select$" + e.Row.RowIndex);

            Literal lit_EstadoLinea = (Literal)e.Row.FindControl("lit_EstadoLinea");

            bool disponible = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Disponible"));

            if (disponible)
            {
                lit_EstadoLinea.Text = "<i title=\"L&iacute;nea disponible para asignar\" class=\"ace-icon green fa fa-exclamation-circle bigger-150\"></i>";
            }
            else {
                lit_EstadoLinea.Text = "<i title=\"L&iacute;nea asignada\" class=\"ace-icon red fa fa-exclamation-circle bigger-150\"></i>";
            }
			registros_por_pagina = e.Row.RowIndex + 1;
		}
	}
	protected void gv_Datos_PageIndexChanging(object sender, GridViewPageEventArgs e)
{
		this.gv_Datos.PageIndex = e.NewPageIndex;
		this.Cargar_Datos();
	}
	protected void gv_Datos_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.gv_Datos.SelectedIndex >= 0){
			this.wuc_mantto.MostrarEditar = true;
			this.wuc_mantto.MostrarEliminar = true;

			this.nb_IdLinea.Text = this.gv_Datos.SelectedDataKey["IdLinea"].ToString();
		}
	}
	#endregion //"GESTION DEL COMPORTAMIENTO DE LA GRID"

	#region "GESTION DEL ACCESO A DATOS"

	//Métodos para cargar lista de selección.
	protected void Cargar_Datos()
	{
		Lineas lineas = new Lineas();

        string nombreLinea = "";
        string numeroContrato = "";
        string nombreConcesionario = "";

        if (this.wuc_mantto.Filtro_Criterio.SelectedValue == "LINEA")
        {
            try
            {
                nombreLinea = Convert.ToString(this.wuc_mantto.Filtro_Valor_TXT);
            }
            catch
            {
                nombreLinea = null;
            }
        }

        if (this.wuc_mantto.Filtro_Criterio.SelectedValue == "CONTRATO")
        {
            try
            {
                numeroContrato = Convert.ToString(this.wuc_mantto.Filtro_Valor_TXT);
            }
            catch
            {
                numeroContrato = null;
            }
        }

        if (this.wuc_mantto.Filtro_Criterio.SelectedValue == "CONCESIONARIO")
        {
            try
            {
                nombreConcesionario = Convert.ToString(this.wuc_mantto.Filtro_Valor_TXT);
            }
            catch
            {
                nombreConcesionario = null;
            }
        }


        DataTable dt = bllLineas.ListaLineas(nombreLinea, numeroContrato, nombreConcesionario);
        this.gv_Datos.DataSource = dt;
		this.gv_Datos.DataBind();

        int cantidad_registros = dt.Rows.Count;
		lbl_ContadorRegistros.Text = new Utilidades().ContadorRegistrosGrid(cantidad_registros, registros_por_pagina, gv_Datos);
	}
	protected void Cargar_Registro()
{
		Lineas lineas = new Lineas();

		lineas.IdLinea = Convert.ToInt32(nb_IdLinea.Text);

		lineas = bllLineas.buscar(lineas)[0];

		this.txt_Nombre.Text = lineas.Nombre.ToString();
	}
	protected int Guardar_Registro()
{
		Lineas lineas = new Lineas();
		lineas.Nombre = Convert.ToString(txt_Nombre.Text);

		int r = 0;

        //Validar que no exista una línea con el mismo nombre cuando se ingrese un registro nuevo o se actualice.
        bool respuesta = new BllLineas().ExisteLinea(lineas.Nombre);
        if (respuesta)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Notificación','Ya existe un número de línea con el mismo nombre, verifique.','error', 'Aceptar')", true);
        }
        else {
            if (this.wuc_mantto.Accion == "I")
            {
                r = bllLineas.insertar(lineas);
            }
            else
            {
                lineas.IdLinea = Convert.ToInt32(nb_IdLinea.Text);
                r = bllLineas.actualizar(lineas);
            }
        }
        return r;
	}
	protected void Eliminar_Registro(){
		Lineas lineas = new Lineas();

		lineas.IdLinea = Convert.ToInt32(nb_IdLinea.Text);
		int r = bllLineas.eliminar(lineas);
	}
	#endregion //"GESTION DEL ACCESO A DATOS"

} // Fin Clase
