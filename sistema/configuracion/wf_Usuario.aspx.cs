using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using ENT;
//using BLL;
using Mop.Seg.BLL.WcfMaestra;

/// <summary>
/// Clase para el mantenimiento de la tabla: tbl_Usuario
/// </summary>
public partial class sistema_configuracion_wf_Usuario : System.Web.UI.Page
{
    //Entidad a la que corresponde el formulario
    WcfMaestraClient bllUsuario = new WcfMaestraClient();
    
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
            this.wuc_mantto.Filtro_Criterio.Items.Add("IdUsuario");
            this.wuc_mantto.Filtro_Criterio.Items.Add("Nombre de usuario");
            //this.wuc_mantto.Filtro_Criterio.Items.Add("Estatus");
            this.wuc_mantto.Filtro_Criterio.Items.Add("Correo eletrónico");
            this.wuc_mantto.Filtro_Criterio.Items.Add("Código de empleado");
            this.wuc_mantto.Filtro_Criterio.Items.Add("NIT");
            //this.wuc_mantto.Filtro_Criterio.Items.Add("Bloqueado");

            //Limpiando el formulario
            this.Habilitar_Edicion(false);
            this.Limpiar_Campos();

            //Cargando los datos de las entidades
            Cargartipos_servicios();

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
        this.txt_Id_Usuario.Enabled = true;
    }
    protected void Editar(object sender, EventArgs e)
    {
        this.Cargar_Registro();
        this.Habilitar_Edicion(true);
        this.lbl__Accion.Text = "Actualizar registro:";
        this.txt_Id_Usuario.Enabled = false;
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
        this.txt_Id_Usuario.Text = "";
        this.txt_Descripcion.Text = "";
        this.cbx_Estatus.Checked = false;
        this.txt_Email.Text = "";
        this.txt_Nit.Text = "";
        this.cbx_Bloqueado.Checked = false;
        this.cal_Fecha_Creacion_Usuario.Text = "";
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
            string s = Page.ClientScript.GetPostBackClientHyperlink(this.gv_Datos, "Select$" + e.Row.RowIndex);
            e.Row.Cells[0].Attributes["onclick"] = s;
            e.Row.Cells[1].Attributes["onclick"] = s;
            e.Row.Cells[2].Attributes["onclick"] = s;
            e.Row.Cells[3].Attributes["onclick"] = s;
            e.Row.Cells[4].Attributes["onclick"] = s;
            e.Row.Cells[5].Attributes["onclick"] = s;
            e.Row.Cells[5].Attributes["onclick"] = s;
            e.Row.Cells[7].Attributes["onclick"] = s;
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

            this.txt_Id_Usuario.Text = this.gv_Datos.SelectedDataKey["Id_Usuario"].ToString(); ;
        }
    }
    #endregion //"GESTION DEL COMPORTAMIENTO DE LA GRID"

    #region "GESTION DEL ACCESO A DATOS"

    //Método para cargar los datos de la entidad: tipos_servicios
    protected void Cargartipos_servicios()
    {
        //tipos_servicios tipos_servicios = new tipos_servicios();
        //Blltipos_servicios blltipos_servicios = new Blltipos_servicios();

        //this.ddl_Id_Tipo_Servicio.DataSource = blltipos_servicios.buscar(tipos_servicios,"Descripcion");
        //this.ddl_Id_Tipo_Servicio.DataBind();
        //this.ddl_Id_Tipo_Servicio.Items.Insert(0, new ListItem("-- Seleccione una opción --", ""));
        //this.ddl_Id_Tipo_Servicio.SelectedIndex = 0;
    }
    protected void Cargar_Datos()
    {
        Usuario usuario = new Usuario();
        //usuario.Id_Sistema = this.Master.IdSistema;


        if ((this.wuc_mantto.Filtro_Criterio.SelectedValue == "IdUsuario") && (this.wuc_mantto.Filtro_Valor.Trim() != ""))
            usuario.Id_Usuario = this.wuc_mantto.Filtro_Valor;

        if ((this.wuc_mantto.Filtro_Criterio.SelectedValue == "Nombre de usuario") && (this.wuc_mantto.Filtro_Valor.Trim() != ""))
            usuario.Descripcion = this.wuc_mantto.Filtro_Valor;

        if ((this.wuc_mantto.Filtro_Criterio.SelectedValue == "Estatus") && (this.wuc_mantto.Filtro_Valor.Trim() != ""))
            usuario.Estatus = Convert.ToBoolean(this.wuc_mantto.Filtro_Valor);

        if ((this.wuc_mantto.Filtro_Criterio.SelectedValue == "Correo eletrónico") && (this.wuc_mantto.Filtro_Valor.Trim() != ""))
            usuario.Email = this.wuc_mantto.Filtro_Valor;

        if ((this.wuc_mantto.Filtro_Criterio.SelectedValue == "Código de empleado") && (this.wuc_mantto.Filtro_Valor.Trim() != ""))
            usuario.Id_Empleado = this.wuc_mantto.Filtro_Valor;

        if ((this.wuc_mantto.Filtro_Criterio.SelectedValue == "NIT") && (this.wuc_mantto.Filtro_Valor.Trim() != ""))
            usuario.Nit = this.wuc_mantto.Filtro_Valor;

        if ((this.wuc_mantto.Filtro_Criterio.SelectedValue == "Bloqueado") && (this.wuc_mantto.Filtro_Valor.Trim() != ""))
            usuario.Bloqueado = Convert.ToBoolean(this.wuc_mantto.Filtro_Valor);
            


        
        List<Usuario> lstUsuario = bllUsuario
                                .Usuario_B(usuario)
                                .OrderBy(a => a.Descripcion)
                                .ToList();

        this.gv_Datos.DataSource = lstUsuario;
        this.gv_Datos.DataBind();
    }
    protected void Cargar_Registro()
    {
        Usuario usuario = new Usuario();
        usuario.Id_Sistema = this.Master.IdSistema;

        usuario.Id_Usuario = Convert.ToString(txt_Id_Usuario.Text);
        usuario = bllUsuario.Usuario_US(usuario)[0];

        this.txt_Id_Usuario.Text = usuario.Id_Usuario.ToString();
        this.txt_Descripcion.Text = usuario.Descripcion.ToString();
        this.cbx_Estatus.Checked = (usuario.Estatus == true) ? true : false;
        this.txt_Email.Text = usuario.Email.ToString();
        this.txt_Nit.Text = usuario.Nit.ToString();
        this.cbx_Bloqueado.Checked = (usuario.Bloqueado == true) ? true : false;
        this.cal_Fecha_Creacion_Usuario.Text = Convert.ToDateTime(usuario.Fecha_Creacion_Usuario).ToString("dd/MM/yyyy");
    }
    protected void Guardar_Registro()
    {
        Usuario usuario = new Usuario();
        usuario.Id_Sistema = this.Master.IdSistema;
        //usuario.tipos_servicios = new tipos_servicios();

        usuario.Id_Usuario = Convert.ToString(txt_Id_Usuario.Text);
        usuario.Descripcion = Convert.ToString(txt_Descripcion.Text);
        //usuario.Clave = Convert.ToString(txt_Clave.Text);
        usuario.Tipo_Usuario = true; // Convert.ToBoolean(cbx_Tipo_Usuario.Checked);
        usuario.Estatus = Convert.ToBoolean(cbx_Estatus.Checked);
        usuario.Email = Convert.ToString(txt_Email.Text);
        //usuario.Id_Empleado = Convert.ToString(txt_Id_Empleado.Text);
        //usuario.Fecha_Cambio_Contrasena = Convert.ToDateTime(cal_Fecha_Cambio_Contrasena.SelectedDate);
        //usuario.Clave_Anterior = Convert.ToString(txt_Clave_Anterior.Text);
        usuario.Nit = Convert.ToString(txt_Nit.Text);
        //usuario.tipos_servicios.Id_Tipo_Servicio = Convert.ToInt32(ddl_Id_Tipo_Servicio.SelectedValue);
        //usuario.Insticion_Representa = Convert.ToString(txt_Insticion_Representa.Text);
        usuario.Bloqueado = Convert.ToBoolean(cbx_Bloqueado.Checked);
        //usuario.Fecha_Creacion_Usuario = Convert.ToDateTime(cal_Fecha_Creacion_Usuario.SelectedDate);
        usuario.Id_Sistema = this.Master.IdSistema;

        int r;
        if (this.wuc_mantto.Accion == "I")
        {
            r = bllUsuario.Usuario_I(usuario);
        }
        else
        {
            r = bllUsuario.Usuario_A(usuario);
        }
    }
    protected void Eliminar_Registro()
    {
        Usuario usuario = new Usuario();
        //usuario.tipos_servicios = new tipos_servicios();

        usuario.Id_Usuario = Convert.ToString(txt_Id_Usuario.Text);
        int r = bllUsuario.Usuario_E(usuario);
    }
    #endregion //"GESTION DEL ACCESO A DATOS"

} // fIN DE LA CLASE sistema_wf_Usuario
// Clase para el mantenimiento de la tabla: tbl_Usuario
