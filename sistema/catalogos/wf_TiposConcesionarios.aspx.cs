/*
============================================================================================
tbl_TiposConcesionarios:	Tabla que almacena los diferentes tipos de concesionarios.
Creada por:	VMT\marvin.ruiz
Fecha generación:	jueves, 01 de julio de 2021 10:25:12
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

public partial class wf_Tiposconcesionarios : System.Web.UI.Page
{

	BllTiposConcesionarios bllTiposConcesionarios = new BllTiposConcesionarios();
	int registros_por_pagina = 0;

	#region "CARGA DEL FORMULARIO"
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{

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
			this.nb_IdTipoConcesionario.Enabled = false;
		}
		protected void Editar(object sender, EventArgs e){
			this.Cargar_Registro();
			this.Habilitar_Edicion(true);
			this.lbl_Accion.Text = "Actualizar registro:";
			this.nb_IdTipoConcesionario.Enabled = false;
		}
		protected void Eliminar(object sender, EventArgs e){
			this.Eliminar_Registro();
			this.Habilitar_Edicion(false);
			this.Limpiar_Campos();
			this.Cargar_Datos();
		}
		protected void Guardar(object sender, EventArgs e){
			this.Guardar_Registro();
			this.Habilitar_Edicion(false);
			this.Limpiar_Campos();
			this.Cargar_Datos();
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
		this.nb_IdTipoConcesionario.Text = String.Empty;
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
		this.wuc_mantto.MostrarBuscar = false;
		
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

			this.nb_IdTipoConcesionario.Text = this.gv_Datos.SelectedDataKey["IdTipoConcesionario"].ToString();
		}
	}
	#endregion //"GESTION DEL COMPORTAMIENTO DE LA GRID"

	#region "GESTION DEL ACCESO A DATOS"

	//Métodos para cargar lista de selección.
	protected void Cargar_Datos()
	{
		TiposConcesionarios tiposconcesionarios = new TiposConcesionarios();

	    List<TiposConcesionarios> lstTiposConcesionarios = bllTiposConcesionarios.buscar(tiposconcesionarios).ToList();
		this.gv_Datos.DataSource = lstTiposConcesionarios;
		this.gv_Datos.DataBind();

		int cantidad_registros = lstTiposConcesionarios.Count;
		lbl_ContadorRegistros.Text = new Utilidades().ContadorRegistrosGrid(cantidad_registros, registros_por_pagina, gv_Datos);
	}
	protected void Cargar_Registro()
{
		TiposConcesionarios tiposconcesionarios = new TiposConcesionarios();

		tiposconcesionarios.IdTipoConcesionario = Convert.ToInt32(nb_IdTipoConcesionario.Text);

		tiposconcesionarios = bllTiposConcesionarios.buscar(tiposconcesionarios)[0];

		this.txt_Nombre.Text = tiposconcesionarios.Nombre.ToString();
	}
	protected void Guardar_Registro()
{
		TiposConcesionarios tiposconcesionarios = new TiposConcesionarios();

		tiposconcesionarios.Nombre = Convert.ToString(txt_Nombre.Text);

		int r;
		if (this.wuc_mantto.Accion == "I"){
			r = bllTiposConcesionarios.insertar(tiposconcesionarios);
		}
		else{
			tiposconcesionarios.IdTipoConcesionario = Convert.ToInt32(nb_IdTipoConcesionario.Text);
			r = bllTiposConcesionarios.actualizar(tiposconcesionarios);
		}
	}
	protected void Eliminar_Registro(){
		TiposConcesionarios tiposconcesionarios = new TiposConcesionarios();

		tiposconcesionarios.IdTipoConcesionario = Convert.ToInt32(nb_IdTipoConcesionario.Text);
		int r = bllTiposConcesionarios.eliminar(tiposconcesionarios);
	}
	#endregion //"GESTION DEL ACCESO A DATOS"

} // Fin Clase
