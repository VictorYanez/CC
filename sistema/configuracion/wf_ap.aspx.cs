using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mop.Seg.BLL.WcfMaestra;
using System.Configuration;

public partial class sistema_configuracion_wf_ap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            this.cargarDatos();
        }
    }

    protected void cargarDatos()
    {
        string IdUsuario = "";
        try
        {
            IdUsuario = Request.Params["IdUsuario"].ToString();
            this.lblMensaje.Visible = false;
            WcfMaestraClient wcf = new WcfMaestraClient();
            ParSeguridad parSeguridad = new ParSeguridad();
            parSeguridad.Id_Usuario = IdUsuario;
            parSeguridad.Id_Sistema = ConfigurationManager.AppSettings["id_sistema"].ToString();

            List<PerfilesDeUsuario> lst = wcf.PerfilesDeUsuario(parSeguridad).ToList();

            this.cbl_Perfiles.DataSource = lst;
            this.cbl_Perfiles.DataBind();

            foreach(ListItem li in this.cbl_Perfiles.Items)
            {
                foreach(PerfilesDeUsuario p in lst)
                {
                    if (p.IdPerfil == li.Value)
                        li.Selected = p.Activo;
                }
            }

        }
        catch
        {
            this.lblMensaje.Visible = true;
            this.lblMensaje.Text = "Parámetros incorrectos";
        }
    }
    protected void lbnAplicar_Click(object sender, EventArgs e)
    {
        WcfMaestraClient wcf = new WcfMaestraClient();
        
        foreach(ListItem li in this.cbl_Perfiles.Items)
        {
            Perfil_Usuario pu = new Perfil_Usuario();
            pu.Sistema = new Sistema();
            pu.Perfil = new Perfil();
            pu.Usuario = new Usuario();

            pu.Sistema.Id_Sistema = ConfigurationManager.AppSettings["id_sistema"].ToString();
            pu.Perfil.Id_Perfil = li.Value;
            pu.Usuario.Id_Usuario = Request.Params["IdUsuario"].ToString();
            pu.Id_Nivel_Usuario = null;

            if (li.Selected)
                wcf.Perfil_Usuario_I(pu);
            else
                wcf.Perfil_Usuario_E(pu);
        }
    }
}