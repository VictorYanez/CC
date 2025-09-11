using Mop.Audit.Huellas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class wuc_master_wucEncUsuario : System.Web.UI.UserControl
{

   
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void litUsuario_Init(object sender, EventArgs e)
    {
        try
        {
            this.litUsuario.Text = Session["Usuario"].ToString();
            this.litPerfil.Text = Session["IdPerfil"].ToString();
            this.imgFoto.ImageUrl = "http://std.mop.gob.sv/ws/rh/foto/foto.aspx?" + Session["IdPersona"].ToString();
            this.imgFoto.AlternateText = Session["NombreCompleto"].ToString();
            this.imgFoto.ToolTip = Session["NombreCompleto"].ToString();
           
            if (Session["IdPerfil"].ToString().ToUpper() == ConfigurationManager.AppSettings["ID_PERFIL_TECNICO"].ToString()) {
                li_Manual.Visible = true;
            }
           
        }
        catch
        {
            Response.Redirect("/login.aspx");
        }
    }
    protected void lbnCerrarSesion_LoggedOut(object sender, EventArgs e)
    {
        try
        {
            Sesion sesion = (Sesion)(Session["sesion"]);
            sesion.FechaHoraSalida = DateTime.Now;
            WcfHuellasClient huellas = new WcfHuellasClient();
            huellas.actualizarSesion(sesion);
        }
        catch
        {
        }
        Response.Redirect("~/login.aspx");

    }
}