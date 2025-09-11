using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mop.Seg.BLL.WcfMaestra;
public partial class sistema_configuracion_wf_ac : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.CargarDatos();
            this.divCampos.Style["display"] = "block";
            this.divMensaje.Style["display"] = "none";
        }
    }

    protected void CargarDatos()
    {
        this.txt_ContrasenaNueva.Focus();
    }

    protected void lbn_CambiarContrasena_Click(object sender, EventArgs e)
    {
        this.divCampos.Style["display"] = "none";
        this.divMensaje.Style["display"] = "block";
        WcfMaestraClient wcf = new WcfMaestraClient();
        Usuario u = new Usuario();
        u.Id_Usuario = Session["IdUsuario"].ToString();
        u.Clave = this.txt_ContrasenaNueva.Text;

        bool ok = false;

        try
        {
            if (wcf.Usuario_A(u) > 0)
                ok = true;
        }
        catch
        {
            ok = false;
        }

        if (ok)
        {
            this.divMensaje.Attributes["class"] = "alert alert-success";
            this.lit_Mensaje.Text = "Contrase&ntilde;a actualizada correctamente.";
        }
        else
        {
            this.divMensaje.Attributes["class"] = "alert alert-danger";
            this.lit_Mensaje.Text = "Error al actualizar la contrase&ntilde;a,<br><a href='" + HttpContext.Current.Request.Url.AbsoluteUri + "'>Intente de nuevo.</a>";
        }

    }
}