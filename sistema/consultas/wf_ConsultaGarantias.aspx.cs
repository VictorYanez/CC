using BLL;
using ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sistema_consultas_wf_ConsultaGarantias : System.Web.UI.Page
{

    BllGarantias bllGarantias = new BllGarantias();

    int registros_por_pagina = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            this.CargarAlertasGarantias();
            this.CargarEstadosGarantias();

            if (Request.QueryString["estado"] != null)
            {
                ddl_Alertas.SelectedValue = Request.QueryString["estado"].ToString().ToUpper();
            }
       
            CargarDatos();
        }
    }

    private void CargarAlertasGarantias() {

        this.ddl_Alertas.DataSource = new BllGarantias().EstadosAlertas();
        this.ddl_Alertas.DataTextField = "Nombre";
        this.ddl_Alertas.DataValueField = "Codigo";
        this.ddl_Alertas.DataBind();
        this.ddl_Alertas.Items.Insert(0, new ListItem("-- TODOS --", "0"));
        this.ddl_Alertas.SelectedIndex = 0;
    }

    protected void CargarEstadosGarantias()
    {
        BllEstados bllEstados = new BllEstados();
        Estados estados = new Estados();

        this.ddl_Estados.DataSource = bllEstados.buscar(estados).Where(x => x.Final == false).OrderBy(x => x.Orden).ToList();
        this.ddl_Estados.DataTextField = "Nombre";
        this.ddl_Estados.DataValueField = "IdEstado";
        this.ddl_Estados.DataBind();
        this.ddl_Estados.Items.Insert(0, new ListItem("-- TODOS --", "0"));
        this.ddl_Estados.SelectedIndex = 0;
    }

   
    protected void CargarDatos()
    {
        bool? gpv = null;
        bool? gve = null;
        bool? gdp = null;


        if (ddl_Alertas.SelectedValue == "GPV")
            gpv = true;

        if (ddl_Alertas.SelectedValue == "GVE")
            gve = true;

        if (ddl_Alertas.SelectedValue == "GDP")
            gdp = true;

        int idEstado = Convert.ToInt32(ddl_Estados.SelectedValue);
        DataTable dt = bllGarantias.ConsultaGarantias(txt_Numero.Text, idEstado, gpv, gve, gdp);
        this.gv_Datos.DataSource = dt;
        this.gv_Datos.DataBind();
        int cantidad_registros = dt.Rows.Count;
        lbl_ContadorRegistrosGarantias.Text = new Utilidades().ContadorRegistrosGrid(cantidad_registros, registros_por_pagina, gv_Datos);
    }
    protected void gv_Datos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.gv_Datos, "Select$" + e.Row.RowIndex);

            Literal lit_NumeroGarantia = (Literal)e.Row.FindControl("lit_NumeroGarantia");
            Literal lit_FechaVigenciaFinal = (Literal)e.Row.FindControl("lit_FechaVigenciaFinal");

            DateTime fechaVigenciaFinal = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "FechaVigenciaFinal"));
            int dias = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DiasAlertas"));
            int diasParametroVencimiento = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DiasParametroVencimiento"));
            bool final = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Final"));
            bool pendiente = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "DocumentacionPendiente"));

            lit_NumeroGarantia.Text = "<strong>" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Numero")) + "</strong>";

            if (dias > diasParametroVencimiento)
            {
                lit_FechaVigenciaFinal.Text = fechaVigenciaFinal.ToString("dd/MM/yyyy");
            }
            else if (dias <= diasParametroVencimiento && dias > 0)
            {
                lit_FechaVigenciaFinal.Text = "<span class=\"label label-warning\" title=\"Garantía pr&oacute;xima a vencerse.\">" + fechaVigenciaFinal.ToString("dd/MM/yyyy") + "</span>";
            }
            else if (dias <= 0 && final == false)
            {
                lit_FechaVigenciaFinal.Text = "<span class=\"label label-danger\" title=\"Garant&iacute;a vencida\">" + fechaVigenciaFinal.ToString("dd/MM/yyyy") + "</span>";
            }
            else
            {
                lit_FechaVigenciaFinal.Text = fechaVigenciaFinal.ToString("dd/MM/yyyy");
            }

            if (pendiente)
            {
                lit_NumeroGarantia.Text = lit_NumeroGarantia.Text + "&nbsp;<i title=\"Pendiente de entrega de documentos\" class=\"ace-icon purple fa fa-exclamation-triangle bigger-150\"></i>";
            }

            registros_por_pagina = e.Row.RowIndex + 1;
        }
    }
    protected void gv_Datos_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.gv_Datos.SelectedIndex >= 0)
        {
            GridViewRow fila = gv_Datos.SelectedRow;
            int idGarantia = Convert.ToInt32(gv_Datos.DataKeys[fila.RowIndex].Values["IdGarantia"]);
            wuc_InformacionContactos.CargarContactos(idGarantia,0);
            mpe_ModalInformacionContactos.Show();
        }
    }
    protected void gv_Datos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gv_Datos.PageIndex = e.NewPageIndex;
        this.CargarDatos();
    }
    protected void lb_Filtrar_Click(object sender, EventArgs e)
    {
        CargarDatos();
    }
    protected void lb_Reestablecer_Click(object sender, EventArgs e)
    {
        txt_Numero.Text = String.Empty;
        ddl_Estados.SelectedIndex = 0;
        ddl_Alertas.SelectedIndex = 0;
        CargarDatos();
    }
   
}