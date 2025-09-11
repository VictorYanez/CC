//ESPACIOS DE NOMBRES A IMPORTAR EN EL FORMULARIO
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mop.Seg.BLL.WcfMaestra;
//using Mop.Seg.BLL.WcfMaestra.;

/// <summary>
/// Clase para el mantenimiento de la tabla: tbl_Menu
/// </summary>
public partial class sistema_wf_Menu : System.Web.UI.Page
{
	//Entidad a la que corresponde el formulario
    WcfMaestraClient bllMenu = new WcfMaestraClient();
    

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
			this.wuc_mantto.Filtro_Criterio.Items.Add("Id_Menu");
			this.wuc_mantto.Filtro_Criterio.Items.Add("Id_Sistema");
			this.wuc_mantto.Filtro_Criterio.Items.Add("Descripcion");
			this.wuc_mantto.Filtro_Criterio.Items.Add("Icono");
			this.wuc_mantto.Filtro_Criterio.Items.Add("Texto");
			this.wuc_mantto.Filtro_Criterio.Items.Add("Id_Padre");
			this.wuc_mantto.Filtro_Criterio.Items.Add("Nombre_Forma");
			this.wuc_mantto.Filtro_Criterio.Items.Add("Nivel");
			this.wuc_mantto.Filtro_Criterio.Items.Add("Jerarquia");
			this.wuc_mantto.Filtro_Criterio.Items.Add("Id_Modulo");
			this.wuc_mantto.Filtro_Criterio.Items.Add("Url_Ayuda");
			this.wuc_mantto.Filtro_Criterio.Items.Add("Url_Ayuda_Video");

			//Limpiando el formulario
			this.Habilitar_Edicion(false);
			this.Limpiar_Campos();

			//Cargando los datos de las entidades
			CargarSistema();
			CargarMenu();

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
		this.nbx_Id_Menu.Enabled = true;
        //this.ddl_Id_Sistema.Enabled = true;
	}
	protected void Editar(object sender, EventArgs e)
	{
		this.Cargar_Registro();
		this.Habilitar_Edicion(true);
		this.lbl__Accion.Text = "Actualizar registro:";
		this.nbx_Id_Menu.Enabled = false;
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
		this.nbx_Id_Menu.Text = "";
        //this.ddl_Id_Sistema.SelectedIndex = 0;
		this.txt_Descripcion.Text = "";
        //this.nbx_Icono.Text = "";
        //this.txt_Texto.Text = "";
        this.wucIcono.Clase = "";
        this.wucPadre.IdMenu = null;
        //this.txt_Nombre_Forma.Text = "";
        //this.nbx_Nivel.Text = "";
        //this.txt_Jerarquia.Text = "";
        //this.txt_Id_Modulo.Text = "";
		//this.txt_Url_Ayuda.Text = "";
        //this.txt_Url_Ayuda_Video.Text = "";
	}
	protected void Habilitar_Edicion(bool opcion)
	{
		this.pnl_campos.Enabled = opcion;
		this.tvw_Datos.Enabled = !opcion;

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
    protected void tvw_Datos_SelectedNodeChanged(object sender, EventArgs e)
    {
        if (this.tvw_Datos.SelectedNode.Value != "" )
        {
            this.wuc_mantto.MostrarEditar = true;
            this.wuc_mantto.MostrarEliminar = true;

            this.nbx_Id_Menu.Text = this.tvw_Datos.SelectedNode.Value;
            //this.ddl_Id_Sistema.SelectedValue = this.Master.IdSistema; //this.gv_Datos.SelectedDataKey["Id_Sistema"].ToString();;
        }
    }
	#endregion //"GESTION DEL COMPORTAMIENTO DE LA GRID"

	#region "GESTION DEL ACCESO A DATOS"

	//Método para cargar los datos de la entidad: Sistema
	protected void CargarSistema()
	{
        //Sistema sistema = new Sistema();
        //sistema.Id_Sistema = this.Master.IdSistema;
        ////BllSistema bllSistema = new BllSistema();

        //this.ddl_Id_Sistema.DataSource = bllMenu.Sistema_B(sistema);
        //this.ddl_Id_Sistema.DataBind();
        ////this.ddl_Id_Sistema.Items.Insert(0, new ListItem("-- Seleccione una opción --", ""));
        ////this.ddl_Id_Sistema.SelectedIndex = 0;
	}
	//Método para cargar los datos de la entidad: Menu
	protected void CargarMenu()
	{
        //Mop.Seg.BLL.WcfMaestra.Menu menu = new Mop.Seg.BLL.WcfMaestra.Menu();
        //menu.Sistema = new Sistema();
        //menu.Sistema.Id_Sistema = this.Master.IdSistema;
        ////menu.Menu = new Mop.Seg.BLL.WcfMaestra.Menu();
        ////BllMenu bllMenu = new BllMenu();

        ////this.ddl_Id_Padre.DataSource = bllMenu.buscar(menu,"Descripcion");
        //this.ddl_Id_Padre.DataSource = bllMenu.Menu_B(menu);
        //this.ddl_Id_Padre.DataBind();
        //this.ddl_Id_Padre.Items.Insert(0, new ListItem("-- Seleccione una opción --", ""));
        //this.ddl_Id_Padre.SelectedIndex = 0;
	}
	protected void Cargar_Datos()
	{
		Mop.Seg.BLL.WcfMaestra.Menu menu = new Mop.Seg.BLL.WcfMaestra.Menu();
		menu.Sistema = new Sistema();
        menu.Sistema.Id_Sistema = this.Master.IdSistema;
		//menu.Menu = new Menu();

		List<Mop.Seg.BLL.WcfMaestra.Menu> lstMenu = bllMenu
								.Menu_B(menu)
								.OrderBy(a => a.Icono)
								//.ThenBy(a => a.Descripcion)
								.ToList();

        //this.gv_Datos.DataSource = lstMenu;
        //this.gv_Datos.DataBind();

        this.tvw_Datos.Nodes.Clear();
        TreeNode tnRaiz = new TreeNode();
        tnRaiz.Value = "";
        tnRaiz.Text = this.Master.NombreSistema;
        this.tvw_Datos.Nodes.Add(tnRaiz);

        foreach(Mop.Seg.BLL.WcfMaestra.Menu mnu in lstMenu)
        {
            if(mnu.IdPadre == null)
            {
                TreeNode tn = new TreeNode();
                tn.Value = mnu.Id_Menu.ToString();
                tn.Text = String.Format("<i class='fa {0}'></i> {1}", mnu.Texto, mnu.Descripcion);

                this.tvw_Datos.Nodes[0].ChildNodes.Add(tn);
                this.Cargar_Datos_Hijos(ref tn, lstMenu);
            }
        }

        this.tvw_Datos.ExpandAll();

        this.wucPadre.llenarArbol(lstMenu, null);
	}
    protected void Cargar_Datos_Hijos(ref TreeNode tnPadre, List<Mop.Seg.BLL.WcfMaestra.Menu> lstMenu)
    {
        foreach(Mop.Seg.BLL.WcfMaestra.Menu mnu in lstMenu)
        {
            if(mnu.IdPadre.ToString() == tnPadre.Value)
            {
                TreeNode tn = new TreeNode();
                tn.Value = mnu.Id_Menu.ToString();
                tn.Text = String.Format("<i class='fa {0}'></i> {1}", mnu.Texto, mnu.Descripcion);

                tnPadre.ChildNodes.Add(tn);
                this.Cargar_Datos_Hijos(ref tn, lstMenu);
            }
        }
    }



	protected void Cargar_Registro()
	{
		Mop.Seg.BLL.WcfMaestra.Menu menu = new Mop.Seg.BLL.WcfMaestra.Menu();
		menu.Sistema = new Sistema();
        //menu.Menu = new Menu();

		menu.Id_Menu = Convert.ToInt16(nbx_Id_Menu.Text);
        menu.Sistema.Id_Sistema = this.Master.IdSistema;
        //menu.Sistema.Id_Sistema = Convert.ToString(ddl_Id_Sistema.SelectedValue);

		menu = bllMenu.Menu_B(menu)[0];

		this.nbx_Id_Menu.Text = menu.Id_Menu.ToString();
        //this.ddl_Id_Sistema.SelectedValue = menu.Sistema.Id_Sistema.ToString();
		this.txt_Descripcion.Text = menu.Descripcion.ToString();
        //this.nbx_Icono.Text = menu.Icono.ToString();
        //this.txt_Texto.Text = menu.Texto.ToString();
        this.wucIcono.Clase = menu.Texto.ToString();
        this.wucPadre.IdMenu = menu.IdPadre;
        this.wucFormulario.Url = menu.Nombre_Forma.ToString();
        //this.nbx_Nivel.Text = menu.Nivel.ToString();
        //this.txt_Jerarquia.Text = menu.Jerarquia.ToString();
        //this.txt_Id_Modulo.Text = menu.Id_Modulo.ToString();
        this.wucManual.Url = menu.Url_Ayuda.ToString();
        this.wucVideo.Url = menu.Url_Ayuda_Video.ToString();
	}
	protected void Guardar_Registro()
	{
		Mop.Seg.BLL.WcfMaestra.Menu menu = new Mop.Seg.BLL.WcfMaestra.Menu();
		menu.Sistema = new Sistema();
		//menu.Menu = new Menu();

		menu.Id_Menu = Convert.ToInt16(nbx_Id_Menu.Text);
        menu.Sistema.Id_Sistema = this.Master.IdSistema;
        //menu.Sistema.Id_Sistema = Convert.ToString(ddl_Id_Sistema.SelectedValue);
		menu.Descripcion = Convert.ToString(txt_Descripcion.Text);
        //menu.Icono = Convert.ToInt16(nbx_Icono.Text);
        //menu.Texto = Convert.ToString(txt_Texto.Text);
        menu.Texto = this.wucIcono.Clase;
        try { menu.IdPadre = Convert.ToInt16(this.wucPadre.IdMenu); }
        catch { menu.IdPadre = null; }
        menu.Nombre_Forma = Convert.ToString(this.wucFormulario.Url);
        menu.Nivel = this.wucPadre.Nivel;
        menu.Jerarquia = this.wucPadre.Jerarquia + this.nbx_Id_Menu.Text + ".";
        //menu.Id_Modulo = Convert.ToString(txt_Id_Modulo.Text);
        menu.Url_Ayuda = Convert.ToString(wucManual.Url);
        menu.Url_Ayuda_Video = Convert.ToString(wucVideo.Url);

        int r;
        if (this.wuc_mantto.Accion == "I")
        {
            r = bllMenu.Menu_I(menu);
        }
        else
        {
            r = bllMenu.Menu_A(menu);
        }
	}
	protected void Eliminar_Registro()
	{
        Mop.Seg.BLL.WcfMaestra.Menu menu = new Mop.Seg.BLL.WcfMaestra.Menu();
		menu.Sistema = new Sistema();
		//menu.Menu = new Menu();

		menu.Id_Menu = Convert.ToInt16(nbx_Id_Menu.Text);
        menu.Sistema.Id_Sistema = this.Master.IdSistema;
        //menu.Sistema.Id_Sistema = Convert.ToString(ddl_Id_Sistema.SelectedValue);

		int r = bllMenu.Menu_E(menu);
	}
	#endregion //"GESTION DEL ACCESO A DATOS"

    
} // fIN DE LA CLASE sistema_wf_Menu
// Clase para el mantenimiento de la tabla: tbl_Menu
