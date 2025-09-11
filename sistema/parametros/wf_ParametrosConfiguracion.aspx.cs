/*
============================================================================================
tbl_ParametrosConfiguracion:	
Creada por:	VMT\marvin.ruiz
Fecha generación:	miércoles, 21 de julio de 2021 18:20:36
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

public partial class wf_Parametrosconfiguracion : System.Web.UI.Page
{

	BllParametrosConfiguracion bllParametrosConfiguracion = new BllParametrosConfiguracion();
	

	#region "CARGA DEL FORMULARIO"
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{

			this.HabilitarEdicion(false);
			this.LimpiarCampos();
			this.CargarDatos();
		}
	}
	#endregion //"CARGA DEL FORMULARIO"

	#region "EVENTOS DE LOS BOTONES"

		
		protected void Editar(object sender, EventArgs e){
			this.CargarRegistro();
			this.HabilitarEdicion(true);
			this.lbl_Accion.Text = "Actualizar registro:";
            this.txt_IdParametro.Enabled = false;
		}
		
		protected void Guardar(object sender, EventArgs e){
			this.GuardarRegistro();
			this.HabilitarEdicion(false);
			this.LimpiarCampos();
			this.CargarDatos();
			this.wuc_mantto.MostrarBuscar = false;
		}
		protected void Cancelar(object sender, EventArgs e){
			this.HabilitarEdicion(false);
			this.LimpiarCampos();
			this.CargarDatos();
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
			this.CargarDatos();
		}
	#endregion //"EVENTOS DE LOS BOTONES"

	#region "GESTION DEL COMPORTAMIENTO DE EDICION"

	protected void LimpiarCampos(){
		this.txt_IdParametro.Text = String.Empty;
		this.txt_Nombre.Text = String.Empty;
		this.nb_ValorNumerico.Text = String.Empty;
		this.txt_ValorCadena.Text = String.Empty;
		}
	protected void HabilitarEdicion(bool opcion){

		this.pnl_campos.Enabled = opcion;
		this.gv_Datos.Enabled = !opcion;

		this.wuc_mantto.Limpiar_Filtro();

		this.wuc_mantto.MostrarGuardar = opcion;
		this.wuc_mantto.MostrarCancelar = opcion;

		this.wuc_mantto.MostrarEditar = false;
        this.wuc_mantto.MostrarNuevo = false;
        this.wuc_mantto.MostrarBuscar = false;
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
			
		}
	}
	
	protected void gv_Datos_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.gv_Datos.SelectedIndex >= 0){
			this.wuc_mantto.MostrarEditar = true;
			
            this.txt_IdParametro.Text = this.gv_Datos.SelectedDataKey["IdParametro"].ToString();
		}
	}
	#endregion //"GESTION DEL COMPORTAMIENTO DE LA GRID"

	#region "GESTION DEL ACCESO A DATOS"

	//Métodos para cargar lista de selección.
	protected void CargarDatos()
	{
		ParametrosConfiguracion parametrosconfiguracion = new ParametrosConfiguracion();

		List<ParametrosConfiguracion> lstParametrosConfiguracion = bllParametrosConfiguracion.buscar(parametrosconfiguracion).ToList();
		this.gv_Datos.DataSource = lstParametrosConfiguracion;
		this.gv_Datos.DataBind();

	}
	protected void CargarRegistro()
{
		ParametrosConfiguracion parametrosconfiguracion = new ParametrosConfiguracion();

        parametrosconfiguracion.IdParametro = Convert.ToString(txt_IdParametro.Text);

		parametrosconfiguracion = bllParametrosConfiguracion.buscar(parametrosconfiguracion)[0];

		this.txt_Nombre.Text = parametrosconfiguracion.Nombre.ToString();
		this.nb_ValorNumerico.Text = parametrosconfiguracion.ValorNumerico.ToString();
		this.txt_ValorCadena.Text = parametrosconfiguracion.ValorCadena.ToString();
	}
	protected void GuardarRegistro()
{
		ParametrosConfiguracion parametrosconfiguracion = new ParametrosConfiguracion();

		parametrosconfiguracion.IdParametro = Convert.ToString(txt_IdParametro.Text);
		parametrosconfiguracion.Nombre = Convert.ToString(txt_Nombre.Text);
		parametrosconfiguracion.ValorNumerico = Convert.ToInt32(nb_ValorNumerico.Text);
		parametrosconfiguracion.ValorCadena = Convert.ToString(txt_ValorCadena.Text);

		int r;
		if (this.wuc_mantto.Accion == "I"){
			r = bllParametrosConfiguracion.insertar(parametrosconfiguracion);
		}
		else{
            parametrosconfiguracion.IdParametro = Convert.ToString(txt_IdParametro.Text);
			r = bllParametrosConfiguracion.actualizar(parametrosconfiguracion);
		}
	}
	
	#endregion //"GESTION DEL ACCESO A DATOS"

} // Fin Clase
