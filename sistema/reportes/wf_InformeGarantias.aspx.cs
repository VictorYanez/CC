using BLL;
using ENT;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sistema_reportes_wf_InformeGarantias : System.Web.UI.Page
{
    BllContratos bllContratos = new BllContratos();
    int registros_por_pagina = 0;
    bool esPerfilGfi = true;
    List<int?> lstIds = new List<int?>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["IdPerfil"].ToString().ToUpper() == ConfigurationManager.AppSettings["ID_PERFIL_TECNICO"].ToString())
            {
                esPerfilGfi = false;
            }

            CargarContratos();
            CargarAlertasGarantias();
            CargarConcesionarios();
            CargarEstadosGarantias();


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

    private void CargarAlertasGarantias()
    {

        this.ddl_Alertas.DataSource = new BllGarantias().EstadosAlertas();
        this.ddl_Alertas.DataTextField = "Nombre";
        this.ddl_Alertas.DataValueField = "Codigo";
        this.ddl_Alertas.DataBind();
        this.ddl_Alertas.Items.Insert(0, new ListItem("-- TODOS --", "0"));
        this.ddl_Alertas.SelectedIndex = 0;

        if (esPerfilGfi)
        {
            ddl_Alertas.Enabled = false;
        }
    }

    protected void CargarEstadosGarantias()
    {
        BllEstados bllEstados = new BllEstados();
        Estados estados = new Estados();
        List<Estados> lstEstados;

        if (esPerfilGfi)
        {
            lstIds.Add(Convert.ToInt32(ConfigurationManager.AppSettings["ID_ESTADO_ENVIADA_RESGUARDO_GFI"].ToString()));
            lstIds.Add(Convert.ToInt32(ConfigurationManager.AppSettings["ID_ESTADO_EN_RESGUARDO_GFI"].ToString()));
            lstEstados = bllEstados.buscar(estados).Where(x => lstIds.Contains(x.IdEstado)).OrderBy(x => x.Orden).ToList();
        }
        else
        {
            lstEstados = bllEstados.buscar(estados).OrderBy(x => x.Orden).ToList();
        }

        this.lb_FlujosEstados.DataSource = lstEstados;
        this.lb_FlujosEstados.DataTextField = "Nombre";
        this.lb_FlujosEstados.DataValueField = "IdEstado";
        this.lb_FlujosEstados.DataBind();
    }

    protected void CargarDatos()
    {
        ContratosParamsRep parRep = new ContratosParamsRep();

        string idsContratos = getIdsContratos();
        if (idsContratos.Length > 0) parRep.IdsContratos = idsContratos;

        string idsConcesionarios = getIdsConcesionarios();
        if (idsConcesionarios.Length > 0) parRep.IdsConcesionarios = idsConcesionarios;

        string idFlujosEstados = getIdsEstadosFlujos();

        if (idFlujosEstados.Length > 0)
        {
            parRep.IdsFlujoGarantias = idFlujosEstados;
        }
        else
        {
            if (esPerfilGfi)
            {
                parRep.IdsFlujoGarantias = getIdsEstadosFlujos(false);
            }
        }


        if (ddl_Alertas.SelectedValue == "GPV")
            parRep.RegistrosPorVencer = true;

        if (ddl_Alertas.SelectedValue == "GVE")
            parRep.RegistrosVencidos = true;

        if (ddl_Alertas.SelectedValue == "GDP")
            parRep.RegistrosDocPendiente = true;

        if (!String.IsNullOrEmpty(txt_NumeroGarantia.Text)) parRep.NumeroGarantia = txt_NumeroGarantia.Text;

        if (!String.IsNullOrEmpty(txt_FechaIngresoInicial.Text) && !String.IsNullOrEmpty(txt_FechaIngresoFinal.Text))
        {
            parRep.FechaIngresoInicio = Convert.ToDateTime(txt_FechaIngresoInicial.Text);
            parRep.FechaIngresoFin = Convert.ToDateTime(txt_FechaIngresoFinal.Text);
        }

        DataTable dt = bllContratos.ReporteGarantias(parRep);

        this.gv_Datos.DataSource = dt;
        this.gv_Datos.DataBind();

        div_grilla_garantia.Visible = true;
        int cantidad_registros = dt.Rows.Count;
        lbl_ContadorRegistrosGarantias.Text = new Utilidades().ContadorRegistrosGrid(cantidad_registros, registros_por_pagina, gv_Datos);
    }

    protected string getIdsContratos()
    {
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

    protected string getIdsEstadosFlujos(bool? soloSeleccionados = true)
    {
        string ids = "";
        foreach (ListItem listItem in this.lb_FlujosEstados.Items)
        {
            if (Convert.ToBoolean(soloSeleccionados))
            {
                if (listItem.Selected)
                {
                    ids += listItem.Value + ",";
                }
            }
            else
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
            Literal lit_NumeroGarantia = (Literal)e.Row.FindControl("lit_NumeroGarantia");
            Literal lit_FechaVigenciaFinal = (Literal)e.Row.FindControl("lit_FechaVigenciaFinal");

            DateTime fechaVigenciaFinal = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "FechaFin"));
            int dias = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DiasAlertas"));
            int diasParametroVencimiento = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ParamDiasVcto"));
            bool final = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "UltimoEstado"));
            bool pendiente = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "DocPendiente"));

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
    protected void gv_Datos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gv_Datos.PageIndex = e.NewPageIndex;
        this.CargarDatos();
    }
    protected void lb_Imprimir_Click(object sender, EventArgs e)
    {
        string strCmd = "";

        Imprimir imprimir = new Imprimir();
        imprimir.Titulo = "Informe de garantias";
        imprimir.IdReporte = "rpt_garantias";

        //Formando comando SQL
        strCmd = String.Format("pa_br_Reportes @_accion = '{0}'", "GarantiasContrato");

        string idsContratos = getIdsContratos();
        if (idsContratos.Length > 0) strCmd = strCmd += String.Format(", @IdsContratos='{0}'", idsContratos);

        string idsConcesionarios = getIdsConcesionarios();
        if (idsConcesionarios.Length > 0) strCmd = strCmd += String.Format(", @IdsConcesionarios='{0}'", idsConcesionarios);

        string idFlujosEstados = getIdsEstadosFlujos();
        if (idFlujosEstados.Length > 0) strCmd = strCmd += String.Format(", @IdsFlujoGarantias='{0}'", idFlujosEstados);

        if (ddl_Alertas.SelectedValue == "GPV")
            strCmd = strCmd += ", @RegistrosPorVencer = 1";

        if (ddl_Alertas.SelectedValue == "GVE")
            strCmd = strCmd += ", @RegistrosVencidos = 1";

        if (ddl_Alertas.SelectedValue == "GDP")
            strCmd = strCmd += ", @RegistrosDocPendiente = 1";

        if (!String.IsNullOrEmpty(txt_NumeroGarantia.Text)) strCmd = strCmd += String.Format(", @NumeroGarantia='{0}'", txt_NumeroGarantia.Text);

        if (!String.IsNullOrEmpty(txt_FechaIngresoInicial.Text) && !String.IsNullOrEmpty(txt_FechaIngresoFinal.Text))
        {
            strCmd = strCmd += String.Format(", @FechaIngresoInicio='{0}'", Convert.ToDateTime(txt_FechaIngresoInicial.Text).Year + Convert.ToDateTime(txt_FechaIngresoInicial.Text).Month.ToString().PadLeft(2, '0') + Convert.ToDateTime(txt_FechaIngresoInicial.Text).Day.ToString().PadLeft(2, '0'));
            strCmd = strCmd += String.Format(", @FechaIngresoFin='{0}'", Convert.ToDateTime(txt_FechaIngresoFinal.Text).Year + Convert.ToDateTime(txt_FechaIngresoFinal.Text).Month.ToString().PadLeft(2, '0') + Convert.ToDateTime(txt_FechaIngresoFinal.Text).Day.ToString().PadLeft(2, '0'));
        }
        strCmd = strCmd += String.Format(", @UsuarioConsulta='{0}'", Utilidades.GetUserApp());

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
        txt_NumeroGarantia.Text = String.Empty;
        div_grilla_garantia.Visible = false;
        txt_FechaIngresoInicial.Text = String.Empty;
        txt_FechaIngresoFinal.Text = String.Empty;
    }
}