using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mop.Seg.BLL.BS3;

public partial class wuc_master_wucMenuPrincipal : System.Web.UI.UserControl
{

    public string TituloFormulario
    {
        get { return this.hdfTitulo.Value;  }
    }

    //public string UrlAyudaManual
    //{
    //    get { return this.hdfUrlAyudaManual.Value; }
    //    set { this.hdfUrlAyudaManual.Value = value; }
    //}
    //public string UrlAyudaVideo
    //{
    //    get { return this.hdfUrlAyudaVideo.Value; }
    //    set { this.hdfUrlAyudaVideo.Value = value; }
    //}


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void litMenu_Init(object sender, EventArgs e)
    {
        //if(this.URL() != "/login.aspx")
            this.cargarMenu();
    }

    protected string URL()
    {
        return HttpContext.Current.Request.CurrentExecutionFilePath;
    }

    protected void cargarMenu()
    {
        int? ItemId = null;

        try
        {
            ItemId = Convert.ToInt32(Request.Params["ItemID"].ToString());
        }
        catch
        {
            ItemId = null;
            string url = Request.Url.AbsolutePath;
            if (url.ToLower() != "/default.aspx")
            {
                //Response.Redirect("/");
            }

        }

        try
        {
            string idSistema = ConfigurationManager.AppSettings["id_sistema"].ToString();
            ParSeguridad parSeguridad = new ParSeguridad();
            parSeguridad.Id_Sistema = idSistema;
            parSeguridad.Id_Perfil = Session["IdPerfil"].ToString();
            parSeguridad.Id_Modulo = ItemId.ToString();
			parSeguridad.Id_Menu = ItemId;

            WcfSeguridadBS3Client seg = new WcfSeguridadBS3Client();
            this.litMenu.Text = seg.MenuPrincipal(parSeguridad);

            if (ItemId == null)
            {
                this.hdfTitulo.Value = ConfigurationManager.AppSettings["nombre_sistema"].ToString();
                //this.hdfUrlAyudaManual.Value = "";
                //this.hdfUrlAyudaVideo.Value = "";
            }
            else
            {
                parSeguridad.Id_Menu = ItemId;
                this.hdfTitulo.Value = seg.NombreFormulario(parSeguridad);
            }
        }
        catch
        {
            Response.Redirect("/login.aspx");
        }

    }
    
}