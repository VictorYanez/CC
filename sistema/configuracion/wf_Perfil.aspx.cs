//ESPACIOS DE NOMBRES A IMPORTAR EN EL FORMULARIO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mop.Seg.BLL.WcfMaestra;
//using ENT;
//using BLL;

/// <summary>
/// Clase para el mantenimiento de la tabla: tbl_Perfil
/// </summary>
public partial class sistema_wf_Perfil : System.Web.UI.Page
{
	//Entidad a la que corresponde el formulario
    WcfMaestraClient bllPerfil = new WcfMaestraClient();

	#region "CARGA DEL FORMULARIO"
	/// <summary>
	/// Evento que ejecuta el formulario cuando se carga en el navegador,
	/// así como también al realizar PostBack's
	/// </summary>
	/// <param name="sender">Objeto que desencadena el evento</param>
	/// <param name="e">Parámetros asociados al evento</param>
	/// <returns>void</returns>
	protected void Page_Load(object sender, EventArgs e)
	{
		//Evaluar si es la carga incial del formulario
		if (!IsPostBack)
		{
			//Definición de los filtros de búsqueda en el formulario
			this.wuc_mantto.Filtro_Criterio.Items.Add(new ListItem("Código", "Id_Perfil"));
			this.wuc_mantto.Filtro_Criterio.Items.Add(new ListItem("Sistema", "Id_Sistema"));
			this.wuc_mantto.Filtro_Criterio.Items.Add(new ListItem("Descripción", "Descripcion"));
			this.wuc_mantto.Filtro_Criterio.Items.Add(new ListItem("Fecha de creación", "Fecha_Creacion"));
			this.wuc_mantto.Filtro_Criterio.Items.Add(new ListItem("Fecha de modificación", "Fecha_Modificacion"));
			this.wuc_mantto.Filtro_Criterio.Items.Add(new ListItem("Tipo de permiso", "Id_Tipo_Permiso"));
			this.wuc_mantto.Filtro_Criterio.Items.Add(new ListItem("Nivel", "Nivel_Perfil"));

			//Limpiando el formulario
			this.Habilitar_Edicion(false);
			this.Limpiar_Campos();

			//Cargando los datos de las entidades
			CargarSistema();

			//Cargando los datos de la tabla
			this.Cargar_Datos();
		}

		//Verificación de los permisos acorde al perfil del usuario
		//if (this.Master.Permiso_Seleccionar)
		//{
			//this.gv_Datos.Visible = true;
		//}
		//else
		//{
			//this.gv_Datos.Visible = false;
		//}
	}
	#endregion //"CARGA DEL FORMULARIO"

	#region "EVENTOS DE LOS BOTONES"
	protected void Nuevo(object sender, EventArgs e)
	{
		this.Habilitar_Edicion(true);
		this.Limpiar_Campos();
		this.lbl__Accion.Text = "Insertar registro:";
		this.txt_Id_Perfil.Enabled = true;
        //this.ddl_Id_Sistema.Enabled = true;

        this.wucPerfilDetalle.IdPerfil = null;
        this.wucPerfilDetalle.Guardar_Datos();
	}
	protected void Editar(object sender, EventArgs e)
	{
		this.Cargar_Registro();
		this.Habilitar_Edicion(true);
		this.lbl__Accion.Text = "Actualizar registro:";
		this.txt_Id_Perfil.Enabled = false;
        //this.ddl_Id_Sistema.Enabled = false;
	}
	protected void Eliminar(object sender, EventArgs e)
	{
		this.Eliminar_Registro();
		this.Habilitar_Edicion(false);
		this.Limpiar_Campos();
		this.Cargar_Datos();
	}
	protected void Guardar(object sender, EventArgs e)
	{
		this.Guardar_Registro();
		this.Habilitar_Edicion(false);
		this.Limpiar_Campos();
		this.Cargar_Datos();
		this.wuc_mantto.MostrarBuscar = false;
	}
	protected void Cancelar(object sender, EventArgs e)
	{
		this.Habilitar_Edicion(false);
		this.Limpiar_Campos();
		this.Cargar_Datos();
	}
	protected void Imprimir(object sender, EventArgs e)
	{
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
	protected void AplicarFiltro(object sender, EventArgs e)
	{
		this.Cargar_Datos();
	}

	#endregion //"EVENTOS DE LOS BOTONES"

	#region "GESTION DEL COMPORTAMIENTO DE EDICION"
	protected void Limpiar_Campos()
	{
		this.txt_Id_Perfil.Text = "";
        //this.ddl_Id_Sistema.SelectedIndex = 0;
		this.txt_Descripcion.Text = "";
		this.cal_Fecha_Creacion.Text = "";
		this.cal_Fecha_Modificacion.Text = "";
        //this.nbx_Id_Tipo_Permiso.Text = "";
		this.nbx_Nivel_Perfil.Text = "0";
	}
	protected void Habilitar_Edicion(bool opcion)
	{
		this.pnl_campos.Enabled = opcion;
		this.gv_Datos.Enabled = !opcion;

		this.wuc_mantto.Limpiar_Filtro();

		this.wuc_mantto.MostrarNuevo = !opcion;
		this.wuc_mantto.MostrarGuardar = opcion;
		this.wuc_mantto.MostrarCancelar = opcion;

		this.wuc_mantto.MostrarEditar = false;
		this.wuc_mantto.MostrarEliminar = false;
		this.wuc_mantto.MostrarBuscar = !opcion;
		this.wuc_mantto.MostrarImprimir = !opcion;

		if (opcion)
		{
			this.pnl_campos.Style["display"] = "block";
			this.div_grilla.Style["display"] = "none";
		}
		else
		{
			this.pnl_campos.Style["display"] = "none";
			this.div_grilla.Style["display"] = "block";
		}
	}
	#endregion //"GESTION DEL COMPORTAMIENTO DE EDICION"

	#region "GESTION DEL COMPORTAMIENTO DE LA GRID"
	protected void gv_Datos_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.gv_Datos, "Select$" + e.Row.RowIndex);
		}
	}
	protected void gv_Datos_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		this.gv_Datos.PageIndex = e.NewPageIndex;        
		this.Cargar_Datos();
	}
	protected void gv_Datos_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (this.gv_Datos.SelectedIndex >= 0)
		{
			this.wuc_mantto.MostrarEditar = true;
			this.wuc_mantto.MostrarEliminar = true;

			this.txt_Id_Perfil.Text = this.gv_Datos.SelectedDataKey["Id_Perfil"].ToString();;
			//this.ddl_Id_Sistema.SelectedValue = this.gv_Datos.SelectedDataKey["Id_Sistema"].ToString();;
		}
	}
	#endregion //"GESTION DEL COMPORTAMIENTO DE LA GRID"

	#region "GESTION DEL ACCESO A DATOS"

	//Método para cargar los datos de la entidad: Sistema
	protected void CargarSistema()
	{
        //Sistema sistema = new Sistema();
        //BllSistema bllSistema = new BllSistema();

        //this.ddl_Id_Sistema.DataSource = bllSistema.buscar(sistema,"Id_Unidad");
        //this.ddl_Id_Sistema.DataBind();
        //this.ddl_Id_Sistema.Items.Insert(0, new ListItem("-- Seleccione una opción --", ""));
        //this.ddl_Id_Sistema.SelectedIndex = 0;
	}
	protected void Cargar_Datos()
	{
        Mop.Seg.BLL.WcfMaestra.Perfil perfil = new Mop.Seg.BLL.WcfMaestra.Perfil();
		perfil.Sistema = new Sistema();
        perfil.Sistema.Id_Sistema = this.Master.IdSistema;

        List<Mop.Seg.BLL.WcfMaestra.Perfil> lstPerfil = bllPerfil
								                            .Perfil_B(perfil)
								                            .OrderBy(a => a.Id_Perfil)
								                            .ThenBy(a => a.Descripcion)
								                            .ToList();
        
		this.gv_Datos.DataSource = lstPerfil;
		this.gv_Datos.DataBind();
	}
	protected void Cargar_Registro()
	{
        Mop.Seg.BLL.WcfMaestra.Perfil perfil = new Mop.Seg.BLL.WcfMaestra.Perfil();
        perfil.Sistema = new Sistema();
        

        perfil.Id_Perfil = Convert.ToString(txt_Id_Perfil.Text);
        perfil.Sistema.Id_Sistema = this.Master.IdSistema;

        perfil = bllPerfil.Perfil_B(perfil)[0];

        this.txt_Id_Perfil.Text = perfil.Id_Perfil.ToString();
        //this.ddl_Id_Sistema.SelectedValue = perfil.Sistema.Id_Sistema.ToString();
        this.txt_Descripcion.Text = perfil.Descripcion.ToString();
        this.cal_Fecha_Creacion.Text = Convert.ToDateTime(perfil.Fecha_Creacion).ToString("dd/MM/yyyy hh:mm:ss");
        this.cal_Fecha_Modificacion.Text = Convert.ToDateTime(perfil.Fecha_Modificacion).ToString("dd/MM/yyyy hh:mm:ss");
        //this.nbx_Id_Tipo_Permiso.Text = perfil.Id_Tipo_Permiso.ToString();
        this.nbx_Nivel_Perfil.Text = perfil.Nivel_Perfil.ToString();

        this.wucPerfilDetalle.IdPerfil = perfil.Id_Perfil;
        this.wucPerfilDetalle.Cargar_Datos();
	}
	protected void Guardar_Registro()
	{
        Mop.Seg.BLL.WcfMaestra.Perfil perfil = new Mop.Seg.BLL.WcfMaestra.Perfil();
        perfil.Sistema = new Sistema();


        perfil.Id_Perfil = Convert.ToString(txt_Id_Perfil.Text);
        perfil.Sistema.Id_Sistema = this.Master.IdSistema;

        perfil.Descripcion = Convert.ToString(txt_Descripcion.Text);

        perfil.Id_Tipo_Permiso = 0; // Convert.ToInt16(nbx_Id_Tipo_Permiso.Text);
        perfil.Nivel_Perfil = 0; // Convert.ToInt16(nbx_Nivel_Perfil.Text);

        int r;
        if (this.wuc_mantto.Accion == "I")
        {
            perfil.Fecha_Creacion = DateTime.Now;
            r = bllPerfil.Perfil_I(perfil);
        }
        else
        {
            perfil.Fecha_Modificacion = DateTime.Now;
            r = bllPerfil.Perfil_A(perfil);
        }

        this.wucPerfilDetalle.IdPerfil = perfil.Id_Perfil;
        this.wucPerfilDetalle.Guardar_Datos();
	}
	protected void Eliminar_Registro()
	{
        Mop.Seg.BLL.WcfMaestra.Perfil perfil = new Mop.Seg.BLL.WcfMaestra.Perfil();
        perfil.Sistema = new Sistema();


        perfil.Id_Perfil = Convert.ToString(txt_Id_Perfil.Text);
        perfil.Sistema.Id_Sistema = this.Master.IdSistema;

        int r = bllPerfil.Perfil_E(perfil);
	}
	#endregion //"GESTION DEL ACCESO A DATOS"

} // fIN DE LA CLASE sistema_wf_Perfil
// Clase para el mantenimiento de la tabla: tbl_Perfil
