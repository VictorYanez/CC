using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class wuc_master_wucReporte : System.Web.UI.UserControl
{

    //Imprimir imprimir = new Imprimir();
    public Imprimir Imprimir { get; set; }

    public void Mostar(bool opcion)
    {
        if (opcion)
        {
            Session["Imprimir"] = Imprimir;
            this.lblReporteTitulo.Text = Imprimir.Titulo;

            string url = "/sistema/reportes/wfReporte.aspx";
            this.ifmReporte.Attributes["src"] = url + "?" + DateTime.Now.ToString("HHmmssfff");

            this.lb_pdf.NavigateUrl = url + "?tipo=pdf";
            this.lb_doc.NavigateUrl = url + "?tipo=doc";
            this.lb_xls.NavigateUrl = url + "?tipo=xls";

            this.lb_doc.Visible = false;

            if (Session["IdPerfil"].ToString().ToUpper() != ConfigurationManager.AppSettings["ID_PERFIL_TECNICO"].ToString())
            {
                this.lb_xls.Visible = true;
                this.lb_doc.Visible = true;
            }
            else
            {
                this.lb_xls.Visible = false;
                this.lb_doc.Visible = false;
            }


            this.pnlReporte.CssClass = "modal-dialog modal-ayuda";
            this.mdlReporte.Show();
        }
        else
        {
            this.mdlReporte.Hide();
        }
    }


    //public string IdReporte
    //{
    //    get { return this.hdfIdReporte.Value; }
    //    set { this.hdfIdReporte.Value = value; }
    //}
    //public string SqlPrincipal
    //{
    //    get { return this.hdfSqlPrincipal.Value; }
    //    set { this.hdfSqlPrincipal.Value = value; }
    //}
    //public List<string> SqlSubReportes { get; set; }
    //public CrystalDecisions.Shared.PaperSize TamanoPapel { get; set; }
    //public CrystalDecisions.Shared.PaperOrientation Orientacion { get; set; }


    //public Panel pnlMensaje
    //{
    //    get { return this.pnl_reporte_cuerpo; }
    //    set { this.pnl_reporte_cuerpo = value; }
    //}

    //public Panel Cuerpo
    //{
    //    get { return this.pnl_reporte_cuerpo; }
    //    set { this.pnl_reporte_cuerpo = value; }
    //}
    //public System.Web.UI.HtmlControls.HtmlGenericControl Marco
    //{
    //    get { return this.ifmReporte; }
    //    set { this.ifmReporte = value; }
    //}


    //public string Mensaje
    //{
    //    get { return this.lit_reporte.Text; }
    //    set { this.lit_reporte.Text = value; }
    //}
    //public string Icono
    //{
    //    get { return this.i.Attributes["class"].ToString(); }
    //    set
    //    {
    //        this.i.Attributes["class"] = value + " icon-white";
    //        //this.i_tit.Attributes["class"] = value;
    //    }
    //}
    //public string Titulo
    //{
    //    get { return this.lblReporteTitulo.Text; }
    //    set { this.lblReporteTitulo.Text = value; }
    //}
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //protected void lb_cerrar_Click(object sender, EventArgs e)
    //{
    //    this.mdlReporte.Hide();
    //}
}