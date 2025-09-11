using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Mop.Seg.BLL;
using System.Configuration;

public partial class wuc_login_wucRestablecer : System.Web.UI.UserControl
{
    WcfSeguridadClient wcf = new WcfSeguridadClient();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lbnSolicitarCambioContrasenia_Click(object sender, EventArgs e)
    {
         bool isHuman = this.cap_Restablecer.Validate(this.txt_CapRestablecer.Text);

         this.txt_CapRestablecer.Text = null; // clear previous user input

        if (isHuman)
        {
            if (this.ValidarCorreo())
            {
                this.EnviarSolicitud();
            }
            else
            {

            }
            
        }

    }

    private string NombreSistema
    {
        get { return ConfigurationManager.AppSettings["nombre_sistema"].ToString(); }
    }

    protected bool ValidarCorreo()
    {
        bool ok = false;
        //WcfSeguridadClient wcf = new WcfSeguridadClient();
        ok = wcf.ValidarCorreo(this.txt_Correo.Text);

        return ok;
    }
    protected void EnviarSolicitud()
    {
        
        Correo correo = new Correo();
        correo.Html = true;

        correo.Asunto = "Solicitud de cambio de contraseña";

        correo.Para = new Contacto[1] { new Contacto() };
        correo.Para[0].DireccionCorreo = this.txt_Correo.Text;

        correo.De = new Contacto();
        correo.De.DireccionCorreo = "sistemasti@mop.gob.sv";
        correo.De.NombreCompleto = this.NombreSistema;

        correo.CC = new Contacto[] { };
        correo.CCO = new Contacto[] { new Contacto() };
        correo.CCO[0].DireccionCorreo = "edwin.paredes@mop.gob.sv";

        //correo.Cuerpo = "Invitación al evento " + this.gv_Cursos.SelectedDataKey["Nombre"].ToString();
        correo.Cuerpo = this.CuerpoMensaje();

        if (wcf.EnviarCorreo(correo))
        {            
            this.lit_Mensaje.Text = "Mensaje enviado";
            this.txt_Correo.Text = "";
            this.txt_CapRestablecer.Text = "";
        }
        else
        {
            this.lit_Mensaje.Text = "No enviado";
        }
    }

    protected string CuerpoMensaje()
    {
        SolicitudContrasena sc = wcf.SolicitarContrasena(this.txt_Correo.Text);

        StringBuilder s = new StringBuilder();
        s.Append("<p>Buen día,</p>");
        s.AppendFormat(@"   <p>Hemos recibido una solicitud para el cambio de contraseña en el sistema {0}.</p>
                            <p>Para continuar el proceso, <a href='{1}{2}'>confirme que ha recibido este mensaje haciendo clic aqu&iacute;.</a></p>"
                        ,this.NombreSistema
                        ,"http://tutor.mop.gob.sv/public/CambiarContrasena.aspx?"
                        ,sc.Clave.Replace("-","").ToLower()
                 
                 );
            
        return s.ToString();
    }
   
}