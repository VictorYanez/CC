using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mop.Seg.BLL.BS3;
using System.Configuration;
using System.Web.Security;
using Mop.Audit.Huellas;
using BLL;
using ENT;
public partial class wuc_login_wucIngresar : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.DefaultButton = this.btnIngresar.UniqueID;

    }
    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        string IdSistema = ConfigurationManager.AppSettings["id_sistema"].ToString();
        WcfSeguridadBS3Client estandar = new WcfSeguridadBS3Client();
        ParSeguridad parSeguridad = new ParSeguridad();

        parSeguridad.Id_Sistema = IdSistema;
        parSeguridad.Id_Usuario = this.txtUsuario.Text;
        parSeguridad.Password = this.txtPassword.Text;

        if(estandar.VerificarUsuario(parSeguridad))
        {
            if (estandar.VerificarUsuarioContrasena(parSeguridad) )
            {
                List<UsuarioPerfiles> lstUsuarioPerfiles = estandar.UsuarioPerfiles(parSeguridad).ToList();
                if (lstUsuarioPerfiles.Count > 0)
                {
                    if(lstUsuarioPerfiles.Count == 1)
                    {
                        this.iniciarSesion(lstUsuarioPerfiles[0].IdPerfil);
                    }
                    else
                    {
                        this.ddlPerfil.DataSource = lstUsuarioPerfiles;
                        this.ddlPerfil.DataBind();

                        this.ddlPerfil.Items.Insert(0, new ListItem("--Seleccione el perfil--", ""));
                        this.ddlPerfil.SelectedIndex = 0;

                       
                        this.divCampos.Style["display"] = "none";
                        //this.divNavegacion.Style["display"] = "none";
                        this.divIngresar.Style["display"] = "none";
                        this.divPerfil.Style["display"] = "block";
                        this.divPerfil.Attributes["class"] = "";
                    }
                }
                else
                {
                    this.lblMensaje.Text = "<br />No posee permisos en el sistema<br /><br />";
                }
            }
            else
            {
                this.lblMensaje.Text = "<br />Contrase&ntilde;a incorrecta.<br /><br />";
            }
        }
        else
        {
            this.lblMensaje.Text = "<br />La cuenta de usuario no existe.<br /><br />";
        }
    }

    protected void ddlPerfil_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.ddlPerfil.SelectedIndex > 0)
        {
            this.iniciarSesion(this.ddlPerfil.SelectedValue);
        }
    }

    protected void iniciarSesion(string IdPerfil)
    {
        Session["IdPerfil"] = IdPerfil;
        Session["Usuario"] = this.txtUsuario.Text;
        

        ParSeguridad parSeguridad = new ParSeguridad();
        WcfSeguridadBS3Client estandar = new WcfSeguridadBS3Client();
        parSeguridad.Id_Usuario = this.txtUsuario.Text;

        List<PersonaUsuario> lstPersonaUsuario = new List<PersonaUsuario>();
        lstPersonaUsuario = estandar.CargarPersonaUsuario(parSeguridad).ToList();
        PersonaUsuario personaUsuario = new PersonaUsuario();

        if (lstPersonaUsuario.Count > 0)
        {
            personaUsuario = lstPersonaUsuario[0];

            Session["IdUsuario"] = personaUsuario.IdUsuario;
            Session["NombreCompleto"] = personaUsuario.NombreCompleto;
            Session["IdPersona"] = personaUsuario.IdPersona;
        }

        Sesion sesion = new Sesion();
        sesion.IdSesionIIS = Session.SessionID;
        sesion.IdUsuario = txtUsuario.Text;
        sesion.IdSistema = ConfigurationManager.AppSettings["id_sistema"].ToString();
        sesion.IdPerfil = IdPerfil;
        sesion.IpIngreso = Request.ServerVariables["REMOTE_ADDR"].ToString();
        sesion.FechaHoraIngreso = DateTime.Now;
        sesion.Hostname = Request.ServerVariables["REMOTE_HOST"].ToString();
        WcfHuellasClient huellas = new WcfHuellasClient();
        sesion.IdSesion = huellas.registrarSesion(sesion);
        Session["sesion"] = sesion;
         
      
        FormsAuthentication.RedirectFromLoginPage(this.txtUsuario.Text, true);
    }

   
}