using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
public partial class sistema_reportes_wfReporte : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack) {
            this.Generar_Reporte();
       }
      
        //try
        //{
        //    this.Generar_Reporte();
        //}
        //catch
        //{
        //    Response.Write("<h2>Problemas con el informe</h2>");
        //}       

    }

    protected void Generar_Reporte()
    {
        string tipo;
        try
        {
            tipo = Request.Params["tipo"].ToString();
        }
        catch
        {
            tipo = "vistaprevia";
        }

        CrystalDecisions.Shared.ParameterValues pv = new CrystalDecisions.Shared.ParameterValues();

        Imprimir imprimir = new Imprimir();
        imprimir = (Imprimir)(Session["Imprimir"]);
        DAL.Conexion conexion = new DAL.Conexion();
        
        this.Page.Title = imprimir.Titulo;
        crsReporte.Report.FileName = imprimir.IdReporte + ".rpt";
        DataTable dt = new DataTable();
        dt = conexion.Seleccionar(imprimir.SqlPrincipal);
        crsReporte.ReportDocument.SetDataSource(dt);
       
        crsReporte.ReportDocument.PrintOptions.PaperSize = imprimir.TamanoPapel;
        crsReporte.ReportDocument.PrintOptions.PaperOrientation = imprimir.Orientacion;
        
      
        try
        {
            for (int i = 0; i < imprimir.ColeccionParametros.Count; i++)
            {
                (crsReporte.ReportDocument.ReportDefinition.ReportObjects[imprimir.ColeccionParametros[i].NombreParametro] as TextObject).Text = imprimir.ColeccionParametros[i].ValorParametro;
            }
        }
        catch
        {

        }

        try
        {
            for (int i = 0; i < imprimir.SqlSubReportes.Count; i++)
            {
                crsReporte.ReportDocument.Subreports[i].SetDataSource(conexion.Seleccionar(imprimir.SqlSubReportes[i]));
            }
        }
        catch
        {

        }

        string nombre_archivo = "";
       
        if (String.IsNullOrEmpty(imprimir.NombreArchivoDescarga))
        {
            nombre_archivo = imprimir.IdReporte + "__" + DateTime.Now.ToShortDateString().Replace("/", "_");
        }
        else 
        {
            nombre_archivo = imprimir.NombreArchivoDescarga;
        }

        switch (tipo)
        {
            case "pdf":
                {
                    this.crsReporte.ReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, nombre_archivo);
                    break;
                }
            case "doc":
                {
                    this.crsReporte.ReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.WordForWindows, Response, true, nombre_archivo);
                    break;
                }
            case "xls":
                {
                    this.crsReporte.ReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.Excel, Response, true, nombre_archivo);
                    break;
                }
            case "printer":
                {
                    this.crsReporte.ReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.RichText, Response, false, nombre_archivo);
                    break;
                }
            default:
                {
                    this.crsReporte.ReportDocument.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, false, nombre_archivo);
                    break;
                }
        }


    }


}