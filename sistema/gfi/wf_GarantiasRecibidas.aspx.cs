using BLL;
using ENT;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sistema_gfi_wf_GarantiasRecibidas : System.Web.UI.Page
{
    BllGarantias bllGarantias = new BllGarantias();

    int registros_por_pagina = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarDatos();
        }
    }

    protected void CargarDatos()
    {
        bool? gpv = false;
        bool? gve = false;
        bool? gdp = false;

        int idEstado = Convert.ToInt32(ConfigurationManager.AppSettings["ID_ESTADO_ENVIADA_RESGUARDO_GFI"].ToString());
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
            Literal lit_NumeroGarantia = (Literal)e.Row.FindControl("lit_NumeroGarantia");
            Literal lit_FechaVigenciaFinal = (Literal)e.Row.FindControl("lit_FechaVigenciaFinal");
            DateTime fechaVigenciaFinal = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "FechaVigenciaFinal"));

            lit_NumeroGarantia.Text = "<strong>" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Numero")) + "</strong>";
            lit_FechaVigenciaFinal.Text = fechaVigenciaFinal.ToString("dd/MM/yyyy");

            registros_por_pagina = e.Row.RowIndex + 1;
        }
    }

    protected void gv_Datos_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.gv_Datos.SelectedIndex >= 0)
        {

        }
    }
    protected void gv_Datos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        RememberOldValues();
        this.gv_Datos.PageIndex = e.NewPageIndex;
        this.CargarDatos();
        RePopulateValues();
    }

    private void RememberOldValues()
    {
        ArrayList categoryIDList = new ArrayList();
        int index = -1;
        foreach (GridViewRow row in gv_Datos.Rows)
        {
            index = (int)gv_Datos.DataKeys[row.RowIndex].Value;
            bool result = ((CheckBox)row.FindControl("cb_Garantia")).Checked;

            // Check in the Session
            if (Session["CHECKED_ITEMS"] != null)
                categoryIDList = (ArrayList)Session["CHECKED_ITEMS"];
            if (result)
            {
                if (!categoryIDList.Contains(index))
                    categoryIDList.Add(index);
            }
            else
                categoryIDList.Remove(index);
        }
        if (categoryIDList != null && categoryIDList.Count > 0)
            Session["CHECKED_ITEMS"] = categoryIDList;
    }

    private void RePopulateValues()
    {
        ArrayList categoryIDList = (ArrayList)Session["CHECKED_ITEMS"];
        if (categoryIDList != null && categoryIDList.Count > 0)
        {
            foreach (GridViewRow row in gv_Datos.Rows)
            {
                int index = (int)gv_Datos.DataKeys[row.RowIndex].Value;
                if (categoryIDList.Contains(index))
                {
                    CheckBox myCheckBox = (CheckBox)row.FindControl("cb_Garantia");
                    myCheckBox.Checked = true;
                }
            }
        }
    }
    protected void cb_Todos_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox ChkBoxHeader = (CheckBox)gv_Datos.HeaderRow.FindControl("cb_Todos");

        foreach (GridViewRow row in gv_Datos.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox ChkBoxRows = (CheckBox)row.FindControl("cb_Garantia");

                if (ChkBoxHeader.Checked == true)
                {
                    ChkBoxRows.Checked = true;
                }
                else
                {
                    ChkBoxRows.Checked = false;
                }
            }
        }
    }
    protected void lb_Filtrar_Click(object sender, EventArgs e)
    {
        this.CargarDatos();
    }
    protected void lb_Reestablecer_Click(object sender, EventArgs e)
    {
        txt_Numero.Text = "";
        this.CargarDatos();
    }
    protected void lb_CambiarEstado_Click(object sender, EventArgs e)
    {
        div_alerta.Visible = false;
        RememberOldValues();
        RePopulateValues();
        int r = 0;
        if (Session["CHECKED_ITEMS"] != null && ((ArrayList)Session["CHECKED_ITEMS"]).Count != 0)
        {
            ArrayList listaIdsGarantias = (ArrayList)Session["CHECKED_ITEMS"];
            
            foreach (int id in listaIdsGarantias) {

              r =  GuardarEstadoGarantia(id);
            }
            if (r > 0) {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Notificacion('Listo!','Se ha cambiado el estado de la(s) garantia(s).','success', 'Aceptar')", true);
                this.CargarDatos();
            }
        }
        else {
            div_alerta.Visible = true;
        }
    }

    protected int GuardarEstadoGarantia(int idGarantia)
    {
        FlujosGarantias flujogarantia = new FlujosGarantias();
        flujogarantia.IdEstado = new Estados();
        flujogarantia.IdGarantia = new Garantias();
        BllFlujosGarantias bllflujosgarantias = new BllFlujosGarantias();

        flujogarantia.IdEstado.IdEstado = new BllGarantias().ObtenerIdProximoEstado(idGarantia);
        flujogarantia.IdGarantia.IdGarantia = idGarantia;
        flujogarantia.UsuarioIngreso = Utilidades.GetUserApp();
        flujogarantia.IpEquipoUsuarioIngreso = Utilidades.GetIPAddress();
        int r;
        return r = bllflujosgarantias.insertar(flujogarantia);

    }
}