using BLL;
using ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sistema_reportes_wf_InformeContratos : System.Web.UI.Page
{
    BllContratos bllContratos = new BllContratos();
    int registros_por_pagina = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarContratos();
            CargarAlertasContratos();
            CargarConcesionarios();
            CargarEstadosGarantias();
            CargarDisenosReportes();
        }
    }

    protected void CargarContratos()
    {
        Contratos contratos = new Contratos();
        BllContratos bllcontratos = new BllContratos();
        contratos.Finalizado = false;

        this.lb_Contratos.DataSource = bllcontratos.ContratosCodigoNombre();
        this.lb_Contratos.DataTextField = "Numero";
        this.lb_Contratos.DataValueField = "IdContrato";
        this.lb_Contratos.DataBind();
    }
    protected void CargarConcesionarios()
    {
        Concesionarios concesionario = new Concesionarios();
        BllConcesionarios bllconcesionarios = new BllConcesionarios();

        List<Concesionarios> lst_Concesionarios = bllconcesionarios.buscar(concesionario);
        this.lb_Concesionarios.DataSource = lst_Concesionarios;
        this.lb_Concesionarios.DataTextField = "Abreviatura";
        this.lb_Concesionarios.DataValueField = "IdConcesionario";
        this.lb_Concesionarios.DataBind();
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

    protected void CargarEstadosGarantias()
    {
        BllEstados bllEstados = new BllEstados();
        Estados estados = new Estados();

        this.lb_FlujosEstados.DataSource = bllEstados.buscar(estados).OrderBy(x => x.Orden).ToList();
        this.lb_FlujosEstados.DataTextField = "Nombre";
        this.lb_FlujosEstados.DataValueField = "IdEstado";
        this.lb_FlujosEstados.DataBind();
    }

    private void CargarDisenosReportes()
    {
        this.ddl_DisenosReporte.Items.Insert(0, new ListItem("-- SELECCIONE --", "0"));
        this.ddl_DisenosReporte.Items.Insert(1, new ListItem("CONTRATOS", "rpt_contratos_simple;Contratos"));
        this.ddl_DisenosReporte.Items.Insert(2, new ListItem("CONTRATOS Y GARANTÍAS", "rpt_contratos_garantias;ContratosGarantias"));
        this.ddl_DisenosReporte.SelectedIndex = 0;
    }

    protected void CargarDatos()
    {
        ContratosParamsRep parRep = new ContratosParamsRep();
     
        string idsContratos = getIdsContratos();
        if (idsContratos.Length > 0) parRep.IdsContratos = idsContratos;

        string idsConcesionarios = getIdsConcesionarios();
        if (idsConcesionarios.Length > 0) parRep.IdsConcesionarios = idsConcesionarios;

        string idFlujosEstados = getIdsEstadosFlujos();
        if (idFlujosEstados.Length > 0) parRep.IdsFlujoGarantias = idFlujosEstados;

        if (ddl_Alertas.SelectedValue == "CPV")
            parRep.RegistrosPorVencer = true;

        if (ddl_Alertas.SelectedValue == "CVE")
            parRep.RegistrosVencidos = true;

        if (cb_ContratosFinalizados.Checked) { parRep.ContratoFinalizado = true; }
        
        DataTable dt = bllContratos.ReporteContratos(parRep);

        this.gv_Datos.DataSource = dt;
        this.gv_Datos.DataBind();

        div_grilla_garantia.Visible = true;
        int cantidad_registros = dt.Rows.Count;
        lbl_ContadorRegistros.Text = new Utilidades().ContadorRegistrosGrid(cantidad_registros, registros_por_pagina, gv_Datos);
    }

    protected string getIdsContratos() {
        string ids = "";
        foreach (ListItem listItem in this.lb_Contratos.Items)
        {
            if (listItem.Selected)
            {
                ids += listItem.Value + ",";
            }
        }
        return ids;
    }

    protected string getIdsConcesionarios()
    {
        string ids = "";
        foreach (ListItem listItem in this.lb_Concesionarios.Items)
        {
            if (listItem.Selected)
            {
                ids += listItem.Value + ",";
            }
        }
        return ids;
    }

    protected string getIdsEstadosFlujos()
    {
        string ids = "";
        foreach (ListItem listItem in this.lb_FlujosEstados.Items)
        {
            if (listItem.Selected)
            {
                ids += listItem.Value + ",";
            }
        }
        return ids;
    }


    protected void gv_Datos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Literal lit_CantidadGarantias = (Literal)e.Row.FindControl("lit_CantidadGarantias");
            Literal lit_FechaVigenciaFinalContrato = (Literal)e.Row.FindControl("lit_FechaVigenciaFinalContrato");
            Literal lit_NumeroContrato = (Literal)e.Row.FindControl("lit_NumeroContrato");
            Literal lit_CantidadLineas = (Literal)e.Row.FindControl("lit_CantidadLineas");
            Literal lit_CantidadLineasInactivas = (Literal)e.Row.FindControl("lit_CantidadLineasInactivas");


            int IdContrato = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IdContrato"));
            int diasParametroVencimiento = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ParamDiasVctoContrato"));
            DateTime fechaVigenciaFinal = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "FechaFinContrato"));
            int dias = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DiasAlertasContrato"));
            int modificativa = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ModificativaContrato"));
            bool finalizado = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Finalizado"));

            if (modificativa > 0)
            {
                lit_NumeroContrato.Text = "<strong>" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "NumeroContrato")) + "</strong>&nbsp;<span class=\"label label-sm label-grey arrowed-in-right arrowed-in\" title=\"Modificativa\">" + modificativa.ToString() + "</div>";
            }
            else
            {
                lit_NumeroContrato.Text = "<strong>" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "NumeroContrato")) + "</strong>";
            }

            if (dias > diasParametroVencimiento)
            {
                lit_FechaVigenciaFinalContrato.Text = fechaVigenciaFinal.ToString("dd/MM/yyyy");
            }
            else if (dias <= diasParametroVencimiento && dias > 0)
            {
                lit_FechaVigenciaFinalContrato.Text = "<span class=\"label label-warning\" title=\"Contrato próximo a vencerse.\">" + fechaVigenciaFinal.ToString("dd/MM/yyyy") + "</span>";
            }
            else if (dias <= 0 && finalizado == false)
            {
                lit_FechaVigenciaFinalContrato.Text = "<span class=\"label label-danger\" title=\"Contrato vencida\">" + fechaVigenciaFinal.ToString("dd/MM/yyyy") + "</span>";
            }
            else
            {
                lit_FechaVigenciaFinalContrato.Text = fechaVigenciaFinal.ToString("dd/MM/yyyy");
            }

            if (finalizado)
                lit_NumeroContrato.Text = lit_NumeroContrato.Text + " <span class=\"label arrowed label-light\" >Finalizado</span>";

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
    protected void lb_Imprimir_Click(object sender, EventArgs e)
    {

        string strCmd = "";
        string nombreReporte = "";
        string accionSp = "";
        
        if (ddl_DisenosReporte.SelectedValue != "0")
        {
            nombreReporte = ddl_DisenosReporte.SelectedValue.ToString().Split(';')[0].Trim(); //Nombre del reporte
            accionSp = ddl_DisenosReporte.SelectedValue.ToString().Split(';')[1].Trim(); //Acción del procedimiento almacenado
        }
        
        Imprimir imprimir = new Imprimir();
        imprimir.Titulo = "Informe de contratos";
        imprimir.IdReporte = nombreReporte;

        //Formando comando SQL
        strCmd = String.Format("pa_br_Reportes @_accion = '{0}'", accionSp);
        
        string idsContratos = getIdsContratos();
        if (idsContratos.Length > 0) strCmd = strCmd += String.Format(", @IdsContratos='{0}'",idsContratos);

        string idsConcesionarios = getIdsConcesionarios();
        if (idsConcesionarios.Length > 0) strCmd = strCmd += String.Format(", @IdsConcesionarios='{0}'",idsConcesionarios);

        string idFlujosEstados = getIdsEstadosFlujos();
        if (idFlujosEstados.Length > 0) strCmd = strCmd += String.Format(", @IdsFlujoGarantias='{0}'",idFlujosEstados);

        if (ddl_Alertas.SelectedValue == "CPV")
            strCmd = strCmd += ", @RegistrosPorVencer = 1";

        if (ddl_Alertas.SelectedValue == "CVE")
            strCmd = strCmd += ", @RegistrosVencidos = 1";

        if (cb_ContratosFinalizados.Checked) {
            strCmd = strCmd += ", @ContratoFinalizado = 1";
        }

        strCmd = strCmd += String.Format(", @UsuarioConsulta='{0}'",Utilidades.GetUserApp());

        //Pasando comando a reporte
        imprimir.SqlPrincipal = strCmd;

        imprimir.TamanoPapel = CrystalDecisions.Shared.PaperSize.PaperLetter;
        imprimir.Orientacion = CrystalDecisions.Shared.PaperOrientation.Landscape;
        Session["Imprimir"] = null;
        this.Master.Imprimir = imprimir;
    }
    protected void lb_Filtrar_Click(object sender, EventArgs e)
    {
        CargarDatos();
    }
    protected void lb_Reestablecer_Click(object sender, EventArgs e)
    {
        ddl_Alertas.SelectedIndex = 0;
        lb_Contratos.ClearSelection();
        lb_Concesionarios.ClearSelection();
        lb_FlujosEstados.ClearSelection();
        ddl_DisenosReporte.SelectedIndex = 0;
        cb_ContratosFinalizados.Checked = false;
        div_grilla_garantia.Visible = false;
    }
}