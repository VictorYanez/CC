using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using ENT;
using System.Data;
public partial class sistema_consultas_wf_ConsultaContratos : System.Web.UI.Page
{
    BllContratos bllContratos = new BllContratos();
    int registros_por_pagina = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarConcesionarios();
            CargarAlertasContratos();
            
            if (Request.QueryString["estado"] != null)
            {
                ddl_Alertas.SelectedValue = Request.QueryString["estado"].ToString().ToUpper();
            }

            CargarDatos();
        }
    }

    protected void CargarConcesionarios()
    {
        Concesionarios concesionario = new Concesionarios();
        BllConcesionarios bllconcesionarios = new BllConcesionarios();

        List<Concesionarios> lst_Concesionarios = bllconcesionarios.buscar(concesionario);
        this.ddl_Concesionarios.DataSource = lst_Concesionarios;
        this.ddl_Concesionarios.DataTextField = "Nombre";
        this.ddl_Concesionarios.DataValueField = "IdConcesionario";
        this.ddl_Concesionarios.DataBind();
        this.ddl_Concesionarios.Items.Insert(0, new ListItem("-- TODOS --", "0"));
        this.ddl_Concesionarios.SelectedIndex = 0;
   }

    private void CargarAlertasContratos()
    {
        this.ddl_Alertas.DataSource = new BllContratos().EstadosAlertas();
        this.ddl_Alertas.DataTextField = "Nombre";
        this.ddl_Alertas.DataValueField = "Codigo";
        this.ddl_Alertas.DataBind();
        this.ddl_Alertas.Items.Insert(0, new ListItem("-- TODOS --", "0"));
        this.ddl_Alertas.SelectedIndex = 0;
    }
    protected void CargarDatos()
    {
        Contratos contratos = new Contratos();
        contratos.IdContratoDepende = new Contratos();

        bool? cpv = null;
        bool? cve = null;

        int idConcesionario = Convert.ToInt32(ddl_Concesionarios.SelectedValue);

        if (ddl_Alertas.SelectedValue == "CPV")
            cpv = true;

        if (ddl_Alertas.SelectedValue == "CVE")
            cve = true;

        DataTable dt = bllContratos.ConsultaContratos(txt_Numero.Text, idConcesionario, cpv, cve);
        this.gv_Datos.DataSource = dt;
        this.gv_Datos.DataBind();

        int cantidad_registros = dt.Rows.Count;
        lbl_ContadorRegistros.Text = new Utilidades().ContadorRegistrosGrid(cantidad_registros, registros_por_pagina, gv_Datos);
    }

   
    protected void gv_Datos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.gv_Datos, "Select$" + e.Row.RowIndex);

            Literal lit_CantidadGarantias = (Literal)e.Row.FindControl("lit_CantidadGarantias");
            Literal lit_FechaVigenciaFinalContrato = (Literal)e.Row.FindControl("lit_FechaVigenciaFinalContrato");
            Literal lit_NumeroContrato = (Literal)e.Row.FindControl("lit_NumeroContrato");
            Literal lit_CantidadLineas = (Literal)e.Row.FindControl("lit_CantidadLineas");
            Literal lit_CantidadLineasInactivas = (Literal)e.Row.FindControl("lit_CantidadLineasInactivas");


            int IdContrato = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IdContrato"));
            int diasParametroVencimiento = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DiasParametroVencimiento"));
            DateTime fechaVigenciaFinal = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "FechaVigenciaFinal"));
            int dias = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DiasAlertas"));
            int modificativa = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Modificativa"));

            if (modificativa > 0)
            {

                lit_NumeroContrato.Text = "<strong>" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Numero")) + "</strong>&nbsp;<span class=\"label label-sm label-grey arrowed-in-right arrowed-in\" title=\"Modificativa\">" + modificativa.ToString() + "</div>";
            }
            else
            {
                lit_NumeroContrato.Text = "<strong>" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Numero")) + "</strong>";
            }

            if (dias > diasParametroVencimiento)
            {
                lit_FechaVigenciaFinalContrato.Text = fechaVigenciaFinal.ToString("dd/MM/yyyy");
            }
            else if (dias <= diasParametroVencimiento && dias > 0)
            {
                lit_FechaVigenciaFinalContrato.Text = "<span class=\"label label-warning\" title=\"Contrato próximo a vencerse.\">" + fechaVigenciaFinal.ToString("dd/MM/yyyy") + "</span>";
            }
            else if (dias <= 0)
            {
                lit_FechaVigenciaFinalContrato.Text = "<span class=\"label label-danger\" title=\"Contrato vencida\">" + fechaVigenciaFinal.ToString("dd/MM/yyyy") + "</span>";
            }
            else
            {
                lit_FechaVigenciaFinalContrato.Text = fechaVigenciaFinal.ToString("dd/MM/yyyy");
            }

            lit_CantidadGarantias.Text = new BllContratos().CantidadGarantiasContrato(IdContrato).ToString();
            lit_CantidadLineas.Text = new BllContratos().CantidadLineasContrato(IdContrato, true).ToString();
            lit_CantidadLineasInactivas.Text = new BllContratos().CantidadLineasContrato(IdContrato, false).ToString();

            registros_por_pagina = e.Row.RowIndex + 1;
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
        ddl_Concesionarios.SelectedIndex = 0;
        ddl_Alertas.SelectedIndex = 0;
        CargarDatos();
    }
    protected void gv_Datos_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.gv_Datos.SelectedIndex >= 0)
        {
            GridViewRow fila = gv_Datos.SelectedRow;
            int idContrato = Convert.ToInt32(gv_Datos.DataKeys[fila.RowIndex].Values["IdContrato"]);
            wuc_InformacionContactos.CargarContactos(0, idContrato);
            mpe_ModalInformacionContactos.Show();
        }
    }
}