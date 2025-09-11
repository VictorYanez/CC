using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Mop.Audit.Huellas;

public partial class master_ajax : System.Web.UI.MasterPage
{

    #region PROPIEDADES

    public string IdSistema
    {
        get
        {
            return ConfigurationManager.AppSettings["id_sistema"].ToString();
        }

    }

    public string NombreSistema
    {
        get { return ConfigurationManager.AppSettings["nombre_sistema"].ToString();  }
    }

    public string Usuario
    {
        get 
        {
            try { return Session["Usuario"].ToString(); }
            catch { return null; Response.Redirect("/login.aspx"); }
        }
    }
    public string IdUsuario
    {
        get
        {
            try { return Session["IdUsuario"].ToString(); }
            catch { return null; Response.Redirect("/login.aspx"); }
        }
    }

    public string IdPerfil
    {
        get
        {
            try { return Session["IdPerfil"].ToString(); }
            catch { return null; Response.Redirect("/login.aspx"); }
        }
    }

    public int? IdPersona
    {
        get
        {
            try { return Convert.ToInt32(Session["IdPersona"].ToString()); }
            catch { Response.Redirect("/login.aspx"); return null; }
        }
    }

    public string NombreUsuario
    {
        get
        {
            try { return Session["NombreCompleto"].ToString(); }
            catch { Response.Redirect("/login.aspx"); return null;  }
        }
    }

    public string NombreUnidad
    {
        get
        {
            try { return Session["NombreUnidad"].ToString(); }
            catch { return null;  }
        }
    }
      
    //public string UrlAyudaManual
    //{
    //    get { return this.wucMenuPrincipal.UrlAyudaManual; }
    //}
    //public string UrlAyudaVideo
    //{
    //    get { return this.wucMenuPrincipal.UrlAyudaVideo; }
    //}

    public Imprimir Imprimir
    {
        get { return this.wucReporte.Imprimir; }
        set 
        { 
            this.wucReporte.Imprimir = value;
            this.wucReporte.Mostar(true);
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            this.litTitulo.Text = this.wucMenuPrincipal.TituloFormulario;
            this.titPrincipal.Text = this.litTitulo.Text;
            lit_Unidad.Text = NombreUnidad;
            //this.wucMenuShortcut.UrlAyudaManual = this.wucMenuPrincipal.UrlAyudaManual;
            //this.wucMenuShortcut.UrlAyudaVideo = this.wucMenuPrincipal.UrlAyudaVideo;
            this.RegistrarNavegacion();
        }
    }

    /// <summary>
    /// Bitácora de Navegación
    /// </summary>
    protected void RegistrarNavegacion()
    {
        
        try
        {
            Sesion sesion = (Sesion)(Session["sesion"]);
            Navegacion navegacion = new Navegacion();
            navegacion.Sesion = sesion;
            navegacion.IdSesionIIS = Session.SessionID;
            navegacion.Url = HttpContext.Current.Request.Url.ToString();
            navegacion.Fecha = DateTime.Now;
            WcfHuellasClient huellas = new WcfHuellasClient();
            navegacion.IdNavegacion = huellas.registrarNavegacion(navegacion);
            Session["navegacion"] = navegacion;
        }
        catch
        {
            Response.Redirect("~/login.aspx");
        }

        
    }

    protected void cargarTitulo()
    {

    }

    
    public string MsgInfo
    {
        set 
        {
            this.wucMensaje.MensajeTitulo = "<i class='fa fa-info-circle'></i> Informaci&oacute;n";
            this.wucMensaje.MensajeTexto = value;
            this.wucMensaje.Tipo = "alert alert-info";
            this.wucMensaje.Mostar(true);
        }
    }

    public string MsgSucces
    {
        set
        {
            this.wucMensaje.MensajeTitulo = "<i class='fa fa-check-square-o'></i> Correcto";
            this.wucMensaje.MensajeTexto = value;
            this.wucMensaje.Tipo = "alert alert-success";
            this.wucMensaje.Mostar(true);
        }
    }
    
    public string MsgWarning
    {
        set
        {
            this.wucMensaje.MensajeTitulo = "<i class='fa fa-exclamation-circle'></i> Atenci&oacute;n";
            this.wucMensaje.MensajeTexto = value;
            this.wucMensaje.Tipo = "alert alert-warning";
            this.wucMensaje.Mostar(true);
        }
    }

    public string MsgDanger
    {
        set
        {
            this.wucMensaje.MensajeTitulo = "<i class='fa fa-bell'></i> Error";
            this.wucMensaje.MensajeTexto = value;
            this.wucMensaje.Tipo = "alert alert-danger";
            this.wucMensaje.Mostar(true);
        }
    }
}
