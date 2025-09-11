using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Especiales.DAL;
using System.Configuration;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {

            div_alertas_direccion_legal.Visible = false;
            div_alerta_documento_direccion_legal.Visible = false;
            div_gerencia_financiera.Visible = false;

            if (Session["IdPerfil"].ToString().ToUpper() == ConfigurationManager.AppSettings["ID_PERFIL_TECNICO"].ToString())
            {
                lit_GarantiasPorVencer.Text = new ParDashboard().GarantiasProximasVencer().ToString();
                lit_ContratosPorVencer.Text = new ParDashboard().ContratosProximosVencer().ToString();
                lit_GarantiasVencidas.Text = new ParDashboard().GarantiasVencidas().ToString();
                lit_ContratosVencidos.Text = new ParDashboard().ContratosVencidos().ToString();
                lit_GarantiasConDocumentosPendientes.Text = new ParDashboard().GarantiasDocumentosPendientes().ToString();
                div_alertas_direccion_legal.Visible = true;
                div_alerta_documento_direccion_legal.Visible = true;
            }
            else {
                div_gerencia_financiera.Visible = true;
                lit_PendientesProcesarGfi.Text = new ParDashboard().GarantiasEnviadasResguardo().ToString();
            }
           
        }
    }
    
}