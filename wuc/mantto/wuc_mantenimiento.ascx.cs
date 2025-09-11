using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Estandar;
using System.Data;
using ENT;
using BLL;

public partial class wuc_mantto_wuc_mantenimiento : System.Web.UI.UserControl
{

    #region "DELEGADOS Y EVENTOS"
    public delegate void regresar(object sender, EventArgs e);
    public delegate void nuevo(object sender, EventArgs e);
    public delegate void editar(object sender, EventArgs e);
    public delegate void finalizar(object sender, EventArgs e);
    public delegate void eliminar(object sender, EventArgs e);    
    public delegate void buscar(object sender, EventArgs e);
    public delegate void enviar(object sender, EventArgs e);
    public delegate void imprimir(object sender, EventArgs e);
    public delegate void guardar(object sender, EventArgs e);
    public delegate void guardar2(object sender, EventArgs e);
    public delegate void cancelar(object sender, EventArgs e);
    public delegate void seleccionar(object sender, EventArgs e);
    public delegate void limpiar(object sender, EventArgs e);
    public delegate void aplicarfiltro(object sender, EventArgs e);
    public delegate void boton_1(object sender, EventArgs e);
    public delegate void boton_2(object sender, EventArgs e);
    public delegate void asignarLineas(object sender, EventArgs e);
    public delegate void nuevaModificativa(object sender, EventArgs e);
    public delegate void buscarPersonalizado(object sender, EventArgs e);
    public delegate void seleccionarTipoFiltro(object sender, EventArgs e);

    public event regresar Regresar;
    public event nuevo Nuevo;
    public event editar Editar;
    public event finalizar Finalizar;
    public event eliminar Eliminar;
    public event buscar Buscar;
    public event enviar Enviar;
    public event imprimir Imprimir;
    public event guardar Guardar;
    public event guardar2 Guardar2;
    public event cancelar Cancelar;    
    public event seleccionar Seleccionar;
    public event limpiar Limpiar;
    public event aplicarfiltro AplicarFiltro;
    public event boton_1 Boton_1;
    public event boton_2 Boton_2;
    public event asignarLineas AsignarLineas;
    public event nuevaModificativa NuevaModificativa;
    public event buscarPersonalizado BuscarPersonalizado;
    public event seleccionarTipoFiltro SeleccionarTipoFiltro;
    #endregion

    #region "PROPIEDADES"

    public bool FiltroTipoLista
    {
        get
        {
            try
            {
                return Convert.ToBoolean(this.hdf_TipoFiltro.Value);
            }
            catch
            {
                return false;
            }
        }
        set
        {
            this.hdf_TipoFiltro.Value = value.ToString();
        }
    }
    public string ValidationGroup
    {
        get { return this.lbn_Guardar.ValidationGroup; }
        set { this.lbn_Guardar.ValidationGroup = value; }
    }
        
    public bool MostrarRegresar
    {
        get { return this.lbn_Regresar.Visible; }
        set
        {
            this.lbn_Regresar.Visible = value;            
        }
    }
    public bool MostrarNuevo
    {
        get { return this.lbn_Nuevo.Visible; }
        set { 
            this.lbn_Nuevo.Visible = value;
            //if (!((master_ajax)(this.Page.Master)).Permiso_Insertar) this.lbn_Nuevo.Visible = false; 
        }
    }
    public bool MostrarEditar
    {
        get { return this.lbn_Editar.Visible; }
        set 
        { 
            this.lbn_Editar.Visible = value;
            //if (!((master_ajax)(this.Page.Master)).Permiso_Actualizar) 
            //    this.lbn_Editar.Visible = false; 
        }
    }

    public bool MostrarFinalizar
    {
        get { return this.lb_Finalizar.Visible; }
        set
        {
            this.lb_Finalizar.Visible = value;
        }
    }
    public bool MostrarEliminar
    {
        get { return this.lbn_Eliminar.Visible; }
        set 
        { 
            this.lbn_Eliminar.Visible = value;
            //if (!((master_ajax)(this.Page.Master)).Permiso_Eliminar) this.lbn_Eliminar.Visible = false; 
        }
    }
    public bool MostrarBuscar
    {
        get { return this.lbn_Buscar.Visible; }
        set 
        {
            if (value)
                this.lbn_Buscar.Style["display"] = "normal";
            else
                this.lbn_Buscar.Style["display"] = "none";
        }
    }
   
    public bool MostrarImprimir
    {
        get { return this.lbn_Imprimir.Visible; }
        set
        {
            this.lbn_Imprimir.Visible = value;
            //if (!((master_ajax)(this.Page.Master)).Permiso_Imprimir)
            //    this.lbn_Imprimir.Visible = false;
        }
    }
    public bool MostrarGuardar
    {
        get { return this.lbn_Guardar.Visible; }
        set 
        { 
            this.lbn_Guardar.Visible = value;

            //if (this.Accion == "I")
            //{
            //    if (!((master_ajax)(this.Page.Master)).Permiso_Insertar) this.lbn_Guardar.Visible = false; 
            //}
            //else
            //{
            //    if (!((master_ajax)(this.Page.Master)).Permiso_Actualizar) this.lbn_Guardar.Visible = false; 
            //}
        }
    }
    public bool MostrarGuardar2
    {
        get { return this.lbn_Guardar2.Visible; }
        set { this.lbn_Guardar2.Visible = value; }
    }
    public bool MostrarCancelar
    {
        get { return this.lbn_Cancelar.Visible; }
        set { this.lbn_Cancelar.Visible = value; }
    }
    public bool MostrarCriterio
    {
        get { return this.ddl_filtro.Visible; }
        set 
        { 
            this.ddl_filtro.Visible = value;
            this.lbl_filtro.Visible = value;
        }
    }

    public bool MostrarAsignarLineas
    {
        get { return this.lb_AsignarLineas.Visible; }
        set { this.lb_AsignarLineas.Visible = value; }
    }

    public bool MostrarNuevaModificativa
    {
        get { return this.lb_NuevaModificativa.Visible; }
        set { this.lb_NuevaModificativa.Visible = value; }
    }

    public bool MostrarBuscarPersonalizado
    {
        get { return this.lb_BuscarPersonalizado.Visible; }
        set { this.lb_BuscarPersonalizado.Visible = value; }
    }
    public DropDownList Filtro_Criterio
    {
        get { return this.ddl_filtro; }
        set { this.ddl_filtro = value; }
    }

    public DropDownList Descripcion_Filtro
    {
        get { return this.ddl_Descripcion_Filtro; }
        set { this.ddl_Descripcion_Filtro = value; }
    }
    public string Filtro_Valor
    {
        get 
        {            
            if (this.txt_Descripcion_Filtro.Visible)
            {
                return this.txt_Descripcion_Filtro.Text;
            }
            else
            {
                return this.ddl_Descripcion_Filtro.SelectedValue;
            }
        }
        set { this.txt_Descripcion_Filtro.Text = value; }
    }
    public string Filtro_Valor_TXT
    {
        get
        {
            if (this.txt_Descripcion_Filtro.Visible)
            {
                return this.txt_Descripcion_Filtro.Text;
            }
            else
            {
                return this.ddl_Descripcion_Filtro.SelectedItem.Text;
            }
        }
        set { this.txt_Descripcion_Filtro.Text = value; }
    }

    public LinkButton LbnRegresar
    {
        get { return this.lbn_Regresar; }
        set { this.lbn_Regresar = value; }
    }

    public LinkButton LbnNuevo
    {
        get { return this.lbn_Nuevo;  }
        set { this.lbn_Nuevo = value; }
    }
    public LinkButton LbnEditar
    {
        get { return this.lbn_Editar; }
        set { this.lbn_Editar = value; }
    }

    public LinkButton lbFinalizar
    {
        get { return this.lb_Finalizar; }
        set { this.lb_Finalizar = value; }
    }
    public LinkButton LbnEliminar
    {
        get { return this.lbn_Eliminar; }
        set { this.lbn_Eliminar= value; }
    }
    public LinkButton LbnGuardar
    {
        get { return this.lbn_Guardar; }
        set { this.lbn_Guardar = value; }
    }
    public LinkButton LbnCancelar
    {
        get { return this.lbn_Cancelar; }
        set { this.lbn_Cancelar = value; }
    }

    public LinkButton lbAsignarLineas
    {
        get { return this.lb_AsignarLineas; }
        set { this.lb_AsignarLineas = value; }
    }

    public LinkButton lbNuevaModificativa
    {
        get { return this.lb_NuevaModificativa; }
        set { this.lb_NuevaModificativa = value; }
    }

    public LinkButton lbBuscarPersonalizado
    {
        get { return this.lb_BuscarPersonalizado; }
        set { this.lb_BuscarPersonalizado = value; }
    }
    public string Accion
    {
        set { this.hf_accion.Value = value; }
        get { return this.hf_accion.Value; }
    }
    public bool HabilitarEdicion
    {
        set { this.Habilitar_Edicion(value); }
    }
    public void Limpiar_Filtro()
    {
        this.txt_Descripcion_Filtro.Text = string.Empty;
        this.txt_Descripcion_Filtro.Visible = true;
        this.ddl_Descripcion_Filtro.Visible = false;
        this.ddl_filtro.SelectedIndex = -1;
    }

    public void Ocultar_Panel_Busqueda()
    {
        this.pnl_filtro.Visible = false;
    }
    public string Confirmacion_Envio_Texto
    {
        get
        {
            return "";// cbe_Enviar.ConfirmText;
        }
        //set
        //{
        //    cbe_Enviar.ConfirmText = value;
        //}
    }
    public string Confirmacion_Envio_ToolTip
    {
        get
        {
            return "";// lbn_Enviar.ToolTip;
        }
        //set
        //{
        //    lbn_Enviar.ToolTip = value;
        //}
    }

    public LinkButton BOTON_1
    {
        get { return this.lb_Boton_1; }
        set { this.lb_Boton_1 = value; }
    }

    public LinkButton BOTON_2
    {
        get { return this.lb_Boton_2; }
        set { this.lb_Boton_2 = value; }
    }

    public bool MostrarBoton_1
    {
        get { return this.lb_Boton_1.Visible; }
        set { this.lb_Boton_1.Visible = value; }
    }

    public bool MostrarBoton_2
    {
        get { return this.lb_Boton_2.Visible; }
        set { this.lb_Boton_2.Visible = value; }
    }
    #endregion

    #region "CARGA DEL FORMULARIO"
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.MostrarBuscar = false;

        

        if (!Page.IsPostBack)
        {
            //this.MostrarRegresar = true;
            //this.MostrarEnviar = false;

            //if(HttpContext.Current.Request.Url.ToString().Contains("/sistema/configuracion/wf_Usuario.aspx") ||
            //    HttpContext.Current.Request.Url.ToString().Contains("/sistema/tramite/wf_tramite.aspx"))
            //    this.MostrarBuscar = true;
            //else
            //    this.MostrarBuscar = false;
            ////this.MostrarImprimir = false;
            
            //this.Verificar_Permisos_Id_Menu();                        
            //try
            //{
            //    Session["ItemID"] = Request.Params["ItemID"].ToString();
            //}
            //catch
            //{

            //}

            //this.pnl_filtro.CssClass = "";
        }

        this.lbn_Imprimir.Visible = false;

    }
    protected void Verificar_Permisos_Id_Menu()
    {
        //this.lbn_Nuevo.Visible = ((master_ajax)(this.Page.Master)).Permiso_Insertar;        
    }
    #endregion

    #region "EVENTOS DE LOS BOTONES"
    /// <summary>
    /// Evento Click del Botón Regresar
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbn_Regresar_Click(object sender, EventArgs e)
    {
        if (Regresar != null)
        {
            Regresar(sender, e);
        }
        else
        {
            Response.Redirect("/");
            //this.lbn_Regresar.Attributes.Add("onclick", "window.location = '/'");
        }
    }


    protected void Descarga(object sender, EventArgs e)
    {
        this.pnl_filtro.CssClass = "";
    }
    protected void lbn_Regresar_Init(object sender, EventArgs e)
    {
        //if (Regresar != null)
        //{
        //    lbn_Regresar.Attributes.Clear();
        //    Regresar(sender, e);
        //}
        //else
        //{


        //    //try
        //    //{
        //    //    string url = Session["regresar"].ToString();

        //    //    //url = url.Substring(url.IndexOf('?') + 0, url.Length - 1);


        //    //    if (HttpContext.Current.Request.Url.ToString().Contains(url))
        //    //    {

        //    //        this.lbn_Regresar.Attributes.Add("onclick", "window.location = '/'");
        //    //    }
        //    //    else
        //    //    {
        //    //        this.lbn_Regresar.Attributes.Add("onclick", "window.location = '" + Session["regresar"].ToString() + "'");
        //    //    }
        //    //}
        //    //catch
        //    //{
        //        this.lbn_Regresar.Attributes.Add("onclick", "window.location = '/'");
        //    //}

        //}
    }
    protected void lbn_Regresar_Unload(object sender, EventArgs e)
    {
        
    }






    /// <summary>
    /// Evento Click del Botón Nuevo
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbn_Nuevo_Click(object sender, EventArgs e)
    {
        this.hf_accion.Value = "I";     //Guarda la Acción a Ejecutar (Insertar).
        this.Habilitar_Edicion(true);   //Habilita los Campos.
        this.Limpiar_Campos();          //Limpia los Campos para la Inserción.
        
        if (Nuevo != null)
        {
            Nuevo(sender, e);
        }
    }

    /// <summary>
    /// Evento Click del Botón Editar
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbn_Editar_Click(object sender, EventArgs e)
    {
        this.hf_accion.Value = "U";     //Guarda la Acción a Ejecutar (Actualizar).
        this.Habilitar_Edicion(true);   //Habilita los Campos.
        
        if (Editar != null)
        {
            Editar(sender, e);
        }
    }

    protected void lb_Finalizar_Click(object sender, EventArgs e)
    {
         this.Habilitar_Edicion(true);
         if (Finalizar != null)
         {
             Finalizar(sender, e);
         }
    }

    /// <summary>
    /// Evento Click del Botón Eliminar
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbn_Eliminar_Click(object sender, EventArgs e)
    {
        //this.Eliminar();                    //Ejecutar la Eliminación del Registro.
        this.Limpiar_Campos();              //Limpia los Campos.
        //this.Cargar_Datos();                //Carga los Datos en la Grilla.
        //this.gv_Datos.SelectedIndex = -1;   //Limpia el Registro seleccionado de la grilla.

        if (Eliminar != null)
        {
            Eliminar(sender, e);
        }
    }

    /// <summary>
    /// Evento Click del Botón Buscar
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbn_Buscar_Click(object sender, EventArgs e)
    {
        //this.div_botones.Visible = false;   //Oculta los Botones de Edición.        

        this.pnl_filtro.Visible = !this.pnl_filtro.Visible;
    }
   
    /// <summary>
    /// Evento Click del Botón Imprimir
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbn_Imprimir_Click(object sender, EventArgs e)
    {
        if (Imprimir != null)
        {
            Imprimir(sender, e);
        }
    }

    /// <summary>
    /// Evento Click del Botón Guardar
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbn_Guardar_Click(object sender, EventArgs e)
    {

        //this.Guardar();
        this.Habilitar_Edicion(false);
        this.Limpiar_Campos();
        //this.Cargar_Datos();
        //this.gv_Datos.SelectedIndex = -1;
        if (Guardar != null)
        {
            Guardar(sender, e);
        }
    }
    /// <summary>
    /// Evento Click del Botón Guardar
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbn_Guardar2_Click(object sender, EventArgs e)
    {

        //this.Guardar();
        //this.Habilitar_Edicion(false);
        //this.Limpiar_Campos();
        //this.Cargar_Datos();
        //this.gv_Datos.SelectedIndex = -1;
        if (Guardar2 != null)
        {
            Guardar2(sender, e);
        }
    }

    /// <summary>
    /// Evento Click del Botón Cancelar
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbn_Cancelar_Click(object sender, EventArgs e)
    {
        this.Habilitar_Edicion(false);
        this.Limpiar_Campos();
        //this.Cargar_Datos();
        //this.gv_Datos.SelectedIndex = -1;

        if (Cancelar != null)
        {
            Cancelar(sender, e);
        }
    }



    protected void btn_Filtro_Click(object sender, EventArgs e)
    {
        if (AplicarFiltro != null)
        {
            AplicarFiltro(sender, e);
        }
    }
    protected void btn_Todos_Click(object sender, EventArgs e)
    {
        this.Limpiar_Filtro();
        this.Habilitar_Edicion(false);
        this.pnl_filtro.Visible = false;
        
        if (AplicarFiltro != null)
        {
            AplicarFiltro(sender, e);
        }
    }


    protected void lb_Boton_1_Click(object sender, EventArgs e)
    {
        if (Boton_1 != null)
        {
            Boton_1(sender, e);
        }
    }

    protected void lb_Boton_2_Click(object sender, EventArgs e)
    {
        if (Boton_2 != null)
        {
            Boton_2(sender, e);
        }
    }

    protected void lb_AsignarLineas_Click(object sender, EventArgs e)
    {
        this.Habilitar_Edicion(true);
        if (AsignarLineas != null)
        {
            AsignarLineas(sender, e);
        }
    }

    protected void lb_NuevaModificativa_Click(object sender, EventArgs e)
    {
        this.hf_accion.Value = "I";
        this.Habilitar_Edicion(true);   //Habilita los Campos.
        this.Limpiar_Campos();          //Limpia los Campos para la Inserción.
        
        if (NuevaModificativa != null)
        {
            NuevaModificativa(sender, e);
        }
    }

    protected void lb_BuscarPersonalizado_Click(object sender, EventArgs e)
    {
        this.Habilitar_Edicion(true);
        if (BuscarPersonalizado != null)
        {
            BuscarPersonalizado(sender, e);
        }
    }
    #endregion

    #region "ADMINISTRACION DE COMPORTAMIENTO DE LOS CONTROLES"
    /// <summary>
    /// Permite Habilitar la Edicion en los Campos del Formulario.
    /// </summary>
    /// <param name="opcion">True: Habilita los Campos. False: Deshabilita los Campos.</param>
    protected void Habilitar_Edicion(bool opcion)
    {
        
        this.lbn_Buscar.Visible = !opcion; // !opcion;  
       // this.lbBuscarPersonalizado.Visible = !opcion; // !opcion;
        this.MostrarImprimir = !opcion;

        if (opcion)
        {
            //this.pnl_filtro.Style["display"] = "none";
            this.pnl_filtro.Visible = false;
        }
        //else
        //{
        //    this.pnl_filtro.Style["display"] = "block";
        //    this.pnl_filtro.Visible = true;
        //}

        this.lbn_Editar.Visible = false;     // !opcion;
        this.lbn_Eliminar.Visible = false;   // !opcion;
        this.lb_Finalizar.Visible = false;
        this.lb_AsignarLineas.Visible = false;
        this.lb_NuevaModificativa.Visible = false;
        this.MostrarNuevo = true;
        this.MostrarGuardar = false;
        this.lbn_Cancelar.Visible = false;
        this.lbBuscarPersonalizado.Visible = false;

        //((master_ajax)(this.Page.Master)).Menu_Principal_Visible = !opcion;
    }

    /// <summary>
    /// Limpiar los valores en los campos del formulario.
    /// </summary>
    protected void Limpiar_Campos()
    {

    }
    protected void ddl_filtro_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (SeleccionarTipoFiltro != null)
        {
            SeleccionarTipoFiltro(sender, e);
        }

        if (this.FiltroTipoLista)
        {
            ddl_Descripcion_Filtro.Visible = true;
            txt_Descripcion_Filtro.Visible = false;
        }
        else
        {
            ddl_Descripcion_Filtro.Visible = false;
            txt_Descripcion_Filtro.Visible = true;
        }
    }

    #endregion

    #region "EVENTOS EXTERNOS"

    public virtual void OnSeleccionarTipoFiltro(object sender, EventArgs e)
    {
        if (SeleccionarTipoFiltro != null)
        {
            SeleccionarTipoFiltro(sender, e);
        }
    }
    public virtual void OnRegresar(object sender, EventArgs e)
    {
        if (Regresar != null)
        {
            Regresar(sender, e);
        }
    }
    public virtual void OnNuevo(object sender, EventArgs e)
    {
        if (Nuevo != null)
        {
            Nuevo(sender, e);
        }
    }
    public virtual void OnEditar(object sender, EventArgs e)
    {
        if (Editar != null)
        {
            Editar(sender, e);
        }
    }

    public virtual void OnFinalizar(object sender, EventArgs e)
    {
        if (Finalizar != null)
        {
            Finalizar(sender, e);
        }
    }
    public virtual void OnEliminar(object sender, EventArgs e)
    {
        if (Eliminar != null)
        {
            Eliminar(sender, e);
        }
    }
    public virtual void OnGuardar(object sender, EventArgs e)
    {
        if (Guardar != null)
        {
            Guardar(sender, e);
        }
    }
    
    public virtual void OnGuardar2(object sender, EventArgs e)
    {
        if (Guardar2 != null)
        {
            Guardar2(sender, e);
        }
    }
    public virtual void OnImprimir(object sender, EventArgs e)
    {
        if (Imprimir != null)
        {
            Imprimir(sender, e);
        }
    }

    public virtual void OnCancelar(object sender, EventArgs e)
    {
        if (Cancelar != null)
        {
            Cancelar(sender, e);
        }
    }
  
    public virtual void OnAplicarFiltro(object sender, EventArgs e)
    {
        if (AplicarFiltro != null)
        {
            AplicarFiltro(sender, e);
        }
    }

    public virtual void OnAsignarLineas(object sender, EventArgs e)
    {
        if (AsignarLineas != null)
        {
            AsignarLineas(sender, e);
        }
    }

    public virtual void OnNuevaModificativa(object sender, EventArgs e)
    {
        if (NuevaModificativa != null)
        {
            NuevaModificativa(sender, e);
        }
    }

    public virtual void OnBuscarPersonalizado(object sender, EventArgs e)
    {
        if (BuscarPersonalizado != null)
        {
            BuscarPersonalizado(sender, e);
        }
    }
    #endregion




}