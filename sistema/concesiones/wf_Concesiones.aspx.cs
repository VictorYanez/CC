/*
============================================================================================
tbl_Concesionarios:	Tabla que almacena la información relevante de los concesionarios.
Creada por:	VMT\marvin.ruiz
Fecha generación:	jueves, 08 de julio de 2021 10:42:57
============================================================================================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENT;
using BLL;
using System.Web.UI.HtmlControls;


public partial class sistema_concesiones_wf_Concesiones : System.Web.UI.Page
{
    BllContratos bllContratos = new BllContratos();
    BllGarantias bllGarantias = new BllGarantias();

    int registros_por_pagina = 0;
    int registros_por_pagina_garantias = 0;

    #region "CARGA DEL FORMULARIO"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.wuc_mantto.Filtro_Criterio.Items.Add("Numero");
            this.wuc_mantto.Filtro_Criterio.Items.Add("Concesionario");
            this.CargarEmisores();
            this.CargarFormasGarantias();
            this.CargarConcesionarios();
            this.CargarContratos();
            this.HabilitarEdicion(false);
            this.LimpiarCampos();
            this.CargarDatosContratos();
            this.div_grilla_garantia.Style["display"] = "none";
            this.div_Mantenimiento.Style["display"] = "none";
        }
    }
    #endregion //"CARGA DEL FORMULARIO"

    #region "EVENTOS DE LOS BOTONES"

    protected void Nuevo(object sender, EventArgs e)
    {
        this.HabilitarEdicion(true);
        this.LimpiarCampos();
        this.lbl_Accion.Text = "Insertar registro:";
        this.nb_IdContrato.Enabled = false;
        this.div_grilla_garantia.Style["display"] = "none";
        this.div_Mantenimiento.Style["display"] = "none";
        this.txt_Numero.Focus();

    }
    protected void Editar(object sender, EventArgs e)
    {
        this.CargarRegistro();
        this.HabilitarEdicion(true);
        this.lbl_Accion.Text = "Actualizar registro:";
        this.nb_IdContrato.Enabled = false;
        this.div_grilla_garantia.Style["display"] = "none";
        this.div_Mantenimiento.Style["display"] = "none";

    }

    protected void Finalizar(object sender, EventArgs e)
    {
        this.FinalizarContrato();
        this.HabilitarEdicion(false);
        this.LimpiarCampos();
        this.CargarDatosContratos();
    }
    protected void Eliminar(object sender, EventArgs e)
    {
        this.EliminarRegistro();
        this.HabilitarEdicion(false);
        this.LimpiarCampos();
        this.CargarDatosContratos();
    }
    protected void Guardar(object sender, EventArgs e)
    {
        this.GuardarRegistro();
        this.HabilitarEdicion(false);
        this.LimpiarCampos();
        this.CargarDatosContratos();
        this.wuc_mantto.MostrarBuscar = false;
    }
    protected void Cancelar(object sender, EventArgs e)
    {
        this.HabilitarEdicion(false);
        this.LimpiarCampos();
        this.CargarDatosContratos();
    }
    protected void Imprimir(object sender, EventArgs e)
    {
        /*
            this.Master.Reporte.Titulo = "Modulo";
            this.Master.Reporte.ID_Reporte = "rpt_modulo";
            this.Master.Reporte.SQL_Principal = "pa_br_Modulo @_accion='buscar'";
            //this.Master.Reporte.SQL_SubReportes = new string[] { "sql uno", "sql dos", "sql n" };
            this.Master.Reporte.TamanoPapel = CrystalDecisions.Shared.PaperSize.PaperLetter;
            this.Master.Reporte.Orientacion = CrystalDecisions.Shared.PaperOrientation.Portrait;
            this.Master.Reporte.Mostar(true);
        */
    }

    protected void AsignarLineas(object sender, EventArgs e)
    {
        this.CargarLineasSinAsignar();
        this.CargarDatosLineas();
        mpe_ModalLineas.Show();
    }

    protected void NuevaModificativa(object sender, EventArgs e)
    {
        this.HabilitarEdicion(true);
        this.LimpiarCampos();
        this.lbl_Accion.Text = "Insertar registro:";
       this.nb_IdContrato.Enabled = false;
        this.div_grilla_garantia.Style["display"] = "none";
        this.div_Mantenimiento.Style["display"] = "none";
        this.rfv_ResolucionContrato.Enabled = true;
        this.ddl_Contratos.Enabled = false;
        this.txt_ResolucionContrato.ReadOnly = false;
        wuc_mantto.Accion = "I";

        txt_Numero.Text = this.hf_NumeroContratoModificativa.Value;
        txt_FechaVigenciaInicial.Text = this.hf_FechaVigenciaInicialModificativa.Value;
        txt_FechaVigenciaFinal.Text = this.hf_FechaVigenciaFinalModificativa.Value;
        ddl_Contratos.SelectedItem.Text = this.hf_NumeroContratoModificativa.Value;
        txt_NumeroModificativa.Text = new BllContratos().ObtenerNumeroProximaModificacion(this.hf_NumeroContratoModificativa.Value).ToString();
    }

    protected void BuscarPersonalizado(object sender, EventArgs e)
    {
        this.mpe_ModalBusqueda.Show();
    }

    protected void lb_NuevaGarantia_Click(object sender, EventArgs e)
    {
        LimpiarCamposGarantia();
        hf_AccionGarantia.Value = "I";
        this.HabilitarEdicionGarantias(true);
        this.lb_NuevaGarantia.Visible = true;
        txt_NumeroGarantia.Focus();
        mpe_Garantia.Show();
    }
    protected void lb_EditarGarantia_Click(object sender, EventArgs e)
    {
        CargarRegistroGarantia();
        hf_AccionGarantia.Value = "U";
        this.lb_GuardarGarantia.Visible = true;
        mpe_Garantia.Show();
    }

    protected void lb_GuardarGarantia_Click(object sender, EventArgs e)
    {
        this.GuardarRegistroGarantia();
        this.CargarDatosGarantias();
        this.CargarDatosContratos();
        this.HabilitarEdicionGarantias(false);
        hf_AccionGarantia.Value = "";
        this.lb_GuardarGarantia.Visible = true;
        LimpiarCamposGarantia();
    }
    protected void lb_EliminarGarantia_Click(object sender, EventArgs e)
    {
        this.EliminarRegistroGarantia();
        this.CargarDatosGarantias();
        this.CargarDatosContratos();
        this.HabilitarEdicionGarantias(false);
        this.lb_GuardarGarantia.Visible = true;
    }

    protected void lb_CambiarEstadoGarantia_Click(object sender, EventArgs e)
    {
        CargarEstadosGarantias();
        mpe_ModalCambiarEstadoGarantia.Show();
    }
    protected void lb_GuardarCambiarEstadoGarantia_Click(object sender, EventArgs e)
    {
        GuardarEstadoGarantia();
        this.CargarDatosGarantias();
    }
    protected void lb_AsignarLinea_Click(object sender, EventArgs e)
    {
        this.GuardarAsignacionLinea();
        this.CargarDatosContratos();
    }

    protected void lb_EjecutarBusqueda_Click(object sender, EventArgs e)
    {
        this.CargarDatosContratos();
        wuc_mantto.MostrarBuscarPersonalizado = true;
    }

    protected void lb_LimpiarBusqueda_Click(object sender, EventArgs e)
    {
        txt_NumeroContratoFiltro.Text = String.Empty;
        ddl_ConcesionarioFiltro.SelectedIndex = 0;
        txt_PalabraClaveFiltro.Text = string.Empty;
        wuc_mantto.MostrarBuscarPersonalizado = true;
        mpe_ModalBusqueda.Show();
        this.CargarDatosContratos();
    }
    #endregion //"EVENTOS DE LOS BOTONES"

    #region "GESTION DEL COMPORTAMIENTO DE EDICION"

    protected void LimpiarCampos()
    {
        this.nb_IdContrato.Text = String.Empty;
        this.txt_Numero.Text = String.Empty;
        this.txt_FechaVigenciaInicial.Text = String.Empty;
        this.txt_FechaVigenciaFinal.Text = String.Empty;
        this.ddl_Contratos.SelectedIndex = 0;
        this.txt_ComentarioContrato.Text = String.Empty;
        this.ddl_Concesionarios.SelectedIndex = 0;
        this.txt_NumeroModificativa.Text = String.Empty;
        this.txt_ResolucionContrato.Text = String.Empty;
    }
    protected void LimpiarCamposGarantia()
    {
        this.hf_IdGarantia.Value = String.Empty;
        this.txt_NumeroGarantia.Text = String.Empty;
        this.nb_Monto.Text = String.Empty;
        this.txt_FechaEmisionGarantia.Text = String.Empty;
        this.txt_FechaVigenciaInicialGarantia.Text = String.Empty;
        this.txt_FechaVigenciaFinalGarantia.Text = String.Empty;
        this.ddl_Emisores.SelectedIndex = 0;
        this.ddl_FormasGarantias.SelectedIndex = 0;
        this.txt_ComentarioGarantia.Text = String.Empty;
    }
    protected void HabilitarEdicion(bool opcion)
    {

        this.pnl_campos.Enabled = opcion;
        this.gv_Datos_Contratos.Enabled = !opcion;

        this.wuc_mantto.Limpiar_Filtro();

        this.wuc_mantto.MostrarNuevo = !opcion;
        this.wuc_mantto.MostrarGuardar = opcion;
        this.wuc_mantto.MostrarCancelar = opcion;

        this.wuc_mantto.MostrarEditar = false;
        this.wuc_mantto.MostrarEliminar = false;
        this.wuc_mantto.MostrarFinalizar = false;
        //this.wuc_mantto.MostrarBuscar = !opcion;
        this.wuc_mantto.MostrarBuscarPersonalizado = !opcion;
        this.wuc_mantto.MostrarImprimir = false;

        if (opcion)
        {
            this.pnl_campos.Style["display"] = "block";
            this.div_grilla.Style["display"] = "none";
        }
        else
        {
            this.pnl_campos.Style["display"] = "none";
            this.div_grilla.Style["display"] = "block";
        }

        this.rfv_ResolucionContrato.Enabled = false;
    }
    protected void HabilitarEdicionGarantias(bool opcion)
    {

        this.gv_Datos_Garantias.Enabled = !opcion;

        this.lb_NuevaGarantia.Visible = !opcion;
        this.lb_GuardarGarantia.Visible = opcion;

        this.lb_EditarGarantia.Visible = false;
        this.lb_EliminarGarantia.Visible = false;
        this.lb_CambiarEstadoGarantia.Visible = false;
    }


    #endregion //"GESTION DEL COMPORTAMIENTO DE EDICION"

    #region "GESTION DEL COMPORTAMIENTO DE LA GRID"
    protected void gv_Datos_Contratos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.gv_Datos_Contratos, "Select$" + e.Row.RowIndex);

            Literal lit_CantidadGarantias = (Literal)e.Row.FindControl("lit_CantidadGarantias");
            Literal lit_FechaVigenciaFinalContrato = (Literal)e.Row.FindControl("lit_FechaVigenciaFinalContrato");
            Literal lit_NumeroContrato = (Literal)e.Row.FindControl("lit_NumeroContrato");
            Literal lit_CantidadLineas = (Literal)e.Row.FindControl("lit_CantidadLineas");
            Literal lit_CantidadLineasInactivas = (Literal)e.Row.FindControl("lit_CantidadLineasInactivas");
            Literal lit_NumeroContratoDependiente = (Literal)e.Row.FindControl("lit_NumeroContratoDependiente");
            Literal lit_ComentarioContrato = (Literal)e.Row.FindControl("lit_ComentarioContrato");
            
            int IdContrato = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IdContrato"));
            int dias = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DiasAlertas"));
            bool finalizado = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Finalizado"));
            int diasParametroVencimiento = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DiasParametroVencimiento"));
            int modificativa = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Modificativa"));
            string comentario = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Comentario"));

            if (modificativa > 0)
            {

                lit_NumeroContrato.Text = "<strong>" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Numero")) + "</strong>&nbsp;<span class=\"label label-sm label-grey arrowed-in-right arrowed-in\" title=\"Modificativa\">" + modificativa.ToString() + "</div>";
            }
            else
            {
                lit_NumeroContrato.Text = "<strong>" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Numero")) + "</strong>";
            }


            DateTime fechaVigenciaFinal = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "FechaVigenciaFinal"));

            if (dias > diasParametroVencimiento)
            {
                lit_FechaVigenciaFinalContrato.Text = fechaVigenciaFinal.ToString("dd/MM/yyyy");
            }
            else if (dias <= diasParametroVencimiento && dias > 0)
            {
                lit_FechaVigenciaFinalContrato.Text = "<span class=\"label label-warning\">" + fechaVigenciaFinal.ToString("dd/MM/yyyy") + "</span>";
            }
            else if (dias <= 0 && finalizado == false)
            {
                lit_FechaVigenciaFinalContrato.Text = "<span class=\"label label-danger\">" + fechaVigenciaFinal.ToString("dd/MM/yyyy") + "</span>";
            }
            else
            {
                lit_FechaVigenciaFinalContrato.Text = fechaVigenciaFinal.ToString("dd/MM/yyyy");
            }

            if (finalizado)
                lit_NumeroContrato.Text = lit_NumeroContrato.Text + " <span class=\"label arrowed label-light\" >Finalizado</span>";

            if (comentario.Length > 0)
                lit_ComentarioContrato.Text = "<span class='help-button' data-rel='popover' data-placement='left' data-trigger='hover' data-content='" + comentario + "' title='COMENTARIO'><i class='ace-icon fa fa-comment icon-only bigger-120'></i></span>";
            
            lit_NumeroContratoDependiente.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "NumeroContratoDependiente"));
            lit_CantidadGarantias.Text = new BllContratos().CantidadGarantiasContrato(IdContrato).ToString();
            lit_CantidadLineas.Text = new BllContratos().CantidadLineasContrato(IdContrato, true).ToString();
            lit_CantidadLineasInactivas.Text = new BllContratos().CantidadLineasContrato(IdContrato, false).ToString();

            registros_por_pagina = e.Row.RowIndex + 1;
        }
    }
    protected void gv_Datos_Contratos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gv_Datos_Contratos.PageIndex = e.NewPageIndex;
        this.CargarDatosContratos();
    }
    protected void gv_Datos_Contratos_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.gv_Datos_Contratos.SelectedIndex >= 0)
        {
            this.wuc_mantto.MostrarEditar = true;
            this.wuc_mantto.MostrarEliminar = true;
            this.wuc_mantto.MostrarFinalizar = false;
            this.wuc_mantto.MostrarAsignarLineas = true;
            this.wuc_mantto.MostrarNuevaModificativa = false;

            GridViewRow fila = gv_Datos_Contratos.SelectedRow;

            this.nb_IdContrato.Text = Convert.ToString(gv_Datos_Contratos.DataKeys[fila.RowIndex].Values["IdContrato"]);
            hf_IdContratoDependiente.Value = Convert.ToString(gv_Datos_Contratos.DataKeys[fila.RowIndex].Values["IdContrato"]);
            bool finalizado = Convert.ToBoolean(this.gv_Datos_Contratos.DataKeys[fila.RowIndex].Values["Finalizado"]);
            int dias = Convert.ToInt32(this.gv_Datos_Contratos.DataKeys[fila.RowIndex].Values["DiasAlertas"]);
            int modificativa = Convert.ToInt32(this.gv_Datos_Contratos.DataKeys[fila.RowIndex].Values["Modificativa"]);
           
            this.hf_IdConcesionario.Value = Convert.ToString(gv_Datos_Contratos.DataKeys[fila.RowIndex].Values["CodigoConcesionario"]);

            if (dias <= 0 && finalizado == false) {
                this.wuc_mantto.MostrarFinalizar = true;
            }
            if (modificativa == 0 && finalizado == false) { 
                this.wuc_mantto.MostrarNuevaModificativa = true; 
            }

            this.div_grilla_garantia.Style["display"] = "block";
            this.div_Mantenimiento.Style["display"] = "block";

            HabilitarEdicionGarantias(false);
            this.lb_NuevaGarantia.Visible = true;
            CargarDatosGarantias();

            hf_NumeroContratoModificativa.Value = Convert.ToString(gv_Datos_Contratos.DataKeys[fila.RowIndex].Values["Numero"]);
            hf_FechaVigenciaInicialModificativa.Value = Convert.ToDateTime(gv_Datos_Contratos.DataKeys[fila.RowIndex].Values["FechaVigenciaInicial"]).ToString("dd/MM/yyyy");
            hf_FechaVigenciaFinalModificativa.Value = Convert.ToDateTime(gv_Datos_Contratos.DataKeys[fila.RowIndex].Values["FechaVigenciaFinal"]).ToString("dd/MM/yyyy");
        }
    }
    protected void gv_Datos_Garantias_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.gv_Datos_Garantias, "Select$" + e.Row.RowIndex);

            Literal lit_FechaVigenciaFinal = (Literal)e.Row.FindControl("lit_FechaVigenciaFinal");
            Literal lit_NumeroGarantia = (Literal)e.Row.FindControl("lit_NumeroGarantia");
            Literal lit_ComentarioGarantia = (Literal)e.Row.FindControl("lit_ComentarioGarantia");

            int dias = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DiasAlertas"));
            DateTime fechaVigenciaFinal = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "FechaVigenciaFinal"));
            bool final = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Final"));
            bool pendiente = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "DocumentacionPendiente"));
            int diasParametroVencimiento = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DiasParametroVencimiento"));
            string comentario = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Comentario"));

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
            if (final)
            {
                lit_NumeroGarantia.Text = lit_NumeroGarantia.Text + " <span class=\"label arrowed label-light\" title=\"Garant&iacute;a finalizada\">Finalizada</span>";
            }
            if (pendiente)
            {
                lit_NumeroGarantia.Text = lit_NumeroGarantia.Text + "&nbsp;<i title=\"Pendiente de entrega de documentos\" class=\"ace-icon purple fa fa-exclamation-triangle bigger-150\"></i>";
            }

             if (comentario.Length > 0)
                lit_ComentarioGarantia.Text = "<span class='help-button' data-rel='popover' data-placement='left' data-trigger='hover' data-content='" + comentario + "' title='COMENTARIO'><i class='ace-icon fa fa-comment icon-only bigger-120'></i></span>";

             registros_por_pagina_garantias = e.Row.RowIndex + 1;
        }
    }
    protected void gv_Datos_Garantias_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.gv_Datos_Garantias.PageIndex = e.NewPageIndex;
        this.CargarDatosGarantias();
    }
    protected void gv_Datos_Garantias_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.gv_Datos_Garantias.SelectedIndex >= 0)
        {
            this.lb_EditarGarantia.Visible = true;
            this.lb_EliminarGarantia.Visible = true;
            this.lb_NuevaGarantia.Visible = true;

            GridViewRow fila = gv_Datos_Contratos.SelectedRow;

            this.hf_IdGarantia.Value = this.gv_Datos_Garantias.SelectedDataKey["IdGarantia"].ToString();
            bool final = Convert.ToBoolean(this.gv_Datos_Garantias.SelectedDataKey["Final"]);

            if (final)
            {
                lb_CambiarEstadoGarantia.Visible = false;
            }
            else
            {
                this.lb_CambiarEstadoGarantia.Visible = true;
            }
        }
    }
    protected void rep_Asignaciones_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Literal lit_NombreLinea = (Literal)e.Item.FindControl("lit_NombreLinea");
            Literal lit_NumeroContrato = (Literal)e.Item.FindControl("lit_NumeroContrato");
            Literal lit_NombreConcesionario = (Literal)e.Item.FindControl("lit_NombreConcesionario");
            LinkButton lb_QuitarLinea = (LinkButton)e.Item.FindControl("lb_QuitarLinea");
            LinkButton lb_CambiarEstadoAsignacion = (LinkButton)e.Item.FindControl("lb_CambiarEstadoAsignacion");
            HtmlGenericControl iconEstado = (HtmlGenericControl)e.Item.FindControl("iconEstado");

            AsignacionesLineas oAsignacion = (AsignacionesLineas)e.Item.DataItem;

            lit_NombreLinea.Text = oAsignacion.IdLinea.Nombre;
            lit_NumeroContrato.Text = oAsignacion.IdContrato.Numero;
            lit_NombreConcesionario.Text = oAsignacion.IdConcesionario.Nombre;
            lb_QuitarLinea.CommandArgument = oAsignacion.IdAsignacionLinea.ToString();
            lb_CambiarEstadoAsignacion.CommandArgument = oAsignacion.IdAsignacionLinea.ToString() + ";" + oAsignacion.Activo.ToString();
            lb_CambiarEstadoAsignacion.Visible = true;
            iconEstado.Visible = false;
            lb_QuitarLinea.Visible = true;
            if (!Convert.ToBoolean(oAsignacion.Activo))
            {
                lb_CambiarEstadoAsignacion.Visible = false;
                iconEstado.Visible = true;
                lb_QuitarLinea.Visible = false;
            }
        }
    }
    protected void rep_Asignaciones_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "QuitarLinea")
        {
            EliminarRegistroAsignacionLinea(Convert.ToInt32(e.CommandArgument));
        }
        if (e.CommandName == "CambiarEstadoAsignacion")
        {
            string[] valores = e.CommandArgument.ToString().Split(';');
            CambiarEstadoAsignacionLinea(Convert.ToInt32(valores[0]), Convert.ToBoolean(valores[1]));
            this.CargarDatosContratos();
        }
    }
    #endregion //"GESTION DEL COMPORTAMIENTO DE LA GRID"

    #region "GESTION DEL ACCESO A DATOS"

    //Métodos para cargar lista de selección.

    protected void CargarContratos()
    {
        Contratos contratos = new Contratos();
        BllContratos bllcontratos = new BllContratos();
        contratos.Finalizado = false;

        this.ddl_Contratos.DataSource = bllcontratos.buscar(contratos).Where(x => x.Modificativa == null).ToList();
        this.ddl_Contratos.DataTextField = "Numero";
        this.ddl_Contratos.DataValueField = "IdContrato";
        this.ddl_Contratos.DataBind();
        this.ddl_Contratos.Items.Insert(0, new ListItem("-- NINGUNO --", "0"));
        this.ddl_Contratos.SelectedIndex = 0;
    }
    protected void CargarEmisores()
    {
        Emisores emisores = new Emisores();
        BllEmisores bllemisores = new BllEmisores();

        this.ddl_Emisores.DataSource = bllemisores.buscar(emisores);
        this.ddl_Emisores.DataTextField = "Nombre";
        this.ddl_Emisores.DataValueField = "IdEmisor";
        this.ddl_Emisores.DataBind();
        this.ddl_Emisores.Items.Insert(0, new ListItem("-- SELECCIONE --", "0"));
        this.ddl_Emisores.SelectedIndex = 0;
    }
    protected void CargarFormasGarantias()
    {
        FormasGarantias formasgarantias = new FormasGarantias();
        BllFormasGarantias bllformasgarantias = new BllFormasGarantias();

        this.ddl_FormasGarantias.DataSource = bllformasgarantias.buscar(formasgarantias);
        this.ddl_FormasGarantias.DataTextField = "Nombre";
        this.ddl_FormasGarantias.DataValueField = "IdForma";
        this.ddl_FormasGarantias.DataBind();
        this.ddl_FormasGarantias.Items.Insert(0, new ListItem("-- SELECCIONE --", "0"));
        this.ddl_FormasGarantias.SelectedIndex = 0;
    }
    protected void CargarEstadosGarantias()
    {
        BllFlujosGarantias bllflujosgarantias = new BllFlujosGarantias();

        this.ddl_Estados.DataSource = bllflujosgarantias.EstadosPendienteGarantia(Convert.ToInt32(hf_IdGarantia.Value));
        this.ddl_Estados.DataTextField = "Nombre";
        this.ddl_Estados.DataValueField = "IdEstado";
        this.ddl_Estados.DataBind();
        this.ddl_Estados.Items.Insert(0, new ListItem("-- SELECCIONE --", "0"));
        this.ddl_Estados.SelectedIndex = 0;
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
        this.ddl_Concesionarios.Items.Insert(0, new ListItem("-- SELECCIONE --", "0"));
        this.ddl_Concesionarios.SelectedIndex = 0;

        this.ddl_ConcesionarioFiltro.DataSource = lst_Concesionarios;
        this.ddl_ConcesionarioFiltro.DataTextField = "Nombre";
        this.ddl_ConcesionarioFiltro.DataValueField = "IdConcesionario";
        this.ddl_ConcesionarioFiltro.DataBind();
        this.ddl_ConcesionarioFiltro.Items.Insert(0, new ListItem("-- TODOS --", "0"));
        this.ddl_ConcesionarioFiltro.SelectedIndex = 0;


    }
    protected void CargarLineasSinAsignar()
    {

        BllLineas bllineas = new BllLineas();

        this.ddl_LineasDisponibles.DataSource = bllineas.LineasSinAsignar();
        this.ddl_LineasDisponibles.DataTextField = "Nombre";
        this.ddl_LineasDisponibles.DataValueField = "IdLinea";
        this.ddl_LineasDisponibles.DataBind();
        this.ddl_LineasDisponibles.Items.Insert(0, new ListItem("-- SELECCIONE --", "-- SELECCIONE --"));
        this.ddl_LineasDisponibles.SelectedIndex = 0;
    }
    protected void CargarDatosContratos()
    {
        Contratos contratos = new Contratos();
        contratos.IdContratoDepende = new Contratos();
        contratos.IdConcesionario = new Concesionarios();

        if (!String.IsNullOrEmpty(txt_NumeroContratoFiltro.Text))
        {
            contratos.Numero = txt_NumeroContratoFiltro.Text;
        }

        if (ddl_ConcesionarioFiltro.SelectedValue != "0")
        {
            contratos.IdConcesionario.IdConcesionario = Convert.ToInt32(ddl_ConcesionarioFiltro.SelectedValue);
        }

        if (!String.IsNullOrEmpty(txt_PalabraClaveFiltro.Text))
        {
            contratos.PalabraClave = txt_PalabraClaveFiltro.Text;
        }

        List<Contratos> lstContratos = bllContratos.buscar(contratos).OrderBy(x => x.Finalizado).ThenByDescending(x => x.IdContrato).ToList();
        this.gv_Datos_Contratos.DataSource = lstContratos;
        this.gv_Datos_Contratos.DataBind();

        int cantidad_registros = lstContratos.Count;
        lbl_ContadorRegistros.Text = new Utilidades().ContadorRegistrosGrid(cantidad_registros, registros_por_pagina, gv_Datos_Contratos);
    }
    protected void CargarDatosGarantias()
    {
        Garantias garantias = new Garantias();
        garantias.IdEmisor = new Emisores();
        garantias.IdForma = new FormasGarantias();
        garantias.IdContrato = new Contratos();

        garantias.IdContrato.IdContrato = Convert.ToInt32(nb_IdContrato.Text);

        if (this.wuc_mantto.Filtro_Criterio.SelectedValue == "Numero")
        {
            try
            {
                garantias.Numero = Convert.ToString(this.wuc_mantto.Filtro_Valor_TXT);
            }
            catch
            {
                garantias.Numero = null;
            }
        }

        List<Garantias> lstGarantias = bllGarantias.buscar(garantias).ToList();

        this.gv_Datos_Garantias.DataSource = lstGarantias;
        this.gv_Datos_Garantias.DataBind();
        int cantidad_registros = lstGarantias.Count;
        lbl_ContadorRegistrosGarantias.Text = new Utilidades().ContadorRegistrosGrid(cantidad_registros, registros_por_pagina_garantias, gv_Datos_Garantias);
    }
    protected void CargarDatosLineas()
    {

        BllAsignacionesLineas bllasignacioneslineas = new BllAsignacionesLineas();
        AsignacionesLineas asignacionlineas = new AsignacionesLineas();
        asignacionlineas.IdLinea = new Lineas();
        asignacionlineas.IdConcesionario = new Concesionarios();
        asignacionlineas.IdContrato = new Contratos();

        asignacionlineas.IdContrato.IdContrato = Convert.ToInt32(nb_IdContrato.Text);

        List<AsignacionesLineas> lstAsignacionesGarantias = bllasignacioneslineas.buscar(asignacionlineas)
                                                            .OrderByDescending(x => x.Activo)
                                                            .ThenByDescending(x => x.FechaIngreso).ToList();

        if (lstAsignacionesGarantias.Count > 0)
        {
            rep_Asignaciones.Visible = true;
            this.rep_Asignaciones.DataSource = lstAsignacionesGarantias;
            this.rep_Asignaciones.DataBind();
            div_MensajeSinLineas.Visible = false;
        }
        else
        {
            rep_Asignaciones.Visible = false;
            div_MensajeSinLineas.Visible = true;
        }
    }
    protected void CargarRegistro()
    {
        Contratos contratos = new Contratos();
        contratos.IdContratoDepende = new Contratos();

        contratos.IdContrato = Convert.ToInt32(nb_IdContrato.Text);

        contratos = bllContratos.buscar(contratos)[0];

        this.txt_Numero.Text = contratos.Numero.ToString();
        this.txt_FechaVigenciaInicial.Text = Convert.ToDateTime(contratos.FechaVigenciaInicial).ToString("dd/MM/yyyy");
        this.txt_FechaVigenciaFinal.Text = Convert.ToDateTime(contratos.FechaVigenciaFinal).ToString("dd/MM/yyyy");
        try { this.ddl_Contratos.SelectedValue = contratos.IdContratoDepende.IdContrato.ToString(); }        catch { }
        try { this.ddl_Concesionarios.SelectedValue = contratos.IdConcesionario.IdConcesionario.ToString(); }        catch { }
        this.txt_ComentarioContrato.Text = contratos.Comentario;
        this.txt_NumeroModificativa.Text = contratos.Modificativa.ToString();
        this.txt_ResolucionContrato.Text = contratos.Resolucion;
    }
    protected void CargarRegistroGarantia()
    {
        Garantias garantias = new Garantias();
        garantias.IdEmisor = new Emisores();
        garantias.IdForma = new FormasGarantias();
        garantias.IdContrato = new Contratos();

        garantias.IdGarantia = Convert.ToInt32(hf_IdGarantia.Value);

        garantias = bllGarantias.buscar(garantias)[0];

        this.txt_NumeroGarantia.Text = garantias.Numero.ToString();
        this.nb_Monto.Text = garantias.Monto.ToString();
        this.txt_FechaEmisionGarantia.Text = Convert.ToDateTime(garantias.FechaEmision).ToString("dd/MM/yyyy");
        this.txt_FechaVigenciaInicialGarantia.Text = Convert.ToDateTime(garantias.FechaVigenciaInicial).ToString("dd/MM/yyyy");
        this.txt_FechaVigenciaFinalGarantia.Text = Convert.ToDateTime(garantias.FechaVigenciaFinal).ToString("dd/MM/yyyy");
        try { this.ddl_Emisores.SelectedValue = garantias.IdEmisor.IdEmisor.ToString(); }        catch { }
        try { this.ddl_FormasGarantias.SelectedValue = garantias.IdForma.IdForma.ToString(); }        catch { }
        cb_DocumentacionPendiente.Checked = Convert.ToBoolean(garantias.DocumentacionPendiente);
        txt_ComentarioGarantia.Text = garantias.Comentario;

    }
    protected void GuardarRegistro()
    {
        Contratos contratos = new Contratos();
        contratos.IdContratoDepende = new Contratos();
        contratos.IdConcesionario = new Concesionarios();

        contratos.Numero = Convert.ToString(txt_Numero.Text);
        contratos.FechaVigenciaInicial = Convert.ToDateTime(txt_FechaVigenciaInicial.Text);
        contratos.FechaVigenciaFinal = Convert.ToDateTime(txt_FechaVigenciaFinal.Text);

        if (ddl_Contratos.SelectedItem.Text != "-- NINGUNO --")
            contratos.IdContratoDepende.IdContrato = Convert.ToInt32(hf_IdContratoDependiente.Value);

        contratos.IdConcesionario.IdConcesionario = Convert.ToInt32(ddl_Concesionarios.SelectedValue);
        contratos.Comentario = txt_ComentarioContrato.Text.ToUpper();

        if (!String.IsNullOrEmpty(txt_NumeroModificativa.Text))
            contratos.Modificativa = Convert.ToInt32(txt_NumeroModificativa.Text);

        if (!String.IsNullOrEmpty(txt_ResolucionContrato.Text))
            contratos.Resolucion = txt_ResolucionContrato.Text.ToUpper();

        int r;
        if (this.wuc_mantto.Accion == "I")
        {
            contratos.UsuarioIngreso = Utilidades.GetUserApp();
            contratos.IpEquipoUsuarioIngreso = Utilidades.GetIPAddress();
            r = bllContratos.insertar(contratos);
        }
        else
        {
            contratos.IdContrato = Convert.ToInt32(nb_IdContrato.Text);
            contratos.UsuarioActualizacion = Utilidades.GetUserApp();
            contratos.IpEquipoActualizacion = Utilidades.GetIPAddress();
            r = bllContratos.actualizar(contratos);
        }
    }
    protected void GuardarRegistroGarantia()
    {
        Garantias garantias = new Garantias();
        garantias.IdEmisor = new Emisores();
        garantias.IdForma = new FormasGarantias();
        garantias.IdContrato = new Contratos();


        garantias.Numero = Convert.ToString(txt_NumeroGarantia.Text);
        garantias.Monto = Convert.ToDecimal(nb_Monto.Text);
        garantias.FechaEmision = Convert.ToDateTime(txt_FechaEmisionGarantia.Text);
        garantias.FechaVigenciaInicial = Convert.ToDateTime(txt_FechaVigenciaInicialGarantia.Text);
        garantias.FechaVigenciaFinal = Convert.ToDateTime(txt_FechaVigenciaFinalGarantia.Text);
        garantias.IdEmisor.IdEmisor = Convert.ToInt32(ddl_Emisores.SelectedValue);
        garantias.IdForma.IdForma = Convert.ToInt32(ddl_FormasGarantias.SelectedValue);
        garantias.IdContrato.IdContrato = Convert.ToInt32(nb_IdContrato.Text);
        garantias.DocumentacionPendiente = Convert.ToBoolean(cb_DocumentacionPendiente.Checked);
        garantias.Comentario = txt_ComentarioGarantia.Text.ToUpper();
        int r;
        if (this.hf_AccionGarantia.Value == "I")
        {
            garantias.UsuarioIngreso = Utilidades.GetUserApp();
            garantias.IpEquipoUsuarioIngreso = Utilidades.GetIPAddress();
            r = bllGarantias.insertar(garantias);
        }
        else
        {
            garantias.IdGarantia = Convert.ToInt32(hf_IdGarantia.Value);
            garantias.UsuarioActualizacion = Utilidades.GetUserApp();
            garantias.IpEquipoActualizacion = Utilidades.GetIPAddress();
            r = bllGarantias.actualizar(garantias);
        }
    }
    protected void GuardarEstadoGarantia()
    {
        FlujosGarantias flujogarantia = new FlujosGarantias();
        flujogarantia.IdEstado = new Estados();
        flujogarantia.IdGarantia = new Garantias();
        BllFlujosGarantias bllflujosgarantias = new BllFlujosGarantias();

        flujogarantia.IdEstado.IdEstado = Convert.ToInt32(ddl_Estados.SelectedValue);
        flujogarantia.IdGarantia.IdGarantia = Convert.ToInt32(hf_IdGarantia.Value);
        flujogarantia.UsuarioIngreso = Utilidades.GetUserApp();
        flujogarantia.IpEquipoUsuarioIngreso = Utilidades.GetIPAddress();
        int r;
        r = bllflujosgarantias.insertar(flujogarantia);

    }
    protected void GuardarAsignacionLinea()
    {

        BllAsignacionesLineas bllasignacioneslineas = new BllAsignacionesLineas();
        AsignacionesLineas asignacionlineas = new AsignacionesLineas();
        asignacionlineas.IdLinea = new Lineas();
        asignacionlineas.IdConcesionario = new Concesionarios();
        asignacionlineas.IdContrato = new Contratos();

        asignacionlineas.IdLinea.IdLinea = Convert.ToInt32(ddl_LineasDisponibles.SelectedValue);
        asignacionlineas.IdConcesionario.IdConcesionario = Convert.ToInt32(hf_IdConcesionario.Value);
        asignacionlineas.IdContrato.IdContrato = Convert.ToInt32(nb_IdContrato.Text);
        asignacionlineas.UsuarioIngreso = Utilidades.GetUserApp();
        asignacionlineas.IpEquipoUsuarioIngreso = Utilidades.GetIPAddress();

        int r = bllasignacioneslineas.insertar(asignacionlineas);
        if (r > 0)
        {
            this.CargarLineasSinAsignar();
            this.CargarDatosLineas();
            mpe_ModalLineas.Show();
        }
    }
    protected void EliminarRegistro()
    {
        Contratos contratos = new Contratos();
        contratos.IdContratoDepende = new Contratos();

        contratos.IdContrato = Convert.ToInt32(nb_IdContrato.Text);
        int r = bllContratos.eliminar(contratos);
    }
    protected void EliminarRegistroGarantia()
    {
        Garantias garantias = new Garantias();
        garantias.IdEmisor = new Emisores();
        garantias.IdForma = new FormasGarantias();
        garantias.IdContrato = new Contratos();

        garantias.IdGarantia = Convert.ToInt32(hf_IdGarantia.Value);
        int r = bllGarantias.eliminar(garantias);
    }
    protected void FinalizarContrato()
    {
        Contratos contratos = new Contratos();
        contratos.IdContratoDepende = new Contratos();
        contratos.IdContrato = Convert.ToInt32(nb_IdContrato.Text);
        contratos.Finalizado = true;
        contratos.UsuarioActualizacion = Utilidades.GetUserApp();
        contratos.IpEquipoActualizacion = Utilidades.GetIPAddress();
        int r = bllContratos.actualizar(contratos);
    }
    protected void EliminarRegistroAsignacionLinea(int idLineaAsignacion)
    {

        BllAsignacionesLineas bllasignacioneslineas = new BllAsignacionesLineas();
        AsignacionesLineas asignacionlineas = new AsignacionesLineas();
        asignacionlineas.IdLinea = new Lineas();
        asignacionlineas.IdConcesionario = new Concesionarios();
        asignacionlineas.IdContrato = new Contratos();

        asignacionlineas.IdAsignacionLinea = idLineaAsignacion;
        asignacionlineas.UsuarioActualizacion = Utilidades.GetUserApp();
        asignacionlineas.IpEquipoActualizacion = Utilidades.GetIPAddress();

        int r = bllasignacioneslineas.eliminar(asignacionlineas);
        if (r > 0)
        {
            this.CargarDatosLineas();
            this.CargarLineasSinAsignar();
            mpe_ModalLineas.Show();
        }
    }
    protected void CambiarEstadoAsignacionLinea(int idLineaAsignacion, bool estado)
    {
        BllAsignacionesLineas bllasignacioneslineas = new BllAsignacionesLineas();
        AsignacionesLineas asignacionlineas = new AsignacionesLineas();
        asignacionlineas.IdLinea = new Lineas();
        asignacionlineas.IdConcesionario = new Concesionarios();
        asignacionlineas.IdContrato = new Contratos();

        asignacionlineas.IdAsignacionLinea = idLineaAsignacion;
        asignacionlineas.Activo = !estado;
        asignacionlineas.UsuarioActualizacion = Utilidades.GetUserApp();
        asignacionlineas.IpEquipoActualizacion = Utilidades.GetIPAddress();

        int r = bllasignacioneslineas.actualizar(asignacionlineas);
        if (r > 0)
        {
            this.CargarDatosLineas();
            this.CargarLineasSinAsignar();
            mpe_ModalLineas.Show();
        }
    }

    #endregion //"GESTION DEL ACCESO A DATOS"
}